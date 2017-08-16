using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrimpBomb : MonoBehaviour {

    public float DamageValue = 5f;
    public GameObject VFXExplosion;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<ResourceManagement>().DamageHealth(DamageValue);
        }
        Instantiate(VFXExplosion, transform.position, Random.rotation);
        Destroy(gameObject);
    }
}
