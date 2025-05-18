using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class move : MonoBehaviour
{
    [SerializeField]
    private float speed = 1.0f;
    private Renderer rend;
    public float horizontalInput;
    public float verticalInput;
    public AudioClip sonidoDisparo;
    public AudioSource audioSource;





    //variable de tipo GameObject para guerdar la esfera.
    public GameObject miObjeto;

    public GameObject miOtroObjeto;

    //variable para interactuar en otra clase.
    public bool cambioObjeto = false;

    void Start()
    {
        rend = GetComponent<Renderer>();
        audioSource = GetComponent<AudioSource>();
        
    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);
        transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);
        //Debug.Log(transform.position);

        //Limites del escenario vertical
        if (transform.position.z > 15.6f)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 15.6f);
        };
        if (transform.position.z < -23.18279f)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -23.18279f);
        };

        //Limites del escenario horizontal
        if (transform.position.x < -22.70373f)
        {
            transform.position = new Vector3(-22.70373f, transform.position.y, transform.position.z);
        };
        if (transform.position.x > 22.65776f)
        {
            transform.position = new Vector3(22.65776f, transform.position.y, transform.position.z);
        };

        //Uso de miObjeto
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Instantiate(miObjeto, transform.position, Quaternion.identity);
            cambiaMiObjeto();
            if (audioSource != null && sonidoDisparo != null)
            {
                audioSource.PlayOneShot(sonidoDisparo);
            }
        }
    }

    private void cambiaMiObjeto()
    {
        if (cambioObjeto == true)
        {
            Instantiate(miOtroObjeto, transform.position, Quaternion.identity);
            Debug.Log("P�ldora recogida.");
        }
        else
        {
            Instantiate(miObjeto, transform.position, Quaternion.identity);
        }
    }
    void CambiarColor()
    {
        Color nuevoColor = new Color(Random.value, Random.value, Random.value);
        rend.material.color = nuevoColor;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pildora"))
        {
            CambiarColor();
            Destroy(other.gameObject); // Destruye la p�ldora recogida
            

        }
    }

}

//Nota: la f junto a los numeros indica el tipo de dato "float".
//Quaternion: unidades que controlan la rotacion en un momento determinado de tiempo
//cualquier clase PUBLICA puede ser llamada desde otra.
//objetos para coleccionar: requisitos:
//1. personaje y objeto con collider
//2. personaje con RigidBody
//3. objeto con isTrigger activado