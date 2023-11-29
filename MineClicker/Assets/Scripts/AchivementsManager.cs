using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AchivementsManager : MonoBehaviour
{
    public int money_current;
    public int money_total;
    public bool tryNewGame;

    private int[] achivements_rewards = new int[10] { 0, 10, 100, 500, 1000, 5000, 10000, 500, 1000, 200000};
   
    public Text money_txt;

    [SerializeField] Button Ach1, Ach2, Ach3, Ach4, Ach5, Ach6, Ach7, Ach8;
    [SerializeField] bool checkAch1, checkAch2, checkAch3, checkAch4, checkAch5, checkAch6,
                        checkAch7, checkAch8;


    public void Start()
    {
        tryNewGame = PlayerPrefs.GetInt("New_Game_Test_Achivements") == 1 ? true : false;

        if (tryNewGame)
        {           
            int zero = 0;
            PlayerPrefs.SetInt("Check_First_1", zero);
            PlayerPrefs.SetInt("Check_First_2", zero);
            PlayerPrefs.SetInt("Check_First_3", zero);
            PlayerPrefs.SetInt("Check_First_4", zero);
            PlayerPrefs.SetInt("Check_First_5", zero);
            PlayerPrefs.SetInt("Check_First_6", zero);

            PlayerPrefs.SetInt("Check_First_7", zero);
            PlayerPrefs.SetInt("Check_First_8", zero);

            // delete later
            //int check1 = PlayerPrefs.GetInt("Check_First_1");
            //int check2 = PlayerPrefs.GetInt("Check_First_2");
            //int check3 = PlayerPrefs.GetInt("Check_First_3");
            //int check4 = PlayerPrefs.GetInt("Check_First_4");
            //int check5 = PlayerPrefs.GetInt("Check_First_5");
            //int check6 = PlayerPrefs.GetInt("Check_First_6");

            //int check7 = PlayerPrefs.GetInt("Check_First_7");
            //int check8 = PlayerPrefs.GetInt("Check_First_8");

            //Debug.Log("All check first time __ " + check1 + check2 + check3 + check4 + check5 + check6 +
            //    check7 + check8);

            // delete till here

            PlayerPrefs.SetInt("New_Game_Test_Achivements", 0);
        }

        money_current = PlayerPrefs.GetInt("Player_Current_Money");
        money_total = PlayerPrefs.GetInt("Player_Total_Money");

        testAllAchivements();
    }

    public void testAllAchivements()
    {
        // delete
        //int check1 = PlayerPrefs.GetInt("Check_First_1");
        //int check2 = PlayerPrefs.GetInt("Check_First_2");
        //int check3 = PlayerPrefs.GetInt("Check_First_3");
        //int check4 = PlayerPrefs.GetInt("Check_First_4");
        //int check5 = PlayerPrefs.GetInt("Check_First_5");
        //int check6 = PlayerPrefs.GetInt("Check_First_6");

        //int check7 = PlayerPrefs.GetInt("Check_First_7");
        //int check8 = PlayerPrefs.GetInt("Check_First_8");

        //Debug.Log("All check __ " + check1 + check2 + check3 + check4 + check5 + check6 + check7 + check8);

        // delete till here


        checkAch1 = PlayerPrefs.GetInt("Check_First_1") == 1 ? true : false;
        checkAch2 = PlayerPrefs.GetInt("Check_First_2") == 1 ? true : false;
        checkAch3 = PlayerPrefs.GetInt("Check_First_3") == 1 ? true : false;
        checkAch4 = PlayerPrefs.GetInt("Check_First_4") == 1 ? true : false;
        checkAch5 = PlayerPrefs.GetInt("Check_First_5") == 1 ? true : false;
        checkAch6 = PlayerPrefs.GetInt("Check_First_6") == 1 ? true : false;

        checkAch7 = PlayerPrefs.GetInt("Check_First_7") == 1 ? true : false;
        checkAch8 = PlayerPrefs.GetInt("Check_First_8") == 1 ? true : false;

        Debug.Log("All acheckach __ " + checkAch1 +""+ checkAch2 + "" + checkAch3 + "" 
            + checkAch4 + "" + checkAch5 + "" + checkAch6 + "" + checkAch7 + "" + checkAch8) ;


        AchivementTest(Ach1, 1, checkAch1);
        AchivementTest(Ach2, 2, checkAch2);
        AchivementTest(Ach3, 3, checkAch3);
        AchivementTest(Ach4, 4, checkAch4);
        AchivementTest(Ach5, 5, checkAch5);
        AchivementTest(Ach6, 6, checkAch6);

        AchivementTest(Ach7, 7, checkAch7);
        AchivementTest(Ach8, 8, checkAch8);

    }

    private void AchivementTest(Button Achivement, int num, bool check)
    {
        if (num <= 6) 
        {
            if (money_current >= achivements_rewards[num] && !check)
            {
                Achivement.interactable = true;
            }
            else { Achivement.interactable = false; }
        }
        else
        {
            ShopManager temp_shop_manager = new ShopManager();

            switch (num)
            {
                // Achivement 7  -  upgrade 5 times
                case 7:
                    int sum_all_current_ugrade_lvl = temp_shop_manager.Returning_Sum_All_Current_Upgrades_Lvl();
                    if (sum_all_current_ugrade_lvl >= 5 && !check)
                    {
                        Achivement.interactable = true;
                    }
                    else { Achivement.interactable = false; }
                    Debug.Log("Summ OF All Current Bougnt LVLs " + sum_all_current_ugrade_lvl);
                    break;

                // Achivement 8  -  upgrade item in shop 10 times
                case 8:
                    int current_ugrade_lvl = temp_shop_manager.Returning_Max_Current_Upgrade_Lvl();
                    if (current_ugrade_lvl == 10 && !check)
                    {
                        Achivement.interactable = true;
                    }
                    else { Achivement.interactable = false; }
                    Debug.Log("Max Current Lvl " + current_ugrade_lvl);

                    break;
                //default:
                //    Achivement.interactable = false;
                //    break;
            }
        }
    }


    public void Click_On_Achivement(int id)
    {
        money_current = money_current + achivements_rewards[id];
        PlayerPrefs.SetInt("Player_Current_Money", money_current);
        
        PlayerPrefs.SetInt(determinePrefsName(id), 1);

        //int key2 = PlayerPrefs.GetInt(determinePrefsName(id));
        //Debug.Log("Key2 ___" + key2 +"___");

        testAllAchivements();
    }

    private string determinePrefsName(int num)
    {
        if      (num == 1) return "Check_First_1";
        else if (num == 2) return "Check_First_2";
        else if (num == 3) return "Check_First_3";
        else if (num == 4) return "Check_First_4";
        else if (num == 5) return "Check_First_5";
        else if (num == 6) return "Check_First_6";
        else if (num == 7) return "Check_First_7";
        else if (num == 8) return "Check_First_8";
        else return "Null";
    }

    //void Start()
    //{
    //    money_total = PlayerPrefs.GetInt("Player_Total_Money");
    //    isFirst = PlayerPrefs.GetInt("isFirst") == 1 ? true : false;
    //    if (money_total >= 10 && !isFirst)
    //    {
    //        first_Achivement.interactable = true;
    //    }
    //    else
    //    {
    //        first_Achivement.interactable = false;
    //    }
    //}

    //public void GetFirst()
    //{
    //    int money_reward = PlayerPrefs.GetInt("Player_money");
    //    money_reward += 10;
    //    PlayerPrefs.SetInt("Player_money", money_reward);
    //    isFirst = true;
    //    PlayerPrefs.SetInt("isFirst", isFirst ? 1 : 0);
    //}

    //public void Shift_Scene(int id)
    //{
    //    SceneManager.LoadScene(id);
    //}

    void Update()
    {
        money_txt.text = money_current.ToString();
    }
}
