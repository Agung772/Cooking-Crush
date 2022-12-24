using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerCustomer : MonoBehaviour
{
    public Vector3 zBelakang;
    public Vector3 zDepan;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ZBelakang()
    {
        gameObject.transform.position = zBelakang;
    }
    public void ZDepan()
    {
        gameObject.transform.position = zDepan;
    }

}
