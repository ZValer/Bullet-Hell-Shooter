using UnityEngine;

public static class ShotAttack
{
    // Método para disparar una sola bala
    public static void SimpleShot(Vector3 origin, Vector3 velocity)
    {
        // Solicitar una bala del pool
        Bullet bullet = BulletPool.Instance.RequestBullet();

        // Establecer la posición inicial de la bala
        bullet.transform.position = origin;

        // Asignar la velocidad a la bala
        bullet.Velocity = velocity;
    }

    // Método para disparar múltiples balas en un patrón radial
    public static void RadialShot(Vector2 origin, Vector2 aimDirection, RadialShotSettings settings)
    {
        // Calcular el ángulo entre cada bala con la fórmula
        float angleBetweenBullets = 360f / settings.NumberOfBullets;

        // Loop para crear las balas de nuestro disparo
        for (int i = 0; i < settings.NumberOfBullets; i++)
        {
            // Calcular el ángulo de dirección de cada bala con su índice
            float bulletDirectionAngle = angleBetweenBullets * i;

            // Rotar la dirección de disparo inicial según el ángulo calculado
            Vector2 bulletDirection = aimDirection.Rotate(bulletDirectionAngle);

            // Disparar la bala con la dirección rotada y la velocidad especificada
            SimpleShot(origin, bulletDirection * settings.BulletSpeed);
        }
    }

}
