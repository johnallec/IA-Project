using UnityEngine;
using UnityEngine.UI;

public class PlatformUI : MonoBehaviour
{
    public GameObject ui;

    public Text upgradeCost;
    public Button upgradeButton;

    public Text sellCost;
    public Button sellButton;

    private Platform target;

    public void SetTarget(Platform _target)
    {
        target = _target;

        transform.position = target.GetBuildPosition();

        if(!target.isUpgraded)
        {
            upgradeCost.text = "$" + target.turretBlueprint.upgradeCost;
            upgradeButton.interactable = true;

            sellCost.text = "$" + target.turretBlueprint.GetSellAmount().ToString();
            sellButton.interactable = true;
        } else
        {
            upgradeCost.text = "DONE";
            upgradeButton.interactable = false;
        }
        
        ui.SetActive(true);
    }

    public void Hide()
    {
        ui.SetActive(false);
    }

    public void Upgrade()
    {
        target.UpgradeTurret();
        BuildManager.instanceOf.DeselectPlatform();
    }

    public void Sell()
    {
        target.SellTurret();
        BuildManager.instanceOf.DeselectPlatform();
    }
}
