using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ActressMas;
public class Actor : TurnBasedAgent 
{
    public override void Setup()
    {
        Debug.Log("Starting " + Name);
    }
    // Start is called before the first frame update

}
