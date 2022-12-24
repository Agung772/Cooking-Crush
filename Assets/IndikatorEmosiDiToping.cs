using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndikatorEmosiDiToping : MonoBehaviour
{
    public bool adaIndikator, IndikatorEmosiDiSceneToping;
    public GameObject IndikatorEmosi;
    public Vector3 LetakAwal;

    public bool[] checkE = new bool[4];
    public bool moveIndokator;
    public GameObject[] eIcon;
    public float kecepatanIndikatorEmosi, posisiIndikator;

    // Start is called before the first frame update
    void Start()
    {
        LetakAwal = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        AksesIndikatorEmosi();
        CheckBarEmosi();
    }
    void AksesIndikatorEmosi()
    {
        if (adaIndikator)
        {
            
            IndikatorEmosi = GameObject.FindGameObjectWithTag("IndikatorEmosi");
            if (IndikatorEmosiDiSceneToping)
            {
                IndikatorEmosiDiSceneToping = false;
                moveIndokator = true;
                transform.position = LetakAwal;
                
            }
        }
        if (GameObject.FindGameObjectWithTag("IndikatorEmosi") != null)
        {
            adaIndikator = true;
            
            
            
        }
        if (GameObject.FindGameObjectWithTag("IndikatorEmosi") == null)
        {
            adaIndikator = false;
            IndikatorEmosiDiSceneToping = true;
            
        }
    }
    void CheckBarEmosi()
    {
        if (moveIndokator)
        {
            transform.Translate(Vector2.down * kecepatanIndikatorEmosi * Time.deltaTime);

        }

        if (checkE[1])
        {
            checkE[3] = false;
            eIcon[1].SetActive(true);
            eIcon[2].SetActive(false);
            eIcon[3].SetActive(false);

        }
        if (!checkE[1])
        {
            eIcon[1].SetActive(false);

        }
        if (checkE[2])
        {
            eIcon[2].SetActive(true);
            eIcon[1].SetActive(false);
            eIcon[3].SetActive(false);

        }
        if (!checkE[2])
        {
            eIcon[2].SetActive(false);
        }
        if (checkE[3])
        {

            eIcon[3].SetActive(true);
            eIcon[1].SetActive(false);
            eIcon[2].SetActive(false);
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

        }
    }
}
