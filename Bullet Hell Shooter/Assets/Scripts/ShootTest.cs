using UnityEngine;

public class ShootTest : MonoBehaviour
{
    [SerializeField] private float _shootCooldown; // Tiempo mínimo entre disparos
    [SerializeField] private CircleShotSettings _circleShotSettings; // Configuración para disparos en círculo
    [SerializeField] private AsteriskShotSettings _asteriskShotSettings; // Configuración para disparos en asterisco
    [SerializeField] private StarShotSettings _starShotSettings; // Configuración para disparos en estrella
    [SerializeField] private FlowerShotSettings _flowerShotSettings; // Configuración para disparos en flor
    [SerializeField] private float _switchDuration = 10f; // Duración de cada tipo de disparo

    private float _shootCooldownTimer = 0f; // Temporizador para controlar el cooldown
    private float _switchTimer = 0f; // Temporizador para alternar disparos
    private int _currentAttackIndex = 0; // Índice del ataque actual (0: Circle, 1: Asterisk, etc.)

    void Update()
    {
        // Incrementar los temporizadores
        _shootCooldownTimer += Time.deltaTime;
        _switchTimer += Time.deltaTime;

        // Alternar entre los tipos de disparo cada _switchDuration segundos
        if (_switchTimer >= _switchDuration)
        {
            _currentAttackIndex = (_currentAttackIndex + 1) % 4; // Cambiar al siguiente ataque (0 a 3)
            _switchTimer = 0f; // Reiniciar el temporizador de alternancia
        }

        // Verificar si el cooldown ha terminado
        if (_shootCooldownTimer >= GetCurrentCooldown())
        {
            // Ejecutar el ataque correspondiente al índice actual
            switch (_currentAttackIndex)
            {
                case 0:
                    ShotAttack.CircleShot(transform.position, transform.up, _circleShotSettings);
                    break;
                case 1:
                    ShotAttack.AsteriskShot(transform.position, transform.up, _asteriskShotSettings);
                    break;
                case 2:
                    ShotAttack.StarShot(transform.position, transform.up, _starShotSettings);
                    break;
                case 3:
                    ShotAttack.FlowerShot(transform.position, transform.up, _flowerShotSettings);
                    break;
            }

            // Reiniciar el temporizador de cooldown
            _shootCooldownTimer = 0f;
        }
    }

    // Obtener el cooldown del ataque actual
    private float GetCurrentCooldown()
    {
        switch (_currentAttackIndex)
        {
            case 0: return _circleShotSettings.CooldownAfterShot;
            case 1: return _asteriskShotSettings.CooldownAfterShot;
            case 2: return _starShotSettings.CooldownAfterShot;
            case 3: return _flowerShotSettings.CooldownAfterShot;
            default: return _shootCooldown; // Fallback si algo sale mal
        }
    }
}
