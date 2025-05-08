using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum WPName
{
    PISTOL = 0,
    BAZOKA,
    LAZER,
    KNIFE
}
[Serializable]
public class GunData
{
    [SerializeField] private WPName wPName;
    [SerializeField] private int magazine;
    [SerializeField] private float reloadTime;
    [SerializeField] private float limitSpeed;
    [SerializeField] private float attackSpeed;
    [SerializeField] private BulletData bulletData; // 

    public int Magazine
    {
        get
        {
            return magazine;
        }
    }
    public float ReloadTime
    {
        get
        {
            return reloadTime;
        }
    }
    public float LimitSpeed
    {
        get
        {
            return limitSpeed;
        }
    }
    public float AttackSpeed
    {
        get
        {
            return attackSpeed;
        }
    }
    public WPName WPName
    {
        get
        {
            return wPName;
        }
    }

}
