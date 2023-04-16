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
    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag == "tentaclesTrigger")
        {
            tentaclesPack.SetActive(true);
            tentacle = GetComponent<Animator>();
        }
    }
}
