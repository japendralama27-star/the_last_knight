using UnityEngine;

public class Player_MoveState : Player_GroundState
{
    public Player_MoveState(Player player, StateMachine stateMachine, string animboolName) : base(player, stateMachine, animboolName)
    {
    }
   

    public override void Update()
    {
        base.Update();
        if (player.MoveInput.x == 0 ||player.wallDetected)
            stateMachine.ChangeState(player.idolState);

        if(input.Player.roll.WasPressedThisFrame() && player.wallDetected==false)
        {
            audiomanager.PlaySFX(audiomanager.roll);
            stateMachine.ChangeState(player.rollState);
        }

        player.SetVelocity(player.MoveInput.x * player.movespeed, rb.linearVelocity.y);
    }
}
