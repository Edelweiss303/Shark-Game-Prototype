﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieBehaviour : StateMachineBehaviour
{
    private FishController _fc;

    override public void OnStateEnter(Animator fsm, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _fc = fsm.GetComponentInParent<FishController>();
    }
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }


    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

}
