using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class FireController : MonoBehaviour
{
    [SerializeField] private List<Gun> guns;
    [SerializeField] private Gun currentGun;
    [SerializeField] private ButtonFire btnFire;
    public event Action<WPName, int> OnFire;
    void Start()
    {
        btnFire.OnFireSelect += FireSelect;

        btnFire.OnFireDeselect += FireDeselect;
        foreach (var gun in guns)
        {
            gun.OnFire += OnGunFire;
        }

    }
    public void InitData(List<GunData> gunDatas, WPName startGun)
    {
        foreach (var data in gunDatas)
        {
            GetGun(data.WPName).InitData(data);
        }
        currentGun = GetGun(startGun);
    }
    public void ChangeWeapon(WPName wPName)
    {
        currentGun = GetGun(wPName);
    }
    private void OnGunFire(WPName name, int cammo)
    {
        OnFire?.Invoke(name, cammo);
    }

    private void FireDeselect()
    {
        currentGun.StopFire();
    }

    private void FireSelect()
    {
        currentGun.StartFire();
    }

    private Gun GetGun(WPName wPName)
    {
        foreach (var gun in guns)
        {
            if (wPName == gun.WPName)
                return gun;
        }
        return null;
    }

}
