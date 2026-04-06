using UnityEngine;

public class Player_DashState : PlayerState
{
    private float OrginalGravityScale;
    private int dashdir;
    public Player_DashState(Player player, StateMachine stateMachine, string animboolName) : base(player, stateMachine, animboolName)
    {
    }
    public override void Enter()
    {
        base.Enter();
        stateTimer=player.dashDuration;
        dashdir = player.facingdir;
        OrginalGravityScale=rb.gravityScale;
        rb.gravityScale = 0;
    }
    public override void Update()
    {
        base.Update();
        CancleDashState();
        player.SetVelocity(player.dashSpeed * dashdir, 0);

        if (stateTimer < 0)
            if (player.groundDetected)
                stateMachine.ChangeState(player.idolState);
            else
                stateMachine.ChangeState(player.fallState);
    }
    public override void Exit()
    {
        base.Exit();
        player.SetVelocity(0, 0);
        rb.gravityScale = OrginalGravityScale;
    }
    private void CancleDashState()
    {
        if (player.wallDetected)
        {
            if (player.groundDetected)
                stateMachine.ChangeState(player.idolState);

            else
            {
                audiomanager.PlaySFX(audiomanager.wallslide);
                stateMachine.ChangeState(player.wallSlideState);

            }
        }
    }
}
