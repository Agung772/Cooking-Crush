using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NamaTopingController : MonoBehaviour
{
    public bool clickToping;
    public GameObject namaTopingUI;
    public TextMeshProUGUI namaTopingText;
    public string namaToping;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (clickToping)
        {
            namaTopingText.text = namaToping;
        }
        
    }

    private void OnMouseDown()
    {
        namaTopingUI.SetActive(true);
        clickToping = true;
        print("Masuk");
    }

    private void OnMouseUp()
    {
        namaTopingUI.SetActive(false);
        clickToping = false;
        print("Keluar");
    }
}
