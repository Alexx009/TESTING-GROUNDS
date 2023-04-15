using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReloaderScript : MonoBehaviour
{
    public GameObject gun;
    GunScript gunScript;
    Ammos ammosScript;
   // public GameObject reloadHuds;
    public float ammoTotal = 30f;
    public float increaseAmmo;

    void Awake()
    {
        gunScript = gun.GetComponent<GunScript>();
        ammosScript = gun.GetComponent<Ammos>();
    }
    void Start()
    {
      //  reloadHuds.SetActive(false);
       
    }
    void Update()
    {
        increaseAmmo = ammoTotal - gunScript.loadedAmmo;
        if (Input.GetKeyDown(KeyCode.R) && gunScript.loadedAmmo <=29 )
        {
            StartCoroutine(Coroutines());

            if (increaseAmmo == gunScript.remainingAmmo && gunScript.remainingAmmo >= 1 && gunScript.remainingAmmo <= 29)
            {
                gunScript.remainingAmmo -= increaseAmmo;
                gunScript.loadedAmmo += increaseAmmo;
                return;
            }

            if (increaseAmmo <= gunScript.remainingAmmo && gunScript.remainingAmmo >= 1)
            {
                gunScript.remainingAmmo -= increaseAmmo;
                gunScript.loadedAmmo += increaseAmmo;
               
                return;
            }
            if(increaseAmmo >= gunScript.remainingAmmo && gunScript.remainingAmmo >= 1)
            {
                gunScript.loadedAmmo += gunScript.remainingAmmo;
                gunScript.remainingAmmo -= increaseAmmo;
               
                return;
            }
           
            
        }
    }
    IEnumerator Coroutines()
    {
       // reloadHuds.SetActive(true);
        gunScript.enabled = false;
        yield return new WaitForSeconds(2f);
       // reloadHuds.SetActive(false);
        gunScript.enabled = true;

        
    }
    void GunscriptDisabled()
    {
        gunScript.enabled = false;
    }
}
