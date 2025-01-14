using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public GameObject bulletPrefab;
    public Transform firePoint;

    private List<float> shootAngles = new List<float> {0f};

    void Update()
    {
        MovePlayer();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ShootBullets();
        }
    }

    void MovePlayer()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(moveX, moveY, 0) * moveSpeed * Time.deltaTime);
    }

    void ShootBullets()
    {
        foreach (float angle in shootAngles)
        {
            float radian = angle * Mathf.Deg2Rad;
            Vector3 direction = new Vector3(Mathf.Cos(radian), 0, Mathf.Sin(radian));
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
            bullet.GetComponent<Rigidbody>().linearVelocity = direction * 10f;
        }
    }

    public void AddShootingDirection(float newAngle)
    {
        if (!shootAngles.Contains(newAngle))
        {
            shootAngles.Add(newAngle);
        }
    }
}