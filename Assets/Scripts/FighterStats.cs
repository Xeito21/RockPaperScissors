using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;


public class FighterStats : MonoBehaviour, IComparable
{
    [SerializeField] private Animator animator;
    [SerializeField] GameObject healthFill;
    [SerializeField] GameObject manaFill;


    [Header("Stats")]
    public float health;
    public float mana;
    public float melee;
    public float defense;
    public float manaRange;
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
    private GameObject GameControllerObj;


    private void Awake()
    {
        healthTransform = healthFill.GetComponent<RectTransform>();
        healthScale = healthFill.transform.localScale;

        manaTransform = manaFill.GetComponent<RectTransform>();
        manaScale = manaFill.transform.localScale;

        startHealth = health;
        startmana = mana;

        GameControllerObj = GameObject.Find("GameControllerObject");
    }

    public void ReceiveDamage(float damage)
    {
        Debug.Log("Damage rece");

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
        else if(damage > 0 )
        {
            xNewHealthScale = healthScale.x * (health / startHealth);
            healthFill.transform.localScale = new Vector2(xNewHealthScale, healthScale.y);
        }
        if(damage > 0)
        {
            GameControllerObj.GetComponent<GameController>().battleText.gameObject.SetActive(true);
            GameControllerObj.GetComponent<GameController>().battleText.text = damage.ToString();
        }

        Invoke("ContinueGame", 2);
    }

    public void updateManaFill(float cost)
    {
        if(cost > 0)
        {
            mana = mana - cost;
            xNewManaScale = manaScale.x * (mana / startmana);
            manaFill.transform.localScale = new Vector2(xNewManaScale, manaScale.y);
        }

    }
    void ContinueGame()
    {
        GameObject.Find("GameControllerObject").GetComponent<GameController>().NextTurn();
    }
    public int CompareTo(object otherStats)
    {
        int nex = nextActTurn.CompareTo(((FighterStats)otherStats).nextActTurn);
        return nex;
    }

    public void CalculateNextTurn(int currentTurn)
    {
        nextActTurn = currentTurn + Mathf.CeilToInt(100f / speed);
    }

    public bool GetDead()
    {
        return dead;
    }

}
