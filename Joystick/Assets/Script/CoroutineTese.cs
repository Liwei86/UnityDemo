using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineTese : MonoBehaviour {

    // Use this for initialization
    private bool isStartCall = false;  //Makesure Update() and LateUpdate() Log only once  
    private bool isUpdateCall = false;
    private bool isLateUpdateCall = false;
    public GameObject cube;
    Material material;
    // Use this for initialization  
    void Start()
    {
       Material material = cube.GetComponent<Renderer>().materials[0];
        StartCoroutine(UpdateCoutine(material));
    }

    // Update is called once per frame  
    void Update()
    {

    }
    IEnumerator UpdateCoutine(Material material)
    {
        for (float f = 1f; f >= 0; f -= 0.01f)
        {
            Color c = material.color;   
            c.g = f;
            Debug.Log(c.g);
            material.color = c;
            yield return new WaitForSeconds(.1f);
        }
    }


}
