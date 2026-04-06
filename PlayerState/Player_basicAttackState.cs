using UnityEngine;

public class Player_basicAttackState : PlayerState
{
    private float attackVelocityTimer;
    private float lastTimeAttack;

    private int comboIndex = 1;
    private int comboLimit = 2;
    private const int FirstComboIndex = 1;//constant allways should start from capital alphabet

    private float LastTimeAttack;
    public Player_basicAttackState(Player player, StateMachine stateMachine, string animboolName) : base(player, stateMachine, animboolName)
    {
    }
    public override void Enter()
    {
        base.Enter();
        ResetComboIndexIfNeeded();
       
        anim.SetInteger("AttackIndex",comboIndex);
        ApplyAttackVelocity();
    }
    public override void Update()
    {
        base.Update();
        HandleAttackVelocity();

        if(triggerCalled)
            stateMachine.ChangeState(player.idolState);
    }
    public override void Exit()
    {
        base.Exit();
        comboIndex++;
        lastTimeAttack = Time.time;
    }
    private void HandleAttackVelocity()
    {
        attackVelocityTimer -= Time.deltaTime;

        if(attackVelocityTimer < 0)
            player.SetVelocity(0, rb.linearVelocity.y);

    }
    private void ApplyAttackVelocity()//when player is in attak state it will move little bit forward and upward direction
    {
        Vector2 attackvelocity = player.attackVelocity[comboIndex-1];
        attackVelocityTimer = player.attackVelocityDuration;
       player.SetVelocity(attackvelocity.x * player.facingdir, attackvelocity.y);
    }
    private void ResetComboIndexIfNeeded()
    {
        if (Time.time > lastTimeAttack + player.comboResetTime)
            comboIndex = FirstComboIndex;
        if (comboIndex>comboLimit)
            comboIndex = FirstComboIndex;
    }
}

