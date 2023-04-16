using UnityEngine;

public class GunScript : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public Camera fpscam;
    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;
    public float impactForce = 700f;
    public float fireRate = 4f;
    private float fireInterval = 0f;
    public float loadedAmmo = 30;
    public float remainingAmmo = 70;
  //  public Animator shooting;
   // public bool isShooting;
  


    void awake()
    {
        
    }
    void Start()
    {

       
     //  isShooting = false;
    }

    void Update()
    {

        if (Input.GetButton("Fire1") && Time.time >= fireInterval)
        {
            fireInterval = Time.time + 1f / fireRate;
            loadedAmmo -= 1;
        //    isShooting = true;
           // shooting.SetBool("IsShooting", isShooting);
            Shoot();
        }
        if (!Input.GetButton("Fire1"))
        {
         //   isShooting = false;
        //    Notshooting();
        }
       

    }
    void Shoot()
    {
        
        muzzleFlash.Play();
        RaycastHit hit;
      if (Physics.Raycast(fpscam.transform.position, fpscam.transform.forward, out hit, range)){
            Debug.Log(hit.transform.name);
            Target target = hit.transform.GetComponent<Target>();

            if (target != null)
            {
                target.TakeDamage(damage);
            }
            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }
            GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGO, 1f);
           
        }
    }
    void Notshooting()
    {
     //   shooting.SetBool("IsShooting", isShooting);
    }
}
