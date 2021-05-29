using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public bool canRepairHull = true;
    public float hullTempHP;
    public bool canRepairArmor = true;
    public float armorTempHP;
    public bool canRepairHardpoints = true;
    public float hardPointTempHP;
    [Range(0, 6)]
    public float numSquadrons;    //Depleted through squadron destruction. Damaged fighters will reduce from the squadron repair stat to fix themselves. 7 fighters to a squadron.
    public float maxNumSquadrons = 6;
    public bool canPurchaseSquadrons;
    [Range(0, 120)]
    public float numFighterRepairs;    //This stat is strange. Destroyed fighters will take 10 from pool. Damaged fighters will take 0.x from pool to repair themselves. 12 spare fighters, or 120 minor repairs.
    public float maxNumFighterRepairs = 120;
    public bool canPurchaseFighterRepairs;
    [Range(0, 3000)]
    public int lightMunitions;  //Depleted through squadron and light turret engagement
    public int maxLightMunitions = 3000;
    public bool canPurchaseLightMunitions;
    [Range(0, 300)]
    public int numMissiles;     //Depleted through use of missiles
    public int maxNumMissiles = 300;
    public bool canPurchaseMissiles;
    [Range(0, 800)]
    public int mainGunMunitions;    //Depleted through main gun firing
    public int maxNumMainGunMunitions = 800;
    public bool canPurchaseMainGunMunitions;


    public float GalacticCredits = 25000;
    public TextMeshProUGUI creditText;

    // Update is called once per frame
    void Update()
    {
        creditText.text = ("Galactic Credits: ") + GalacticCredits;
        #region Spending Allowances
        if (numSquadrons < maxNumSquadrons)
        {
            canPurchaseSquadrons = true;
        }
        else
        {
            canPurchaseSquadrons = false;
        }
        if (numFighterRepairs < maxNumFighterRepairs)
        {
            canPurchaseFighterRepairs = true;
        }
        else
        {
            canPurchaseFighterRepairs = false;
        }
        if (lightMunitions < maxLightMunitions)
        {
            canPurchaseLightMunitions = true;
        }
        else
        {
            canPurchaseLightMunitions = false;
        }
        if (numMissiles < maxNumMissiles)
        {
            canPurchaseMissiles = true;
        }
        else
        {
            canPurchaseMissiles = false;
        }
        if (mainGunMunitions < maxNumMainGunMunitions)
        {
            canPurchaseMainGunMunitions = true;
        }
        else
        {
            canPurchaseMainGunMunitions = false;
        }
        #endregion
        #region Overage Corrections

        if (numSquadrons > maxNumSquadrons)
        {
            numSquadrons = maxNumSquadrons;
        }
        if (numFighterRepairs > maxNumFighterRepairs)
        {
            numFighterRepairs = maxNumFighterRepairs;
        }
        if (lightMunitions > maxLightMunitions)
        {
            lightMunitions = maxLightMunitions;
        }
        if (numMissiles > maxNumMissiles)
        {
            numMissiles = maxNumMissiles;
        }
        if (mainGunMunitions > maxNumMainGunMunitions)
        {
            mainGunMunitions = maxNumMainGunMunitions;
        }
        #endregion
    }
}
