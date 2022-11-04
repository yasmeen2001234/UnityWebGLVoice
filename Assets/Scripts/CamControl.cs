using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CamControl : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject MyCenter;
    Vector3 offset;
    void Start()
    {
        offset = transform.position - MyCenter.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = MyCenter.transform.position + offset;
    }
}
