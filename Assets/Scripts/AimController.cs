using System.Collections;
using UnityEngine;

public class AimController : MonoBehaviour
{
    [Header("Aim Settings")]
    public AimPivot aimPivot;
    public float aimSpeed = 5f;
    public Vector2 horizontalLimit = new Vector2(-60f, 60f);
    public Vector2 verticalLimit = new Vector2(-30f, 45f);
    public float fireCooldown = 1.3f;

    [Header("Camera Settings")]
    public Camera playerCamera;
    public float normalFOV = 60f;
    public float zoomedFOV = 40f;
    public float zoomSpeed = 5f;

    [Header("Control Flags")]
    public bool isAiming = false;
    public bool lockMovement = false;

    private Vector2 currentRotation;
    private Quaternion defaultPlayerRotation;
    private Quaternion defaultCameraRotation;
    private Animator playerAnimator;
    private bool canFire = true;

    void Start()
    {
        playerAnimator = gameObject.GetComponent<Animator>();

        if (playerCamera == null)
        {
            playerCamera = Camera.main;
        }

        defaultPlayerRotation = transform.rotation;
        defaultCameraRotation = playerCamera.transform.localRotation;

        currentRotation = Vector2.zero;
    }

    void OnEnable()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void OnDisable()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void Update()
    {
        HandleAiming();
        HandleZoom();
    }

    void HandleAiming()
    {
        if (Input.GetMouseButton(1))
        {
            isAiming = true;
            lockMovement = true;

            playerAnimator.SetTrigger("DrawArrow");
            playerAnimator.SetBool("isAiming", true);


            float mouseX = Input.GetAxis("Mouse X") * aimSpeed;
            float mouseY = Input.GetAxis("Mouse Y") * aimSpeed;

            currentRotation.x += mouseX;
            currentRotation.y -= mouseY;

            currentRotation.x = Mathf.Clamp(currentRotation.x, horizontalLimit.x, horizontalLimit.y);
            currentRotation.y = Mathf.Clamp(currentRotation.y, verticalLimit.x, verticalLimit.y);

            transform.rotation = Quaternion.Euler(0f, currentRotation.x, 0f);
            playerCamera.transform.localRotation = Quaternion.Euler(currentRotation.y, 0f, 0f);

            if (Input.GetMouseButtonDown(0))
            {
                FiringArrow();
            }
        }
        else
        {
            isAiming = false;
            lockMovement = false;

            playerAnimator.ResetTrigger("DrawArrow");
            playerAnimator.SetBool("isAiming", false);

            transform.rotation = Quaternion.Slerp(transform.rotation, defaultPlayerRotation, Time.deltaTime * aimSpeed);
            playerCamera.transform.localRotation = Quaternion.Slerp(playerCamera.transform.localRotation, defaultCameraRotation, Time.deltaTime * aimSpeed);

            currentRotation = Vector2.Lerp(currentRotation, Vector2.zero, Time.deltaTime * aimSpeed);
        }
    }

    void HandleZoom()
    {
        float targetFOV = isAiming ? zoomedFOV : normalFOV;
        playerCamera.fieldOfView = Mathf.Lerp(playerCamera.fieldOfView, targetFOV, Time.deltaTime * zoomSpeed);
    }

    void FiringArrow()
    {
        if (!canFire) return;

        playerAnimator.SetTrigger("FireArrow");

        if (aimPivot.enemiesInRange.Count > 0)
        {
            GameObject targetEnemy = aimPivot.enemiesInRange[0];

            if (targetEnemy != null)
            {
                EnemyRagdollController ragdoll = targetEnemy.GetComponent<EnemyRagdollController>();

                if (ragdoll != null)
                {
                    ragdoll.ActivateRagdoll();
                    Destroy(targetEnemy, 5f);
                }

                aimPivot.enemiesInRange.RemoveAt(0);
            }
        }

        StartCoroutine(FireCooldownRoutine());
    }

    private IEnumerator FireCooldownRoutine()
    {
        canFire = false;
        yield return new WaitForSeconds(fireCooldown);
        canFire = true;
    }
}