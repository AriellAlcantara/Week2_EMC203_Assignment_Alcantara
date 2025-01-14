using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public float[] anglesToAdd;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController player = other.GetComponent<PlayerController>();
            if (player != null)
            {
                foreach (float angle in anglesToAdd)
                {
                    player.AddShootingDirection(angle);
                }
                Destroy(gameObject);
            }
        }
    }
}