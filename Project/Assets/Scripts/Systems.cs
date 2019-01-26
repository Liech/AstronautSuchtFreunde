using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Systems : MonoBehaviour
{
    public float WeaponLvL = 1;
    public int Health = 100;
    public float DriveFactor = 1;

    int weaponLVL = 0;
    int healthLVL = 0;
    int driveLVL = 0;

    List<float> driveFactors = new List<float> {1.0f, 1.5f, 2.5f}; 
    List<int> healthAmounts = new List<int> {100, 150, 220}; 

    public void lvlUpDrive()
    {
        driveLVL += 1;
        DriveFactor = driveFactors[driveLVL];
    }

    public void lvlUpHealth()
    {
        healthLVL += 1;
        Health = healthAmounts[healthLVL];
        GetComponent<Life>().MaxLife = Health;
        GetComponent<Life>().currentLife = Health;
    }

    public void lvlUpWeapons()
    {
        weaponLVL += 1;
        WeaponLvL = weaponLVL;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
