using UnityEngine;

[System.Serializable]
public class StarShotSettings
{
    public int NumberOfBullets = 50;
    public float BaseBulletSpeed = 10f;
    public float SpeedMultiplier = 1.5f; // Multiplicador de velocidad en los picos
    public float CooldownAfterShot = 2f;
    public int StarPoints = 5;
}
