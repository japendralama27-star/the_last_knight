using UnityEngine;

public class Enemy_IdolState : Enemy_GroundState
{
    public Enemy_IdolState(Enemy enemy, StateMachine stateMachine, string animboolName) : base(enemy, stateMachine, animboolName)
    {
    }
    public override void Enter()
    {
        base.Enter();
        stateTimer = enemy.idleTime;
    }
    public override void Update()
    {
        base.Update();
        if (stateTimer < 0)
        {
            audioManager.PlaySFX(audioManager.walk);
            stateMachine.ChangeState(enemy.moveState);
        }
    }
}
