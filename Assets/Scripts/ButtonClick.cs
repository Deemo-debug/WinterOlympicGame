using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonClick : MonoBehaviour
{
    public GameObject rightPanel_1;
    public GameObject rightPanel_2;
    public GameObject wrongPanel_1;
    public GameObject wrongPanel_2;
    public GameObject agreePanel;
    public GameObject showPanel_1;

    public int Money = 0;
    public int flag_1 = 0;

    public Text moneyNum;
    public Text Lock_1;

    void Start()
    {
        Money = PlayerPrefs.GetInt("Money");
        flag_1 = PlayerPrefs.GetInt("flag_1");
        moneyNum.text = Money.ToString();
    }

    void Update()
    {
        if (flag_1 == 0)
        {
            Lock_1.text = "解锁需要1金币";
        }
        else
        {
            Lock_1.text = "查看";
        }
    }

    public void StartClick()
    {
        SceneManager.LoadScene("Question1");
    }

    public void ReturnClick()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void CollectClick()
    {
        SceneManager.LoadScene("CollectionScene");
    }

    public void AgainClick_1()
    {
        SceneManager.LoadScene("Question1");
    }

    public void RightClick_1()
    {
        rightPanel_1.SetActive(true);
        Money++;
        moneyNum.text = Money.ToString();
        PlayerPrefs.SetInt("Money", Money);
    }

    public void WrongClick_1()
    {
        wrongPanel_1.SetActive(true);
    }

    public void NextClick_1()
    {
        SceneManager.LoadScene("Question2");
    }
    
    public void AgainClick_2()
    {
        SceneManager.LoadScene("Question2");
    }

    public void RightClick_2()
    {
        rightPanel_2.SetActive(true);
        Money++;
        moneyNum.text = Money.ToString();
        PlayerPrefs.SetInt("Money", Money);
    }

    public void WrongClick_2()
    {
        wrongPanel_2.SetActive(true);
    }

    public void NextClick_2()
    {
        SceneManager.LoadScene("GameOverScene");
    }

    public void LockLick_1()
    {
        //flag_1 = 0;
        //PlayerPrefs.SetInt("flag_1", flag_1);
        if (flag_1 == 0)
        {
            if(Money >= 1)
            {
                Money--;
                moneyNum.text = Money.ToString();
                PlayerPrefs.SetInt("Money", Money);
                Lock_1.text = "查看";
                flag_1 = 1;
                PlayerPrefs.SetInt("flag_1", flag_1);
            }
            else
            {
                agreePanel.SetActive(true);
            }
        }
        else
        {
            showPanel_1.SetActive(true);
        }
    }

    public void ReturnCloseClick()
    {
        SceneManager.LoadScene("CollectionScene");
    }

    public void AgreeClick()
    {
        agreePanel.SetActive(false);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
