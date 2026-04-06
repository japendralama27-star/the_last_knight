using UnityEngine;

public class Player_AiredState : PlayerState//this is a parent class for jump and fall states
{
    public Player_AiredState(Player player, StateMachine stateMachine, string animboolName) : base(player, stateMachine, animboolName)
    {
    }
    public override void Update()
    {
        base.Update();

        if(player.MoveInput.x!=0)
            player.SetVelocity(player.MoveInput.x*(player.movespeed*player.inAirMoveMultipler),rb.linearVelocity.y);//playermultipler slows the movement of player

        if (input.Player.Attack.WasPressedThisFrame())
        {
            audiomanager.PlaySFX(audiomanager.Attack);
            stateMachine.ChangeState(player.JumpAttackState);
        }
    }
}
