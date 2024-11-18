using UnityEngine;

[System.Serializable]
public class FlowerShotSettings
{
    public int NumberOfPetals = 6; // Número de "pétalos" o secciones
    public int BulletsPerPetal = 3; // Balas por pétalo
    public float AngleSpread = 15f; // Ángulo de dispersión dentro de cada pétalo
    public float BulletSpeed = 7f; // Velocidad de las balas
    public float CooldownAfterShot = 0.5f; // Tiempo después de cada disparo
}
