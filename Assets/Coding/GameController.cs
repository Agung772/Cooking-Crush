using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour
{
    public int iniLevelBerapa;
    public GameObject[] Customer;
    public bool hentikanGerakCustomer;  
    public int jumRandom, totalUang, pendapatanEmosiCustomer;
    public float random;
    public bool[] nomorCustomer;
    public bool[] nomorEmosi;
    public GameObject topingUI, pesananDiTopingUI, semuaToping, tampilanMulaiGame, tampilanPause, bungkusMakanan, notifCustomerPergi, waktuLevelTelahHabis, mainMenu, keMainMenuVideoUI, pauseVideoButton, playVideoButton;
    public TextMeshProUGUI pesananDiTopingText;
    public Text uangText;
    public bool barEmosiHilang;
    
    LayerCustomer lCustomer;
    IndikatorController iController;
    IndikatorEmosiController iEC;
    CustomerController cController1;
    CustomerController cController2;
    CustomerController cController3;
    CustomerController cController4;
    CustomerController cController5;
    CustomerController cController6;
    CustomerController cController7;
    CustomerController cController8;
    CustomerController cController9;

    SoundManager sM;
    JamController jC;
    public GameObject soundManager, musik, mute, unmute;

    //Video
    public GameObject videoAwalLevel1, videoAwalLevel2, videoAwalLevel3, videoAwalLevel4, videoAwalLevel5;
    public GameObject videoAkhirLevel1, videoAkhirLevel2, videoAkhirLevel3, videoAkhirLevel4, videoAkhirLevel5;
    public VideoPlayer videoAwalLevel1VP, videoAwalLevel2VP, videoAwalLevel3VP, videoAwalLevel4VP, videoAwalLevel5VP;
    public VideoPlayer videoAkhirLevel1VP, videoAkhirLevel2VP, videoAkhirLevel3VP, videoAkhirLevel4VP, videoAkhirLevel5VP;


    public float timeVideoAwalLevel1, timeVideoAwalLevel2, timeVideoAwalLevel3, timeVideoAwalLevel4, timeVideoAwalLevel5;
    public float timeVideoAkhirLevel1, timeVideoAkhirLevel2, timeVideoAkhirLevel3, timeVideoAkhirLevel4, timeVideoAkhirLevel5;
    public int videoLevel1, videoLevel2, videoLevel3, videoLevel4, videoLevel5;
    bool matiinTimerVideoAwalLevel1, matiinTimerVideoAwalLevel2, matiinTimerVideoAwalLevel3, matiinTimerVideoAwalLevel4, matiinTimerVideoAwalLevel5;
    bool matiinTimerVideoAkhirLevel1, matiinTimerVideoAkhirLevel2, matiinTimerVideoAkhirLevel3, matiinTimerVideoAkhirLevel4, matiinTimerVideoAkhirLevel5;
    public bool VideoAwalLevel1Bool, VideoAwalLevel2Bool, VideoAwalLevel3Bool, VideoAwalLevel4Bool, VideoAwalLevel5Bool;
    public bool VideoAkhirLevel1Bool, VideoAkhirLevel2Bool, VideoAkhirLevel3Bool, VideoAkhirLevel4Bool, VideoAkhirLevel5Bool;
    // Start is called before the first frame update
    private void Awake()
    {
        
        totalUang = PlayerPrefs.GetInt("Uang");
        videoLevel1 = PlayerPrefs.GetInt("VideoLevel1");
        videoLevel2 = PlayerPrefs.GetInt("VideoLevel2");
        videoLevel3 = PlayerPrefs.GetInt("VideoLevel3");
        videoLevel4 = PlayerPrefs.GetInt("VideoLevel4");
        videoLevel5 = PlayerPrefs.GetInt("VideoLevel5");
        VideoSudahDiTonton();
        //random = Random.Range(1, 4);


    }
    void Start()
    {
        CekSaveVideoAwal();
        CekSaveVideoAkhir();


        hentikanGerakCustomer = false;
        jC = GameObject.FindGameObjectWithTag("JarumJam").GetComponent<JamController>();
        sM = soundManager.GetComponent<SoundManager>();
        cController1 = Customer[1].GetComponent<CustomerController>();
        cController2 = Customer[2].GetComponent<CustomerController>();
        cController3 = Customer[3].GetComponent<CustomerController>();
        cController4 = Customer[4].GetComponent<CustomerController>();
        cController5 = Customer[5].GetComponent<CustomerController>();
        cController6 = Customer[6].GetComponent<CustomerController>();
        cController7 = Customer[7].GetComponent<CustomerController>();
        cController8 = Customer[8].GetComponent<CustomerController>();
        cController9 = Customer[9].GetComponent<CustomerController>();

        lCustomer = FindObjectOfType<LayerCustomer>();
        iController = FindObjectOfType<IndikatorController>();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        AksesIEController();
        VideoManager();
        if (jumRandom == 7)
        {
            random = 1;
            nomorCustomer[1] = false;
            nomorEmosi[1] = false;
            Invoke("NomorCustomerDanNomorEmosiFalse", 4);
            jumRandom = 0;
        }

        uangText.text = ": " + totalUang;

        
    }

    void CheckRandomCustomer()
    {
        if (!hentikanGerakCustomer)
        {
            print("Customer Datang");
            if (random == 1 && !nomorCustomer[1])
            {
                Customer[1].SetActive(true);
                Customer[1].GetComponent<CustomerController>().moveCustomer = true;
                nomorCustomer[1] = true;
                cController1.prosesPesanan = true;
                cController1.pesananCustomerText.text = cController1.pesanan;
                cController1.pesananDiToping = cController1.pesanan;
                pesananDiTopingText.text = cController1.pesananDiToping;


            }
            else if (random == 2 && !nomorCustomer[2])
            {
                Customer[2].SetActive(true);
                Customer[2].GetComponent<CustomerController>().moveCustomer = true;
                nomorCustomer[2] = true;
                cController2.prosesPesanan = true;
                cController2.pesananCustomerText.text = cController2.pesanan;
                cController2.pesananDiToping = cController2.pesanan;
                pesananDiTopingText.text = cController2.pesananDiToping;

            }
            else if (random == 3 && !nomorCustomer[3])
            {
                Customer[3].SetActive(true);
                Customer[3].GetComponent<CustomerController>().moveCustomer = true;
                nomorCustomer[3] = true;
                cController3.prosesPesanan = true;
                cController3.pesananCustomerText.text = cController3.pesanan;
                cController3.pesananDiToping = cController3.pesanan;
                pesananDiTopingText.text = cController3.pesananDiToping;

            }
            else if (random == 4 && !nomorCustomer[4])
            {
                Customer[4].SetActive(true);
                Customer[4].GetComponent<CustomerController>().moveCustomer = true;
                nomorCustomer[4] = true;
                cController4.prosesPesanan = true;
                cController4.pesananCustomerText.text = cController4.pesanan;
                cController4.pesananDiToping = cController4.pesanan;
                pesananDiTopingText.text = cController4.pesananDiToping;

            }
            else if (random == 5 && !nomorCustomer[5])
            {
                Customer[5].SetActive(true);
                Customer[5].GetComponent<CustomerController>().moveCustomer = true;
                nomorCustomer[5] = true;
                cController5.prosesPesanan = true;
                cController5.pesananCustomerText.text = cController5.pesanan;
                cController5.pesananDiToping = cController5.pesanan;
                pesananDiTopingText.text = cController5.pesananDiToping;

            }
            else if (random == 6 && !nomorCustomer[6])
            {
                Customer[6].SetActive(true);
                Customer[6].GetComponent<CustomerController>().moveCustomer = true;
                nomorCustomer[6] = true;
                cController6.prosesPesanan = true;
                cController6.pesananCustomerText.text = cController6.pesanan;
                cController6.pesananDiToping = cController6.pesanan;
                pesananDiTopingText.text = cController6.pesananDiToping;

            }
            else if (random == 7 && !nomorCustomer[7])
            {
                Customer[7].SetActive(true);
                Customer[7].GetComponent<CustomerController>().moveCustomer = true;
                nomorCustomer[7] = true;
                cController7.prosesPesanan = true;
                cController7.pesananCustomerText.text = cController7.pesanan;
                cController7.pesananDiToping = cController7.pesanan;
                pesananDiTopingText.text = cController7.pesananDiToping;

            }
            else if (random == 8 && !nomorCustomer[8])
            {
                Customer[8].SetActive(true);
                Customer[8].GetComponent<CustomerController>().moveCustomer = true;
                nomorCustomer[8] = true;
                cController8.prosesPesanan = true;
                cController8.pesananCustomerText.text = cController8.pesanan;
                cController8.pesananDiToping = cController8.pesanan;
                pesananDiTopingText.text = cController8.pesananDiToping;

            }
            else if (random == 9 && !nomorCustomer[9])
            {
                Customer[9].SetActive(true);
                Customer[9].GetComponent<CustomerController>().moveCustomer = true;
                nomorCustomer[9] = true;
                cController9.prosesPesanan = true;
                cController9.pesananCustomerText.text = cController9.pesanan;
                cController9.pesananDiToping = cController9.pesanan;
                pesananDiTopingText.text = cController9.pesananDiToping;

            }

            else
            {
                random = Random.Range(1, 10);
                CheckRandomCustomer();
            }
        }

    }
    public void KeluarSceneToping()
    {
        sM.EfekSuaraTombol();

        topingUI.SetActive(false);
        lCustomer.ZDepan();
        
        iController.gerakIndikator = false;
        pesananDiTopingUI.SetActive(false);
        semuaToping.SetActive(false);
        if (!barEmosiHilang)
        {
            iEC.ZDepan();
        }
        if (nomorCustomer[1] == true)
        {
            
            cController1.PesananCustomer();

            if (cController1.pesananSelesai)
            {
                print("Iya bener");
                iEC.moveIndokator = false;
                cController1.prosesPesanan = false;
                cController1.pesananSelesai = false;
                
                Invoke("FalsePesananCustomerUI1", 2);
                
                cController1.pesananCustomerText.text = "Terimakasih";
                Invoke("RandomCustomer", 3);
                iController.ResetToping();
                cController1.pesananCustomerUI.SetActive(true);
                
                bungkusMakanan.SetActive(true);
                iEC.HapusBarEmosi();
                totalUang += cController1.harga;
                totalUang += pendapatanEmosiCustomer;
                SaveUang();
                jumRandom++;

            }
            if (cController1.pesananSalah)
            {
                print("Iya salah");
                Invoke("TextCustomer1", 2);
                cController1.pesananSalah = false;
                cController1.pesananCustomerUI.SetActive(true);
                cController1.pesananCustomerText.text = "Saya bukan pesan ini";
                
            }

        }
        if (nomorCustomer[2] == true)
        {
            
            cController2.PesananCustomer();
            if (cController2.pesananSelesai)
            {
                print("Iya bener");
                iEC.moveIndokator = false;
                cController2.prosesPesanan = false;
                cController2.pesananSelesai = false;

                Invoke("FalsePesananCustomerUI2", 2);

                cController2.pesananCustomerText.text = "Terimakasih";
                Invoke("RandomCustomer", 3);
                iController.ResetToping();
                cController2.pesananCustomerUI.SetActive(true);

                bungkusMakanan.SetActive(true);
                iEC.HapusBarEmosi();
                totalUang += cController2.harga;
                totalUang += pendapatanEmosiCustomer;
                SaveUang();
                jumRandom++;

            }
            if (cController2.pesananSalah)
            {
                print("Iya salah");
                Invoke("TextCustomer2", 2);
                cController2.pesananSalah = false;
                cController2.pesananCustomerUI.SetActive(true);
                cController2.pesananCustomerText.text = "Saya bukan pesan ini";

            }

        }
        if (nomorCustomer[3] == true)
        {
            
            cController3.PesananCustomer();
            if (cController3.pesananSelesai)
            {
                print("Iya bener");
                iEC.moveIndokator = false;
                cController3.prosesPesanan = false;
                cController3.pesananSelesai = false;

                Invoke("FalsePesananCustomerUI3", 2);

                cController3.pesananCustomerText.text = "Terimakasih";
                Invoke("RandomCustomer", 3);
                iController.ResetToping();
                cController3.pesananCustomerUI.SetActive(true);

                bungkusMakanan.SetActive(true);
                iEC.HapusBarEmosi();
                totalUang += cController3.harga;
                totalUang += pendapatanEmosiCustomer;
                SaveUang();
                jumRandom++;

            }
            if (cController3.pesananSalah)
            {
                print("Iya salah");
                Invoke("TextCustomer3", 2);
                cController3.pesananSalah = false;
                cController3.pesananCustomerUI.SetActive(true);
                cController3.pesananCustomerText.text = "Saya bukan pesan ini";

            }

        }

        if (nomorCustomer[4] == true)
        {

            cController4.PesananCustomer();
            if (cController4.pesananSelesai)
            {
                print("Iya bener");
                iEC.moveIndokator = false;
                cController4.prosesPesanan = false;
                cController4.pesananSelesai = false;

                Invoke("FalsePesananCustomerUI4", 2);

                cController4.pesananCustomerText.text = "Terimakasih";
                Invoke("RandomCustomer", 3);
                iController.ResetToping();
                cController4.pesananCustomerUI.SetActive(true);

                bungkusMakanan.SetActive(true);
                iEC.HapusBarEmosi();
                totalUang += cController4.harga;
                totalUang += pendapatanEmosiCustomer;
                SaveUang();
                jumRandom++;

            }
            if (cController4.pesananSalah)
            {
                print("Iya salah");
                Invoke("TextCustomer4", 2);
                cController4.pesananSalah = false;
                cController4.pesananCustomerUI.SetActive(true);
                cController4.pesananCustomerText.text = "Saya bukan pesan ini";

            }

        }

        if (nomorCustomer[5] == true)
        {

            cController5.PesananCustomer();
            if (cController5.pesananSelesai)
            {
                print("Iya bener");
                iEC.moveIndokator = false;
                cController5.prosesPesanan = false;
                cController5.pesananSelesai = false;

                Invoke("FalsePesananCustomerUI5", 2);

                cController5.pesananCustomerText.text = "Terimakasih";
                Invoke("RandomCustomer", 3);
                iController.ResetToping();
                cController5.pesananCustomerUI.SetActive(true);

                bungkusMakanan.SetActive(true);
                iEC.HapusBarEmosi();
                totalUang += cController5.harga;
                totalUang += pendapatanEmosiCustomer;
                SaveUang();
                jumRandom++;

            }
            if (cController5.pesananSalah)
            {
                print("Iya salah");
                Invoke("TextCustomer5", 2);
                cController5.pesananSalah = false;
                cController5.pesananCustomerUI.SetActive(true);
                cController5.pesananCustomerText.text = "Saya bukan pesan ini";

            }

        }

        if (nomorCustomer[6] == true)
        {

            cController6.PesananCustomer();
            if (cController6.pesananSelesai)
            {
                print("Iya bener");
                iEC.moveIndokator = false;
                cController6.prosesPesanan = false;
                cController6.pesananSelesai = false;

                Invoke("FalsePesananCustomerUI6", 2);

                cController6.pesananCustomerText.text = "Terimakasih";
                Invoke("RandomCustomer", 3);
                iController.ResetToping();
                cController6.pesananCustomerUI.SetActive(true);

                bungkusMakanan.SetActive(true);
                iEC.HapusBarEmosi();
                totalUang += cController6.harga;
                totalUang += pendapatanEmosiCustomer;
                SaveUang();
                jumRandom++;

            }
            if (cController6.pesananSalah)
            {
                print("Iya salah");
                Invoke("TextCustomer6", 2);
                cController6.pesananSalah = false;
                cController6.pesananCustomerUI.SetActive(true);
                cController6.pesananCustomerText.text = "Saya bukan pesan ini";

            }

        }

        if (nomorCustomer[7] == true)
        {

            cController7.PesananCustomer();
            if (cController7.pesananSelesai)
            {
                print("Iya bener");
                iEC.moveIndokator = false;
                cController7.prosesPesanan = false;
                cController7.pesananSelesai = false;

                Invoke("FalsePesananCustomerUI7", 2);

                cController7.pesananCustomerText.text = "Terimakasih";
                Invoke("RandomCustomer", 3);
                iController.ResetToping();
                cController7.pesananCustomerUI.SetActive(true);

                bungkusMakanan.SetActive(true);
                iEC.HapusBarEmosi();
                totalUang += cController7.harga;
                totalUang += pendapatanEmosiCustomer;
                SaveUang();
                jumRandom++;

            }
            if (cController7.pesananSalah)
            {
                print("Iya salah");
                Invoke("TextCustomer7", 2);
                cController7.pesananSalah = false;
                cController7.pesananCustomerUI.SetActive(true);
                cController7.pesananCustomerText.text = "Saya bukan pesan ini";

            }

        }

        if (nomorCustomer[8] == true)
        {

            cController8.PesananCustomer();
            if (cController8.pesananSelesai)
            {
                print("Iya bener");
                iEC.moveIndokator = false;
                cController8.prosesPesanan = false;
                cController8.pesananSelesai = false;

                Invoke("FalsePesananCustomerUI8", 2);

                cController8.pesananCustomerText.text = "Terimakasih";
                Invoke("RandomCustomer", 3);
                iController.ResetToping();
                cController8.pesananCustomerUI.SetActive(true);

                bungkusMakanan.SetActive(true);
                iEC.HapusBarEmosi();
                totalUang += cController8.harga;
                totalUang += pendapatanEmosiCustomer;
                SaveUang();
                jumRandom++;

            }
            if (cController8.pesananSalah)
            {
                print("Iya salah");
                Invoke("TextCustomer8", 2);
                cController8.pesananSalah = false;
                cController8.pesananCustomerUI.SetActive(true);
                cController8.pesananCustomerText.text = "Saya bukan pesan ini";

            }

        }

        if (nomorCustomer[9] == true)
        {

            cController9.PesananCustomer();
            if (cController9.pesananSelesai)
            {
                print("Iya bener");
                iEC.moveIndokator = false;
                cController9.prosesPesanan = false;
                cController9.pesananSelesai = false;

                Invoke("FalsePesananCustomerUI9", 2);

                cController9.pesananCustomerText.text = "Terimakasih";
                Invoke("RandomCustomer", 3);
                iController.ResetToping();
                cController9.pesananCustomerUI.SetActive(true);

                bungkusMakanan.SetActive(true);
                iEC.HapusBarEmosi();
                totalUang += cController9.harga;
                totalUang += pendapatanEmosiCustomer;
                SaveUang();
                jumRandom++;

            }
            if (cController9.pesananSalah)
            {
                print("Iya salah");
                Invoke("TextCustomer9", 2);
                cController9.pesananSalah = false;
                cController9.pesananCustomerUI.SetActive(true);
                cController9.pesananCustomerText.text = "Saya bukan pesan ini";

            }

        }
    }
    public void MasukSceneToping()
    {
        sM.EfekSuaraTombol();

        pesananDiTopingUI.SetActive(true);
        topingUI.SetActive(true);
        lCustomer.ZBelakang();
        iEC.ZBelakang();
        semuaToping.SetActive(true);
        iController.gerakIndikator = true;
        

    }
    public void HabisKesabaran()
    {
        if (nomorCustomer[1] == true)
        {
            if (iEC.habisKesabaran && !nomorEmosi[1])
            {
                nomorEmosi[1] = true;
                print("Customer pergi");
                cController1.prosesPesanan = false;
                cController1.pesananSelesai = false;
                Invoke("FalsePesananCustomerUI1", 2);
                cController1.pesananCustomerText.text = "Terlalu lama";
                Invoke("RandomCustomer", 3);
                iController.ResetToping();
                cController1.pesananCustomerUI.SetActive(true);
                iEC.HapusBarEmosi();
                jC.PenguranganWaktu();
                notifCustomerPergi.SetActive(true);
                jumRandom++;
            }
        }

        if (nomorCustomer[2] == true)
        {
            if (iEC.habisKesabaran && !nomorEmosi[2])
            {
                nomorEmosi[2] = true;
                print("Customer pergi");
                cController2.prosesPesanan = false;
                cController2.pesananSelesai = false;
                Invoke("FalsePesananCustomerUI2", 2);
                cController2.pesananCustomerText.text = "Terlalu lama";
                Invoke("RandomCustomer", 3);
                iController.ResetToping();
                cController2.pesananCustomerUI.SetActive(true);
                iEC.HapusBarEmosi();
                jC.PenguranganWaktu();
                notifCustomerPergi.SetActive(true);
                jumRandom++;
            }
        }

        if (nomorCustomer[3] == true)
        {
            if (iEC.habisKesabaran && !nomorEmosi[3])
            {
                nomorEmosi[3] = true;
                print("Customer pergi");
                cController3.prosesPesanan = false;
                cController3.pesananSelesai = false;
                Invoke("FalsePesananCustomerUI3", 2);
                cController3.pesananCustomerText.text = "Terlalu lama";
                Invoke("RandomCustomer", 3);
                iController.ResetToping();
                cController3.pesananCustomerUI.SetActive(true);
                iEC.HapusBarEmosi();
                jC.PenguranganWaktu();
                notifCustomerPergi.SetActive(true);
                jumRandom++;
            }
        }

        if (nomorCustomer[4] == true)
        {
            if (iEC.habisKesabaran && !nomorEmosi[4])
            {
                nomorEmosi[4] = true;
                print("Customer pergi");
                cController4.prosesPesanan = false;
                cController4.pesananSelesai = false;
                Invoke("FalsePesananCustomerUI4", 2);
                cController4.pesananCustomerText.text = "Terlalu lama";
                Invoke("RandomCustomer", 3);
                iController.ResetToping();
                cController4.pesananCustomerUI.SetActive(true);
                iEC.HapusBarEmosi();
                jC.PenguranganWaktu();
                notifCustomerPergi.SetActive(true);
                jumRandom++;
            }
        }

        if (nomorCustomer[5] == true)
        {
            if (iEC.habisKesabaran && !nomorEmosi[5])
            {
                nomorEmosi[5] = true;
                print("Customer pergi");
                cController5.prosesPesanan = false;
                cController5.pesananSelesai = false;
                Invoke("FalsePesananCustomerUI5", 2);
                cController5.pesananCustomerText.text = "Terlalu lama";
                Invoke("RandomCustomer", 3);
                iController.ResetToping();
                cController5.pesananCustomerUI.SetActive(true);
                iEC.HapusBarEmosi();
                jC.PenguranganWaktu();
                notifCustomerPergi.SetActive(true);
                jumRandom++;
            }
        }

        if (nomorCustomer[6] == true)
        {
            if (iEC.habisKesabaran && !nomorEmosi[6])
            {
                nomorEmosi[6] = true;
                print("Customer pergi");
                cController6.prosesPesanan = false;
                cController6.pesananSelesai = false;
                Invoke("FalsePesananCustomerUI6", 2);
                cController6.pesananCustomerText.text = "Terlalu lama";
                Invoke("RandomCustomer", 3);
                iController.ResetToping();
                cController6.pesananCustomerUI.SetActive(true);
                iEC.HapusBarEmosi();
                jC.PenguranganWaktu();
                notifCustomerPergi.SetActive(true);
                jumRandom++;
            }
        }

        if (nomorCustomer[7] == true)
        {
            if (iEC.habisKesabaran && !nomorEmosi[7])
            {
                nomorEmosi[7] = true;
                print("Customer pergi");
                cController7.prosesPesanan = false;
                cController7.pesananSelesai = false;
                Invoke("FalsePesananCustomerUI7", 2);
                cController7.pesananCustomerText.text = "Terlalu lama";
                Invoke("RandomCustomer", 3);
                iController.ResetToping();
                cController7.pesananCustomerUI.SetActive(true);
                iEC.HapusBarEmosi();
                jC.PenguranganWaktu();
                notifCustomerPergi.SetActive(true);
                jumRandom++;
            }
        }

        if (nomorCustomer[8] == true)
        {
            if (iEC.habisKesabaran && !nomorEmosi[8])
            {
                nomorEmosi[8] = true;
                print("Customer pergi");
                cController8.prosesPesanan = false;
                cController8.pesananSelesai = false;
                Invoke("FalsePesananCustomerUI8", 2);
                cController8.pesananCustomerText.text = "Terlalu lama";
                Invoke("RandomCustomer", 3);
                iController.ResetToping();
                cController8.pesananCustomerUI.SetActive(true);
                iEC.HapusBarEmosi();
                jC.PenguranganWaktu();
                notifCustomerPergi.SetActive(true);
                jumRandom++;
            }
        }
        if (nomorCustomer[9] == true)
        {
            if (iEC.habisKesabaran && !nomorEmosi[9])
            {
                nomorEmosi[9] = true;
                print("Customer pergi");
                cController9.prosesPesanan = false;
                cController9.pesananSelesai = false;
                Invoke("FalsePesananCustomerUI9", 2);
                cController9.pesananCustomerText.text = "Terlalu lama";
                Invoke("RandomCustomer", 3);
                iController.ResetToping();
                cController9.pesananCustomerUI.SetActive(true);
                iEC.HapusBarEmosi();
                jC.PenguranganWaktu();
                notifCustomerPergi.SetActive(true);
                jumRandom++;
            }
        }

    }
    void TextCustomer1()
    {
        cController1.pesananCustomerText.text = cController1.pesanan;
    }
    void TextCustomer2()
    {
        cController2.pesananCustomerText.text = cController2.pesanan;
    }
    void TextCustomer3()
    {
        cController3.pesananCustomerText.text = cController3.pesanan;
    }
    void TextCustomer4()
    {
        cController4.pesananCustomerText.text = cController4.pesanan;
    }
    void TextCustomer5()
    {
        cController5.pesananCustomerText.text = cController5.pesanan;
    }
    void TextCustomer6()
    {
        cController6.pesananCustomerText.text = cController6.pesanan;
    }
    void TextCustomer7()
    {
        cController7.pesananCustomerText.text = cController7.pesanan;
    }
    void TextCustomer8()
    {
        cController8.pesananCustomerText.text = cController8.pesanan;
    }
    void TextCustomer9()
    {
        cController9.pesananCustomerText.text = cController9.pesanan;
    }
    void FalsePesananCustomerUI1()
    {
        bungkusMakanan.SetActive(false);
        cController1.pesananCustomerUI.SetActive(false);
        cController1.moveCustomer = true;

    }
    void FalsePesananCustomerUI2()
    {
        bungkusMakanan.SetActive(false);
        cController2.pesananCustomerUI.SetActive(false);
        cController2.moveCustomer = true;

    }
    void FalsePesananCustomerUI3()
    {
        bungkusMakanan.SetActive(false);
        cController3.pesananCustomerUI.SetActive(false);
        cController3.moveCustomer = true;

    }

    void FalsePesananCustomerUI4()
    {
        bungkusMakanan.SetActive(false);
        cController4.pesananCustomerUI.SetActive(false);
        cController4.moveCustomer = true;

    }

    void FalsePesananCustomerUI5()
    {
        bungkusMakanan.SetActive(false);
        cController5.pesananCustomerUI.SetActive(false);
        cController5.moveCustomer = true;

    }

    void FalsePesananCustomerUI6()
    {
        bungkusMakanan.SetActive(false);
        cController6.pesananCustomerUI.SetActive(false);
        cController6.moveCustomer = true;

    }

    void FalsePesananCustomerUI7()
    {
        bungkusMakanan.SetActive(false);
        cController7.pesananCustomerUI.SetActive(false);
        cController7.moveCustomer = true;

    }

    void FalsePesananCustomerUI8()
    {
        bungkusMakanan.SetActive(false);
        cController8.pesananCustomerUI.SetActive(false);
        cController8.moveCustomer = true;

    }

    void FalsePesananCustomerUI9()
    {
        bungkusMakanan.SetActive(false);
        cController9.pesananCustomerUI.SetActive(false);
        cController9.moveCustomer = true;

    }

    void RandomCustomer()
    {
        random = Random.Range(1, 10);
        CheckRandomCustomer();
    }

    void NomorCustomerDanNomorEmosiFalse()
    {
        nomorCustomer[2] = false;
        nomorCustomer[3] = false;
        nomorCustomer[4] = false;
        nomorCustomer[5] = false;
        nomorCustomer[6] = false;
        nomorCustomer[7] = false;
        nomorCustomer[8] = false;
        nomorCustomer[9] = false;

        nomorEmosi[2] = false;
        nomorEmosi[3] = false;
        nomorEmosi[4] = false;
        nomorEmosi[5] = false;
        nomorEmosi[6] = false;
        nomorEmosi[7] = false;
        nomorEmosi[8] = false;
        nomorEmosi[9] = false;
    }
    public void AksesIEController()
    {
        Invoke("DelayAksesIEController", 0.1f);

    }
    public void SaveUang()
    {
        PlayerPrefs.SetInt("Uang", totalUang);
    }
    public void MulaiGameAwal()
    {
        Time.timeScale = 1;
        sM.EfekSuaraTombol();
        tampilanMulaiGame.SetActive(false);
        jC.MoveJamTrue();
        random = 1;
        CheckRandomCustomer();
        musik.SetActive(true);
    }
    public void Mute()
    {
        sM.EfekSuaraTombol();
        mute.SetActive(false);
        unmute.SetActive(true);
        musik.SetActive(false);
    }
    public void Unmute()
    {
        sM.EfekSuaraTombol();
        mute.SetActive(true);
        unmute.SetActive(false);
        musik.SetActive(true);
    }
    public void MulaiGameDariPause()
    {
        sM.EfekSuaraTombol();
        Time.timeScale = 1;
        tampilanPause.SetActive(false);
    }
    public void PauseGame()
    {
        sM.EfekSuaraTombol();
        tampilanPause.SetActive(true);
        Time.timeScale = 0;
        
    }
    public void NotifikasiCustomerPergi()
    {
        notifCustomerPergi.SetActive(false);
    }
    public void MainMenu()
    {
        sM.EfekSuaraTombol();
        Time.timeScale = 0;
        mainMenu.SetActive(true);
    }

    public void UnMainMenu()
    {
        sM.EfekSuaraTombol();
        Time.timeScale = 1;
        mainMenu.SetActive(false);
    }
    public void PauseVideo()
    {
        if (VideoAwalLevel1Bool)
        {
            videoAwalLevel1VP.Pause();
        }

        if (VideoAwalLevel2Bool)
        {
            videoAwalLevel2VP.Pause();
        }

        if (VideoAwalLevel3Bool)
        {
            videoAwalLevel3VP.Pause();
        }

        if (VideoAwalLevel4Bool)
        {
            videoAwalLevel4VP.Pause();
        }

        if (VideoAwalLevel5Bool)
        {
            videoAwalLevel5VP.Pause();
        }

        //AkhirVideo

        if (VideoAkhirLevel1Bool)
        {
            videoAkhirLevel1VP.Pause();
        }

        if (VideoAkhirLevel2Bool)
        {
            videoAkhirLevel2VP.Pause();
        }

        if (VideoAkhirLevel3Bool)
        {
            videoAkhirLevel3VP.Pause();
        }

        if (VideoAkhirLevel4Bool)
        {
            videoAkhirLevel4VP.Pause();
        }

        if (VideoAkhirLevel5Bool)
        {
            videoAkhirLevel5VP.Pause();
        }

        playVideoButton.SetActive(true);
        pauseVideoButton.SetActive(false);
        sM.EfekSuaraTombol();
        Time.timeScale = 0;
        
    }
    public void PlayVideo()
    {
        //AwalVideo

        if (VideoAwalLevel1Bool)
        {
            videoAwalLevel1VP.Play();
        }

        if (VideoAwalLevel2Bool)
        {
            videoAwalLevel2VP.Play();
        }

        if (VideoAwalLevel3Bool)
        {
            videoAwalLevel3VP.Play();
        }

        if (VideoAwalLevel4Bool)
        {
            videoAwalLevel4VP.Play();
        }

        if (VideoAwalLevel5Bool)
        {
            videoAwalLevel5VP.Play();
        }

        //AkhirVideo

        if (VideoAkhirLevel1Bool && !VideoAwalLevel1Bool)
        {
            videoAkhirLevel1VP.Play();
        }

        if (VideoAkhirLevel2Bool && !VideoAwalLevel2Bool)
        {
            videoAkhirLevel2VP.Play();
        }

        if (VideoAkhirLevel3Bool && !VideoAwalLevel3Bool)
        {
            videoAkhirLevel3VP.Play();
        }

        if (VideoAkhirLevel4Bool && !VideoAwalLevel4Bool)
        {
            videoAkhirLevel4VP.Play();
        }

        if (VideoAkhirLevel5Bool && !VideoAwalLevel5Bool)
        {
            videoAkhirLevel5VP.Play();
        }

        playVideoButton.SetActive(false);
        pauseVideoButton.SetActive(true);
        sM.EfekSuaraTombol();
        Time.timeScale = 1;
    }
    void DelayAksesIEController()
    {
        if(GameObject.FindGameObjectWithTag("IndikatorEmosi") != null)
        {
            iEC = GameObject.FindGameObjectWithTag("IndikatorEmosi").GetComponent<IndikatorEmosiController>();
        }
    }

    void CekSaveVideoAwal()
    {
        if (iniLevelBerapa == 1 && videoLevel1 == 0)
        {
            VideoAwalLevel1Bool = true;
            videoAwalLevel1.SetActive(true);
            VideoAkhirLevel1Bool = true;
        }
        if (iniLevelBerapa == 2 && videoLevel2 == 0)
        {
            VideoAwalLevel2Bool = true;
            videoAwalLevel2.SetActive(true);
        }
        if (iniLevelBerapa == 3 && videoLevel3 == 0)
        {
            VideoAwalLevel3Bool = true;
            videoAwalLevel3.SetActive(true);
        }
        if (iniLevelBerapa == 4 && videoLevel4 == 0)
        {
            VideoAwalLevel4Bool = true;
            videoAwalLevel4.SetActive(true);
        }
        if (iniLevelBerapa == 5 && videoLevel5 == 0)
        {
            VideoAwalLevel5Bool = true;
            videoAwalLevel5.SetActive(true);
        }
    }

    void CekSaveVideoAkhir()
    {
        if (iniLevelBerapa == 1 && videoLevel1 <= 1)
        {
            VideoAkhirLevel1Bool = true;
        }

        if (iniLevelBerapa == 2 && videoLevel1 <= 1)
        {
            VideoAkhirLevel2Bool = true;
        }

        if (iniLevelBerapa == 3 && videoLevel1 <= 1)
        {
            VideoAkhirLevel3Bool = true;
        }

        if (iniLevelBerapa == 4 && videoLevel1 <= 1)
        {
            VideoAkhirLevel4Bool = true;
        }

        if (iniLevelBerapa == 5 && videoLevel1 <= 1)
        {
            VideoAkhirLevel5Bool = true;
        }
    }
    void VideoManager()
    {
        //Level1
        if (VideoAwalLevel1Bool)
        {
            pauseVideoButton.SetActive(true);
            
            if (!matiinTimerVideoAwalLevel1)
            {
                timeVideoAwalLevel1 -= Time.deltaTime;
            }

            if (timeVideoAwalLevel1 < 0)
            {
                pauseVideoButton.SetActive(false);
                matiinTimerVideoAwalLevel1 = true;
                timeVideoAwalLevel1 = 1;
                videoAwalLevel1.SetActive(false);
                PlayerPrefs.SetInt("VideoLevel1", 1);
                print("Bisa di save");
                VideoAwalLevel1Bool = false;
                playVideoButton.SetActive(false);
                pauseVideoButton.SetActive(false);
            }
        }

        if (VideoAwalLevel2Bool)
        {
            pauseVideoButton.SetActive(true);
            if (!matiinTimerVideoAwalLevel2)
            {
                timeVideoAwalLevel2 -= Time.deltaTime;
            }

            if (timeVideoAwalLevel2 < 0)
            {
                pauseVideoButton.SetActive(false);
                matiinTimerVideoAwalLevel2 = true;
                timeVideoAwalLevel2 = 1;
                videoAwalLevel2.SetActive(false);
                PlayerPrefs.SetInt("VideoLevel2", 1);
                print("Bisa di save");
                VideoAwalLevel2Bool = false;
                playVideoButton.SetActive(false);
                pauseVideoButton.SetActive(false);
            }
        }

        if (VideoAwalLevel3Bool)
        {
            pauseVideoButton.SetActive(true);
            if (!matiinTimerVideoAwalLevel3)
            {
                timeVideoAwalLevel3 -= Time.deltaTime;
            }

            if (timeVideoAwalLevel3 < 0)
            {
                pauseVideoButton.SetActive(false);
                matiinTimerVideoAwalLevel3 = true;
                timeVideoAwalLevel3 = 1;
                videoAwalLevel3.SetActive(false);
                PlayerPrefs.SetInt("VideoLevel3", 1);
                print("Bisa di save");
                VideoAwalLevel3Bool = false;
                playVideoButton.SetActive(false);
                pauseVideoButton.SetActive(false);
            }
        }

        if (VideoAwalLevel4Bool)
        {
            pauseVideoButton.SetActive(true);
            if (!matiinTimerVideoAwalLevel4)
            {
                timeVideoAwalLevel4 -= Time.deltaTime;
            }

            if (timeVideoAwalLevel4 < 0)
            {
                pauseVideoButton.SetActive(false);
                matiinTimerVideoAwalLevel4 = true;
                timeVideoAwalLevel4 = 1;
                videoAwalLevel4.SetActive(false);
                PlayerPrefs.SetInt("VideoLevel4", 1);
                print("Bisa di save");
                VideoAwalLevel4Bool = false;
                playVideoButton.SetActive(false);
                pauseVideoButton.SetActive(false);
            }
        }

        if (VideoAwalLevel5Bool)
        {
            pauseVideoButton.SetActive(true);
            if (!matiinTimerVideoAwalLevel5)
            {
                timeVideoAwalLevel5 -= Time.deltaTime;
            }

            if (timeVideoAwalLevel5 < 0)
            {
                pauseVideoButton.SetActive(false);
                matiinTimerVideoAwalLevel5 = true;
                timeVideoAwalLevel5 = 1;
                videoAwalLevel5.SetActive(false);
                PlayerPrefs.SetInt("VideoLevel5", 1);
                print("Bisa di save");
                VideoAwalLevel5Bool = false;
                playVideoButton.SetActive(false);
                pauseVideoButton.SetActive(false);
            }
        }

    }

    void VideoSudahDiTonton()
    {
        //Level1
        if (videoLevel1 >= 1)
        {
            VideoAwalLevel1Bool = false;
            videoAwalLevel1.SetActive(false);
        }

        if(videoLevel1 == 2)
        {
            
            if(VideoAkhirLevel1Bool == true)
            {
                VideoAkhirLevel1Bool = false;
            }
        }

        //Level2
        if (videoLevel2 >= 1)
        {
            VideoAwalLevel2Bool = false;
            videoAwalLevel2.SetActive(false);
        }

        if (videoLevel2 == 2)
        {

            if (VideoAkhirLevel2Bool == true)
            {
                VideoAkhirLevel2Bool = false;
            }
        }

        //Level3
        if (videoLevel3 >= 1)
        {
            VideoAwalLevel3Bool = false;
            videoAwalLevel3.SetActive(false);
        }

        if (videoLevel3 == 2)
        {

            if (VideoAkhirLevel3Bool == true)
            {
                VideoAkhirLevel3Bool = false;
            }
        }

        //Level4
        if (videoLevel4 >= 1)
        {
            VideoAwalLevel4Bool = false;
            videoAwalLevel4.SetActive(false);
        }

        if (videoLevel4 == 2)
        {

            if (VideoAkhirLevel4Bool == true)
            {
                VideoAkhirLevel4Bool = false;
            }
        }
        //Level5
        if (videoLevel5 >= 1)
        {
            VideoAwalLevel5Bool = false;
            videoAwalLevel5.SetActive(false);
        }

        if (videoLevel5 == 2)
        {

            if (VideoAkhirLevel5Bool == true)
            {
                VideoAkhirLevel5Bool = false;
            }
        }
    }
    public void VideoAkhir()
    {
        //Level1
        if (VideoAkhirLevel1Bool)
        {
            pauseVideoButton.SetActive(true);
            musik.SetActive(false);
            hentikanGerakCustomer = true;
            videoAkhirLevel1.SetActive(true);
            iEC.moveIndokator = false;

            if (!matiinTimerVideoAkhirLevel1)
            {
                timeVideoAkhirLevel1 -= Time.deltaTime;
            }

            if (timeVideoAkhirLevel1 < 0)
            {
                pauseVideoButton.SetActive(false);
                matiinTimerVideoAkhirLevel1 = true;
                timeVideoAkhirLevel1 = 1;
                PlayerPrefs.SetInt("VideoLevel1", 2);
                print("Bisa di save");
                keMainMenuVideoUI.SetActive(true);
                playVideoButton.SetActive(false);
                pauseVideoButton.SetActive(false);
            }
        }
        //Level2
        if (VideoAkhirLevel2Bool)
        {
            pauseVideoButton.SetActive(true);
            musik.SetActive(false);
            hentikanGerakCustomer = true;
            videoAkhirLevel2.SetActive(true);
            iEC.moveIndokator = false;

            if (!matiinTimerVideoAkhirLevel2)
            {
                timeVideoAkhirLevel2 -= Time.deltaTime;
            }

            if (timeVideoAkhirLevel2 < 0)
            {
                pauseVideoButton.SetActive(false);
                matiinTimerVideoAkhirLevel2 = true;
                timeVideoAkhirLevel2 = 1;
                PlayerPrefs.SetInt("VideoLevel2", 2);
                print("Bisa di save");
                keMainMenuVideoUI.SetActive(true);
                playVideoButton.SetActive(false);
                pauseVideoButton.SetActive(false);
            }
        }
        //Level3
        if (VideoAkhirLevel3Bool)
        {
            pauseVideoButton.SetActive(true);
            musik.SetActive(false);
            hentikanGerakCustomer = true;
            videoAkhirLevel3.SetActive(true);
            iEC.moveIndokator = false;

            if (!matiinTimerVideoAkhirLevel3)
            {
                timeVideoAkhirLevel3 -= Time.deltaTime;
            }

            if (timeVideoAkhirLevel3 < 0)
            {
                pauseVideoButton.SetActive(false);
                matiinTimerVideoAkhirLevel3 = true;
                timeVideoAkhirLevel3 = 1;
                PlayerPrefs.SetInt("VideoLevel3", 2);
                print("Bisa di save");
                keMainMenuVideoUI.SetActive(true);
                playVideoButton.SetActive(false);
                pauseVideoButton.SetActive(false);
            }
        }
        //Level4
        if (VideoAkhirLevel4Bool)
        {
            pauseVideoButton.SetActive(true);
            musik.SetActive(false);
            hentikanGerakCustomer = true;
            videoAkhirLevel4.SetActive(true);
            iEC.moveIndokator = false;

            if (!matiinTimerVideoAkhirLevel4)
            {
                timeVideoAkhirLevel4 -= Time.deltaTime;
            }

            if (timeVideoAkhirLevel4 < 0)
            {
                pauseVideoButton.SetActive(false);
                matiinTimerVideoAkhirLevel4 = true;
                timeVideoAkhirLevel4 = 1;
                PlayerPrefs.SetInt("VideoLevel4", 2);
                print("Bisa di save");
                keMainMenuVideoUI.SetActive(true);
                playVideoButton.SetActive(false);
                pauseVideoButton.SetActive(false);
            }
        }
        //Level5
        if (VideoAkhirLevel5Bool)
        {
            pauseVideoButton.SetActive(true);
            musik.SetActive(false);
            hentikanGerakCustomer = true;
            videoAkhirLevel5.SetActive(true);
            iEC.moveIndokator = false;

            if (!matiinTimerVideoAkhirLevel5)
            {
                timeVideoAkhirLevel5 -= Time.deltaTime;
            }

            if (timeVideoAkhirLevel5 < 0)
            {
                pauseVideoButton.SetActive(false);
                matiinTimerVideoAkhirLevel5 = true;
                timeVideoAkhirLevel5 = 1;
                PlayerPrefs.SetInt("VideoLevel5", 2);
                print("Bisa di save");
                keMainMenuVideoUI.SetActive(true);
                playVideoButton.SetActive(false);
                pauseVideoButton.SetActive(false);
            }
        }

        if (VideoAkhirLevel5Bool == false)
        {
            waktuLevelTelahHabis.SetActive(true);
            hentikanGerakCustomer = true;
            iEC.moveIndokator = false;
        }
    }
    public void LoadSceneMainMenu()
    {
        sM.EfekSuaraTombol();
        SceneManager.LoadScene("MainMenu");

    }
    public void WaktuLevelHabis()
    {

    }

    public void SkipVideo()
    {
        print("Skippp");
    }

    //VideoLevel1 pada awake dan void VideoManager
}
