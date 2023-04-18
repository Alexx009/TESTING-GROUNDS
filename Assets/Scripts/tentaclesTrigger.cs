using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tentaclesTrigger : MonoBehaviour
{
    public GameObject tentaclesPack;
    public Animator tentacle;
    
    
    private void Start() {
        tentaclesPack.SetActive(false);
    }
    void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag == "tentacleTrigger")
        {
            Debug.Log("Welcome to Octofood");
            tentaclesPack.SetActive(true);
        }
    }

}
