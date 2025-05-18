using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class miOtroObjeto : MonoBehaviour
{
    public float speed = 30.0f;
    public float posZ = 2f;
    public GameObject prefabDosBaias;
    public AudioClip sonidoDisparo;
    public AudioSource audioSource;
    private Renderer balaRenderer;
    // Start is called before the first frame update
    void Start()
    {


        if (sonidoDisparo != null)
        {
            audioSource.PlayOneShot(sonidoDisparo);
        }


    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
        if (transform.position.z > posZ)
        {
            Destroy(this.gameObject);
        }
    }
}
