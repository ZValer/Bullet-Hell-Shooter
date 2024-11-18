using UnityEngine;

public class ShootTest : MonoBehaviour
{
    [SerializeField] private float _shootCooldown; // Tiempo mínimo entre disparos
    [SerializeField] private CircleShotSettings _shotSettings; // Configuración para disparos radiales
    //[SerializeField] private AsteriskShotSettings _shotSettings; // Configuración para disparos radiales
    [SerializeField] private float _shootDuration = 10f; // Duración total en la que los disparos están activos

    private float _shootCooldownTimer = 0f; // Temporizador para rastrear cuándo se puede disparar nuevamente
    private float _totalTime = 0f; // Temporizador para rastrear el tiempo total de disparos

    void Update()
    {
        // Incrementar el temporizador total
        _totalTime += Time.deltaTime;

        // Detener los disparos si la duración máxima ha sido alcanzada
        if (_totalTime >= _shootDuration)
        {
            return; // Salir de Update si se cumplió la duración
        }

        // Incrementar el temporizador del cooldown
        _shootCooldownTimer += Time.deltaTime;

        // Verificar si el tiempo de cooldown ha pasado
        if (_shootCooldownTimer >= _shotSettings.CooldownAfterShot)
        {
            // Disparar un ataque radial en la posición actual
            ShotAttack.CircleShot(transform.position, transform.up, _shotSettings);

            // Reiniciar el temporizador de cooldown
            _shootCooldownTimer = 0f;
        }
    }
}
