using UnityEngine;

public class ShootTest : MonoBehaviour
{
    [SerializeField] private float _shootCooldown; // Tiempo mínimo entre disparos
    [SerializeField] private RadialShotSettings _shotSettings; // Configuración para disparos radiales

    // Temporizador para rastrear cuándo se puede disparar nuevamente
    private float _shootCooldownTimer = 0f;

    void Update()
    {
        // Incrementar el temporizador según el tiempo transcurrido desde el último frame
        _shootCooldownTimer += Time.deltaTime;

        // Verificar si el tiempo de cooldown ha pasado
        if (_shootCooldownTimer >= _shootCooldown)
        {
            // Disparar un ataque radial en la posición actual
            ShotAttack.RadialShot(transform.position, transform.up, _shotSettings);

            // Reiniciar el temporizador de cooldown
            _shootCooldownTimer = 0f;
        }
    }
}
