using UnityEngine;

public class Player_WallJumpState : PlayerState
{
    public Player_WallJumpState(Player player, StateMachine stateMachine, string animboolName) : base(player, stateMachine, animboolName)
    {
    }
    public override void Enter()
    {
        base.Enter();

        player.SetVelocity(player.walljumpforce.x * -player.facingdir, player.walljumpforce.y);
       
    }
    public override void Update()
    {
        base.Update();
        if (rb.linearVelocity.y < 0)
        {
            audiomanager.PlaySFX(audiomanager.fall);
            stateMachine.ChangeState(player.fallState);
        }

        if (player.wallDetected)
        {
            audiomanager.PlaySFX(audiomanager.wallslide);
            stateMachine.ChangeState(player.wallSlideState);
        }
    }
    public override void Exit()
    {
        base.Exit();
        player.SetVelocity(0,0);
    }
}
