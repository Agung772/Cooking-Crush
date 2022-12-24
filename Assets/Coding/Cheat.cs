using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cheat : MonoBehaviour
{
    public int clik;
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
        clik++;
        if(clik == 10)
        {
            mainMenuC.uang = 999999999;
            mainMenuC.SaveUang();
        }
    }
}
