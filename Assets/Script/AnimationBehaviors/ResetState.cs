using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Callback
{
    Enter,
    Update,
    Exit
}

public class ResetState : StateMachineBehaviour
{
    public string parameter;
    public Callback callback = Callback.Exit;

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (callback == Callback.Exit)
        {
            animator.SetInteger(parameter, 0);
        }
    }

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (callback == Callback.Enter)
        {
            animator.SetInteger(parameter, 0);
        }
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (callback == Callback.Update)
        {
            animator.SetInteger(parameter, 0);
        }
    }
}
