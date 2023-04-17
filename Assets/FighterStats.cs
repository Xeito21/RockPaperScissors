using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FighterStats : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] GameObject healthFill;
    [SerializeField] GameObject manaFill;

    [Header("Stats")]
    public float health;
    public float mana;
    public float attack;
    public float defense;
    public float range;
    public float speed;
    public float experience;

    private float startHealth;
    private float startmana;
    [HideInInspector]
    public int nextActTurn;
    private bool dead = false;

    //size health dan mana bar
    private Transform healthTransform;
    private Transform manaTransform;
    private Vector2 healthScale;
    private Vector2 manaScale;

    private float xNewHealthScale;
    private float xNewManaScale;


    private void Start()
    {
        healthTransform = healthFill.GetComponent<RectTransform>();
        healthScale = healthFill.transform.localScale;

        manaTransform = manaFill.GetComponent<RectTransform>();
        manaScale = manaFill.transform.localScale;

        startHealth = health;
        startmana = mana;
    }

    public void ReceiveDamage(float damage)
    {
        health = health - damage;
        animator.Play("Hurt");

        //damage
        if(health <= 0)
        {
            dead = true;
            gameObject.tag = "Dead";
            Destroy(healthFill);
            Destroy(gameObject);
        }
        else
        {
            xNewHealthScale = healthScale.x * (health / startHealth);
            healthFill.transform.localScale = new Vector2(xNewHealthScale, healthScale.y);
        }
    }

    public void updateManaFill(float cost)
    {
        mana = mana - cost;
        xNewManaScale = manaScale.x * (mana / startmana);
        manaFill.transform.localScale = new Vector2(xNewManaScale, manaScale.y);
    }
}
