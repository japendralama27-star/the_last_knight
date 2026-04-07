using UnityEngine;

public class Enemy_DeathState : EnemyState
{
    private Collider2D col;
    public Enemy_DeathState(Enemy enemy, StateMachine stateMachine, string animboolName) : base(enemy, stateMachine, animboolName)
    {
        col=enemy.GetComponent<Collider2D>();
    }
    public override void Enter()
    {
        anim.enabled = false; //disable animation on death
        col.enabled = false;//disable collider on death

        rb.gravityScale = 12;
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, 15);

        stateMachine.SwitchOffStateMachine();
       // enemy.GetComponent<Collider2D>().enabled = false;//disable collider on death
    }
}
