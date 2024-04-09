using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerStats : MonoBehaviour
{
    public static playerStats instance;



    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
}
