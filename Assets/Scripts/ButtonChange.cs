using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonChange : MonoBehaviour
{
    [SerializeField] Button mButton;
    [SerializeField] TextMeshProUGUI txtName;
    [SerializeField] TextMeshProUGUI txtCammo;
    [SerializeField] Image imageLimit;
    [SerializeField] WPName id;
    [SerializeField] private GunData mGunData;
    public WPName WPName
    {
        get
        {
            return id;
        }
    }
    public event Action<ButtonChange> OnClick;
    // Start is called before the first frame update
    void Start()
    {
        mButton.onClick.AddListener(OnClickChange);
    }

    private void OnClickChange()
    {
        OnClick?.Invoke(this);
    }

    public void Init(GunData gunData)
    {
        mGunData = gunData;
        txtName.text = mGunData.WPName.ToString();
        UpdateCammo(mGunData.Magazine);
    }

    public void UpdateCammo(int cammo)
    {
        txtCammo.text = cammo.ToString();
    }
    public void Reload()
    {
        Debug.Log("Reload");
    }
    public void OverHead()
    {
        Debug.Log("OverHead");
    }
    // Update is called once per frame
    void Update()
    {

    }
}
