using UnityEngine;
using System.Collections.Generic;

public class BulletPool : MonoBehaviour
{
    // Instancia única del pool (Singleton Pattern)
    static BulletPool _instance;
    public static BulletPool Instance
    {
        get
        {
            // Verificar si la instancia no está configurada
            if (_instance == null)
                Debug.LogError("BulletPool Instance missing.");
            return _instance;
        }
    }

    [SerializeField] private Bullet _bulletPrefab; // Prefab de la bala que se instanciará
    [SerializeField] private int _initialPoolSize = 10; // Tamaño inicial del pool de balas

    // Lista de balas disponibles en el pool
    private List<Bullet> _bulletPool = new List<Bullet>();

    private void Awake()
    {
        // Configurar el Singleton para que solo exista una instancia
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject); // Destruir duplicados
            return;
        }
        _instance = this;

        // Inicializar el pool con el número de balas especificado
        AddBulletsToPool(_initialPoolSize);
    }

    private void AddBulletsToPool(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            // Crear una nueva bala a partir del prefab
            Bullet bullet = Instantiate(_bulletPrefab);

            // Desactivar la bala y agregarla al pool
            bullet.gameObject.SetActive(false);
            _bulletPool.Add(bullet);

            // Ajustar el padre de la bala para organización en la jerarquía
            bullet.transform.parent = transform;
        }
    }

    public Bullet RequestBullet()
    {
        // Buscar una bala inactiva en el pool
        foreach (var bullet in _bulletPool)
        {
            if (!bullet.gameObject.activeSelf)
            {
                // Activar la bala y devolverla
                bullet.gameObject.SetActive(true);
                return bullet;
            }
        }

        // Si no hay balas disponibles, crear una nueva
        AddBulletsToPool(1);
        Bullet newBullet = _bulletPool[_bulletPool.Count - 1];
        newBullet.gameObject.SetActive(true);
        return newBullet;
    }
}
