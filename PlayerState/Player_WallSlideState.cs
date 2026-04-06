using Unity.VisualScripting;
using UnityEngine;

public class Player_WallSlideState : PlayerState
{
    public Player_WallSlideState(Player player, StateMachine stateMachine, string animboolName) : base(player, stateMachine, animboolName)
    {
    }
  
    public override void Update()
    {
        base.Update();
        HandleWallSlide();
        
       
        if(input.Player.Jump.WasPressedThisFrame())
        {
            audiomanager.PlaySFX(audiomanager.jump);
            stateMachine.ChangeState(player.wallJumpState);
        }

        if (player.wallDetected == false)
        {
            audiomanager.PlaySFX(audiomanager.fall);
            stateMachine.ChangeState(player.fallState);
        }
        if (player.groundDetected)
        {
            stateMachine.ChangeState(player.idolState);
            player.flip();
        }
    }
    private void HandleWallSlide()
    {
            player.SetVelocity(player.MoveInput.x,rb.linearVelocity.y*player.wallSlideSlowMultipler);
    }
}
