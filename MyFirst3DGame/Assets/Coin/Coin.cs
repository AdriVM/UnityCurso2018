/*
 *  NAMESPACE
 */
using System.Collections;
using UnityEngine;

/*
 * CLASS
 */ 
public class Coin : MonoBehaviour
{

    /*
     *  PROPIEDADES Y MÉTODOS
     */

    public static int coinsCount = 0; // Una variable static se comparte entre todas las instancias, en este caso solo va a haber un contador para todas las monedas.
    
    private float initialYpos;


    // Start is called before the first frame update
    void Start()
    {
        // Guardamos la posición inicial del gameObject en la coordenada Y
        initialYpos = transform.position.y;
        Coin.coinsCount++;
        Debug.Log("El juego ha comenzado y hay " + Coin.coinsCount + " monedas");
    }

    // Update is called once per frame
    void Update()
    {
        Rotar();
        Rebotar(initialYpos); // Pasamos la posición inicial guardada al método.
    }

    private void OnTriggerEnter(Collider otherCollider)
    {
        if(otherCollider.CompareTag("Player"))
        {
            // Decrecemos el contador
            Coin.coinsCount--;

            Debug.Log("Hemos recogido una moneda y quedan " + Coin.coinsCount + " monedas");

            //Ganamos
            if (Coin.coinsCount == 0)
            {
                Debug.Log("¡Has ganado!");

                GameObject gameManager = GameObject.Find("GameManager");
                Destroy(gameManager); //Paramos el tiempo destruyendolo.

                // Activamos los fuegos artificiales
                GameObject[] fireworksSystem = GameObject.FindGameObjectsWithTag("Fireworks");

                foreach( GameObject fireworks in fireworksSystem)
                {
                    fireworks.GetComponent<ParticleSystem>().Play();
                }
            }

            Destroy(gameObject);
        }
        

    }

    private void Rotar()
    {
        transform.Rotate(0, 0, 360 * Time.deltaTime * .25f);
    }

    private void Rebotar(float Ypos)
    {
        /*
         * PingPong es un metodo que devuelve un rango entre 0 y el limite dado y de este a 0.
         * En nuestro caso nos interesa que vaya desde la posición inicial del GameObject (Ypos en este caso) hasta el limite dado
         * y de este limite a nuestra posición inicial Ypos.
         */
        float y = Mathf.PingPong(Time.time * .25f, .5f) + Ypos;
        transform.position = new Vector3(transform.position.x, y, transform.position.z);
    }
}
