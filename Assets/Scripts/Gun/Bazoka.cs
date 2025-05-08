using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bazoka : Gun
{
    public override void Fire()
    {
        base.Fire();
        Debug.Log(this.name + "- Fire");
    }
}
