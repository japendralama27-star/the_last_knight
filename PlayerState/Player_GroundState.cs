using UnityEngine;

public class Player_GroundState : PlayerState
{
    public Player_GroundState(Player player, StateMachine stateMachine, string animboolName) : base(player, stateMachine, animboolName)
    {
    }
    public override void Update()
    {
        base.Update();

        if(rb.linearVelocity.y<0 && player.groundDetected==false)
        {
            audiomanager.PlaySFX(audiomanager.fall);
            stateMachine.ChangeState(player.fallState);
        }
        
        if(input.Player.Jump.WasPressedThisFrame())
        {
            audiomanager.PlaySFX(audiomanager.jump);
            stateMachine.ChangeState(player.jumpState);
        }

        if (input.Player.Attack.WasPerformedThisFrame())
        {
            audiomanager.PlaySFX(audiomanager.Attack);
        stateMachine.ChangeState(player.AttackState);
        }
    }
}
