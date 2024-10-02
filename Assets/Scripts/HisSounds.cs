using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HisSounds : MonoBehaviour
{
    public AudioClip hitAudio;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            AudioSource.PlayClipAtPoint(hitAudio, collision.contacts[0].point); 
        }
    }
}
