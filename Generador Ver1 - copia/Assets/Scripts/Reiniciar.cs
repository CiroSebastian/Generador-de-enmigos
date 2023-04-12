using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Reiniciar : MonoBehaviour
{
    public float lifes = 5f; 
    public Transform respawnPoint;

    public Text Salud;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
           lifes--;

           if(lifes <=0)
            {
                Die();
            }
           else
            {
                Respawn();
            }
        }
    }

    void Die()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); 
    }

    void Respawn()
    {
        transform.position = respawnPoint.position; 
    }

    private void Update()
    {
        Salud.text = "Vidas: " + lifes.ToString();
    }
}
