using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace SuperSimpleStateMachine
{
    [System.Serializable]
    public class StateMachine : MonoBehaviour
    {
        [System.Serializable]
        public abstract class State : MonoBehaviour
        {
            public string Name;
            public abstract void OnEnter();
            public abstract void Run();
            public abstract string CheckConditions();
            public abstract void OnExit();

        }

        public State[] States;
        public State CurrentState;
        public bool isActive = true;

        void Start()
        {
            if (CurrentState != null)
            {
                CurrentState.OnEnter();
            }
        }

        // Update is called once per frame
        void Update()
        {
            if (isActive == true && CurrentState != null)
            {
                CurrentState.Run();
                string stateId = CurrentState.CheckConditions();
                if (stateId.Length > 0)
                {
                    foreach (State s in States)
                    {
                        if (s.Name == stateId)
                        {
                            CurrentState.OnExit();
                            CurrentState = s;
                            CurrentState.OnEnter();
                            break;
                        }
                    }

                }

            }
        }

        public void ChangeState(State state)
        {
            if (state == null)
                return;
            if (CurrentState != null)
            {
                CurrentState.OnExit();
            }
            CurrentState = state;
            CurrentState.OnEnter();
        }

        public void SetActive(bool isActive)
        {
            this.isActive = isActive;
        }
    }
}