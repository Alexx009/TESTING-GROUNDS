using UnityEngine;

public class ChangeDefaultState : MonoBehaviour
{
    public Animator animator; // Reference to the Animator component

    public string idle; // The name of the state you want to set as default

    void Start()
    {
        // Set the default state of the Animator Controller to the state with the given name
        animator.Play(idle, -1, 0f);

    }
}
