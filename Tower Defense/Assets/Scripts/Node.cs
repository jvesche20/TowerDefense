using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{

    public Color hovColor;
    public Color startColor;

    private Renderer rend;
    public Color noMoneyColor;

    public GameObject turret;
    public Vector3 positionOffset;

    BuildManager buildManager;
    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        buildManager = BuildManager.instance;
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }
    void OnMouseDown()
    {
        if (!buildManager.CanBuild)
            return;


        if(turret != null)
        {
            Debug.Log("Cant build there");
            return;
        }
        buildManager.BuildTurretOn(this);

    }
    void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        if (!buildManager.CanBuild)
            return;


        if (buildManager.hasMoney)
        {
            rend.material.color = hovColor;
        }
        else
        {
            rend.material.color = noMoneyColor;
        }


    }


    void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
