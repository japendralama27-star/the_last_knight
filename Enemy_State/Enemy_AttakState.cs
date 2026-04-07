using UnityEngine;


public class Enemy_AttakState : EnemyState
{
    public Enemy_AttakState(Enemy enemy, StateMachine stateMachine, string animboolName) : base(enemy, stateMachine, animboolName)
    {
    }
    public override void Update()
    {
        base.Update();

        if (triggerCalled)
        {
            stateMachine.ChangeState(enemy.battleState);
        }
    }
}
