using UnityEngine;

public class EnemyWalk : MonoBehaviour
{
    [SerializeField] private float speed = 2f;

    public void StopWalking()
    {
        speed = 0f;
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}