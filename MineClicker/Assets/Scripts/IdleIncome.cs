using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleIncome : MonoBehaviour
{
    public int money_current, current_idle_money_income;
    //int key = 1;    
    void Start()
    {
        money_current = PlayerPrefs.GetInt("Player_Current_Money");
        current_idle_money_income = PlayerPrefs.GetInt("Current_Idle_Incrementation");
        StartCoroutine(IdleMoneyFarm());
    }

    IEnumerator IdleMoneyFarm(float count_time = 3f)
    {        
        while (true)
        {
            yield return new WaitForSeconds(count_time);
            money_current += current_idle_money_income;
            PlayerPrefs.SetInt("Player_Current_Money", money_current);
            Debug.Log(money_current);

        }
        //money_current += current_idle_money_income;
        //Debug.Log("Recieved idle money");
        //PlayerPrefs.SetInt("Player_Current_Money", money_current);
        //Debug.Log("______________" + key);
        //key++;
        //yield return new WaitForSeconds(2f);
    }

}
