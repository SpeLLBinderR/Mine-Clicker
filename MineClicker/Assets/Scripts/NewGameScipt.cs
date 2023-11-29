using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewGameScipt : MonoBehaviour
{
    [SerializeField] int money_current, money_total, new_game_test_shop, new_game_test_achivements,
        current_increment, current_idle_money_income;
    void Start()
    {
        Debug.Log("_______All current money was ereased______");
        money_current = 0;
        money_total = money_current;
        new_game_test_shop = 1;
        new_game_test_achivements = 1;
        current_increment = 1;
        current_idle_money_income = 0;
        PlayerPrefs.SetInt("Player_Current_Money", money_current);
        PlayerPrefs.SetInt("Player_Total_Money", money_total);
        PlayerPrefs.SetInt("New_Game_Test_Shop", new_game_test_shop);
        PlayerPrefs.SetInt("New_Game_Test_Achivements", new_game_test_achivements);
        PlayerPrefs.SetInt("Current_Incrementation_Amount", current_increment);
        PlayerPrefs.SetInt("Current_Idle_Incrementation", current_idle_money_income);
    }
}
