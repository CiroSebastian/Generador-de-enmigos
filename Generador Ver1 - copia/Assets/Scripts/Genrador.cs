using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Genrador : MonoBehaviour
{
    [SerializeField]
    private GameObject EnemigoPrefab;
    private GameObject spawn;

    public float enemyRate = 3.5f;
    public float enemyNum;

    public Text Interfaz;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawn(enemyRate, EnemigoPrefab));
        spawn = GameObject.FindGameObjectWithTag("Spawner");
    }

    private IEnumerator Spawn(float rate, GameObject Enemigo)
    {
        yield return new WaitForSeconds(rate);
        GameObject newEnemy = Instantiate(Enemigo, new Vector3(spawn.transform.position.x, spawn.transform.position.y + 2), Quaternion.identity);
        StartCoroutine(Spawn(rate, Enemigo));
        enemyNum++;

        
    }

    private void Update()
    {
        if (enemyNum == 1)
        { 
            Interfaz.text = "Hay " + enemyNum.ToString() + " enemigo, y aparecen cada " + enemyRate.ToString() + " segundos";
        }
        else
        {
            Interfaz.text = "Hay " + enemyNum.ToString() + " enemigos, y aparecen cada " + enemyRate.ToString() + " segundos";
        }
    }
}
