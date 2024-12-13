//Kanaan Gute 12/08/24
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public BaseState activeState;

    // Initializes the state machine by setting the default starting state
    public void Initialise()
    {
        
        ChangeState(new PatrolState());
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (activeState != null)
        {
            activeState.Perform();
        }
    }

    // Changes the current state to a new state
    public void ChangeState(BaseState newState)
    {
        // If the new state is valid, set up its references and enter it
        if (activeState != null)
        {
            activeState.Exit();
        }
        activeState = newState;

        if(activeState != null )
        {
            activeState.stateMachine = this;
            activeState.enemy = GetComponent<Enemy>();
            activeState.Enter();
        }
    }
}
