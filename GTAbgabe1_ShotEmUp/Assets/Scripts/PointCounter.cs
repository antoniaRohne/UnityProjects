using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointCounter : MonoBehaviour {

    [SerializeField]
    Text pointShow;

    [SerializeField]
    Canvas endUI;
    [SerializeField]
    Canvas ammoUI;

    int points = 0;

    public void setPoints()
    {
        pointShow.text = points.ToString();
        endUI.enabled = true;
        ammoUI.enabled = false;
    }

    public void addPoint()
    {
        points++;
    }

    public void resetPoints()
    {
        points = 0;
        endUI.enabled = false;
        ammoUI.enabled = true;
    }
}
