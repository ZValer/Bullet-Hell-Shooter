using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Tiempo máximo de vida de una bala
    private const float MAX_LIFE_TIME = 3f;

    // Tiempo transcurrido desde que la bala fue activada
    private float _lifeTime = 0f;

    // Velocidad de movimiento de la bala
    public Vector3 Velocity;

    // Evento para notificar cuando la bala se desactiva
    public delegate void BulletEvent();
    public event BulletEvent OnDeactivate;

    void Update()
    {
        // Mover la bala en la dirección de su velocidad, ajustada por el tiempo entre frames
        transform.position += Velocity * Time.deltaTime;

        // Incrementar el tiempo de vida de la bala
        _lifeTime += Time.deltaTime;

        // Desactivar la bala si supera su vida útil máxima
        if (_lifeTime > MAX_LIFE_TIME)
        {
            Disable();
        }
    }

    void Disable()
    {
        // Reiniciar el tiempo de vida de la bala
        _lifeTime = 0f;

        // Desactivar el objeto para reciclarlo en el pool
        gameObject.SetActive(false);

        // Notificar al pool que la bala ha sido desactivada
        OnDeactivate?.Invoke();
    }
}
