using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Weapon/weapon")]

public abstract class Powerup : ScriptableObject
{
    /*public float damage;
    public float attackSpeed;
    public Color color;
    public string name;
    public string type;
    public int ammo;

    public void Talk()
    {
        Debug.Log("hi");

    }*/
    
    //Weapon set up 2

    public int chance = 1;
    public float cooldown = 1f;
    public float duration = 0f;
    public float power = 1f;

    public abstract void UsePowerup(Rigidbody rb);
    
}
