using UnityEngine;
using System.Collections;
using SuperSimpleStateMachine;

[System.Serializable]
public class ChaseState : StateMachine.State
{
	public Transform target;
	public float dampTime = 1.25f;
	private Vector3 velocity = Vector3.zero;
	public float minDistanceToTarget = 1.0f;
	public string OnEnemyLostState = "WanderState";
	public string OnEnemyMinDistanceState = "FleeState";

	public override void   OnEnter()
	{
        // TODO get target
	}
	public override void   Run()
	{
		if(target != null)
		{
			Vector3 delta = target.position - transform.position;
			Vector3 destination = transform.position + delta;
			transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
		}
	}
	public override string CheckConditions()
	{
		//return OnEnemyLockState;
		if(target == null)
		{
			return OnEnemyLostState;
		}
		else if(Vector3.Distance(transform.position, target.position) < minDistanceToTarget)
		{
			return OnEnemyMinDistanceState;
		}
		else
			return "";
	}
	public override void   OnExit()
	{
		
	}
}
