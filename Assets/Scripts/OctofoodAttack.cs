using UnityEngine;
using System.Collections;

public class OctofoodAttack : MonoBehaviour
{
    public Animator tentacle1;
    public Animator tentacle2;
    public Animator tentacle3;
    public Animator tentacle4;
    public Animator tentacle5;
    public Animator tentacle6;

    public string isAttack = "isAttack";
    public string dizzy = "isDizzy";
    private bool isOnce = false;
    private bool isDizzy = false;
    private float bossHealth;
    private float maxBossHealth;
    private EnemyGameManager enemyGameManagerScript;
    private int currentHealthPercentage;

    void Start(){
        enemyGameManagerScript = GameObject.Find("EnemyGameManager").GetComponent<EnemyGameManager>();
            tentacle1.SetFloat(dizzy, 0);
            tentacle2.SetFloat(dizzy, 0);
            tentacle3.SetFloat(dizzy, 0);
            tentacle4.SetFloat(dizzy, 0);
            tentacle5.SetFloat(dizzy, 0);
            tentacle6.SetFloat(dizzy, 0);

    }

    void Update()
    {
        // check if current health percentage is a multiple of 20% and greater than 0%
        if (enemyGameManagerScript.enemyCurrentHealth <= 80 && !isOnce)
        {
            isDizzy = true;
            StartCoroutine(AnimateTentaclesDizzy());
        }
    }

    IEnumerator AnimateTentacles()
    {
        while (true)
        {
            isOnce = true;  
            // Wait for 3 seconds
            yield return new WaitForSeconds(3f);
            Debug.Log("Attacking");
            // Create a random boolean parameter for each tentacle Animator
            tentacle1.SetBool(isAttack, Random.Range(0, 10) == 1);
            tentacle2.SetBool(isAttack, Random.Range(0, 10) == 1);
            tentacle3.SetBool(isAttack, Random.Range(0, 10) == 1);
            tentacle4.SetBool(isAttack, Random.Range(0, 10) == 1);
            tentacle5.SetBool(isAttack, Random.Range(0, 10) == 1);
            tentacle6.SetBool(isAttack, Random.Range(0, 10) == 1);
        }
    }
    IEnumerator AnimateTentaclesDizzy()
    {
        while(isDizzy)
        {       
            isOnce = true; 
            Debug.Log("dizzy");
            

            tentacle1.SetBool(dizzy, true);
            tentacle2.SetBool(dizzy, true);
            tentacle3.SetBool(dizzy, true);
            tentacle4.SetBool(dizzy, true);
            tentacle5.SetBool(dizzy, true);
            tentacle6.SetBool(dizzy, true);

            yield return new WaitForSeconds(5f);

            tentacle1.SetBool(dizzy, false);
            tentacle2.SetBool(dizzy, false);
            tentacle3.SetBool(dizzy, false);
            tentacle4.SetBool(dizzy, false);
            tentacle5.SetBool(dizzy, false);
            tentacle6.SetBool(dizzy, false);
            Debug.Log("not dizzy");

            yield return new WaitForSeconds(1f);
            isDizzy = false;
        }
    }

}
