using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour
{
    public GameObject owner;
    [SerializeField] bool slashAttack2;
    [SerializeField] private float minAttackMultiplier;
    [SerializeField] private float maxAttackMultiplier;
    [SerializeField] private float minDefenseMultiplier;
    [SerializeField] private float maxDefenseMultiplier;

    //private FighterStats attackerStats;
    //private FighterStats targetStats;
    private float damage = 0.0f;
    private float xSlashNewScale;
    private Vector2 slashScale;

}
