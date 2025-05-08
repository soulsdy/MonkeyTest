using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lazer : Gun
{
    public override event Action<WPName, int> OnFire;
    public override event Action<WPName, int> OnRegenCammo;

    IEnumerator RegenCammo()
    {
        while (!isFire && currentCammo < data.Magazine)
        {
            currentCammo++;
            OnRegenCammo?.Invoke(data.WPName, currentCammo);
            yield return new WaitForSeconds(data.LimitSpeed);
        }
    }
    public override void StopFire()
    {
        base.StopFire();
        StartCoroutine(RegenCammo());
    }
    public override void Fire()
    {
        base.Fire();
        OnFire?.Invoke(data.WPName, currentCammo);
        Debug.Log(this.name + "- Fire");
    }
}
