using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : Gun
{
    public override event Action<WPName, int> OnFire;
    public override void Fire()
    {
        OnFire?.Invoke(data.WPName, -1);
        Debug.Log(this.name + "- Fire");
    }
}
