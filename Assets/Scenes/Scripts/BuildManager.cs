using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instanceOf;

    void Awake()
    {
        if (instanceOf != null)
        {
            Debug.LogError("More than one BuildManager in scene!");
            return;
        }
        instanceOf = this;
    } 

    public GameObject lv1TurretPrefab;
    public GameObject lv2TurretPrefab;

    public GameObject buildEffect;

    private TurretBlueprint turretToBuild;
    private Platform selectedPlatform;

    public PlatformUI platformUI;

    public bool CanBuild {get {return turretToBuild != null;} }  
    public bool HasMoney {get {return PlayerStats.Money >= turretToBuild.cost;} } 

    public void SelectPlatform(Platform platform)
    {
        if(selectedPlatform == platform)
        {
            DeselectPlatform();
            return;
        }
        selectedPlatform = platform;
        turretToBuild = null;

        platformUI.SetTarget(platform);
    }

    public void DeselectPlatform()
    {
        selectedPlatform = null;
        platformUI.Hide();
    }

    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
        DeselectPlatform();
    }

    public TurretBlueprint GetTurretToBuild()
    {
        return turretToBuild;
    }
}
