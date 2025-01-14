using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float lifespan = 5f;

    void Start()
    {
        Destroy(gameObject, lifespan);
    }
}