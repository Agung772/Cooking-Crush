using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonBarEmosi : MonoBehaviour
{
    public float waktu;
    public GameObject PrefabBarEmosi;

    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator SummonBarEmosiPrefab()
    {
        yield return new WaitForSeconds(waktu);
        Instantiate(PrefabBarEmosi, transform.position, Quaternion.identity);

    }
    public void SummonLagiBarEmosi()
    {
        StartCoroutine(SummonBarEmosiPrefab());
    }
}
