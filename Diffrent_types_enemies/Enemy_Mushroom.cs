using UnityEngine;

public class Enemy_Mushroom : Enemy
{
    protected override void Awake()
    {
        base.Awake();
        idleState = new Enemy_IdolState(this, stateMachine, "idol");
        moveState = new Enemy_moveState(this, stateMachine, "move");
        attakState = new Enemy_AttakState(this, stateMachine, "attack");
        battleState = new Enemy_BattleState(this, stateMachine, "battle");
        deathState = new Enemy_DeathState(this, stateMachine, "idol");
    }
    protected override void Start()
    {
        base.Start();
        stateMachine.Initialize(idleState);
    }
}
