using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject bulletPrefab; // Prefab c?a ð?n
    public int numberOfBullets = 12; // S? lý?ng ð?n
    public float circleRadius = 3f; // Bán kính c?a h?nh tr?n
    public float childBulletSpeed = 5f; // T?c ð? c?a ð?n

    GameObject player;
    Vector3 targetPl;
    [SerializeField] float bulletSpeed;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void Start()
    {
        targetPl = player.transform.position;

        StartCoroutine(FireCircularBullets());
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position,
                                                targetPl, 
                                                bulletSpeed*Time.deltaTime);
    }

    IEnumerator FireCircularBullets()
    {
        for (int i = 0; i < numberOfBullets; i++)
        {
            // Tính toán vtri cua dan tren hinh tron
            float angle = i * (360f / numberOfBullets);
            Vector3 bulletPosition = transform.position + new Vector3(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad)) * circleRadius;

            // T?o m?t ð?n m?i t?i v? trí ð? tính toán
            GameObject bullet = Instantiate(bulletPrefab, bulletPosition, Quaternion.identity);

            bullet.transform.parent = transform;

            // Tính toán hý?ng c?a ð?n
            Vector2 bulletDirection = (transform.position - bulletPosition).normalized;

            // Thi?t l?p hý?ng và t?c ð? cho ð?n
            bullet.GetComponent<Rigidbody2D>().velocity = bulletDirection * childBulletSpeed;

            yield return null;
        }
    }
}
