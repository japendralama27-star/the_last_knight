using UnityEngine;


public class Enemy : Entity
{

    public Enemy_IdolState idleState;
    public Enemy_moveState moveState;
    public Enemy_AttakState attakState;
    public Enemy_BattleState battleState;
    public Enemy_DeathState deathState;

    [Header("Battle Details")]
    public float BattleMoveSpeed = 3f;
    public float attackDistance = 2f;
    public float battleTimeDuration = 0.1f;
    public float minRetreatDistance = 1f;//minimum distance to player to start retreating
    public Vector2 retreatVelocity;//x and y velocity when retreating

    [Header("Movement Details")]
    public float idleTime = 2f;
    public float moveSpeed = 1.4f;
    [Range(0, 2)]
    public float moveAnimSpeedMultipler = 1f;

    [Header("Player Detection")]
    [SerializeField] public LayerMask WhatIsPlayer;
    [SerializeField] public Transform playerCheck;
    [SerializeField] public float playerChaeckDistance = 10f;
    public Transform player { get; private set; }

    public override void EntityDeath()
    {
        base.EntityDeath();
        stateMachine.ChangeState(deathState);
    }
    private void handlePlayerDeath()
    {
        stateMachine.ChangeState(idleState);
    }
    public void TryEnterBattleState(Transform player)
    {
        if (stateMachine.CurrentState == battleState || stateMachine.CurrentState==attakState)//if already in battle state or attack state then
            return;

        this.player = player;
        stateMachine.ChangeState(battleState);
    }
    public Transform GetPlayerReference()
    {
        if(player==null)
            player = PlayerDetection().transform;
        return player;
    }

    public RaycastHit2D PlayerDetection()
    {
        RaycastHit2D hit=
            Physics2D.Raycast(playerCheck.position, Vector2.right * facingdir, playerChaeckDistance, WhatIsPlayer | WhatIsGround);

        if(hit.collider==null || hit.collider.gameObject.layer!=LayerMask.NameToLayer("player"))//if the raycast did not hit anything or the thing it hit is not the player then it returns default
        {
            return default;//it return default value of RaycastHit2D which is null
        }
        return hit;
         /*Raycast = invisible line you shoot
          RaycastHit2D = report of what that line hitSo your method: 
          Shoots a ray using Physics2D.Raycast(...)
          Returns the hit information
          Simple analogy
          You throw a stone 
          RaycastHit2D = what the stone touched(wall, enemy, ground, or nothing)*/
    }

    protected override void OnDrawGizmos()
    {
        base.OnDrawGizmos();

        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(playerCheck.position, new Vector3(playerCheck.position.x+(playerChaeckDistance * facingdir),  playerCheck.position.y));

        Gizmos.color = Color.blue;
        Gizmos.DrawLine(playerCheck.position, new Vector3(playerCheck.position.x + (attackDistance* facingdir), playerCheck.position.y));

        Gizmos.color = Color.green;
        Gizmos.DrawLine(playerCheck.position, new Vector3(playerCheck.position.x + (minRetreatDistance * facingdir), playerCheck.position.y));
    }
    private void OnEnable()
    {
        Player.OnPlayerDeath += handlePlayerDeath;
    }
    private void OnDisable()
    {
        Player.OnPlayerDeath-= handlePlayerDeath;
    }
}
