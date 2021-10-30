using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Store : MonoBehaviour
{
    /// <summary>
    /// Critical Bug: PlayerWallet isn't stored in memory, and when store 'closes' the PlayerWallet is lost.
    /// MA - Maintains
    /// 
    /// Still to introduce to system
    /// -Quantity view
    /// -Restock Mechanic?
    /// </summary>
    /// 
    [Header("Store Hard Information")]
    public GameObject storeMasterObject;    //The canvas master object
    public GameObject storePromptText;      //UI to inform player

    public enum StoreType
    {
        No_Store,
        Bazaar,         //Sells everything, price raised by 1.25x
        MunitionDepot,  //Only sells munitions
        RepairDepot,    //Repair all
        CivilianDepot,  //Only sells armor and hull
        MercenaryDepot, //Prices raised by 2x
        AbandonedStation,   //Prices are free, but very limited supply
    }
    [Header("Store Type")]
    public StoreType typeOfStore;
    public TextMeshProUGUI storeTypeText;

    [Header("Store Visual Objects")]
    public GameObject bazaarObject;
    public GameObject munitionObject;
    //public GameObject repairObject;
    //public GameObject civilianObject;
    //public GameObject mercenaryObject;
    [Space]
    public PlayerManager playerWallet = null;
    public TextMeshProUGUI storeWalletText;
    public bool allowedToDisplayStore = false;
    #region ButtonGOArray
    [Header("Button Information")]
    [Space]
    public GameObject HullButton;
    public TextMeshProUGUI HullCounter;
    public GameObject ArmorButton;
    public TextMeshProUGUI ArmorCounter;
    public GameObject HardPointButton;
    public TextMeshProUGUI HardPointCounter;
    public GameObject FighterButton;
    public TextMeshProUGUI FighterCounter;
    public GameObject FighterRepairButton;
    public TextMeshProUGUI FighterRepairCounter;
    public GameObject LightButton;
    public TextMeshProUGUI LightCounter;
    public GameObject MainGunButton;
    public TextMeshProUGUI MainGunCounter;
    public GameObject MissileButton;
    public TextMeshProUGUI MissileCounter;
    #endregion

    #region ItemVisibilityInStore   //Determines if the item is in the store
    [Space]
    [Header("Item Visibility in Store")]
    private bool hullRepairs = false;
    private bool armorRepairs = false;
    private bool hardpointRepairs = false;
    private bool fighters = false;
    private bool fighterRepairs = false;
    private bool lightMunitions = false;
    private bool mainGunMunitions = false;
    private bool missiles = false;
    #endregion

    #region itemsAvailableInShop    //Determines how many items are in the shop
    [Space]
    [Header("Items Available In Shop")]
    public int hullRepairsAvailable = 0;
    public int armorRepairsAvailable = 0;
    public int hardpointRepairsAvailable = 0;
    public float fightersAvailable = 0;
    public float fighterRepairsAvailable = 0;
    public int lightMunitionsAvailable = 0;
    public int mainGunMunitionsAvailable = 0;
    public int missilesAvailable = 0;
    #endregion

    #region maxItemsAvailableInShop //Determines the maximum number of items in the shop
    [Space]
    [Header("Max Possible Items Available In This Shop")]
    public int maxHullRepairs = 0;
    public int maxArmorRepairs = 0;
    public int maxHardpointRepairs = 0;
    public float maxFighters = 0;
    public float maxFighterRepairs = 0;
    public int maxLightMunitions = 0;
    public int maxMainGunMunitions = 0;
    public int maxMissiles = 0;
    #endregion

    #region itemsRestockedPerDayInShop  //Determines how many items are restocked every day
    [Space]
    [Header("Items Restocked Per Day [Day not defined]")]
    public int dailyRestockHullRepairs = 0;
    public int dailyRestockArmorRepairs = 0;
    public int dailyRestockHardpointRepairs = 0;
    public float dailyRestockFighters = 0;
    public float dailyRestockFighterRepairs = 0;
    public int dailyRestockLightMunitions = 0;
    public int dailyRestockNainGunMunitions = 0;
    public int dailyRestockMissiles = 0;
    #endregion

    #region PricePerItem    //[Incomplete] Determines the price for each individual item
    [Space]
    [Header("Item Prices")]
    public float storePriceMultiplyer = 1f;
    public float hullRepairPrice = 25;
    public float armorRepairPrice = 35;
    public float hardpointRepairPrice = 200;
    public float fighterPrice = 250;
    public float fighterRepairPrice = 30;
    public float lightMunitionPrice = 10;
    public float mainGunMunitionPrice = 50;
    public float missilePrice = 100;
    #endregion

    #region ShipSliders
    [Header("Player Ship Status Sliders")]
    [Space]
    public Slider playerHullHP;
    public Slider playerArmorHP;
    public Slider playerHardpointHp;
    public Slider playerNumSquadrons;
    public Slider playerNumFighterRepairs;
    public Slider playerLightMunitions;
    public Slider playerMainMunitions;
    public Slider playerMissiles;
    #endregion
    void Start()
    {
        playerWallet = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>();

        typeOfStore = (StoreType)Random.Range(0, 6);    //Randomizes store contents
        storeTypeText.text = typeOfStore.ToString();
        #region Button Active False
        HullButton.SetActive(false);
        ArmorButton.SetActive(false);
        HardPointButton.SetActive(false);
        FighterButton.SetActive(false);
        FighterRepairButton.SetActive(false);
        LightButton.SetActive(false);
        MainGunButton.SetActive(false);
        MissileButton.SetActive(false);
        #endregion
        #region Max Value Assignment for Sliders
        playerHullHP.maxValue = playerWallet.hullTempHP;
        playerArmorHP.maxValue = playerWallet.armorTempHP;
        playerHardpointHp.maxValue = playerWallet.hardPointTempHP;
        playerNumSquadrons.maxValue = playerWallet.maxNumSquadrons;
        playerNumFighterRepairs.maxValue = playerWallet.maxNumFighterRepairs;
        playerLightMunitions.maxValue = playerWallet.maxLightMunitions;
        playerMainMunitions.maxValue = playerWallet.maxNumMainGunMunitions;
        playerMissiles.maxValue = playerWallet.maxNumMissiles;
        #endregion
        storeMasterObject.SetActive(false);
        storePromptText.SetActive(false);
        GenerateStore();
        PopulateStores();
    }

    void GenerateStore()    //This function determines what presets stores utilize
    {
        switch (typeOfStore)
        {
            case StoreType.Bazaar:
                {
                    Instantiate(bazaarObject, transform);
                    hullRepairs = true;
                        maxHullRepairs = 100;
                        hullRepairsAvailable = 100;
                    armorRepairs = true;
                        maxArmorRepairs = 100;
                        armorRepairsAvailable = 100;
                    hardpointRepairs = true;
                        maxHardpointRepairs = 100;
                        hardpointRepairsAvailable = 100;
                    fighters = true;
                        maxFighters = 100;
                        fightersAvailable = 100;
                    fighterRepairs = true;
                        maxFighterRepairs = 100;
                        fighterRepairsAvailable = 100;
                    lightMunitions = true;
                        maxLightMunitions = 100;
                        lightMunitionsAvailable = 100;
                    mainGunMunitions = true;
                        maxMainGunMunitions = 100;
                        mainGunMunitionsAvailable = 100;
                    missiles = true;
                        maxMissiles = 100;
                        missilesAvailable = 100;

                    storePriceMultiplyer = 1.15f;
                    RestockContents();
                    break;
                }
            case StoreType.MunitionDepot:
                {
                    Instantiate(munitionObject, transform);
                    lightMunitions = true;
                        maxLightMunitions = 100;
                        lightMunitionsAvailable = 100;
                    mainGunMunitions = true;
                        maxMainGunMunitions = 100;
                        mainGunMunitionsAvailable = 100;
                    missiles = true;
                        maxMissiles = 100;
                        missilesAvailable = 100;
                    storePriceMultiplyer = .85f;
                    RestockContents();
                    break;
                }
            /*case StoreType.RepairDepot:
                {
                    Instantiate(repairObject, transform);
                    hullRepairs = true;
                        maxHullRepairs = 100;
                        hullRepairsAvailable = 100;
                    armorRepairs = true;
                        maxArmorRepairs = 100;
                        armorRepairsAvailable = 100;
                    hardpointRepairs = true;
                        maxHardpointRepairs = 100;
                        hardpointRepairsAvailable = 100;
                    fighterRepairs = true;
                        maxFighterRepairs = 100;
                        fighterRepairsAvailable = 100;
                    storePriceMultiplyer = 1f;
                    RestockContents();
                    break;
                }
            case StoreType.CivilianDepot:
                {
                    Instantiate(civilianObject, transform);
                    hullRepairs = true;
                        maxHullRepairs = 100;
                        hullRepairsAvailable = 100;
                    armorRepairs = true;
                        maxArmorRepairs = 100;
                        armorRepairsAvailable = 100;
                    storePriceMultiplyer = 1.25f;
                    RestockContents();
                    break;
                }
            case StoreType.MercenaryDepot:
                {
                    Instantiate(mercenaryObject, transform);
                    fighters = true;
                        maxFighters = 100;
                        fightersAvailable = 100;
                    lightMunitions = true;
                        maxLightMunitions = 100;
                        lightMunitionsAvailable = 100;
                    mainGunMunitions = true;
                        maxMainGunMunitions = 100;
                        mainGunMunitionsAvailable = 100;
                    missiles = true;
                        maxMissiles = 100;
                        missilesAvailable = 100;
                    storePriceMultiplyer = 2.25f;
                    RestockContents();
                    break;
                }*/
            case StoreType.AbandonedStation:    //AS's need to be randomized
                {
                    //var spawnedStationVisual = Instantiate(, transform);
                    hullRepairs = false;
                    armorRepairs = false;
                    hardpointRepairs = false;
                    fighters = false;
                    fighterRepairs = false;
                    lightMunitions = false;
                    mainGunMunitions = false;
                    missiles = false;
                    storePriceMultiplyer = 0f;
                    RestockContents();
                    break;
                }
        }            
    }

    void PopulateStores()   //[Partially Complete] This function determines what's shown in store panels, and populates them with an initial quantity.
    {
        if (hullRepairs == true)
        {
            HullButton.SetActive(true);

        }
        if (armorRepairs == true)
        {
            ArmorButton.SetActive(true);
        }
        if (hardpointRepairs == true)
        {
            HardPointButton.SetActive(true);
        }
        if (fighters == true)
        {
            FighterButton.SetActive(true);
        }
        if (fighterRepairs == true)
        {
            FighterRepairButton.SetActive(true);
        }
        if (lightMunitions == true)
        {
            LightButton.SetActive(true);
        }
        if (mainGunMunitions == true)
        {
            MainGunButton.SetActive(true);
        }
        if (missiles == true)
        {
            MissileButton.SetActive(true);
        }
    }

    void RestockContents()  //[Incomplete] This function restocks stores periodically with new supplies
    {
        if (hullRepairsAvailable > maxHullRepairs)
        {

        }
        if (armorRepairsAvailable > maxArmorRepairs)
        {

        }
        if (hardpointRepairsAvailable > maxHardpointRepairs)
        {

        }
        if (fightersAvailable > maxFighters)
        {

        }
        if (fighterRepairsAvailable > maxFighterRepairs)
        {

        }
        if (lightMunitionsAvailable > maxLightMunitions)
        {

        }
        if (mainGunMunitionsAvailable > maxMainGunMunitions)
        {

        }
        if (missilesAvailable > maxMissiles)
        {

        }
    }

    public void OnTriggerStay(Collider other)   //This function shows the player an option to open the store when they enter the collider
    {
        if (other.tag == "Player")
        {
            allowedToDisplayStore = true;
            Debug.Log($"Player has entered {typeOfStore} range");
            storePromptText.SetActive(true);
            playerWallet = other.gameObject.GetComponent<PlayerManager>();
            if (playerWallet.showStore == true && allowedToDisplayStore == true)
            {
                storeMasterObject.SetActive(true);
                storePromptText.SetActive(false);
            }
            storeWalletText.text = ("Galactic Credits: " + playerWallet.GalacticCredits);
        }
        else
        {
            playerWallet = null;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        storePromptText.SetActive(false);
        storeMasterObject.SetActive(false);
        allowedToDisplayStore = false;
        playerWallet.showStore = false;
    }

    #region Button Interactions for Purchase
    //These functions are button triggers for purchasing items
    public void PurchaseHullRepair()
    {
        if (hullRepairsAvailable > 0 && playerWallet.GalacticCredits >= hullRepairPrice && playerWallet.canRepairHull)
        {
            hullRepairsAvailable--;
            playerWallet.GalacticCredits -= hullRepairPrice;
            playerWallet.hullTempHP += 5;
            Debug.Log("Hull Repair purchased successfully");
        }
        else
        {
            Debug.Log("No hull repairs available");
        }
    }
    public void PurchaseArmorRepair()
    {
        if (armorRepairsAvailable > 0 && playerWallet.GalacticCredits >= armorRepairPrice && playerWallet.canRepairArmor)
        {
            armorRepairsAvailable--;
            playerWallet.GalacticCredits -= armorRepairPrice;
            playerWallet.armorTempHP += 5;
            Debug.Log("Armor Repair purchased successfully");
        }
        else
        {
            Debug.Log("No armor repairs available");
        }
    }
    public void PurchaseHardpointRepair()
    {
        if (hardpointRepairsAvailable > 0 && playerWallet.GalacticCredits >= hardpointRepairPrice  && playerWallet.canRepairHardpoints)
        {
            hardpointRepairsAvailable--;
            playerWallet.GalacticCredits -= hardpointRepairPrice;
            playerWallet.hardPointTempHP += 5;
            Debug.Log("Hardpoint repair purchased successfully");
        }
        else
        {
            Debug.Log("No hardpoint repairs available");
        }
    }
    public void PurchaseFighter()
    {
        if (fightersAvailable > 0 && playerWallet.GalacticCredits >= fighterPrice && playerWallet.canPurchaseSquadrons)
        {
            fightersAvailable--;
            playerWallet.GalacticCredits -= fighterPrice;
            playerWallet.numSquadrons += 1;
            Debug.Log("Fighter purchased successfully");
        }
        else
        {
            Debug.Log("No Fighters available");
        }
    }
    public void PurchaseFighterRepair()
    {
        if (fighterRepairsAvailable > 0 && playerWallet.GalacticCredits >= fighterRepairPrice && playerWallet.canPurchaseFighterRepairs)
        {
            fighterRepairsAvailable--;
            playerWallet.GalacticCredits -= fighterRepairPrice;
            playerWallet.numFighterRepairs += 10;
            Debug.Log("Fighter repair purchased successfully");
        }
        else
        {
            Debug.Log("No fighter repairs available");
        }
    }
    public void PurchaseLightMunitions()
    {
        if (lightMunitionsAvailable > 0 && playerWallet.GalacticCredits >= lightMunitionPrice && playerWallet.canPurchaseLightMunitions)
        {
            lightMunitionsAvailable--;
            playerWallet.GalacticCredits -= lightMunitionPrice;
            playerWallet.lightMunitions += 200;
            Debug.Log("Light munitions purchased successfully");
        }
        else
        {
            Debug.Log("No light munitions available");
        }
    }
    public void PurchaseMainGunMunitions()
    {
        if (mainGunMunitionsAvailable > 0 && playerWallet.GalacticCredits >= mainGunMunitionPrice && playerWallet.canPurchaseMainGunMunitions)
        {
            mainGunMunitionsAvailable--;
            playerWallet.GalacticCredits -= mainGunMunitionPrice;
            playerWallet.mainGunMunitions += 50;
            Debug.Log("Main gun munitions purchased successfully");
        }
        else
        {
            Debug.Log("No main gun munitions available");
        }
    }
    public void PurchaseMissiles()
    {
        if (missilesAvailable > 0 && playerWallet.GalacticCredits >= missilePrice && playerWallet.canPurchaseMissiles)
        {
            missilesAvailable--;
            playerWallet.GalacticCredits -= missilePrice;
            playerWallet.numMissiles += 30;
            Debug.Log("Missiles purchased successfully");
        }
        else
        {
            Debug.Log("No missiles available");
        }
    }
    #endregion

    private void Update()
    {
        if (playerWallet)
        {
            playerHullHP.value = playerWallet.hullTempHP;
            playerArmorHP.value = playerWallet.armorTempHP;
            playerHardpointHp.value = playerWallet.hardPointTempHP;
            playerNumSquadrons.value = playerWallet.numSquadrons;
            playerNumFighterRepairs.value = playerWallet.numFighterRepairs;
            playerLightMunitions.value = playerWallet.lightMunitions;
            playerMainMunitions.value = playerWallet.mainGunMunitions;
            playerMissiles.value = playerWallet.numMissiles;

            if (Input.GetKeyDown(KeyCode.Escape) && storeMasterObject.activeSelf == true)
            {
                storeMasterObject.SetActive(false);
            }
        }
    }
}
