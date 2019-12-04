using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Weapon", menuName = "Create New Weapon")]
public class Weapon : ScriptableObject
{
    public string weaponName;
    public Sprite weaponSprite;
    public int ammoPerMag;
    public int fireDamage;
    public enum WeaponType { Pistol, SMG, AssaultRifle, Shotgun };
    public WeaponType wType;
    

}
