using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OpenClass : MonoBehaviour
{
    public GameObject[] But;
    public GameObject[] Player;
    public GameObject PanelClass;
    public InputField PlayerName;
    public PersonPlayerParam personPlayerParam;
    public Text FeaturesText;
    public string SceneNameLoad;
    public string NextScene;
    public bool Open;
    public bool OpenBut;
    public int Id;

    void Start()
    {
        Open = false;
        PanelClass.SetActive(Open);
    }

    void Update()
    {
        for (int i = 0; i < But.Length; i++)
        {
            if (i == Id)
            {
                But[Id].SetActive(true);
                Player[Id].SetActive(true);
                personPlayerParam = Player[Id].GetComponent<PersonPlayerParam>();
                PlayerPrefs.SetInt("idPlayer", Id);
                SetStringFeatures(personPlayerParam);
                personPlayerParam.Name = PlayerName.text;
            }
            else
            {
                But[i].SetActive(false);
                Player[i].SetActive(false);
            }
        }
    }

    #region Button
    public void OpenPanelClass()
    {
        Open = !Open;
        PanelClass.SetActive(Open);
    }

    public void EnterClassCaptain()
    {
        Id = 0;
        Open = !Open;
        PanelClass.SetActive(Open);
    }

    public void EnterClassQuartermaster()
    {
        Id = 1;
        Open = !Open;
        PanelClass.SetActive(Open);
    }

    public void EnterClassNavigator()
    {
        Id = 2;
        Open = !Open;
        PanelClass.SetActive(Open);
    }

    public void EnterClassBosun()
    {
        Id = 3;
        Open = !Open;
        PanelClass.SetActive(Open);
    }

    public void EnterClassCanonier()
    {
        Id = 4;
        Open = !Open;
        PanelClass.SetActive(Open);
    }

    public void EnterClassCarpenter()
    {
        Id = 5;
        Open = !Open;
        PanelClass.SetActive(Open);
    }

    public void EnterClassCaulkman()
    {
        Id = 6;
        Open = !Open;
        PanelClass.SetActive(Open);
    }

    public void EnterClassKock()
    {
        Id = 7;
        Open = !Open;
        PanelClass.SetActive(Open);
    }

    public void EnterClassPirate()
    {
        Id = 8;
        Open = !Open;
        PanelClass.SetActive(Open);
    }

    public void EnterClassSeaman()
    {
        Id = 9;
        Open = !Open;
        PanelClass.SetActive(Open);
    }

    public void EnterClassResettler()
    {
        Id = 10;
        Open = !Open;
        PanelClass.SetActive(Open);
    }

    public void EnterClassPowderMonkey()
    {
        Id = 11;
        Open = !Open;
        PanelClass.SetActive(Open);
    }

    public void EnterClassMerchant()
    {
        Id = 12;
        Open = !Open;
        PanelClass.SetActive(Open);
    }
    #endregion

    public void NewGameIsland()
    {
        PlayerPrefs.SetString("namePlayer", personPlayerParam.Name);
        NextScene = "NewGame";
        PlayerPrefs.SetString("backScene", NextScene);
        NextScene = "Island";
        PlayerPrefs.SetString("nextScene", NextScene);
        SceneManager.LoadScene(SceneNameLoad);
    }

    public void SetStringFeatures(PersonPlayerParam playerFeatur)
    {
        FeaturesText.text =   "Power" + "          " + playerFeatur.Power + " " 
                                + "Endurance" + "   " + playerFeatur.Endurance + " "
                                + "Mana" + "            " + playerFeatur.Mana + " "
                                + "Intellect" + "        " + playerFeatur.Intelect + " "
                                + "Body" + "            " + playerFeatur.Body;
    }
}