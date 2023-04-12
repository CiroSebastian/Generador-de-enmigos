using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Genrador : MonoBehaviour
{
    public GameObject EnemigoPrefab;
    public GameObject EnemigoGrandePrefab;

    public float enemyNum;
    public int maxNum = 10;

    public float tiempoMinimo = 1f;
    public float tiempoMaximo = 3f;

    public int minSuerte = 1;
    public int maxSuerte = 5;

    public Text prefab;
    public Text wait;
    public Text enemyNumber;
    public Text enemyMax;
    public Text enemyPos;
    public Text luck;
    public Text luckRange;
    public Text waitMin;
    public Text waitMax;

    void Start()
    {
        
        StartCoroutine(Spawn());
        prefab.text = "Nulo";
        wait.text = "Nulo";
        enemyPos.text = "Nulo";
        luck.text = "Nulo";
        luckRange.text = "Rango de suerte: " + minSuerte.ToString() + " a " + maxSuerte.ToString();
        waitMin.text = "Espera minima:" + tiempoMinimo.ToString();
        waitMax.text = "Espera maxima:" + tiempoMaximo.ToString();
    }

    private IEnumerator Spawn()
    {
        float espera = Random.Range(tiempoMinimo, tiempoMaximo);
        yield return new WaitForSeconds(espera);
        wait.text = "Se esperaron: " + espera.ToString() + " segundos";

        
        int suerte = Random.Range(minSuerte,maxSuerte);

        if(enemyNum < maxNum)
        { 
            if(suerte < 4)
             {
                Vector3 posicion = new Vector3(Random.Range(-5f, 5f), 1, Random.Range(-6f, 6f));
                GameObject newEnemy = Instantiate(EnemigoPrefab, posicion, Quaternion.identity);

                StartCoroutine(Spawn());

                prefab.text = "Tipo de Enemigo: Pequeño";
                enemyPos.text = "Posicion: " + posicion.ToString();
            }
            else
            {
                Vector3 posicion = new Vector3(Random.Range(-5f, 5f), 4, Random.Range(-6f, 6f));
                GameObject newEnemy = Instantiate(EnemigoGrandePrefab, posicion, Quaternion.identity);

                StartCoroutine(Spawn());

                prefab.text = "Tipo de Enemigo: Grande";
                enemyPos.text = "Posicion: " + posicion.ToString();
            }
        }
        enemyNum++;

        luck.text = "Suerte: " + suerte.ToString();
    }

    private void Update()
    {
        enemyNumber.text = "Numero de enemigos: " + enemyNum.ToString();
        enemyMax.text = "Mximo de enemigos:" + maxNum.ToString();
    }
}
