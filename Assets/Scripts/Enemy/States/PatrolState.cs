//Kanaan Gute 12/05/24
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : BaseState
{
    //keep track of the waypoint in the patrol path
    public int waypointIndex;
    
    public override void Enter()
    {
        // Initialization logic for entering the patrol state can go here
    }

    // Called on every frame while the state is active
    public override void Perform()
    {
        PatrolCycle();
        if (enemy.CanSeePlayer())
        {
            stateMachine.ChangeState(new AttackState());
        }
    }
    // Called when the state is exited
    public override void Exit()
    {

    }

    public void PatrolCycle()
    {
        // Check if the enemy has reached its current waypoint
        if (enemy.Agent.remainingDistance < 0.2f)
        {

            // Move to the next waypoint or loop back to the first waypoint if at the end of the path
            if (waypointIndex < enemy.path.waypoints.Count - 1)
                waypointIndex++;
            else
                waypointIndex = 0;
            // Set the location of the enemy to the next waypoint
            enemy.Agent.SetDestination(enemy.path.waypoints[waypointIndex].position);
                
            
        }
    }
}

