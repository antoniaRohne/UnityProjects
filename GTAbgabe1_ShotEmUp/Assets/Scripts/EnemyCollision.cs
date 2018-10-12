using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyCollision : MonoBehaviour {

    bool dead = false;

    private void OnCollisionEnter(Collision collision)
    {

        if(collision.gameObject.tag.Equals("Player"))
        {
            GameController.instance.endGame();
            return;
        }

        if (collision.gameObject.tag.Equals("bullet"))
        {
            if (!dead)
            {
                dead = true;
                GetComponent<BoxCollider>().enabled = false;
                GameController.instance.addPoint();
                Destroy(collision.gameObject);

                //Dissolve
                Material enemyMaterial = GetComponent<MeshRenderer>().material;
                StartCoroutine(Dissolve(enemyMaterial));
                return;
            }
           
        }
       
    }

    IEnumerator Dissolve(Material m)
    {
        float time = 0.0f;
        while (time < 0.8f)
        {
            time += Time.deltaTime;
            m.SetFloat("_DissolveFactor", time);
            yield return new WaitForEndOfFrame();
        }

        Destroy(gameObject);
    }

}
