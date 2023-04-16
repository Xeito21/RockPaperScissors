using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MakeButton : MonoBehaviour
{
    [SerializeField] private bool physical;
    private GameObject hero;
    // Start is called before the first frame update
    void Start()
    {
        string temp = gameObject.name;
        gameObject.GetComponent<Button>().onClick.AddListener(() => AttachCallback(temp));
        hero = GameObject.FindGameObjectWithTag("Hero");
    }

private void AttachCallback(string btn)
    {
        if (btn.CompareTo("SlashBtn") == 0)
        {
            hero.GetComponent<FighterAction>().SelectAttack("Slash");
        }else if (btn.CompareTo("SlashBtn2") == 0)
        {
            hero.GetComponent<FighterAction>().SelectAttack("Slash2");
        }
        else
        {
            hero.GetComponent<FighterAction>().SelectAttack("Slash3");
        }
    }
}
