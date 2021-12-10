using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
   
    public Text levelNAme;
    private void Start()
    {

       
            string levelname = PlayerPrefs.GetString("NAmeLevel");
            if (!string.IsNullOrEmpty(levelname))
            {
                levelNAme.text = levelname;
            }
           
        


    }

 

    public void CallLevelTwo()
    {
        SceneManager.LoadScene("Level2");
    }
    public void CallLevelOneAsThree()
    {
        SceneManager.LoadScene("LevelMain");
        PlayerPrefs.SetString("NAmeLevel", "Level Three");
        PlayerPrefs.Save();
    }
}
