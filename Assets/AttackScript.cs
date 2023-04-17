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
    private float xManaNewScale;
    private Vector2 manaScale;


    private void Start()
    {
        manaScale = GameObject.Find("HeroManaFill").GetComponent<RectTransform>().localScale;
    }


    public void Attack(GameObject victim)
    {
        attackerStats = owner.GetComponent<FighterStats>();
        targetStats = victim.GetComponent<FighterStats>();

        if(attackerStats.mana >= magicCost)
        {
            float multiplier = Random.Range(minAttackMultiplier, maxAttackMultiplier);
            attackerStats.updateManaFill(magicCost);
            damage = multiplier * attackerStats.attack;
            if (slashAttack2)
            {
                damage = multiplier * attackerStats.mana;
                attackerStats.mana = attackerStats.mana - magicCost;
            }

            float defenseMultiplier = Random.Range(minDefenseMultiplier, maxDefenseMultiplier);
            damage = Mathf.Max(0, damage - (defenseMultiplier * targetStats.defense));
            owner.GetComponent<Animator>().Play(animationName);
            targetStats.ReceiveDamage(damage);
        }
    }
}
