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

    List<float> driveFactors = new List<float> {1.0f, 1.5f, 2.3f,3.0f }; 
    List<int> healthAmounts = new List<int> {100, 150, 220, 300}; 

    public void lvlUpDrive()
    {
        driveLVL += 1;
        DriveFactor = driveFactors[driveLVL];
        Debug.Log("leveled up drive to " + driveLVL.ToString());
    }

    public void lvlUpHealth()
    {
        healthLVL += 1;
        Health = healthAmounts[healthLVL];
        GetComponent<Life>().MaxLife = Health;
        GetComponent<Life>().currentLife = Health;
        Debug.Log("leveled up health to " + healthLVL.ToString());
    }

    public void lvlUpWeapons()
    {
        weaponLVL += 1;
        WeaponLvL = weaponLVL;
        Debug.Log("leveled up weapons to " + weaponLVL.ToString());

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
