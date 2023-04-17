using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour
{
    public GameObject owner;
    [SerializeField] string animationName;
    [SerializeField] bool slashAttack2;
    [SerializeField] float magicCost;
    [SerializeField] private float minAttackMultiplier;
    [SerializeField] private float maxAttackMultiplier;
    [SerializeField] private float minDefenseMultiplier;
    [SerializeField] private float maxDefenseMultiplier;

    private FighterStats attackerStats;
    private FighterStats targetStats;
    private float damage = 0.0f;



    public void Attack(GameObject victim)
    {

        attackerStats = owner.GetComponent<FighterStats>();
        targetStats = victim.GetComponent<FighterStats>();

        if (attackerStats.mana >= magicCost)
        {
            float multiplier = Random.Range(minAttackMultiplier, maxAttackMultiplier);
            if (magicCost > 0)
            {
                attackerStats.updateManaFill(magicCost);
            }

            damage = multiplier * attackerStats.melee;
            if (slashAttack2)
            {
                damage = multiplier * attackerStats.manaRange;
            }

            float defenseMultiplier = Random.Range(minDefenseMultiplier, maxDefenseMultiplier);
            damage = Mathf.Max(0, damage - (defenseMultiplier * targetStats.defense));
            owner.GetComponent<Animator>().Play(animationName);
            targetStats.ReceiveDamage(Mathf.CeilToInt(damage));
            attackerStats.updateManaFill(magicCost);
        }
        else
        {
            Invoke("SkipTurnContinueGame", 2);
        }
    }
    void SkipTurnContinueGame()
    {
        GameObject.Find("GameControllerObject").GetComponent<GameController>().NextTurn();
    }
}
