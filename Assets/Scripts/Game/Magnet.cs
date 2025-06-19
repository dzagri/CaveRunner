using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : CollectibleBase
{
    readonly float timer = 15f;
    public override void Collect(ManageCollectibles manager)
    {
        manager.magnetArea.GetComponent <SphereCollider>().enabled = true;
        manager.Magnet(timer, true);
    }

}
