using UnityEngine;

public class Enemy_Healths : Entity_Health
{
    private Enemy enemy;
    private Transform lastDamageDealer;

    protected override void Awake()
    {
        base.Awake();
        enemy = GetComponent<Enemy>();
    }

    public override void TakeDamage(float damage, Transform damageDealer)
    {
        if (isdead)
            return;

        lastDamageDealer = damageDealer; // remember who hit last
        base.TakeDamage(damage, damageDealer);

        if (isdead)
            HandleDeathReward();
        else if (damageDealer.CompareTag("Player"))
            enemy.TryEnterBattleState(damageDealer);
    }

    private void HandleDeathReward()
    {
        if (lastDamageDealer == null)
            return;

        Player_Healths playerHealth =
            lastDamageDealer.GetComponent<Player_Healths>();

        if (playerHealth != null)
        {
            playerHealth.HealToFull();
        }
    }
}
