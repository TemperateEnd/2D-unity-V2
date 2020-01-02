using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Weapon", menuName = "Create New Weapon")]
public class Weapon : ScriptableObject
{
    public string weaponName; //Name of weapon
    public Sprite weaponSprite; //Sprite of weapon: What it looks like
    public int ammoPerMag; //Max ammo for each weapon
    public int fireDamage; //Damage each weapon does
    public int currentAmmo; //Current ammo for each weapon
    public enum WeaponType { Pistol, SMG, AssaultRifle, Shotgun }; //Type of weapon
    public WeaponType wType; //Instance of the WeaponType enum
    public AudioClip firingAudio; //What sound the gun makes when firing
}