using UnityEngine;

public class Player_IdolState : Player_GroundState
{
    public Player_IdolState(Player player, StateMachine stateMachine, string animboolName) : base(player, stateMachine, animboolName)
    {
    }
    public override void Enter()
    {
        base.Enter();
        player.SetVelocity(0, rb.linearVelocity.y);
    }
    public override void Update()
    {
        base.Update();
        if (player.MoveInput.x == player.facingdir && player.wallDetected)
            return;

        if (player.MoveInput.x != 0)
        {
            audiomanager.PlaySFX(audiomanager.walk);
            stateMachine.ChangeState(player.moveState);
        }

        if (input.Player.roll.WasPressedThisFrame() && player.wallDetected == false)
        {
            audiomanager.PlaySFX(audiomanager.roll);
            stateMachine.ChangeState(player.rollState);
        }
    }
}
