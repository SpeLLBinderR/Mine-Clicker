using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShopManager : MonoBehaviour
{
    [SerializeField] int money_current;
    public int money_total;
    public bool tryNewGame;
    public int current_increment;
    public int current_idle_money_income;

    private int[] shop_basic_list = new int[6] { 0, 1, 2, 5, 10, 20 };
    private int[] shop_idle_list = new int[6] { 0, 1, 2, 3, 5, 10 };

    public Text money_txt;

    public Text lvl_space_1, lvl_space_2, lvl_space_3, lvl_space_4, lvl_space_5,
                description_space_1, description_space_2, description_space_3,
                    description_space_4, description_space_5,
                cost_space_1, cost_space_2, cost_space_3, cost_space_4, cost_space_5;


    public Button PageBasic, PagePercentage, PageIdle;
    public Button Basic1, Basic2, Basic3, Basic4, Basic5;

    public int current_bought_upgrades;

    public AudioSource sound_purchase_1, sound_purchase_2, sound_denial;

    public int achivement_7_counter, achivement_8_counter;

    private int current_page_id;
    void Start()
    {
        Testing_For_New_Game();

        money_current = PlayerPrefs.GetInt("Player_Current_Money");
        money_total = PlayerPrefs.GetInt("Player_Total_Money");
        current_increment = PlayerPrefs.GetInt("Current_Incrementation_Amount");
        current_bought_upgrades = PlayerPrefs.GetInt("Current_Upgrades_Bought");
        current_idle_money_income = PlayerPrefs.GetInt("Current_Idle_Incrementation");

        Show_Lvl_Cost_Txt(1);

    }

    public void Show_Lvl_Cost_Txt(int page)
    {
        string lvl_test_txt, cost_test_txt;
        int current_lvl, current_cost;

        current_page_id = page;

        for (int i = 1; i <= 5; i++)
        {
            switch (page) {
                case 1: 
                    lvl_test_txt = Determine_Prefs_Lvl_Base(i);
                    cost_test_txt = Determine_Prefs_Cost_Base(i);
                    break;
                case 2:
                    lvl_test_txt = Determine_Prefs_Lvl_Percentage(i);
                    cost_test_txt = Determine_Prefs_Cost_Percentage(i);
                    break;
                case 3:
                    lvl_test_txt = Determine_Prefs_Lvl_Idle(i);
                    cost_test_txt = Determine_Prefs_Cost_Idle(i);
                    break;
                
                //  empty default. Left to avoid error
                default:
                    lvl_test_txt = "NULL";
                    cost_test_txt = "NULL";
                    break;
            }

            current_lvl = PlayerPrefs.GetInt(lvl_test_txt);
            current_cost = PlayerPrefs.GetInt(cost_test_txt);

            Show_Current_txt(i, current_lvl, current_cost);
        }

    }



    public void Click_On_Page(int id)
    {
        // something to cahnge list of upgrade stuff
        
        switch (id)
        {
            case 1:
                Same_Description_On__Pages();
                Show_Lvl_Cost_Txt(id);
                break;

            case 2:
                Same_Description_On__Pages();
                Show_Lvl_Cost_Txt(id);
                break;

            case 3:
                description_space_1.text = "+ 1 idle";
                description_space_2.text = "+ 2 idle";
                description_space_3.text = "+ 3 idle";
                description_space_4.text = "+ 5 idle";
                description_space_5.text = "+ 10 idle";

                Show_Lvl_Cost_Txt(id);

                break;
        }
    }
    
    public void Same_Description_On__Pages()
    {
        description_space_1.text = "+ 1 to damage";
        description_space_2.text = "+ 2 to damage";
        description_space_3.text = "+ 5 to damage";
        description_space_4.text = "+ 10 to damage";
        description_space_5.text = "+ 20 to damage";
    }

    // purchase
    public void Click_On_Basic_Tab(int id)
    {
        string prefsLvl = "NULL", prefsName = "NULL";

        switch (current_page_id) 
        {
            case 1:
                prefsLvl = Determine_Prefs_Lvl_Base(id);
                prefsName = Determine_Prefs_Cost_Base(id);
                break;

            case 2:
                prefsLvl = Determine_Prefs_Lvl_Percentage(id);
                prefsName = Determine_Prefs_Cost_Percentage(id);
                break;

            case 3:
                prefsLvl = Determine_Prefs_Lvl_Idle(id);
                prefsName = Determine_Prefs_Cost_Idle(id);
                break;
        }

        int current_lvl = PlayerPrefs.GetInt(prefsLvl);
        int current_cost = PlayerPrefs.GetInt(prefsName);

        Debug.Log("LVL " + current_lvl + "/ current cost" + current_cost + "page" + current_page_id);

        if (money_current >= current_cost && current_lvl < 10)
        {
            Debug.Log("All money now" + money_current);
            money_current = money_current - current_cost;
            Debug.Log("All money after" + money_current);
            // let it slide to ignore error
            int new_cost = current_cost;

            switch (current_page_id)
            {
                case 1:                   
                    current_increment += shop_basic_list[id];
                    PlayerPrefs.SetInt("Current_Incrementation_Amount", current_increment);
                    new_cost = current_cost * 2;
                    break;

                case 2:
                    current_increment += shop_basic_list[id];
                    PlayerPrefs.SetInt("Current_Incrementation_Amount", current_increment);

                    new_cost = current_cost * 2 + 5 * current_lvl;

                    break;

                case 3:
                    current_idle_money_income = current_idle_money_income + shop_idle_list[id];
                    PlayerPrefs.SetInt("Current_Idle_Incrementation", current_idle_money_income);
                    if (current_lvl < 4)
                    {
                        new_cost = current_cost * 3;
                    }
                    else if (current_lvl < 8)
                    {
                        new_cost = current_cost * 5;
                    }
                    else if (current_lvl < 11)
                    {
                        new_cost = current_cost * 5 + 5 * current_lvl;
                    }
                    else
                    {
                        new_cost = current_cost * 10;
                    }
                    PlayerPrefs.SetInt("Player_Current_Money", money_current);
                    break;
                    
            }

            Debug.Log("LVL " +current_lvl+ "/ current cost" + current_cost+ "/ new cost" + new_cost);
            int new_lvl = current_lvl + 1;


            PlayerPrefs.SetInt("Player_Current_Money", money_current);

            PlayerPrefs.SetInt(prefsLvl, new_lvl);
            PlayerPrefs.SetInt(prefsName, new_cost);

            Show_Current_txt(id, new_lvl, new_cost);
            sound_purchase_1.Play();

        }
        else { sound_denial.Play(); }     
    }

    private string Determine_Prefs_Cost_Base(int num)
    {
        if      (num == 1) return "Current_Basic_Cost_1";
        else if (num == 2) return "Current_Basic_Cost_2";
        else if (num == 3) return "Current_Basic_Cost_3";
        else if (num == 4) return "Current_Basic_Cost_4";
        else if (num == 5) return "Current_Basic_Cost_5";
        else return "Null";
    }
    private string Determine_Prefs_Lvl_Base(int num)
    {
        if      (num == 1) return "Current_Basic_Lvl_1";
        else if (num == 2) return "Current_Basic_Lvl_2";
        else if (num == 3) return "Current_Basic_Lvl_3";
        else if (num == 4) return "Current_Basic_Lvl_4";
        else if (num == 5) return "Current_Basic_Lvl_5";
        else return "Null";
    }

    private string Determine_Prefs_Cost_Percentage(int num)
    {
        if      (num == 1) return "Current_Percantage_Cost_1";
        else if (num == 2) return "Current_Percantage_Cost_2";
        else if (num == 3) return "Current_Percantage_Cost_3";
        else if (num == 4) return "Current_Percantage_Cost_4";
        else if (num == 5) return "Current_Percantage_Cost_5";
        else return "Null";
    }
    private string Determine_Prefs_Lvl_Percentage(int num)
    {
        if      (num == 1) return "Current_Percantage_Lvl_1";
        else if (num == 2) return "Current_Percantage_Lvl_2";
        else if (num == 3) return "Current_Percantage_Lvl_3";
        else if (num == 4) return "Current_Percantage_Lvl_4";
        else if (num == 5) return "Current_Percantage_Lvl_5";
        else return "Null";
    }

    private string Determine_Prefs_Cost_Idle(int num)
    {
        if      (num == 1) return "Current_Idle_Cost_1";
        else if (num == 2) return "Current_Idle_Cost_2";
        else if (num == 3) return "Current_Idle_Cost_3";
        else if (num == 4) return "Current_Idle_Cost_4";
        else if (num == 5) return "Current_Idle_Cost_5";
        else return "Null";
    }
    private string Determine_Prefs_Lvl_Idle(int num)
    {
        if      (num == 1) return "Current_Idle_Lvl_1";
        else if (num == 2) return "Current_Idle_Lvl_2";
        else if (num == 3) return "Current_Idle_Lvl_3";
        else if (num == 4) return "Current_Idle_Lvl_4";
        else if (num == 5) return "Current_Idle_Lvl_5";
        else return "Null";
    }


    private void Show_Current_txt(int id, int new_lvl, int new_cost)
    {
        switch (id)
        {
            case 1:
                lvl_space_1.text = new_lvl.ToString();
                cost_space_1.text = new_cost.ToString();
                break;
            case 2:
                lvl_space_2.text = new_lvl.ToString();
                cost_space_2.text = new_cost.ToString();
                break;
            case 3:
                lvl_space_3.text = new_lvl.ToString();
                cost_space_3.text = new_cost.ToString();
                break;
            case 4:
                lvl_space_4.text = new_lvl.ToString();
                cost_space_4.text = new_cost.ToString();
                break;
            case 5:
                lvl_space_5.text = new_lvl.ToString();
                cost_space_5.text = new_cost.ToString();
                break;
        }

    }


    //____________________________________

    // Function specificly for max lvl. __Achivement 8__
    public int Returning_Max_Current_Upgrade_Lvl()
    {
        Testing_For_New_Game();
        int max_current_upgrade_lvl = 0;

        for(int k = 1; k <= 5; k++)
        {
            int temp_lvl = PlayerPrefs.GetInt(Determine_Prefs_Lvl_Base(k));
            if (max_current_upgrade_lvl < temp_lvl)
            {
                max_current_upgrade_lvl = temp_lvl;
            }
        }

        return max_current_upgrade_lvl;
    }

    //Function for summ of upgrades. __Achivement 8__
    public int Returning_Sum_All_Current_Upgrades_Lvl()
    {
        Testing_For_New_Game();

        int sum_all_current_upgrade_lvl = 0;

        for (int k = 1; k <= 5; k++)
        {
            int temp_lvl = PlayerPrefs.GetInt(Determine_Prefs_Lvl_Base(k));
            switch (temp_lvl)
            {
                case 1:
                    break;
                default:
                    sum_all_current_upgrade_lvl += temp_lvl - 1;
                    break;
            }
        }

        return sum_all_current_upgrade_lvl;
    }


    public void Testing_For_New_Game()
    {
        tryNewGame = PlayerPrefs.GetInt("New_Game_Test_Shop") == 1 ? true : false;
        
        if (tryNewGame)
        {
            // Basic
            PlayerPrefs.SetInt("Current_Basic_Cost_1", 5);
            PlayerPrefs.SetInt("Current_Basic_Cost_2", 50);
            PlayerPrefs.SetInt("Current_Basic_Cost_3", 300);
            PlayerPrefs.SetInt("Current_Basic_Cost_4", 2000);
            PlayerPrefs.SetInt("Current_Basic_Cost_5", 5000);

            PlayerPrefs.SetInt("Current_Basic_Lvl_1", 1);
            PlayerPrefs.SetInt("Current_Basic_Lvl_2", 1);
            PlayerPrefs.SetInt("Current_Basic_Lvl_3", 1);
            PlayerPrefs.SetInt("Current_Basic_Lvl_4", 1);
            PlayerPrefs.SetInt("Current_Basic_Lvl_5", 1);

            // Percantage
            PlayerPrefs.SetInt("Current_Percantage_Cost_1", 5);
            PlayerPrefs.SetInt("Current_Percantage_Cost_2", 50);
            PlayerPrefs.SetInt("Current_Percantage_Cost_3", 500);
            PlayerPrefs.SetInt("Current_Percantage_Cost_4", 5000);
            PlayerPrefs.SetInt("Current_Percantage_Cost_5", 50000);

            PlayerPrefs.SetInt("Current_Percantage_Lvl_1", 1);
            PlayerPrefs.SetInt("Current_Percantage_Lvl_2", 1);
            PlayerPrefs.SetInt("Current_Percantage_Lvl_3", 1);
            PlayerPrefs.SetInt("Current_Percantage_Lvl_4", 1);
            PlayerPrefs.SetInt("Current_Percantage_Lvl_5", 1);

            // Idle
            PlayerPrefs.SetInt("Current_Idle_Cost_1", 100);
            PlayerPrefs.SetInt("Current_Idle_Cost_2", 500);
            PlayerPrefs.SetInt("Current_Idle_Cost_3", 1500);
            PlayerPrefs.SetInt("Current_Idle_Cost_4", 3000);
            PlayerPrefs.SetInt("Current_Idle_Cost_5", 5000);

            PlayerPrefs.SetInt("Current_Idle_Lvl_1", 1);
            PlayerPrefs.SetInt("Current_Idle_Lvl_2", 1);
            PlayerPrefs.SetInt("Current_Idle_Lvl_3", 1);
            PlayerPrefs.SetInt("Current_Idle_Lvl_4", 1);
            PlayerPrefs.SetInt("Current_Idle_Lvl_5", 1);

            PlayerPrefs.SetInt("New_Game_Test_Shop", 0);
        }
    }


    void Update()
    {
        money_txt.text = money_current.ToString();
    }
}
