using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Gun
{
    // Start is called before the first frame update
    public override void Fire()
    {
        base.Fire();
        Debug.Log(this.name + "- Fire");
    }
}
