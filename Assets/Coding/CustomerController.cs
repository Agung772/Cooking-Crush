using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CustomerController : MonoBehaviour
{
    public float minX, maxX, tengahX, kecepatanCustomer, direction;
    public int harga;

    public string menu1 = "Toping Sayur Padang";
    public bool tanpaBawang, tanpaCabai, cabaiNya2, tanpaNangka, tanpaKerupuk, tanpaTelor, telorNya2, tanpaBuncis, lontongPadang;

    public string menu2 = "Toping Sayur Betawi";
    public bool tanpaLabuSiamBetawi, tanpaKacangPanjangBetawi, tanpaIrisanTahuBetawi, tanpaIrisanTempeBetawi, tanpaKuahBetawi, tanpaTelurRebusBetawi, tanpaKerupukBetawi, tanpaBawangGorengBetawi;

    public string menu3 = "Toping Cap Go Meh";
    public bool tanpaOporAyamCapGoMeh, tanpaSambalGorengAtiAmpelaCapGoMeh, tanpaAcarCapGoMeh, tanpaKerupukCapGoMeh, tanpaBubukKedelaiCapGoMeh, tanpaTelurPetisCapGoMeh, tanpaSambalGodokCapGoMeh, tanpaAbonSapiCapGoMeh, tanpaSayurLodehCapGoMeh, tanpaBubukKoyaCapGoMeh;

    public string menu4 = "Toping Medan";
    public bool tanpaLabuSiamMedan, tanpaAyamSemurSantanMedan, tanpaBubukKoyaMedan, tanpaTaucoMedan, tanpaSambalMedan, tanpaTelurBaladoMedan, tanpaRendangDagingMedan, tanpaKeringKentangMedan, tanpaKerupukMedan, tanpaBawangGorengMedan, tanpaKuahMedan, tanpaBihunMedan;

    public string EngineCustomer = "Engine Customer";
    public bool prosesPesanan, moveCustomer, boolTengahX, pesananSelesai, pesananSalah, moveKeKiri, moveKeKanan;
    public GameObject pesananCustomerUI, topingUI, sceneCustomer;
    public GameObject summonBarEmosi;
    public TextMeshProUGUI pesananCustomerText;
    public string pesanan, pesananDiToping;
    public float timerAnimasi, resetTimerAnimasi, directionAnimasi, kecepatanAnimasi;
    LayerCustomer lCustomer;
    IndikatorController iController;
    SummonBarEmosi sBE;
    GameController gC;
    public Vector3 letakAwal, letakTengah, letakAkhir, letakSaatIni;
    // Start is called before the first frame update
    void Start()
    {
        gC = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        sBE = summonBarEmosi.GetComponent<SummonBarEmosi>();
        lCustomer = gameObject.GetComponent<LayerCustomer>();
        lCustomer = FindObjectOfType<LayerCustomer>();
        iController = FindObjectOfType<IndikatorController>();
        direction = 1;
        tengahX = Random.Range(-7, 0);
        letakAwal = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        
        timerAnimasi -= Time.deltaTime;

    }
    private void FixedUpdate()
    {
        MoveCustumer();
        ControllerCustomer();
        BatasY();

    }

    void BatasY()
    {
        letakSaatIni = transform.position;
        if(letakSaatIni.y < -2.2f)
        {
            letakSaatIni.y = -2.2f;
        }
        if (letakSaatIni.y > -1.8f)
        {
            letakSaatIni.y = -1.8f;
        }
        transform.position = letakSaatIni;
    }
    void MoveCustumer()
    {

    }

    void ControllerCustomer()
    {
        if (moveKeKanan)
        {
            direction = 1;
            if (moveCustomer)
            {
                transform.Translate(Vector2.right * kecepatanCustomer * Time.deltaTime * direction);
                transform.Translate(Vector2.down * kecepatanAnimasi * Time.deltaTime * directionAnimasi);
                if (timerAnimasi < 0)
                {
                    directionAnimasi *= -1;
                    timerAnimasi = resetTimerAnimasi;
                }

            }
            if (transform.position.x > tengahX && !boolTengahX)
            {
                //letakTengah.x = transform.position.x;
                //letakTengah.y = -2f;
                //letakTengah.z = transform.position.z;
                //transform.position = Vector3.MoveTowards(transform.position, letakTengah, 100 * Time.deltaTime);
                moveCustomer = false;
                boolTengahX = true;
                pesananCustomerUI.SetActive(true);
                sBE.SummonLagiBarEmosi();
                


            }
            if (transform.position.x > maxX)
            {
                directionAnimasi = 1;
                gameObject.transform.position = new Vector3(transform.position.x, -1.506977f, transform.position.z);
                letakAkhir = transform.position;
                moveCustomer = false;
                gameObject.SetActive(false);
                moveKeKanan = false;
                moveKeKiri = true;
                boolTengahX = false;
                


            }

        }

        if (moveKeKiri)
        {
            direction = -1;
            if (moveCustomer)
            {
                transform.Translate(Vector2.right * kecepatanCustomer * Time.deltaTime * direction);
                transform.Translate(Vector2.down * kecepatanAnimasi * Time.deltaTime * directionAnimasi);
                if (timerAnimasi < 0)
                {
                    directionAnimasi *= -1;
                    timerAnimasi = resetTimerAnimasi;
                }

            }
            if (transform.position.x < tengahX && !boolTengahX)
            {
                //letakTengah.x = transform.position.x;
                //letakTengah.y = -2f;
                //letakTengah.z = transform.position.z;
                //transform.position = Vector3.MoveTowards(transform.position, letakTengah, 100 * Time.deltaTime);
                moveCustomer = false;
                boolTengahX = true;
                pesananCustomerUI.SetActive(true);
                sBE.SummonLagiBarEmosi();
                

            }
            if (transform.position.x < minX)
            {
                directionAnimasi = 1;
                gameObject.transform.position = new Vector3(transform.position.x, -1.506977f, transform.position.z);
                letakAkhir = transform.position;
                moveCustomer = false;
                gameObject.SetActive(false);
                moveKeKanan = true;
                moveKeKiri = false;
                boolTengahX = false;
                
            }

        }

    }
    public void MasukSceneToping()
    {

        topingUI.SetActive(true);
        lCustomer.ZBelakang();
        pesananCustomerUI.SetActive(false);
        
        iController.gerakIndikator = true;

    }



    public void PesananCustomer()
    {
        if (prosesPesanan)
        {
            
            if (tanpaBawang)
            {
                if (!iController.bawang && iController.cabai && !iController.cabai2 && iController.nangka && iController.kerupuk && iController.telor && !iController.telor2 && iController.buncis)
                {
                    print("Pesanan Selesai");
                    pesananSelesai = true;
                }
                else
                {
                    print("Pesanan Salah");
                    pesananSalah = true;
                }
            }
            if (tanpaBuncis)
            {
                if (iController.bawang && iController.cabai && !iController.cabai2 && iController.nangka && iController.kerupuk && iController.telor && !iController.telor2 && !iController.buncis)
                {
                    print("Pesanan Selesai");
                    pesananSelesai = true;
                }
                else
                {
                    print("Pesanan Salah");
                    pesananSalah = true;

                }
            }
            if (tanpaCabai)
            {
                if (iController.bawang && !iController.cabai && !iController.cabai2 && iController.nangka && iController.kerupuk && iController.telor && !iController.telor2 && iController.buncis)
                {
                    print("Pesanan Selesai");
                    pesananSelesai = true;
                }
                else
                {
                    print("Pesanan Salah");
                    pesananSalah = true;

                }
            }

            if (cabaiNya2)
            {
                if (iController.bawang && iController.cabai && iController.cabai2 && iController.nangka && iController.kerupuk && iController.telor && !iController.telor2 && iController.buncis)
                {
                    print("Pesanan Selesai");
                    pesananSelesai = true;
                }
                else
                {
                    print("Pesanan Salah");
                    pesananSalah = true;

                }
            }
            if (tanpaKerupuk)
            {
                if (iController.bawang && iController.cabai && !iController.cabai2 && iController.nangka && !iController.kerupuk && iController.telor && !iController.telor2 && iController.buncis)
                {
                    print("Pesanan Selesai");
                    pesananSelesai = true;
                }
                else
                {
                    print("Pesanan Salah");
                    pesananSalah = true;

                }
            }
            if (tanpaNangka)
            {
                if (iController.bawang && iController.cabai && !iController.cabai2 && !iController.nangka && iController.kerupuk && iController.telor && !iController.telor2 && iController.buncis)
                {
                    print("Pesanan Selesai");
                    pesananSelesai = true;
                }
                else
                {
                    print("Pesanan Salah");
                    pesananSalah = true;

                }
            }
            if (tanpaTelor)
            {
                if (iController.bawang && iController.cabai && !iController.cabai2 && iController.nangka && iController.kerupuk && !iController.telor && !iController.telor2 && iController.buncis)
                {
                    print("Pesanan Selesai");
                    pesananSelesai = true;
                }
                else
                {
                    print("Pesanan Salah");
                    pesananSalah = true;

                }
            }

            if (telorNya2)
            {
                if (iController.bawang && iController.cabai && !iController.cabai2 && iController.nangka && iController.kerupuk && iController.telor && iController.telor2 && iController.buncis)
                {
                    print("Pesanan Selesai");
                    pesananSelesai = true;
                }
                else
                {
                    print("Pesanan Salah");
                    pesananSalah = true;

                }
            }

            if (lontongPadang)
            {
                if (iController.bawang && iController.cabai && !iController.cabai2 && iController.nangka && iController.kerupuk && iController.telor && !iController.telor2 && iController.buncis)
                {
                    print("Pesanan Selesai");
                    pesananSelesai = true;
                }
                else
                {
                    print("Pesanan Salah");
                    pesananSalah = true;

                }
            }
            //Lontong Betawi
            if (tanpaLabuSiamBetawi)
            {
                if (!iController.labuSiamBetawi && iController.kacangPanjangBetawi && iController.irisanTahuBetawi && iController.irisanTempeBetawi && iController.kuahBetawi && iController.telurRebusBetawi && iController.kerupukBetawi && iController.bawangGorengBetawi)
                {
                    pesananSelesai = true;
                }
                else
                {
                    pesananSalah = true;
                }
            }

            if (tanpaKacangPanjangBetawi)
            {
                if (iController.labuSiamBetawi && !iController.kacangPanjangBetawi && iController.irisanTahuBetawi && iController.irisanTempeBetawi && iController.kuahBetawi && iController.telurRebusBetawi && iController.kerupukBetawi && iController.bawangGorengBetawi)
                {
                    pesananSelesai = true;
                }
                else
                {
                    pesananSalah = true;
                }
            }

            if (tanpaIrisanTahuBetawi)
            {
                if (iController.labuSiamBetawi && iController.kacangPanjangBetawi && !iController.irisanTahuBetawi && iController.irisanTempeBetawi && iController.kuahBetawi && iController.telurRebusBetawi && iController.kerupukBetawi && iController.bawangGorengBetawi)
                {
                    pesananSelesai = true;
                }
                else
                {
                    pesananSalah = true;
                }
            }

            if (tanpaIrisanTempeBetawi)
            {
                if (iController.labuSiamBetawi && iController.kacangPanjangBetawi && iController.irisanTahuBetawi && !iController.irisanTempeBetawi && iController.kuahBetawi && iController.telurRebusBetawi && iController.kerupukBetawi && iController.bawangGorengBetawi)
                {
                    pesananSelesai = true;
                }
                else
                {
                    pesananSalah = true;
                }
            }

            if (tanpaKuahBetawi)
            {
                if (iController.labuSiamBetawi && iController.kacangPanjangBetawi && iController.irisanTahuBetawi && iController.irisanTempeBetawi && !iController.kuahBetawi && iController.telurRebusBetawi && iController.kerupukBetawi && iController.bawangGorengBetawi)
                {
                    pesananSelesai = true;
                }
                else
                {
                    pesananSalah = true;
                }
            }

            if (tanpaTelurRebusBetawi)
            {
                if (iController.labuSiamBetawi && iController.kacangPanjangBetawi && iController.irisanTahuBetawi && iController.irisanTempeBetawi && iController.kuahBetawi && !iController.telurRebusBetawi && iController.kerupukBetawi && iController.bawangGorengBetawi)
                {
                    pesananSelesai = true;
                }
                else
                {
                    pesananSalah = true;
                }
            }

            if (tanpaKerupukBetawi)
            {
                if (iController.labuSiamBetawi && iController.kacangPanjangBetawi && iController.irisanTahuBetawi && iController.irisanTempeBetawi && iController.kuahBetawi && iController.telurRebusBetawi && !iController.kerupukBetawi && iController.bawangGorengBetawi)
                {
                    pesananSelesai = true;
                }
                else
                {
                    pesananSalah = true;
                }
            }

            if (tanpaBawangGorengBetawi)
            {
                if (iController.labuSiamBetawi && iController.kacangPanjangBetawi && iController.irisanTahuBetawi && iController.irisanTempeBetawi && iController.kuahBetawi && iController.telurRebusBetawi && iController.kerupukBetawi && !iController.bawangGorengBetawi)
                {
                    pesananSelesai = true;
                }
                else
                {
                    pesananSalah = true;
                }
            }
            //Lontong CapGoMeh

            if (tanpaOporAyamCapGoMeh)
            {
                if (!iController.oporAyamCapGoMeh && iController.sambalGorengAtiAmpelaCapGoMeh && iController.acarCapGoMeh && iController.kerupukCapGoMeh && iController.bubukKoyaCapGoMeh && iController.telurPetisCapGoMeh && iController.sambalGodokCapGoMeh && iController.abonSapiCapGoMeh && iController.sayurLodehCapGoMeh && iController.udangCapGoMeh)
                {
                    pesananSelesai = true;
                }
                else
                {
                    pesananSalah = true;
                }
            }

            if (tanpaSambalGorengAtiAmpelaCapGoMeh)
            {
                if (iController.oporAyamCapGoMeh && !iController.sambalGorengAtiAmpelaCapGoMeh && iController.acarCapGoMeh && iController.kerupukCapGoMeh && iController.bubukKoyaCapGoMeh && iController.telurPetisCapGoMeh && iController.sambalGodokCapGoMeh && iController.abonSapiCapGoMeh && iController.sayurLodehCapGoMeh && iController.udangCapGoMeh)
                {
                    pesananSelesai = true;
                }
                else
                {
                    pesananSalah = true;
                }
            }

            if (tanpaAcarCapGoMeh)
            {
                if (iController.oporAyamCapGoMeh && iController.sambalGorengAtiAmpelaCapGoMeh && !iController.acarCapGoMeh && iController.kerupukCapGoMeh && iController.bubukKoyaCapGoMeh && iController.telurPetisCapGoMeh && iController.sambalGodokCapGoMeh && iController.abonSapiCapGoMeh && iController.sayurLodehCapGoMeh && iController.udangCapGoMeh)
                {
                    pesananSelesai = true;
                }
                else
                {
                    pesananSalah = true;
                }
            }

            if (tanpaKerupukCapGoMeh)
            {
                if (iController.oporAyamCapGoMeh && iController.sambalGorengAtiAmpelaCapGoMeh && iController.acarCapGoMeh && !iController.kerupukCapGoMeh && iController.bubukKoyaCapGoMeh && iController.telurPetisCapGoMeh && iController.sambalGodokCapGoMeh && iController.abonSapiCapGoMeh && iController.sayurLodehCapGoMeh && iController.udangCapGoMeh)
                {
                    pesananSelesai = true;
                }
                else
                {
                    pesananSalah = true;
                }
            }

            if (tanpaBubukKedelaiCapGoMeh)
            {
                if (iController.oporAyamCapGoMeh && iController.sambalGorengAtiAmpelaCapGoMeh && iController.acarCapGoMeh && iController.kerupukCapGoMeh && !iController.bubukKoyaCapGoMeh && iController.telurPetisCapGoMeh && iController.sambalGodokCapGoMeh && iController.abonSapiCapGoMeh && iController.sayurLodehCapGoMeh && iController.udangCapGoMeh)
                {
                    pesananSelesai = true;
                }
                else
                {
                    pesananSalah = true;
                }
            }

            if (tanpaTelurPetisCapGoMeh)
            {
                if (iController.oporAyamCapGoMeh && iController.sambalGorengAtiAmpelaCapGoMeh && iController.acarCapGoMeh && iController.kerupukCapGoMeh && iController.bubukKoyaCapGoMeh && !iController.telurPetisCapGoMeh && iController.sambalGodokCapGoMeh && iController.abonSapiCapGoMeh && iController.sayurLodehCapGoMeh && iController.udangCapGoMeh)
                {
                    pesananSelesai = true;
                }
                else
                {
                    pesananSalah = true;
                }
            }

            if (tanpaSambalGodokCapGoMeh)
            {
                if (iController.oporAyamCapGoMeh && iController.sambalGorengAtiAmpelaCapGoMeh && iController.acarCapGoMeh && iController.kerupukCapGoMeh && iController.bubukKoyaCapGoMeh && iController.telurPetisCapGoMeh && !iController.sambalGodokCapGoMeh && iController.abonSapiCapGoMeh && iController.sayurLodehCapGoMeh && iController.udangCapGoMeh)
                {
                    pesananSelesai = true;
                }
                else
                {
                    pesananSalah = true;
                }
            }

            if (tanpaAbonSapiCapGoMeh)
            {
                if (iController.oporAyamCapGoMeh && iController.sambalGorengAtiAmpelaCapGoMeh && iController.acarCapGoMeh && iController.kerupukCapGoMeh && iController.bubukKoyaCapGoMeh && iController.telurPetisCapGoMeh && iController.sambalGodokCapGoMeh && !iController.abonSapiCapGoMeh && iController.sayurLodehCapGoMeh && iController.udangCapGoMeh)
                {
                    pesananSelesai = true;
                }
                else
                {
                    pesananSalah = true;
                }
            }

            if (tanpaSayurLodehCapGoMeh)
            {
                if (iController.oporAyamCapGoMeh && iController.sambalGorengAtiAmpelaCapGoMeh && iController.acarCapGoMeh && iController.kerupukCapGoMeh && iController.bubukKoyaCapGoMeh && iController.telurPetisCapGoMeh && iController.sambalGodokCapGoMeh && iController.abonSapiCapGoMeh && !iController.sayurLodehCapGoMeh && iController.udangCapGoMeh)
                {
                    pesananSelesai = true;
                }
                else
                {
                    pesananSalah = true;
                }
            }

            if (tanpaBubukKoyaCapGoMeh)
            {
                if (iController.oporAyamCapGoMeh && iController.sambalGorengAtiAmpelaCapGoMeh && iController.acarCapGoMeh && iController.kerupukCapGoMeh && iController.bubukKoyaCapGoMeh && iController.telurPetisCapGoMeh && iController.sambalGodokCapGoMeh && iController.abonSapiCapGoMeh && iController.sayurLodehCapGoMeh && !iController.udangCapGoMeh)
                {
                    pesananSelesai = true;
                }
                else
                {
                    pesananSalah = true;
                }
            }
            //Lontong Medan

            if (tanpaLabuSiamMedan)
            {
                if (!iController.labuSiamMedan && iController.ayamSemurSantanMedan && iController.bubukKoyaMedan && iController.taucoMedan && iController.sambalMedan && iController.telurBaladoMedan && iController.rendangDagingMedan && iController.keringKentangMedan && iController.kerupukMedan && iController.bawangGorengMedan && iController.kuahMedan && iController.bihunMedan)
                {
                    pesananSelesai = true;
                }
                else
                {
                    pesananSalah = true;
                }
            }

            if (tanpaAyamSemurSantanMedan)
            {
                if (iController.labuSiamMedan && !iController.ayamSemurSantanMedan && iController.bubukKoyaMedan && iController.taucoMedan && iController.sambalMedan && iController.telurBaladoMedan && iController.rendangDagingMedan && iController.keringKentangMedan && iController.kerupukMedan && iController.bawangGorengMedan && iController.kuahMedan && iController.bihunMedan)
                {
                    pesananSelesai = true;
                }
                else
                {
                    pesananSalah = true;
                }
            }

            if (tanpaBubukKoyaMedan)
            {
                if (iController.labuSiamMedan && iController.ayamSemurSantanMedan && !iController.bubukKoyaMedan && iController.taucoMedan && iController.sambalMedan && iController.telurBaladoMedan && iController.rendangDagingMedan && iController.keringKentangMedan && iController.kerupukMedan && iController.bawangGorengMedan && iController.kuahMedan && iController.bihunMedan)
                {
                    pesananSelesai = true;
                }
                else
                {
                    pesananSalah = true;
                }
            }

            if (tanpaTaucoMedan)
            {
                if (iController.labuSiamMedan && iController.ayamSemurSantanMedan && iController.bubukKoyaMedan && !iController.taucoMedan && iController.sambalMedan && iController.telurBaladoMedan && iController.rendangDagingMedan && iController.keringKentangMedan && iController.kerupukMedan && iController.bawangGorengMedan && iController.kuahMedan && iController.bihunMedan)
                {
                    pesananSelesai = true;
                }
                else
                {
                    pesananSalah = true;
                }
            }

            if (tanpaSambalMedan)
            {
                if (iController.labuSiamMedan && iController.ayamSemurSantanMedan && iController.bubukKoyaMedan && iController.taucoMedan && !iController.sambalMedan && iController.telurBaladoMedan && iController.rendangDagingMedan && iController.keringKentangMedan && iController.kerupukMedan && iController.bawangGorengMedan && iController.kuahMedan && iController.bihunMedan)
                {
                    pesananSelesai = true;
                }
                else
                {
                    pesananSalah = true;
                }
            }

            if (tanpaTelurBaladoMedan)
            {
                if (iController.labuSiamMedan && iController.ayamSemurSantanMedan && iController.bubukKoyaMedan && iController.taucoMedan && iController.sambalMedan && !iController.telurBaladoMedan && iController.rendangDagingMedan && iController.keringKentangMedan && iController.kerupukMedan && iController.bawangGorengMedan && iController.kuahMedan && iController.bihunMedan)
                {
                    pesananSelesai = true;
                }
                else
                {
                    pesananSalah = true;
                }
            }

            if (tanpaRendangDagingMedan)
            {
                if (iController.labuSiamMedan && iController.ayamSemurSantanMedan && iController.bubukKoyaMedan && iController.taucoMedan && iController.sambalMedan && iController.telurBaladoMedan && !iController.rendangDagingMedan && iController.keringKentangMedan && iController.kerupukMedan && iController.bawangGorengMedan && iController.kuahMedan && iController.bihunMedan)
                {
                    pesananSelesai = true;
                }
                else
                {
                    pesananSalah = true;
                }
            }

            if (tanpaKeringKentangMedan)
            {
                if (iController.labuSiamMedan && iController.ayamSemurSantanMedan && iController.bubukKoyaMedan && iController.taucoMedan && iController.sambalMedan && iController.telurBaladoMedan && iController.rendangDagingMedan && !iController.keringKentangMedan && iController.kerupukMedan && iController.bawangGorengMedan && iController.kuahMedan && iController.bihunMedan)
                {
                    pesananSelesai = true;
                }
                else
                {
                    pesananSalah = true;
                }
            }

            if (tanpaKerupukMedan)
            {
                if (iController.labuSiamMedan && iController.ayamSemurSantanMedan && iController.bubukKoyaMedan && iController.taucoMedan && iController.sambalMedan && iController.telurBaladoMedan && iController.rendangDagingMedan && iController.keringKentangMedan && !iController.kerupukMedan && iController.bawangGorengMedan && iController.kuahMedan && iController.bihunMedan)
                {
                    pesananSelesai = true;
                }
                else
                {
                    pesananSalah = true;
                }
            }

            if (tanpaBawangGorengMedan)
            {
                if (iController.labuSiamMedan && iController.ayamSemurSantanMedan && iController.bubukKoyaMedan && iController.taucoMedan && iController.sambalMedan && iController.telurBaladoMedan && iController.rendangDagingMedan && iController.keringKentangMedan && iController.kerupukMedan && !iController.bawangGorengMedan && iController.kuahMedan && iController.bihunMedan)
                {
                    pesananSelesai = true;
                }
                else
                {
                    pesananSalah = true;
                }
            }

            if (tanpaKuahMedan)
            {
                if (iController.labuSiamMedan && iController.ayamSemurSantanMedan && iController.bubukKoyaMedan && iController.taucoMedan && iController.sambalMedan && iController.telurBaladoMedan && iController.rendangDagingMedan && iController.keringKentangMedan && iController.kerupukMedan && iController.bawangGorengMedan && !iController.kuahMedan && iController.bihunMedan)
                {
                    pesananSelesai = true;
                }
                else
                {
                    pesananSalah = true;
                }
            }

            if (tanpaBihunMedan)
            {
                if (iController.labuSiamMedan && iController.ayamSemurSantanMedan && iController.bubukKoyaMedan && iController.taucoMedan && iController.sambalMedan && iController.telurBaladoMedan && iController.rendangDagingMedan && iController.keringKentangMedan && iController.kerupukMedan && iController.bawangGorengMedan && iController.kuahMedan && !iController.bihunMedan)
                {
                    pesananSelesai = true;
                }
                else
                {
                    pesananSalah = true;
                }
            }

        }

    }

}
