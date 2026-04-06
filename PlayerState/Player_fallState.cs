using UnityEngine;

public class Player_fallState : Player_AiredState
{
    public Player_fallState(Player player, StateMachine stateMachine, string animboolName) : base(player, stateMachine, animboolName)
    {
    }
    public override void Update()
    {
        base.Update();

        if (player.groundDetected == true)
            stateMachine.ChangeState(player.idolState);
        if(player.wallDetected==true)
        {
            audiomanager.PlaySFX(audiomanager.wallslide);
            stateMachine.ChangeState(player.wallSlideState);
        }
    }
}
