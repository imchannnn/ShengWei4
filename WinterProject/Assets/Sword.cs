using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;

public class Sword : MonoBehaviour
{
    
    public ParticleSystem ex;
    public GameObject CM;
    void Start()
    {
        CM.transform.gameObject.SetActive(false);
        //CM.GetComponent<CinemachineVirtualCamera>().enabled = false;
        //this.GetComponent<CinemachineVirtualCamera>().enabled = false;
        ex.Stop();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (ex.isStopped)
        {
            CM.transform.gameObject.SetActive(true);
            ex.Play();
            //this.GetComponent<CinemachineVirtualCamera>().enabled = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        CM.transform.gameObject.SetActive(false);
        //this.GetComponent<CinemachineVirtualCamera>().enabled = false;
    }
}
