using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndikatorController : MonoBehaviour
{
    public GameObject soundManager;
    SoundManager sM;
    public GameObject[] topingSayurPadang = new GameObject [7], topingSayurBetawi = new GameObject[9], topingCapGoMeh = new GameObject[11], topingMedan = new GameObject[13];
    public GameObject resetTopingUI, pilihTopingUI, topingSayurPadangUI, topingSayurBetawiUI, topingCapGoMehUI, topingMedanUI;
    public GameObject BarTopingSayurPadang, BarTopingSayurBetawi, BarTopingCapGoMeh, BarTopingMedan;
    public bool[] check;
    public float minX, maxX, kecepatanIndikator;
    public float direction = 1;

    public bool topingSayurPadangBool;
    public bool bawang, cabai, cabai2, nangka, kerupuk, telor, telor2, buncis;

    public bool topingSayurBetawiBool;
    public bool labuSiamBetawi, kacangPanjangBetawi, irisanTahuBetawi, irisanTempeBetawi, kuahBetawi, telurRebusBetawi, kerupukBetawi, bawangGorengBetawi;

    public bool topingCapGoMehBool;
    public bool oporAyamCapGoMeh, sambalGorengAtiAmpelaCapGoMeh, acarCapGoMeh, kerupukCapGoMeh, bubukKoyaCapGoMeh, telurPetisCapGoMeh, sambalGodokCapGoMeh, abonSapiCapGoMeh, sayurLodehCapGoMeh, udangCapGoMeh;

    public bool topingMedanBool;
    public bool labuSiamMedan, ayamSemurSantanMedan, bubukKoyaMedan, taucoMedan, sambalMedan, telurBaladoMedan, rendangDagingMedan, keringKentangMedan, kerupukMedan, bawangGorengMedan, kuahMedan, bihunMedan;


    int jumCabai, jumTelor;
    public bool gerakIndikator;
    // Start is called before the first frame update
    void Start()
    {
        sM = soundManager.GetComponent<SoundManager>();
        transform.position = new Vector3(-3.01f, transform.position.y, transform.position.z);
        minX = -3.01f;
        maxX = 2.93f;
    }

    // Update is called once per frame
    void Update()
    {
        GerakIndikator();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("1"))
        {

            check[1] = true;
        }
        if (collision.CompareTag("2"))
        {

            check[2] = true;
        }
        if (collision.CompareTag("3"))
        {

            check[3] = true;
        }
        if (collision.CompareTag("4"))
        {

            check[4] = true;
        }
        if (collision.CompareTag("5"))
        {

            check[5] = true;
        }
        if (collision.CompareTag("6"))
        {

            check[6] = true;
        }
        if (collision.CompareTag("7"))
        {

            check[7] = true;
        }
        if (collision.CompareTag("8"))
        {

            check[8] = true;
        }
        if (collision.CompareTag("9"))
        {

            check[9] = true;
        }
        if (collision.CompareTag("10"))
        {

            check[10] = true;
        }
        if (collision.CompareTag("11"))
        {

            check[11] = true;
        }
        if (collision.CompareTag("12"))
        {

            check[12] = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("1"))
        {
            check[1] = false;

        }
        if (collision.CompareTag("2"))
        {
            check[2] = false;

        }
        if (collision.CompareTag("3"))
        {
            check[3] = false;

        }
        if (collision.CompareTag("4"))
        {
            check[4] = false;

        }
        if (collision.CompareTag("5"))
        {
            check[5] = false;

        }
        if (collision.CompareTag("6"))
        {
            check[6] = false;

        }
        if (collision.CompareTag("7"))
        {
            check[7] = false;

        }
        if (collision.CompareTag("8"))
        {
            check[8] = false;

        }
        if (collision.CompareTag("9"))
        {

            check[9] = false;
        }
        if (collision.CompareTag("10"))
        {

            check[10] = false;
        }
        if (collision.CompareTag("11"))
        {

            check[11] = false;
        }
        if (collision.CompareTag("12"))
        {

            check[12] = false;
        }
    }

    public void Checker()
    {
        sM.EfekSuaraTombol();
        if (topingSayurPadangBool)
        {
            if (check[1])
            {
                topingSayurPadang[1].SetActive(true);
                buncis = true;


            }
            if (check[2])
            {
                topingSayurPadang[2].SetActive(true);
                bawang = true;


            }
            if (check[3])
            {
                topingSayurPadang[3].SetActive(true);
                cabai = true;
                jumCabai++;
                if (jumCabai == 2)
                {
                    cabai2 = true;
                }


            }
            if (check[4])
            {
                topingSayurPadang[4].SetActive(true);
                kerupuk = true;

            }
            if (check[5])
            {
                topingSayurPadang[5].SetActive(true);
                telor = true;
                jumTelor++;
                if (jumTelor == 2)
                {
                    topingSayurPadang[7].SetActive(true);
                    telor2 = true;
                }

            }
            if (check[6])
            {
                topingSayurPadang[6].SetActive(true);
                nangka = true;

            }
        }

        if (topingSayurBetawiBool)
        {
            if (check[1])
            {
                topingSayurBetawi[1].SetActive(true);
                kerupukBetawi = true;
            }
            if (check[2])
            {
                topingSayurBetawi[2].SetActive(true);
                kacangPanjangBetawi = true;
            }
            if (check[3])
            {
                topingSayurBetawi[3].SetActive(true);
                bawangGorengBetawi = true;
            }
            if (check[4])
            {
                topingSayurBetawi[4].SetActive(true);
                irisanTahuBetawi = true;
            }
            if (check[5])
            {
                topingSayurBetawi[5].SetActive(true);
                labuSiamBetawi = true;
            }
            if (check[6])
            {
                topingSayurBetawi[6].SetActive(true);
                kuahBetawi = true;
            }
            if (check[7])
            {
                topingSayurBetawi[7].SetActive(true);
                telurRebusBetawi = true;
            }
            if (check[8])
            {
                topingSayurBetawi[8].SetActive(true);
                irisanTempeBetawi = true;
            }

        }

        if (topingCapGoMehBool)
        {
            if (check[1])
            {
                topingCapGoMeh[1].SetActive(true);
                sambalGodokCapGoMeh = true;
            }
            if (check[2])
            {
                topingCapGoMeh[2].SetActive(true);
                abonSapiCapGoMeh = true;
            }
            if (check[3])
            {
                topingCapGoMeh[3].SetActive(true);
                udangCapGoMeh = true;
            }
            if (check[4])
            {
                topingCapGoMeh[4].SetActive(true);
                sambalGorengAtiAmpelaCapGoMeh = true;
            }
            if (check[5])
            {
                topingCapGoMeh[5].SetActive(true);
                kerupukCapGoMeh = true;
            }
            if (check[6])
            {
                topingCapGoMeh[6].SetActive(true);
                bubukKoyaCapGoMeh = true;
            }
            if (check[7])
            {
                topingCapGoMeh[7].SetActive(true);
                oporAyamCapGoMeh = true;
            }
            if (check[8])
            {
                topingCapGoMeh[8].SetActive(true);
                sayurLodehCapGoMeh = true;
            }
            if (check[9])
            {
                topingCapGoMeh[9].SetActive(true);
                telurPetisCapGoMeh = true;
            }
            if (check[10])
            {
                topingCapGoMeh[10].SetActive(true);
                acarCapGoMeh = true;
            }
        }

        if (topingMedanBool)
        {
            if (check[1])
            {
                topingMedan[1].SetActive(true);
                rendangDagingMedan = true;
            }
            if (check[2])
            {
                topingMedan[2].SetActive(true);
                labuSiamMedan = true;
            }
            if (check[3])
            {
                topingMedan[3].SetActive(true);
                kerupukMedan = true;
            }
            if (check[4])
            {
                topingMedan[4].SetActive(true);
                bubukKoyaMedan = true;
            }
            if (check[5])
            {
                topingMedan[5].SetActive(true);
                ayamSemurSantanMedan = true;
            }
            if (check[6])
            {
                topingMedan[6].SetActive(true);
                bawangGorengMedan = true;
            }
            if (check[7])
            {
                topingMedan[7].SetActive(true);
                bihunMedan = true;
            }
            if (check[8])
            {
                topingMedan[8].SetActive(true);
                keringKentangMedan = true;  
            }
            if (check[9])
            {
                topingMedan[9].SetActive(true);
                kuahMedan = true;
            }
            if (check[10])
            {
                topingMedan[10].SetActive(true);
                taucoMedan = true;
            }
            if (check[11])
            {
                topingMedan[11].SetActive(true);
                sambalMedan = true;
            }
            if (check[12])
            {
                topingMedan[12].SetActive(true);
                telurBaladoMedan = true;
            }
        }

    }
    void GerakIndikator()
    {
        if (gerakIndikator)
        {
            transform.Translate(Vector2.right * kecepatanIndikator * Time.deltaTime * direction);
            if (transform.position.x > maxX)
            {
                direction = -1;
            }
            if (transform.position.x < minX)
            {
                direction = 1;
            }
        }
    }
    public void ResetToping()
    {
        sM.EfekSuaraTombol();
        topingSayurPadang[1].SetActive(false);
        topingSayurPadang[2].SetActive(false);
        topingSayurPadang[3].SetActive(false);
        topingSayurPadang[4].SetActive(false);
        topingSayurPadang[5].SetActive(false);
        topingSayurPadang[6].SetActive(false);
        topingSayurPadang[7].SetActive(false);

        topingSayurBetawi[1].SetActive(false);
        topingSayurBetawi[2].SetActive(false);
        topingSayurBetawi[3].SetActive(false);
        topingSayurBetawi[4].SetActive(false);
        topingSayurBetawi[5].SetActive(false);
        topingSayurBetawi[6].SetActive(false);
        topingSayurBetawi[7].SetActive(false);
        topingSayurBetawi[8].SetActive(false);

        topingCapGoMeh[1].SetActive(false);
        topingCapGoMeh[2].SetActive(false);
        topingCapGoMeh[3].SetActive(false);
        topingCapGoMeh[4].SetActive(false);
        topingCapGoMeh[5].SetActive(false);
        topingCapGoMeh[6].SetActive(false);
        topingCapGoMeh[7].SetActive(false);
        topingCapGoMeh[8].SetActive(false);
        topingCapGoMeh[9].SetActive(false);
        topingCapGoMeh[10].SetActive(false);

        topingMedan[1].SetActive(false);
        topingMedan[2].SetActive(false);
        topingMedan[3].SetActive(false);
        topingMedan[4].SetActive(false);
        topingMedan[5].SetActive(false);
        topingMedan[6].SetActive(false);
        topingMedan[7].SetActive(false);
        topingMedan[8].SetActive(false);
        topingMedan[9].SetActive(false);
        topingMedan[10].SetActive(false);
        topingMedan[11].SetActive(false);
        topingMedan[12].SetActive(false);

        //Padang
        bawang = false;
        cabai = false;
        cabai2 = false;
        nangka = false;
        kerupuk = false;
        telor = false;
        telor2 = false;
        buncis = false;

        jumCabai = 0;
        jumTelor = 0;

        //Betawi
        labuSiamBetawi = false;
        kacangPanjangBetawi = false;
        irisanTahuBetawi = false;
        irisanTempeBetawi = false;
        kuahBetawi = false;
        telurRebusBetawi = false;
        kerupukBetawi = false;
        bawangGorengBetawi = false;

        //CapGoMeh
        oporAyamCapGoMeh = false;
        sambalGorengAtiAmpelaCapGoMeh = false;
        acarCapGoMeh = false; 
        kerupukCapGoMeh = false;
        bubukKoyaCapGoMeh = false; 
        telurPetisCapGoMeh = false; 
        sambalGodokCapGoMeh = false; 
        abonSapiCapGoMeh = false; 
        sayurLodehCapGoMeh = false; 
        udangCapGoMeh = false;

        //Medan
        labuSiamMedan = false; 
        ayamSemurSantanMedan = false;
        bubukKoyaMedan = false;
        taucoMedan = false;
        sambalMedan = false; 
        telurBaladoMedan = false;
        rendangDagingMedan = false; 
        keringKentangMedan = false; 
        kerupukMedan = false; 
        bawangGorengMedan = false;
        kuahMedan = false; 
        bihunMedan = false;
    }

    public void ResetTopingUI()
    {
        sM.EfekSuaraTombol();
        resetTopingUI.SetActive(true);
    }
    public void ResetTopingUIIya()
    {
        sM.EfekSuaraTombol();
        ResetToping();
        resetTopingUI.SetActive(false);
        
    }
    public void ResetTopingUITidak()
    {
        sM.EfekSuaraTombol();
        resetTopingUI.SetActive(false);
    }
    public void PilihTopingUI()
    {
        sM.EfekSuaraTombol();
        pilihTopingUI.SetActive(true);

    }
    public void KeluarPilihTopingUI()
    {
        sM.EfekSuaraTombol();
        pilihTopingUI.SetActive(false);

    }


    public void TopingSayurPadang()
    {
        sM.EfekSuaraTombol();
        transform.position = new Vector3(-3.01f, transform.position.y, transform.position.z);
        minX = -3.01f;
        maxX = 2.93f;

        topingSayurPadangUI.SetActive(true);
        topingSayurBetawiUI.SetActive(false);
        topingCapGoMehUI.SetActive(false);
        topingMedanUI.SetActive(false);

        topingSayurPadangBool = true;
        topingSayurBetawiBool = false;
        topingCapGoMehBool = false;
        topingMedanBool = false;

        BarTopingSayurPadang.SetActive(true);
        BarTopingSayurBetawi.SetActive(false);
        BarTopingCapGoMeh.SetActive(false);
        BarTopingMedan.SetActive(false);

        pilihTopingUI.SetActive(false);

    }
    public void TopingSayurBetawi()
    {
        sM.EfekSuaraTombol();
        transform.position = new Vector3(-3.8f, transform.position.y, transform.position.z);
        minX = -3.8f;
        maxX = 4.1f;

        topingSayurPadangUI.SetActive(false);
        topingSayurBetawiUI.SetActive(true);
        topingCapGoMehUI.SetActive(false);
        topingMedanUI.SetActive(false);

        topingSayurPadangBool = false;
        topingSayurBetawiBool = true;
        topingCapGoMehBool = false;
        topingMedanBool = false;

        BarTopingSayurPadang.SetActive(false);
        BarTopingSayurBetawi.SetActive(true);
        BarTopingCapGoMeh.SetActive(false);
        BarTopingMedan.SetActive(false);

        pilihTopingUI.SetActive(false);
    }
    public void TopingCapGoMeh()
    {
        sM.EfekSuaraTombol();
        transform.position = new Vector3(-4.84f, transform.position.y, transform.position.z);
        minX = -4.84f;
        maxX = 5.06f;

        topingSayurPadangUI.SetActive(false);
        topingSayurBetawiUI.SetActive(false);
        topingCapGoMehUI.SetActive(true);
        topingMedanUI.SetActive(false);

        topingSayurPadangBool = false;
        topingSayurBetawiBool = false;
        topingCapGoMehBool = true;
        topingMedanBool = false;

        BarTopingSayurPadang.SetActive(false);
        BarTopingSayurBetawi.SetActive(false);
        BarTopingCapGoMeh.SetActive(true);
        BarTopingMedan.SetActive(false);

        pilihTopingUI.SetActive(false);
    }
    public void TopingMedan()
    {
        sM.EfekSuaraTombol();
        transform.position = new Vector3(-5.84f, transform.position.y, transform.position.z);
        minX = -5.84f;
        maxX = 6.12f;

        topingSayurPadangUI.SetActive(false);
        topingSayurBetawiUI.SetActive(false);
        topingCapGoMehUI.SetActive(false);
        topingMedanUI.SetActive(true);

        topingSayurPadangBool = false;
        topingSayurBetawiBool = false;
        topingCapGoMehBool = false;
        topingMedanBool = true;

        BarTopingSayurPadang.SetActive(false);
        BarTopingSayurBetawi.SetActive(false);
        BarTopingCapGoMeh.SetActive(false);
        BarTopingMedan.SetActive(true);

        pilihTopingUI.SetActive(false);
    }
}
