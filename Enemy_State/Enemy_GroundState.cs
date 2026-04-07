using UnityEngine;

public class Enemy_GroundState : EnemyState
{
    public Enemy_GroundState(Enemy enemy, StateMachine stateMachine, string animboolName) : base(enemy, stateMachine, animboolName)
    {
    }
    public override void Update()
    {
        base.Update();
        if (enemy.PlayerDetection() == true)
            stateMachine.ChangeState(enemy.battleState);
    }
}
