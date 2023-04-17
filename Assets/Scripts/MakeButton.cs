using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MakeButton : MonoBehaviour
{
    [SerializeField]
    private bool physical;

    private GameObject Angelica;
    void Start()
    {
        string temp = gameObject.name;
        gameObject.GetComponent<Button>().onClick.AddListener(() => AttachCallback(temp));
        Angelica = GameObject.FindGameObjectWithTag("Hero");
    }

    private void AttachCallback(string btn)
    {
        if (btn.CompareTo("SlashBtn") == 0)
        {
            Angelica.GetComponent<FighterAction>().SelectAttack("Attack");
        }
        else if (btn.CompareTo("SlashBtn2") == 0)
        {
            Angelica.GetComponent<FighterAction>().SelectAttack("Attack2");
        }
        else
        {
            Angelica.GetComponent<FighterAction>().SelectAttack("run");
        }
    }
}