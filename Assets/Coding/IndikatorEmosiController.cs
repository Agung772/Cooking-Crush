using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndikatorEmosiController : MonoBehaviour
{
    public bool[] checkE = new bool[4];
    public bool moveIndokator;
    public bool habisKesabaran, cooldownPenambahanWaktu;
    public GameObject[] eIcon;
    GameController gC;
    JamController jamController;
    public GameObject BarEmosi, sC;
    public float kecepatanIndikatorEmosi, posisiIndikator;
    public Vector3 LetakAwal;

    // Start is called before the first frame update
    void Start()
    {

        //kecepatanIndikatorEmosi = 10;
        moveIndokator = true;

        if (moveIndokator)
        {
            cooldownPenambahanWaktu = false;
        }

        LetakAwal =  BarEmosi.transform.position;
        gC = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        jamController = GameObject.FindGameObjectWithTag("JarumJam").GetComponent<JamController>();
        sC = GameObject.FindGameObjectWithTag("SceneCustomer");
        BarEmosi.transform.position = new Vector3(BarEmosi.transform.position.x, BarEmosi.transform.position.y, sC.transform.position.z);
        gC.barEmosiHilang = false;
    }

    // Update is called once per frame
    void Update()
    {


        CheckBarEmosi();

    }
    void CheckBarEmosi()
    {
        if (moveIndokator)
        {
            transform.Translate(Vector2.down * kecepatanIndikatorEmosi * Time.deltaTime);
            
        }
        
        if (checkE[1])
        {
            if (!moveIndokator && !cooldownPenambahanWaktu)
            {
                jamController.penambahanWaktuBool = true;
                cooldownPenambahanWaktu = true;
            }
            eIcon[1].SetActive(true);
            gC.pendapatanEmosiCustomer = 2000;
        }
        if (!checkE[1])
        {
            eIcon[1].SetActive(false);

        }
        if (checkE[2])
        {
            eIcon[2].SetActive(true);
            gC.pendapatanEmosiCustomer = 0;
        }
        if (!checkE[2])
        {
            eIcon[2].SetActive(false);
        }
        if (checkE[3])
        {
            gC.pendapatanEmosiCustomer = -2000;
            eIcon[3].SetActive(true);
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("E1"))
        {
            checkE[1] = true;
        }
        if (collision.CompareTag("E2"))
        {
            checkE[2] = true;
        }
        if (collision.CompareTag("E3"))
        {
            checkE[3] = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("E1"))
        {
            checkE[1] = false;
        }
        if (collision.CompareTag("E2"))
        {
            checkE[2] = false;
        }
        if (collision.CompareTag("E3"))
        {
            moveIndokator = false;
            habisKesabaran = true;
            gC.HabisKesabaran();
        }
    }

    public void HapusBarEmosi()
    {
        Invoke("DelayHapusBarEmosi", 2);
        
    }
    void DelayHapusBarEmosi()
    {
        Destroy(BarEmosi);
        gC.barEmosiHilang = true;
    }

    public void ZBelakang()
    {
        BarEmosi.transform.position = new Vector3(BarEmosi.transform.position.x, BarEmosi.transform.position.y, 1);
    }
    public void ZDepan()
    {
        BarEmosi.transform.position = new Vector3(BarEmosi.transform.position.x, BarEmosi.transform.position.y, -1);
    }


}
