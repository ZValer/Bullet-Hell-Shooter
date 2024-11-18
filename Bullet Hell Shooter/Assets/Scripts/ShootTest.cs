using UnityEngine;

public class ShootTest : MonoBehaviour
{
    [SerializeField] private float _shootCooldown; // Tiempo entre disparos
    [SerializeField] private RadialShotSettings _shotSettings;
    private float _shootCooldownTimer = 0f;

    void Update()
    {
        _shootCooldownTimer += Time.deltaTime;

        // Verificar si el cooldown ha terminado
        if (_shootCooldownTimer >= _shootCooldown)
        {
            ShotAttack.RadialShot(transform.position, transform.up, _shotSettings);
            _shootCooldownTimer = 0f;
        }
    }
}
