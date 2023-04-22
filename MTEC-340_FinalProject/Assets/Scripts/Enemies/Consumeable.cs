using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Consumeable : MonoBehaviour
{
    public ConsumeableType consumeable;


    public ConsumeableType PickUp()
    {
        Destroy(this.gameObject);
        return consumeable;
    }

}
