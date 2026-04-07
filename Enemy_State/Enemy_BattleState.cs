using UnityEngine;

public class Enemy_BattleState : EnemyState
{
    private Transform player;
    private float lastTimeInBattle;
    public Enemy_BattleState(Enemy enemy, StateMachine stateMachine, string animboolName) : base(enemy, stateMachine, animboolName)
    {
    }
    public override void Enter()
    {
        base.Enter();

        UpdateBattleTime();//update last time in battle to current time

        if (player==null)
            player = enemy.GetPlayerReference();//get player reference from enemy script


        if (shouldRetreat())
        {
          rb.linearVelocity=new Vector2(enemy.retreatVelocity.x * -directionToPlayer(), enemy.retreatVelocity.y);//if should retreat then set velocity to retreat velocity in opposite direction of player
            enemy.HandleFlip(directionToPlayer());//flip enemy to face away from player
        }

    }

    public override void Update()
    {
        base.Update();
        if (enemy.PlayerDetection() == true)
            UpdateBattleTime();//if player is detected then update last time in battle to current time
        if(battleTimeisOver())
            stateMachine.ChangeState(enemy.idleState);//if battle time is over then change to idol state

        if (WithinAttackRange())
        {
            audioManager.PlaySFX(audioManager.Attack);
            stateMachine.ChangeState(enemy.attakState);//if within attack range then change to attack state

        }
        else
            enemy.SetVelocity(enemy.BattleMoveSpeed * directionToPlayer(), rb.linearVelocity.y);//set velocity towards player
    }
    private float UpdateBattleTime() => lastTimeInBattle = Time.time;//last  time in battle 
    private bool battleTimeisOver()=>Time.time >= lastTimeInBattle + enemy.battleTimeDuration;
    //{
    //    return Time.time >= lastTimeInBattle + enemy.battleTimeDuration;//if current time is greater than last time in battle + battle cooldown then return true else false
    //}
    private bool WithinAttackRange()
    {
        return DistanceToPlayer() < enemy.attackDistance;//if distance to player is less than or equal to attack distance then return true else false
    }
    private bool shouldRetreat()
    {
        return DistanceToPlayer() < enemy.minRetreatDistance;//if distance to player is less than minimum retreat distance then return true else false
    }
    private float DistanceToPlayer()
    {
      if(player==null)
            return float.MaxValue;//if player is null then return a very large number that is player is very far away

      return Mathf.Abs(player.position.x - enemy.transform.position.x);//return the absolute distance between player and enemy on x axis//allways give +ve value//even if your result is negative
    }
    private int directionToPlayer()
    {
        if (player == null)
            return 0;//if player is null then return 0 meaning no direction
        return player.position.x > enemy.transform.position.x? 1 : -1;//if player is to the right of enemy return 1 else -1
    }
}
