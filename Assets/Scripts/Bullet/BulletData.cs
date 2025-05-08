using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum BulletName
{
    BLUE,
    RED,
    NADE,
    KNIFE,
    LINE
}
[Serializable]
public class BulletData
{
    [SerializeField] BulletName bulletName;
    [SerializeField] private float damage;
    [SerializeField] private float speed;
    [SerializeField] private float timeToEx;
    // etc .......
}
