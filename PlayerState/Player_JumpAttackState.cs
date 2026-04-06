using UnityEngine;

public class Player_JumpAttackState : PlayerState
{
    private bool TouchedGround;
    public Player_JumpAttackState(Player player, StateMachine stateMachine, string animboolName) : base(player, stateMachine, animboolName)
    {
    }
    public override void Enter()
    {
        base.Enter();
        TouchedGround = false;
        player.SetVelocity(player.jumpAttackvelocity.x * player.facingdir, player.jumpAttackvelocity.y);
    }
    public override void Update()
    {
        base.Update();

        if(player.groundDetected && TouchedGround==false)
        {
            TouchedGround=true;
            anim.SetTrigger("JumpAttackTrigger");//if player ground detected then only jumpattack end animation is performed
            player.SetVelocity(0,rb.linearVelocity.y);//to stop player moving while performing jump attack state
        }
        if(triggerCalled && player.groundDetected) 
            stateMachine.ChangeState(player.idolState);
    }
}
