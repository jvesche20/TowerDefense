using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{

    public Color hovColor;
    public Color startColor;

    private Renderer rend;


    private GameObject turret;
    public Vector3 positionOffset;

    BuildManager buildManager;
    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        buildManager = BuildManager.instance;
    }
    void OnMouseDown()
    {
        if (buildManager.getTurretToBuild() == null)
            return;


        if(turret != null)
        {
            Debug.Log("Cant build there");
            return;
        }
        GameObject turretToBuild = buildManager.getTurretToBuild();
        turret = (GameObject)Instantiate(turretToBuild, transform.position + positionOffset, transform.rotation);

    }
    void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        if (buildManager.getTurretToBuild() == null)
            return;
        GetComponent<Renderer>().material.color = hovColor;
    }


    void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
