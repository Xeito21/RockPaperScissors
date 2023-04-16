using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FighterAction : MonoBehaviour
{
    private GameObject enemy;
    private GameObject hero;

    [SerializeField] private GameObject meleePrefab;
    [SerializeField] private GameObject meleePrefab2;
    [SerializeField] private Sprite faceIcon;
    private GameObject currentAttack;
    private GameObject meleeAttack;
    private GameObject meleeAttack2;


    public void SelectAttack(string btn)
    {
        GameObject victim = hero;
        if (tag == "Hero")
        {
            victim = enemy;
        }
        if (btn.CompareTo("Slash") == 0)
        {
            meleeAttack.GetComponent<AttackScript>().Attack(victim);
        }
        else if (btn.CompareTo("Slash2") == 0)
        {
            meleeAttack2.GetComponent<AttackScript>().Attack(victim);
        }
        else
        {
            Debug.Log("Slash3!");
        }
    }
}
