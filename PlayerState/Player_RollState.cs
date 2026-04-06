using UnityEngine;

public class Player_RollState : Player_GroundState
{
    private float RollTimer;
    private float rollDuration = 0.9f;
    public Player_RollState(Player player, StateMachine stateMachine, string animboolName) : base(player, stateMachine, animboolName)
    {
    }
    public override void Enter()
    {
        base.Enter();
        RollTimer = rollDuration;
    }
   
    public override void Update()
    {
        base.Update();
        RollTimer -= Time.deltaTime;

        player.SetVelocity(player.facingdir * player.rollSpeed, rb.linearVelocity.y);

        if (RollTimer<=0 )
        {
            stateMachine.ChangeState(player.idolState);
        }
        if (player.wallDetected)
            stateMachine.ChangeState(player.idolState);
    }
}
