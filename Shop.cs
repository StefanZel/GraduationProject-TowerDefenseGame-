using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurretBlueprint standardTurret;
    public TurretBlueprint missileLauncher;
    public TurretBlueprint laserBeamer;

    BuildManager buildManager;

    void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void SelectStandardTurret()
    {
        Debug.Log("Standard Turret Purchased");
        buildManager.SelectTurretToBuild(standardTurret);
    
    }
    public void SelectLaserBeamer()
    {
        Debug.Log("Leaser Beamer Selected");
        buildManager.SelectTurretToBuild(laserBeamer);

    }

    public void SelectMissileTurret()
    {
        Debug.Log("Missile Turret Purchased");
        buildManager.SelectTurretToBuild(missileLauncher);

    }
}
