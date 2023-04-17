using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Transactions;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;
using TMPro;

public class GameController : MonoBehaviour
{
    private List<FighterStats> fighterStats;
    [SerializeField] private GameObject battleMenu;
    public TMP_Text battleText;

    private void Awake()
    {
        battleMenu = GameObject.Find("BattleMenu");
    }


    private void Start()
    {
        fighterStats = new List<FighterStats>();
        GameObject angelica = GameObject.FindGameObjectWithTag("Hero");
        FighterStats currentFighterStats = angelica.GetComponent<FighterStats>();
        currentFighterStats.CalculateNextTurn(0);
        fighterStats.Add(currentFighterStats);

        GameObject goblin = GameObject.FindGameObjectWithTag("Enemy");
        FighterStats currentEnemyStats = goblin.GetComponent<FighterStats>();
        currentEnemyStats.CalculateNextTurn(0);
        fighterStats.Add(currentEnemyStats);

        fighterStats.Sort();


        NextTurn();
    }

    public void NextTurn()
    {
        battleText.gameObject.SetActive(false);
        FighterStats currentFighterStats = fighterStats[0];
        fighterStats.Remove(currentFighterStats);
        if (!currentFighterStats.GetDead())
        {
            GameObject currentUnit = currentFighterStats.gameObject;
            currentFighterStats.CalculateNextTurn(currentFighterStats.nextActTurn);
            fighterStats.Add(currentFighterStats);
            fighterStats.Sort();
            if(currentUnit.tag == "Hero")
            {
                battleMenu.SetActive(true);
            }else
            {
                battleMenu.SetActive(false);
                string attackType = Random.Range(0, 2) == 1 ? "Attack" : "Attack2";
                currentUnit.GetComponent<FighterAction>().SelectAttack(attackType);
            }
        }
        else
        {
            NextTurn();
        }
    }
}
