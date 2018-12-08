using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyInstantiater : MonoBehaviour, Instantiater {

    [SerializeField]
    GameObject enemy;
    IEnumerator instantiater;

    public void init()
    {
        instantiater = waitAndInstantiate();
        StartCoroutine(instantiater);
    }
    private IEnumerator waitAndInstantiate()
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(7);

            for (int i = 0; i < 10; i++)
            {
                InstantiateObject();
            }
        } 
    }

    public void InstantiateObject()
    {
        GameObject e = Instantiate(enemy);
        e.transform.position = new Vector3(transform.position.x, Random.Range(-5,5) , 0f);
    }

    public void stop()
    {
        StopCoroutine(instantiater);
        EnemyMovement[] enemys = GameObject.FindObjectsOfType<EnemyMovement>();
        for(int i=0; i < enemys.Length; i++)
        {
            Destroy(enemys[i].gameObject);
        }
    }

}

