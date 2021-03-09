using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{

    BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager.instance;
    }
    public void PurchaseStandardTurret()
    {
        Debug.Log("Standard turret purchased");
        buildManager.SetTurretToBuild(buildManager.standardTurretPrefab);
    }
    public void PurchaseUpgradedTurret()
    {
        Debug.Log("Upgraded turret purchased");
        buildManager.SetTurretToBuild(buildManager.UpgradedTurretPrefab);
    }
}
