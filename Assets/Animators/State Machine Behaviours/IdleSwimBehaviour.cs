using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleSwimBehaviour : StateMachineBehaviour
{
    private int _stateTimeLimit;

    private FishController _fc;
    private float _timeInState = 0.0f;

    override public void OnStateEnter(Animator fsm, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _stateTimeLimit = Random.Range(1, 10);
        _fc = fsm.GetComponentInParent<FishController>();
        _fc.FindRandomPoint();
    }

    override public void OnStateUpdate(Animator fsm, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _timeInState += Time.deltaTime;
        _fc.Move();

        if(_timeInState > _stateTimeLimit)
        {
            _fc.FindRandomPoint();
            _stateTimeLimit = Random.Range(1, 10);
            _timeInState = 0;
        }
    }

    override public void OnStateExit(Animator fsm, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
