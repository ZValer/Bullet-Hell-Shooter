using UnityEngine;
using System.Collections.Generic;

public class BulletPool : MonoBehaviour
{
    static BulletPool _instance;
    public static BulletPool Instance
    {
        get
        {
            if (_instance == null)
                Debug.LogError("BulletPool Instance missing.");
            return _instance;
        }
    }

    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private int _initialPoolSize = 10;

    private List<Bullet> _bulletPool = new List<Bullet>();

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;
        }
        _instance = this;

        AddBulletsToPool(_initialPoolSize);
    }

    private void AddBulletsToPool(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            Bullet bullet = Instantiate(_bulletPrefab);
            bullet.gameObject.SetActive(false);
            _bulletPool.Add(bullet);
            bullet.transform.parent = transform;
        }
    }

    public Bullet RequestBullet()
    {
        foreach (var bullet in _bulletPool)
        {
            if (!bullet.gameObject.activeSelf)
            {
                bullet.gameObject.SetActive(true);
                Debug.Log($"Bullet activated at position {bullet.transform.position}");
            
                return bullet;
            }
        }

        // Si no hay balas disponibles, crea más
        AddBulletsToPool(1);
        Bullet newBullet = _bulletPool[_bulletPool.Count - 1];
        newBullet.gameObject.SetActive(true);
        return newBullet;
    }
}
