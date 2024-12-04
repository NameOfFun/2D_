using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "WeaponDataSO")]
public class WeaponDataSO : ScriptableObject
{
    [SerializeField] private WeaponBase[] weaponBases;

    public WeaponBase GetWeapon(WeaponType weaponType)
    {
        return weaponBases[(int)weaponType];
    }
}
