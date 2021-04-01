using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : NPCbaseFSM
{



    //GameObject NPC;
    GameObject[] waypoints;
    int currentWP;
    private int face = 1;
    public float distnation = 3.0f;
    private Vector2 currentposition;

    void Awake() {
        waypoints = GameObject.FindGameObjectsWithTag("waypoint");

    }


    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //NPC = animator.gameObject;
        base.OnStateEnter(animator, stateInfo, layerIndex);
        currentWP = 0;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (waypoints.Length == 0) return;
        if (Vector2.Distance(waypoints[currentWP].transform.position, NPC.transform.position) < accuracy)
            {
            currentWP++;
            if (currentWP >= waypoints.Length) {
                currentWP = 0;
            }
            }


        var direction = waypoints[currentWP].transform.position - NPC.transform.position;

        NPC.transform.rotation = Quaternion.Slerp(NPC.transform.rotation, Quaternion.LookRotation(direction), 
        1.0f * Time.deltaTime);
        NPC.transform.Translate( Time.deltaTime * speed, 0,0);

        //NPC go and back agian and agian
        //if (face == 1)
        //{
        //    NPC.transform.Translate(Time.deltaTime * speed, 0, 0);

        //}
        //if (face == 0)
        //{
        //    NPC.transform.Translate(-Time.deltaTime * speed, 0, 0);
        //}

        //if (NPC.transform.position.x > currentposition.x + distnation)
        //{
        //    face = 0;
        //}
        //if (NPC.transform.position.x < currentposition.x)
        //{
        //    face = 1;
        //}

        //NPC.transform.Translate(Time.deltaTime * 2.0f, 0, 0);








    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
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
