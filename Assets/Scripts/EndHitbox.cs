using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndHitbox : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            GameManager.Instance.nextScene();
        }
    }
}
