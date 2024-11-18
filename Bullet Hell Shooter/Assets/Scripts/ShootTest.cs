using UnityEngine;

public class ShootTest : MonoBehaviour
{
    [SerializeField] private float _shootCooldown; // Tiempo mínimo entre disparos
    [SerializeField] private CircleShotSettings _circleShotSettings; // Configuración para disparos en círculo
    [SerializeField] private AsteriskShotSettings _asteriskShotSettings; // Configuración para disparos en asterisco
    [SerializeField] private float _switchDuration = 10f; // Duración de cada tipo de disparo

    private float _shootCooldownTimer = 0f; // Temporizador para controlar el cooldown
    private float _switchTimer = 0f; // Temporizador para alternar disparos
    private bool _isCircleShotActive = true; // Controla qué tipo de disparo está activo

    void Update()
    {
        // Incrementar los temporizadores
        _shootCooldownTimer += Time.deltaTime;
        _switchTimer += Time.deltaTime;

        // Alternar entre los tipos de disparo cada _switchDuration segundos
        if (_switchTimer >= _switchDuration)
        {
            _isCircleShotActive = !_isCircleShotActive;
            _switchTimer = 0f; // Reiniciar el temporizador de alternancia
        }

        // Verificar si el cooldown ha terminado
        if (_shootCooldownTimer >= (_isCircleShotActive ? _circleShotSettings.CooldownAfterShot : _asteriskShotSettings.CooldownAfterShot))
        {
            // Disparar el tipo de ataque activo
            if (_isCircleShotActive)
            {
                ShotAttack.CircleShot(transform.position, transform.up, _circleShotSettings);
            }
            else
            {
                ShotAttack.AsteriskShot(transform.position, transform.up, _asteriskShotSettings);
            }

            // Reiniciar el temporizador de cooldown
            _shootCooldownTimer = 0f;
        }
    }
}
