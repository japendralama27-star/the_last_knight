using UnityEngine;

public class Enemy_moveState : Enemy_GroundState
{
    public Enemy_moveState(Enemy enemy, StateMachine stateMachine, string animboolName) : base(enemy, stateMachine, animboolName)
    {
    }
    public override void Enter()
    {
        base.Enter();
        if (enemy.groundDetected == false || enemy.wallDetected==true)
            enemy.flip();
    }
    public override void Update()
    {
        base.Update();
        enemy.SetVelocity(enemy.moveSpeed*enemy.facingdir, rb.linearVelocity.y);

        if (enemy.groundDetected == false || enemy.wallDetected==true)
            stateMachine.ChangeState(enemy.idleState);
    }
}
