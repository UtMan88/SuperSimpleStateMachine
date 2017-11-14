using UnityEngine;
using System.Collections;

public class WanderState : RandomState {

    public float WanderTimeMin = 1.0f;
    public float WanderTimeMax = 5.0f;
    public string WanderFinishState = "FlyTowardsEnemies";

    private float wanderTime = 0.0f;
    private float elaspedTime = 0.0f;

    public override void OnEnter()
    {
        base.OnEnter();
        elaspedTime = 0.0f;
        wanderTime = Random.Range(WanderTimeMin, WanderTimeMax);
    }

    public override void Run()
    {
        base.Run();
        elaspedTime += Time.deltaTime;
    }

    public override string CheckConditions()
    {
        string ret = base.CheckConditions();
        if (ret.Length == 0)
            return ret;
        if (elaspedTime >= wanderTime)
            return WanderFinishState;
        return "";

    }
}
