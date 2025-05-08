using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class FireManager : MonoBehaviour
{
    [SerializeField] private List<ButtonChange> btnsChangeWP;
    [SerializeField] private List<GunData> weaponDatas;
    [SerializeField] private ButtonChange currentBtnChange;
    [SerializeField] private FireController fireController;
    void Start()
    {

    }
    private void OnEnable()
    {
        foreach (var item in btnsChangeWP)
        {
            item.OnClick += ChangeWP;
            item.Init(GetGunData(item.WPName));
        }
        currentBtnChange = btnsChangeWP[0];
        fireController.OnFire += OnFire;
        fireController.OnReload += OnReload;
        fireController.OnReloaded += OnReloaded;
        fireController.OnRegenCammo += OnRegenCammo;
        fireController.InitData(weaponDatas, currentBtnChange.WPName);
    }

    private void OnRegenCammo(WPName name, int cammo)
    {
        Debug.Log("Gun " + name + " Regen");
        currentBtnChange.UpdateCammo(cammo);
    }

    private void OnReloaded(WPName name, int cammo)
    {
        Debug.Log("Gun " + name + " Reloaded");
        currentBtnChange.UpdateCammo(cammo);
    }

    private void OnReload(WPName name)
    {
        Debug.Log("Gun " + name + " Reload");
    }

    private void OnDisable()
    {
        foreach (var item in btnsChangeWP)
        {
            item.OnClick -= ChangeWP;
        }
        fireController.OnFire -= OnFire;

    }

    private void OnFire(WPName name, int cammo)
    {
        currentBtnChange.UpdateCammo(cammo);
    }

    public void Init(List<GunData> gunDatas)
    {
        weaponDatas = gunDatas;
        fireController.InitData(weaponDatas, currentBtnChange.WPName);
    }

    private void Fire()
    {

    }
    private void ChangeWP(ButtonChange buttonChange)
    {
        currentBtnChange = buttonChange;
        fireController.ChangeWeapon(buttonChange.WPName);
    }
    GunData GetGunData(WPName id)
    {
        foreach (var item in weaponDatas)
        {
            if (item.WPName == id)
                return item;
        }
        return null;
    }
}
