using UnityEngine;

public class ActorAnimationBehaviour : MonoBehaviour
{
    public Animator animator;

    public void StartWalk()
    {
        animator.SetBool("Walk", true);
    }

    public void StopWalk()
    {
        animator.SetBool("Walk", false);
    }

    public void SetTriggerString(string s)
    {
        animator.SetTrigger(s);
    }
}