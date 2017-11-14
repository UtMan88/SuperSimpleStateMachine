using UnityEngine;
using System.Collections;
using SuperSimpleStateMachine;

[System.Serializable]
public class FleeState : StateMachine.State {
    

	public float breakAwayMin = 30.0f;
	public float breakAwayMax = 60.0f;

	public float minFleeTime = 2.0f;
	public float maxFleeTime = 5.0f;
	private float fleeTime = 0.0f;

	public Vector3 prebreakDirection = Vector3.up;
	public Vector3 breakDirection = Vector3.right;

	public const float BreakMagnitude = 10.0f;

	public string OnFleeTimerUp = "RandomState";

	public override void   OnEnter()
	{
		int directionMod = (Random.Range(0, 2) == 1 ? 1 : -1);
		float breakAngle = Random.Range(breakAwayMin, breakAwayMax) * directionMod;
		breakDirection = Quaternion.Euler(0, 0, breakAngle) * prebreakDirection;
		breakDirection.Normalize();

		fleeTime = Random.Range(minFleeTime, maxFleeTime);
	}
	
	public override void   Run()
	{
		fleeTime -= Time.deltaTime;
        transform.position += breakDirection * Time.deltaTime;
    }

	public override string CheckConditions()
	{
		if(fleeTime <= 0.0f)
		{
			return OnFleeTimerUp;
		}
		return "";
	}

	public override void   OnExit()
	{
		
	}
}
