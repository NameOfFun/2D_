using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_Shotgun : WeaponBase
{
    [SerializeField] Transform[] bulletPoint;
    [SerializeField] BulletBase bulletBase;

    protected override void Shoot()
    {
        for (int i = 0; i < bulletPoint.Length; i++)
        {
            Instantiate(bulletBase, bulletPoint[i].position, bulletPoint[i].rotation).OnInit(10);
        }
    }
}
