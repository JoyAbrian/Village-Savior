using UnityEngine;

public class Bow : MonoBehaviour
{
    public Transform handBone;
    public Transform bow;

    [Header("Offsets")]
    public Vector3 positionOffset;
    public Vector3 rotationOffset;

    void Start()
    {
        if (handBone != null && bow != null)
        {
            bow.SetParent(handBone);

            bow.localPosition = positionOffset;
            bow.localEulerAngles = rotationOffset;
        }
        else
        {
            Debug.LogWarning("Hand or bow is not assigned!");
        }
    }
}