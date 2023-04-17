using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FighterAction : MonoBehaviour
{
    private GameObject goblin;
    private GameObject angelica;

    [SerializeField] private GameObject meleePrefab;
    [SerializeField] private GameObject meleePrefab2;
    [SerializeField] private Sprite faceIcon;
    [SerializeField] private AudioSource attackSoundEffect;
    [SerializeField] private AudioSource attackSoundEffect2;
    private GameObject currentAttack;

    private void Awake()
    {
        angelica = GameObject.FindGameObjectWithTag("Hero");
        goblin = GameObject.FindGameObjectWithTag("Enemy");
    }


    public void SelectAttack(string btn)
    {
        GameObject victim = angelica;
        if (tag == "Hero")
        {
            victim = goblin;
        }
        if (btn.CompareTo("Attack") == 0)
        {
            meleePrefab.GetComponent<AttackScript>().Attack(victim);
            attackSoundEffect.Play();
        }
        else if (btn.CompareTo("Attack2") == 0)
        {
            meleePrefab2.GetComponent<AttackScript>().Attack(victim);
            attackSoundEffect2.Play();
        }
        else
        {
            Debug.Log("Slash3!");
        }
    }
}
