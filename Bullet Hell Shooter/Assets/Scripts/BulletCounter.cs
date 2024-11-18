using UnityEngine;
using TMPro;

public class BulletCounter : MonoBehaviour
{
    public static BulletCounter Instance;

    [SerializeField] private TextMeshProUGUI _text; // Componente de texto que se actualizará

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    public void UpdateBulletCount(int activeBullets)
    {
        if (_text != null)
        {
            _text.text = $"Active Bullets: {activeBullets}";
        }
    }
}
