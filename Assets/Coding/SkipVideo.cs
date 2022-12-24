using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkipVideo : MonoBehaviour
{
    public int clik;
    GameController gC;
    MainMenuController mainMenu;
    public bool mainmenu;
    // Start is called before the first frame update
    void Start()
    {
        if (!mainmenu)
        {
            gC = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        }

        if (mainmenu)
        {
            mainMenu = GameObject.FindGameObjectWithTag("GameController").GetComponent<MainMenuController>();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void skipVideo()
    {
        clik++;
        if (clik == 15)
        {
            if (mainmenu)
            {
                mainMenu.timerVideo = 1f;
            }
            if (!mainmenu)
            {
                gC.timeVideoAwalLevel1 = 0;
                gC.timeVideoAwalLevel2 = 0;
                gC.timeVideoAwalLevel3 = 0;
                gC.timeVideoAwalLevel4 = 0;
                gC.timeVideoAwalLevel5 = 0;

                if(gC.VideoAwalLevel1Bool || gC.VideoAwalLevel2Bool || gC.VideoAwalLevel3Bool || gC.VideoAwalLevel4Bool || gC.VideoAwalLevel5Bool)
                {
                    if (gC.iniLevelBerapa == 1)
                    {
                        SceneManager.LoadScene(gC.iniLevelBerapa);
                    }

                    if (gC.iniLevelBerapa == 2)
                    {
                        SceneManager.LoadScene(gC.iniLevelBerapa);
                    }

                    if (gC.iniLevelBerapa == 3)
                    {
                        SceneManager.LoadScene(gC.iniLevelBerapa);
                    }

                    if (gC.iniLevelBerapa == 4)
                    {
                        SceneManager.LoadScene(gC.iniLevelBerapa);
                    }

                    if (gC.iniLevelBerapa == 5)
                    {
                        SceneManager.LoadScene(gC.iniLevelBerapa);
                    }
                }

                gC.timeVideoAkhirLevel1 = 0;
                gC.timeVideoAkhirLevel2 = 0;
                gC.timeVideoAkhirLevel3 = 0;
                gC.timeVideoAkhirLevel4 = 0;
                gC.timeVideoAkhirLevel5 = 0;


            }



            clik = 0;
        }
    }
}
