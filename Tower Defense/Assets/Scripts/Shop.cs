using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurretManagement standartTurret;
    public TurretManagement upgradedTurret;

    BuildManager buildManager;

    void Start()
    {
        buildManager = BuildManager.instance;
    }
    public void SelectStandardTurret()
    {
        Debug.Log("Standard turret purchased");
        buildManager.SelectTurretToBuild(standartTurret);
    }
    public void SelectUpgradedTurret()
    {
        Debug.Log("Upgraded turret purchased");
        buildManager.SelectTurretToBuild(upgradedTurret);
    }
}
