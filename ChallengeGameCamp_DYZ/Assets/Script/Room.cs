using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public GameObject parent;
    public int linkCount;
    public int level;

    private void OnTriggerEnter(Collider other)
    {
        if(!this.CompareTag("Placed"))
        {
            if (other.gameObject.CompareTag("Placed"))
            {
                Destroy(this.gameObject);
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (!this.CompareTag("Placed"))
        {
            if (other.gameObject.CompareTag("Placed"))
            {
                Destroy(this.gameObject);
            }
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("aaaaaaaaaaaaaaaa");
        if (!this.CompareTag("Placed"))
        {
            if (collision.gameObject.CompareTag("Placed"))
            {
                Destroy(this.gameObject);
            }
        }
    }

    void OnCollisionStay(Collision collision)
    {
        Debug.Log("aaaaaaaaaaaaaaaa");
        if (!this.CompareTag("Placed"))
        {
            if (collision.gameObject.CompareTag("Placed"))
            {
                Destroy(this.gameObject);
            }
        }
    }
}
