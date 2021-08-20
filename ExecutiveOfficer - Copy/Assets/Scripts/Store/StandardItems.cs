using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardItems
{
    /// <summary>
    /// This script is responsible for holding base item prices, and sprites
    /// </summary>
    /// 
    public enum ItemType
    {
        HullRepairs,
        ArmorRepairs,
        HardpointRepairs,
        Fighters,
        FighterRepairs,
        LightMunitions,
        MainGunMunitions,
        Missiles,
    }

    public static int GetCost(ItemType itemtype)
    {
        switch (itemtype)
        {
            default:
            case ItemType.HullRepairs:          return 25;
            case ItemType.ArmorRepairs:         return 35;
            case ItemType.HardpointRepairs:     return 200;
            case ItemType.Fighters:             return 250;
            case ItemType.FighterRepairs:       return 30;
            case ItemType.LightMunitions:       return 10;
            case ItemType.MainGunMunitions:     return 50;
            case ItemType.Missiles:             return 100;
        }
    }

    public static Sprite GetSprite(ItemType itemtype)
    {
        switch (itemtype)
        {
            default:
            case ItemType.HullRepairs:          return Store_Ui.i.hullSprite;
            case ItemType.ArmorRepairs:         return Store_Ui.i.armorSprite;
            case ItemType.HardpointRepairs:     return Store_Ui.i.hardpointSprite;
            case ItemType.Fighters:             return Store_Ui.i.fighterSprite;
            case ItemType.FighterRepairs:       return Store_Ui.i.fighterRepairSprite;
            case ItemType.LightMunitions:       return Store_Ui.i.lightMunitionsSprite;
            case ItemType.MainGunMunitions:     return Store_Ui.i.mainGunSprite;
            case ItemType.Missiles:             return Store_Ui.i.missileSprite;
        }
    }
}
