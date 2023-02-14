using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{

    private void OnTriggerEnter(Collider other) {
        Debug.Log("ввошел");
        if (other.transform.GetComponent<Wire_Add_Info>())
        {
            Camera.main.GetComponent<OpenOrClose>().IsClose = true;
            Destroy(other.GetComponent<Collider>().gameObject);
        }
    }

    

}
