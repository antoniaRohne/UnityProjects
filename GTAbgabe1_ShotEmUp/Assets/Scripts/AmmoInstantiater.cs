using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoInstantiater : MonoBehaviour,Instantiater {

    [SerializeField]
    GameObject ammoPack;
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
            yield return new WaitForSecondsRealtime(4);

            InstantiateObject();
        } 
    }

    public void InstantiateObject()
    {
        GameObject e = Instantiate(ammoPack);
        e.transform.position = new Vector3( Random.Range(-3,5.5f), Random.Range(-4.5f,4.5f) , 0f);
    }

    public void stop()
    {
        StopCoroutine(instantiater);
        AmmoPackBehaviour[] ammoPacks = GameObject.FindObjectsOfType<AmmoPackBehaviour>();
        for(int i=0; i < ammoPacks.Length; i++)
        {
            Destroy(ammoPacks[i].gameObject);
        }
    }

}


