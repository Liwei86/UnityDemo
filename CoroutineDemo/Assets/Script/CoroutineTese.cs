using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineTese : MonoBehaviour {

    // Use this for initialization
    private bool isStartCall = false;  //Makesure Update() and LateUpdate() Log only once  
    private bool isUpdateCall = false;
    private bool isLateUpdateCall = false;
    // Use this for initialization  
    void Start()
    {

    }

    // Update is called once per frame  
    void Update()
    {
        if (!isUpdateCall)
        {
            Debug.Log("Update Call Begin");
            StartCoroutine(UpdateCoutine());
            Debug.Log("Update Call End");
            isUpdateCall = true;
        }
    }
    IEnumerator UpdateCoutine()
    {
        Debug.Log("This is Update Coroutine Call Before");
        yield return new WaitForSeconds(1f);
        Debug.Log("This is Update Coroutine Call After");
    }
    

}
