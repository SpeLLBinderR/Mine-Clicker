using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MainMenu : MonoBehaviour
{
    [SerializeField] int money_current;
    [SerializeField] int money_total;
    [SerializeField] int current_increment, current_idle_money_income;

    public Text money_txt;
    public Image black_background, pop_up_Window;

    private void Start()
    {
        money_current =             PlayerPrefs.GetInt("Player_Current_Money");
        money_total =               PlayerPrefs.GetInt("Player_Total_Money");
        current_increment =         PlayerPrefs.GetInt("Current_Incrementation_Amount");
        current_idle_money_income = PlayerPrefs.GetInt("Current_Idle_Incrementation");

        StartCoroutine(IdleMoneyFarm());

    }
    public void Save_current_money()
    {
        PlayerPrefs.SetInt("Player_Current_Money", money_current);
    }
   
    public void ButtonClick()
    {
        /////
        money_current = money_current + current_increment;
        // change later !!!
        money_total = money_current;
        PlayerPrefs.SetInt("Player_Current_Money", money_current);
        PlayerPrefs.SetInt("Player_Total_Money", money_total);
    }


    IEnumerator IdleMoneyFarm(float count_time = 2f)
    {
        while (true)
        {
            yield return new WaitForSeconds(count_time);
            money_current = money_current + current_idle_money_income;
            
        }
        //money_current += current_idle_money_income;
        //Debug.Log("Recieved idle money");
        //PlayerPrefs.SetInt("Player_Current_Money", money_current);
        //Debug.Log("______________" + key);
        //key++;
        //yield return new WaitForSeconds(2f);
    }

    //public void Pop_Up_Visual(bool what)
    //{
    //    //string tag = "Pop_Up_Tag"; 
    //    //GameObject[] taggedObjects = GameObject.FindGameObjectsWithTag(tag);
    //    //foreach (GameObject tagged in taggedObjects)
    //    //{
    //    //    tagged.Setactive(false); // or true
    //    //}

    //    //pop_up_Window.

    //    //CanvasGroup canvasGr = GetComponent<CanvasGroup>();
    //    //canvasGr.alpha = what ? 1 : 0;
    //    //canvasGr.interactable = what;

    //    //black_background.enabled = what;
    //    //pop_up_Window.enabled = what;
    //}

    public void Pop_Up_Window_Yes_Click()
    {
        //Pop_Up_Visual(false);

        //Debug.Log("_______All current money was ereased______");
        //money_current = 0;
        //money_total = money_current;
        //new_game_test_shop = 1; 
        //new_game_test_achivements = 1;
        //current_increment = 1;
        //PlayerPrefs.SetInt("Player_Current_Money", money_current);
        //PlayerPrefs.SetInt("Player_Total_Money", money_current);
        //PlayerPrefs.SetInt("New_Game_Test_Shop", new_game_test_shop);
        //PlayerPrefs.SetInt("New_Game_Test_Achivements", new_game_test_achivements);
        //PlayerPrefs.SetInt("Current_Incrementation_Amount", current_increment);


        //RectTransform picture = GetComponent<RectTransform>();
        //picture.anchoredPosition = new Vector2(0, 0);
    }

    void Update()
    {
        //PlayerPrefs.SetInt("Player_Current_Money", money_current);
        money_txt.text = money_current.ToString();
    }
}
