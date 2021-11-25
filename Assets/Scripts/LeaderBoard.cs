using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LeaderBoard : MonoBehaviour
{
    public GameObject Panel;
    public GameObject Player;
    public Text levelNAme;
    private void Start()
    {

       
            string levelname = PlayerPrefs.GetString("NAmeLevel");
            if (!string.IsNullOrEmpty(levelname))
            {
                levelNAme.text = levelname;
            }
           
        


    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag == "Player")
        {
          
            Panel.SetActive(true);
        }
    }


    public void CallLevelTwo()
    {
        SceneManager.LoadScene("Level2");
    }
    public void CallLevelOneAsThree()
    {
        SceneManager.LoadScene("LevelOne");
        PlayerPrefs.SetString("NAmeLevel", "Level Three");
        PlayerPrefs.Save();
    }
}
