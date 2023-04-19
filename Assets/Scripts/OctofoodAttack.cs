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
    public string dizzy = "dizzy";
    public string idle = "idle";
    private bool isOnce = false;
    public bool isAnimating = false;
    private float blendTime = 1f;
    private EnemyGameManager enemyGameManagerScript;


    void Start(){
        enemyGameManagerScript = GameObject.Find("EnemyGameManager").GetComponent<EnemyGameManager>();
    }



    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            if (!isAnimating)
            {
                StartCoroutine(AnimateTentacles());
                isAnimating = true;
                Debug.Log("attack");
            }
        }
        else
        {
            isAnimating = false;
        }
    }

void AnimateTentaclesIdle()
{
    tentacle1.CrossFade(idle, blendTime);
    tentacle2.CrossFade(idle, blendTime);
    tentacle3.CrossFade(idle, blendTime);
    tentacle4.CrossFade(idle, blendTime);
    tentacle5.CrossFade(idle, blendTime);
    tentacle6.CrossFade(idle, blendTime);
    Debug.Log("not dizzy");
    // isAnimating = false;
}

public IEnumerator AnimateTentaclesDizzy()
{
    tentacle1.CrossFade(dizzy, blendTime);
    tentacle2.CrossFade(dizzy, blendTime);
    tentacle3.CrossFade(dizzy, blendTime);
    tentacle4.CrossFade(dizzy, blendTime);
    tentacle5.CrossFade(dizzy, blendTime);
    tentacle6.CrossFade(dizzy, blendTime);
    Debug.Log("dizzy");
    yield return new WaitForSeconds(5f);
    Invoke("AnimateTentaclesIdle", 5f);
}

public IEnumerator AnimateTentacles()
{
    isOnce = true;
 
    Debug.Log("Attacking");
    // Create a random boolean parameter for each tentacle Animator
    tentacle1.SetBool(isAttack, Random.Range(0, 3) == 1);
    tentacle2.SetBool(isAttack, Random.Range(0, 3) == 1);
    tentacle3.SetBool(isAttack, Random.Range(0, 3) == 1);
    tentacle4.SetBool(isAttack, Random.Range(0, 3) == 1);
    tentacle5.SetBool(isAttack, Random.Range(0, 3) == 1);
    tentacle6.SetBool(isAttack, Random.Range(0, 3) == 1);

    // Wait until the attack animation is done
    while (true)
    {
        bool isAttacking = tentacle1.GetCurrentAnimatorStateInfo(0).IsName("attack");
        isAttacking |= tentacle2.GetCurrentAnimatorStateInfo(0).IsName("attack");
        isAttacking |= tentacle3.GetCurrentAnimatorStateInfo(0).IsName("attack");
        isAttacking |= tentacle4.GetCurrentAnimatorStateInfo(0).IsName("attack");
        isAttacking |= tentacle5.GetCurrentAnimatorStateInfo(0).IsName("attack");
        isAttacking |= tentacle6.GetCurrentAnimatorStateInfo(0).IsName("attack");

        if (!isAttacking)
        {
            break;
        }

        yield return null;
    }

    Debug.Log("Finished attacking");
    
    // Wait for 1 second
    yield return new WaitForSeconds(4f);

    // Go to idle animation
    tentacle1.SetBool(isAttack, false);
    tentacle2.SetBool(isAttack, false);
    tentacle3.SetBool(isAttack, false);
    tentacle4.SetBool(isAttack, false);
    tentacle5.SetBool(isAttack, false);
    tentacle6.SetBool(isAttack, false);
    
    Debug.Log("Idle");

    isAnimating = false;
}




}
