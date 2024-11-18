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
    public static void CircleShot(Vector2 origin, Vector2 aimDirection, CircleShotSettings settings)
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

    // Método para disparar en forma de asterisco
    public static void AsteriskShot(Vector2 origin, Vector2 aimDirection, AsteriskShotSettings settings)
    {
        // Calcular el ángulo entre cada bala con la fórmula
        float angleBetweenBullets = 360f / settings.NumberOfBullets;

        // Loop para crear las balas de nuestro disparo
        for (int i = 0; i < settings.NumberOfBullets; i++)
        {
            float bulletDirectionAngle = angleBetweenBullets * i;
            Vector2 bulletDirection = aimDirection.Rotate(bulletDirectionAngle);
            SimpleShot(origin, bulletDirection * settings.BulletSpeed);
        }
    }

    // Método para disparar en forma de flor
    public static void FlowerShot(Vector2 origin, Vector2 aimDirection, FlowerShotSettings settings)
    {
        // Calcular el ángulo entre los "pétalos"
        float angleBetweenPetals = 360f / settings.NumberOfPetals;

        for (int petal = 0; petal < settings.NumberOfPetals; petal++)
        {
            // Calcular la dirección base para el pétalo actual
            float petalBaseAngle = angleBetweenPetals * petal;
            Vector2 petalBaseDirection = aimDirection.Rotate(petalBaseAngle);

            // Disparar múltiples balas por pétalo
            for (int bullet = 0; bullet < settings.BulletsPerPetal; bullet++)
            {
                // Ajustar ligeramente el ángulo dentro del pétalo
                float offsetAngle = settings.AngleSpread * (bullet - (settings.BulletsPerPetal - 1) / 2f);
                Vector2 bulletDirection = petalBaseDirection.Rotate(offsetAngle);

                // Disparar la bala
                SimpleShot(origin, bulletDirection * settings.BulletSpeed);
            }
        }
    }

    // Método para disparar en forma de estrella con picos de velocidad
    public static void StarShot(Vector2 origin, Vector2 aimDirection, StarShotSettings settings)
    {
        // Calcular el ángulo entre cada bala
        float angleBetweenBullets = 360f / settings.NumberOfBullets;

        // Loop para crear las balas de nuestro disparo
        for (int i = 0; i < settings.NumberOfBullets; i++)
        {
            // Calcular el ángulo de dirección de cada bala
            float bulletDirectionAngle = angleBetweenBullets * i;

            // Rotar la dirección inicial según el ángulo calculado
            Vector2 bulletDirection = aimDirection.Rotate(bulletDirectionAngle);

            // Evaluar si el ángulo corresponde a un pico de la estrella
            float normalizedAngle = (bulletDirectionAngle % 360f) / 360f; // Normalizado entre 0 y 1
            float starFactor = Mathf.Abs(5 * Mathf.Sin(normalizedAngle * Mathf.PI * settings.StarPoints)); // Función de estrella

            // Ajustar la velocidad según el factor de estrella
            float bulletSpeed = settings.BaseBulletSpeed + (starFactor * settings.SpeedMultiplier);

            // Disparar la bala con la velocidad ajustada
            SimpleShot(origin, bulletDirection.normalized * bulletSpeed);
        }
    }

}
