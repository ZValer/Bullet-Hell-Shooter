using UnityEngine;

public class Bullet : MonoBehaviour
{
    private const float MAX_LIFE_TIME = 3f;
    private float _lifeTime = 0f;

    public Vector3 Velocity;

    void Update()
    {
        // Mover la bala según su velocidad
        transform.position += Velocity * Time.deltaTime;
        _lifeTime += Time.deltaTime;

        // Desactivar la bala cuando supera su vida útil
        if (_lifeTime > MAX_LIFE_TIME)
            Disable();
    }

    void Disable()
    {
        _lifeTime = 0f;
        gameObject.SetActive(false);
    }
}
