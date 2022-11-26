using UnityEngine;

public class Platform : MonoBehaviour
{
    public Color hoverColor;
    public Vector3 positionOffset;

    [HideInInspector]
    public GameObject turret;
    [HideInInspector]
    public TurretBlueprint turretBlueprint;
    [HideInInspector]
    public bool isUpgraded = false;

    private Renderer rend;
    private Color startColor;

    BuildManager buildManager;

    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;

        buildManager = BuildManager.instanceOf;
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }

    void OnMouseDown()
    {
        if (turret != null)
        {
            buildManager.SelectPlatform(this);
            return;
        }

        if(!buildManager.CanBuild)
            return;

        BuildTurret(buildManager.GetTurretToBuild());
    }

    void BuildTurret(TurretBlueprint blueprint)
    {
        if (PlayerStats.Money < blueprint.cost)
        {
            Debug.Log("Not enought money to build that! -TODO: DISPLAY ON SCEEN ");
            return;
        }

        PlayerStats.Money -= blueprint.cost;

        GameObject _turret = (GameObject)Instantiate(blueprint.prefab, GetBuildPosition(), Quaternion.identity);
        turret = _turret;

        turretBlueprint = blueprint;

        GameObject turretEffect = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(turretEffect, 5f);

        Debug.Log("Turret Build!");
    }

    public void UpgradeTurret()
    {
        if (PlayerStats.Money < turretBlueprint.upgradeCost)
        {
            Debug.Log("Not enought money to upgrade that! -TODO: DISPLAY ON SCEEN ");
            return;
        }

        PlayerStats.Money -= turretBlueprint.upgradeCost;

        //get rid of the old tower before upgrade
        Destroy(turret);

        //building the upgraded tower
        GameObject _turret = (GameObject)Instantiate(turretBlueprint.upgradedPrefab, GetBuildPosition(), Quaternion.identity);
        turret = _turret;

        GameObject turretEffect = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(turretEffect, 5f);

        isUpgraded = true;

        Debug.Log("Turret Upgraded!");
    }

    public void SellTurret()
    {
        PlayerStats.Money += turretBlueprint.GetSellAmount();

        //add an effect maybe later on

        Destroy(turret);
        isUpgraded = false;
        turretBlueprint = null;
    }

    void OnMouseEnter()
    {

        if(!buildManager.CanBuild)
            return;
            
        if (buildManager.HasMoney)
        {
            rend.material.color = hoverColor;
        } else
        {
            rend.material.color = Color.red;
        }
        
    }

    void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
