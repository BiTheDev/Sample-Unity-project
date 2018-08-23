using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour
{
    public GameObject explosion;
    public GameObject playerExplosion;
    public int scoreValue;
    //public int damage;
    //private int TotalDamage;
    private GameController gameController;

    private void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if(gameControllerObject !=null){
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if(gameController == null){
            Debug.Log("Cannot find 'GameController' script ");
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Boundary") || other.CompareTag ("Enemy") || other.CompareTag("Boss"))
        {
            return;
        }
        if(explosion != null){
            Instantiate(explosion, transform.position, transform.rotation);
        }

        if(other.tag == "Player"){
            //gameController.PlayerGetDamage(damage);
            //TotalDamage += damage;
            // total damage to player

            //if(TotalDamage >= 100){
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
                gameController.GameOver();
            //}
           
        }
        gameController.AddScore(scoreValue);
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}