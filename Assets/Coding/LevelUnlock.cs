using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LevelUnlock : MonoBehaviour
{
    public int hargaLevel;
    public bool level2, level3, level4, level5;
    public bool level2Bool, level3Bool, level4Bool, level5Bool;

    public GameObject mainMenu;
    MainMenuController mainMenuC;
    
    // Start is called before the first frame update
    void Start()
    {
        
        mainMenuC = mainMenu.GetComponent<MainMenuController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseDown()
    {
        if (level2)
        {
            level2Bool = true;
            mainMenuC.TrueKeteranganUI();
        }
        if (level3)
        {
            level3Bool = true;
            mainMenuC.TrueKeteranganUI();
        }
        if (level4)
        {
            level4Bool = true;
            mainMenuC.TrueKeteranganUI();
        }
        if (level5)
        {
            level5Bool = true;
            mainMenuC.TrueKeteranganUI();
        }
        print("Masuk");
    }





}
