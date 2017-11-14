using UnityEngine;
using System.Collections;
using SuperSimpleStateMachine;

[System.Serializable]
public class RandomState : StateMachine.State
{
	public Vector3 Center = Vector2.zero;
	private Vector3 newPos = Vector2.zero;
	public float JumpTimeMax = 5.0f;
	public float JumpTimeMin = 3.0f;
	public float JumpMinDist = 0.1f;
	public float JumpRadius = 10.0f;
	private float jumpTime = 0.0f;
	private float curTime = 0.0f;
	public bool useCenter = true;

    public float dampTime = 1.25f;
    private Vector3 velocity = Vector3.zero;

    public float EnemyMinDist = 2.0f;
	public string OnEmemyLockState = "ChaseState";

    public float minStateTime = 2.0f;
    public float maxStateTime = 5.0f;
    private float StateTime = 0.0f;

    public override void   OnEnter()
	{
        StateTime = Random.Range(minStateTime, maxStateTime);
    }
	public override void   Run()
	{
		curTime += Time.deltaTime;
        StateTime -= Time.deltaTime;
        if (curTime >= jumpTime || Vector3.Distance(transform.position, this.transform.position) <= JumpMinDist )
		{
			jumpTime = Random.Range(JumpTimeMin, JumpTimeMax);
			curTime = 0.0f;
			newPos = (useCenter ? Center : newPos) + (Random.insideUnitSphere * JumpRadius);
			newPos.z = this.transform.position.z;
            this.transform.position = Vector3.SmoothDamp(transform.position, newPos, ref velocity, dampTime);
		}
	}
	public override string CheckConditions()
	{
        if(StateTime <= 0.0f)
        {
            return OnEmemyLockState;
        }
		return "";

	}
	public override void   OnExit()
	{
		
	}
}
