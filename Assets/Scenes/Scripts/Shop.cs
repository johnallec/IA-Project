using UnityEngine;

public class Shop : MonoBehaviour
{

    public TurretBlueprint lv1Turret;
    public TurretBlueprint lv2Turret;

    BuildManager buildManager;

    void Start()
    {
        buildManager = BuildManager.instanceOf;
    }

    public void SelectLv1Turret()
    {
        Debug.Log("LV1 Turret Selected!");
        buildManager.SelectTurretToBuild(lv1Turret);
    }

    public void SelectLv2Turret()
    {
        Debug.Log("LV2 Turret Selected!");
        buildManager.SelectTurretToBuild(lv2Turret);
    }
}
