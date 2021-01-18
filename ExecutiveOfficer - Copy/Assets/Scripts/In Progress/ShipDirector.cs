using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipDirector : MonoBehaviour
{
    public Button navTestButton;
    public Button lightsTestButton;


    public enum PlayerOccupyEnum
    {
        Nothing,
        Navigation,
        WeaponGroup,
        Sensors,
        Hangar,
        Shields,
        Lights,
    }
    public PlayerOccupyEnum playerOccupying = PlayerOccupyEnum.Nothing;

    public enum OccupiedWeaponGroup
    {
        NotInWeapon,
        MainBattery,
        SecondaryPort,
        SecondaryStarboard,
        SecondaryVentral,
        SecondaryLateral,
        SecondaryForeward,
        SecondaryAft,
        FlakStarboard,
        FlakPort,
    }
    public OccupiedWeaponGroup weaponGroup = OccupiedWeaponGroup.NotInWeapon;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void LateUpdate()
    {
        if (weaponGroup != OccupiedWeaponGroup.NotInWeapon)
        {
            playerOccupying = PlayerOccupyEnum.WeaponGroup;
        }
    }

    public void m_OnNavClick()
    {
        playerOccupying = PlayerOccupyEnum.Navigation;
        while (playerOccupying == PlayerOccupyEnum.Navigation)
        {
            navTestButton.interactable = false;
            break;
        }
    }
    public void m_OnLightClick()
    {
        playerOccupying = PlayerOccupyEnum.Lights;
        while (playerOccupying == PlayerOccupyEnum.Lights)
        {
            lightsTestButton.interactable = false;
            break;
        }
    }
}
