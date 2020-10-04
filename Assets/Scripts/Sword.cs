using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{

    private float attackLength = 0.25f;


    void Update()
    {
        attackLength -= Time.deltaTime;
        //This calculated the amount of time per frame

        if(attackLength <= 0)
        {
            gameObject.SetActive(false);
            //lowercase g will give you the component that the script is attatched to
            attackLength = 0.25f;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
        }
    }
}
