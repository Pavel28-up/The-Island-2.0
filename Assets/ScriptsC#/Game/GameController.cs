using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject[] PersonPlayer;
    public GameObject[] CameraTaeget;
    public Transform GamePoint;
    public PersonPlayerParam NewPlayerName;
    public int Id;

    void Start()
    {
        Id = PlayerPrefs.GetInt("idPlayer");
        for (int  i = 0;  i < PersonPlayer.Length;  i++)
        {
            if (i == Id)
            {
                // GameObject NewPlayer = Instantiate(PersonPlayer[Id], GamePoint.position, Quaternion.identity) as GameObject;
                NewPlayerName = PersonPlayer[Id].GetComponent<PersonPlayerParam>();
                NewPlayerName.Name = PlayerPrefs.GetString("namePlayer");
            }
            else
            {
                Destroy(PersonPlayer[i]);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
