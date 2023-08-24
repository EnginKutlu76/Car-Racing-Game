using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ArabaHareket : MonoBehaviour
{
    bool oyunBitti = false;
    bool dTusunaBasildiMi = false;
    bool aTusunaBasildiMi = false;
    void Start()
    {
        
    }
    
    void Update()
    {
        if (Input.GetKey("d"))
        {
            dTusunaBasildiMi = true;
        }
        if (Input.GetKey("a"))
        {
            aTusunaBasildiMi = true;
        }

    }
    private void FixedUpdate()
    {
        if ((GetComponent<Rigidbody>().position.z >= 9.5) || (GetComponent<Rigidbody>().position.z < -9.5))
        {
            oyunBitti = true;
            GetComponent<Rigidbody>().velocity = new Vector3(0 , 0, GetComponent<Rigidbody>().velocity.z);
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            Invoke("restart", 1f);
        }
        if (oyunBitti == false)
        {
            GetComponent<Rigidbody>().velocity = new Vector3(-19,0,GetComponent<Rigidbody>().velocity.z);


        }
        if (dTusunaBasildiMi)
        {
            GetComponent<Rigidbody>().AddForce(0, 0, 35, ForceMode.Force);
            dTusunaBasildiMi = false;
        }
        if (aTusunaBasildiMi)
        {
            GetComponent<Rigidbody>().AddForce(0, 0, -35, ForceMode.Force);
            aTusunaBasildiMi = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
            if (collision.collider.tag == "engel")
            {
                Invoke("restart", 1f);
                oyunBitti = true;
            }
    }


    private void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        oyunBitti = false;
    }
}
