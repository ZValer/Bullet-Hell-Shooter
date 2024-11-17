using UnityEngine;

public class ShootTest : MonoBehaviour
{
    [SerializeField] private float _shootCooldown = 0.5f; // Tiempo entre disparos
    [SerializeField] private float _bulletSpeed = 10f;

    private float _shootCooldownTimer = 0f;

    void Update()
    {
        _shootCooldownTimer += Time.deltaTime;

        // Verificar si el cooldown ha terminado
        if (_shootCooldownTimer >= _shootCooldown)
        {
            Shoot(transform.position, transform.forward * _bulletSpeed);
            _shootCooldownTimer = 0f;
        }
    }

    void Shoot(Vector3 origin, Vector3 velocity)
    {
        Bullet bullet = BulletPool.Instance.RequestBullet();
        bullet.transform.position = origin;
        bullet.Velocity = velocity;
    }
}
