using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    // Tiempo máximo 60 segundos
    public float maxTime = 60f;

    private float countdown = 0f;

    // Start is called before the first frame update
    void Start()
    {
        countdown = maxTime;
    }

    // Update is called once per frame
    void Update()
    {
        // El deltaTime es el tiempo en segundos que ha pasado desde que se renderizó en la pantalla el último frame anterior.
        countdown -= Time.deltaTime;

        Debug.Log("Tiempo :" + countdown);

        //El juagor pierde
        if (countdown <= 0f)
        {
            Debug.Log("Te has quedado sin tiempo... ¡FIN DEL JUEGO!");

            //Reiniciamos la partida
            Coin.coinsCount = 0;
            SceneManager.LoadScene("MainScene");

        }
    }
}
