using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LevelController : MonoBehaviour
{
    public static LevelController instance = null;
    public int sceneIndex, levelPassed, uang;

    
    // Start is called before the first frame update
    void Start()
    {
        
        uang = PlayerPrefs.GetInt("Uang");
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        levelPassed = PlayerPrefs.GetInt("LevelPassed");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void BukaLevelBerikutnya()
    {

        if (levelPassed < sceneIndex)
        {
            PlayerPrefs.SetInt("LevelPassed", sceneIndex + 1);
            Debug.Log("LEVEL " + PlayerPrefs.GetInt("LevelPassed") + " TERBUKA");
        }

        if(uang < 30)
        {
            uang += 10;
            print("rteteaaa");
            PlayerPrefs.SetInt("Uang", uang);
        }
    }

}
