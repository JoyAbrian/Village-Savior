using UnityEngine;

public class EnemyRagdollController : MonoBehaviour
{
    private Rigidbody[] ragdollBodies;
    private Animator animator;
    private Collider mainCollider;

    void Awake()
    {
        ragdollBodies = GetComponentsInChildren<Rigidbody>();
        animator = GetComponent<Animator>();
        mainCollider = GetComponent<Collider>();

        SetRagdollActive(false);
    }

    public void SetRagdollActive(bool isActive)
    {
        foreach (Rigidbody rb in ragdollBodies)
        {
            rb.isKinematic = !isActive;
            if (rb.gameObject.GetComponent<Collider>())
                rb.gameObject.GetComponent<Collider>().enabled = isActive;
        }

        if (animator) animator.enabled = !isActive;
        if (mainCollider) mainCollider.enabled = !isActive;
    }

    public void ActivateRagdoll()
    {
        EnemyWalk enemyWalk = GetComponent<EnemyWalk>();
        if (enemyWalk != null)
        {
            enemyWalk.StopWalking();
        }

        SetRagdollActive(true);
    }
}