using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RaycastInteract : MonoBehaviour
{
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private string excludeLayerName;
    public GameObject dialogueBox;

    public GameObject pressE;
    public float range = 100f;
    public bool isReadingDialogue = false;
    public GameObject questText;
    private Animator gateAnimator;

   // public GameObject boss;
    //public GameObject healthBar;
    // Start is called before the first frame update
    void Start()
    {
        gateAnimator = GameObject.Find("Gate").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
      //  int mask = 1 << LayerMask.NameToLayer(excludeLayerName) | layerMask.value;
       if(Physics.Raycast(transform.position, transform.forward, out hit, range)){
        if(hit.collider.CompareTag("Enemy")){
        pressE.SetActive(true);
        }
          else if(!hit.collider.CompareTag("Enemy")){
      
           pressE.SetActive(false);
           dialogueBox.SetActive(false);  
      
        }
        if(hit.collider.CompareTag("Enemy") && Input.GetKey(KeyCode.E) && !isReadingDialogue){
            dialogueBox.SetActive(true);
            isReadingDialogue = true;
            questText.SetActive(true);
            gateAnimator.Play("Door_AnimOpen");
           // StartCoroutine(bossIncoming());
        }
         else if(Input.anyKeyDown && isReadingDialogue){
                    dialogueBox.SetActive(false);  
                       isReadingDialogue = false;
            }
            
        
       }

    }

/*    IEnumerator bossIncoming(){
        yield return new WaitForSeconds(2);
        boss.SetActive(true);
        healthBar.SetActive(true);
    } */
}
