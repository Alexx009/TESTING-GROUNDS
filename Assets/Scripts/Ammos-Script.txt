using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammos : MonoBehaviour
{
    GunScript gunScript;
    public GameObject baril;
    public float tirangBala;

    ReloaderScript reloader;

    void Awake()
    {
        gunScript = baril.GetComponent<GunScript>();
        reloader = baril.GetComponent<ReloaderScript>();
    }
    void Start()
    {
        
        reloader.enabled = false;

    }
    void Update()
    {
        
        if (gunScript.loadedAmmo <= 29)
        {
            reloader.enabled = true;
           
        }
        if (gunScript.loadedAmmo == 0)
        {
            gunScript.enabled = false;
        }
        if (reloader.increaseAmmo > gunScript.remainingAmmo && gunScript.remainingAmmo == 0)
        {
            reloader.enabled = false;
        }
        if (gunScript.loadedAmmo <= 0 && gunScript.remainingAmmo <= 0)
        {
            reloader.enabled = false;
            gunScript.enabled = false;
        }
    }
}  
