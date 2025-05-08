using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] protected GunData data;
    public virtual event Action<WPName, int> OnFire;
    public virtual event Action<WPName> OnReload;
    public virtual event Action<WPName, int> OnReloaded;
    public virtual event Action<WPName, int> OnRegenCammo;
    protected int currentCammo;
    [SerializeField] protected bool isFire, fireAvaiable = true;
    public WPName WPName
    {
        get
        {
            return data.WPName;
        }
    }
    public void InitData(GunData gunData)
    {
        data = gunData;
        currentCammo = data.Magazine;
    }
    public void StartFire()
    {
        if (!fireAvaiable) return;
        isFire = true;
        StartCoroutine(DelayFire());
    }
    public virtual void StopFire()
    {
        isFire = false;
        StopCoroutine(DelayFire());
    }
    IEnumerator DelayFire()
    {
        while (isFire)
        {
            Fire();
            fireAvaiable = false;
            yield return new WaitForSeconds(1 / data.AttackSpeed);
            fireAvaiable = true;
        }
    }
    IEnumerator StartReload()
    {
        StopFire();
        OnReload?.Invoke(data.WPName);
        yield return new WaitForSeconds(data.ReloadTime);
        currentCammo = data.Magazine;
        OnReloaded?.Invoke(data.WPName, currentCammo);
        StartFire();

    }
    public virtual void Fire()
    {
        if (currentCammo <= 0)
            return;
        currentCammo--;
        OnFire?.Invoke(data.WPName, currentCammo);
        if (currentCammo <= 0)
            Reload();
    }
    protected void Reload()
    {
        StartCoroutine(StartReload());
    }
    public void Delay()
    {

    }
    void Update()
    {

    }
}
