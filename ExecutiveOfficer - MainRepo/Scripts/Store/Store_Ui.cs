using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Store_Ui : MonoBehaviour
{
    /// <summary>
    /// This is the script responsible for populating the store UI.
    /// -Contains sprites referenced by standardItems
    /// </summary>
    #region Sprite Information
    public Sprite hullSprite;
    public Sprite armorSprite;
    public Sprite hardpointSprite;
    public Sprite fighterSprite;
    public Sprite fighterRepairSprite;
    public Sprite lightMunitionsSprite;
    public Sprite mainGunSprite;
    public Sprite missileSprite;

    private static Store_Ui _i;
    public static Store_Ui i
    {
        get
        {
            if (_i == null)
            {
                _i = Instantiate(Resources.Load<Store_Ui>("Store_UI"));

            }
            return i;
        }
    }
    #endregion

    private Transform container;
    private Transform shopItemTemplate;

    private void Awake()
    {
        container = transform.Find("Container");
        shopItemTemplate = container.Find("ShopItemTemplate");
        shopItemTemplate.gameObject.SetActive(false);
    }

    private void Start()
    {
        #region Button Creation
        //Create button with info: item, sprite, "name", cost, position
        CreateStandardItemButton(StandardItems.ItemType.HullRepairs, StandardItems.GetSprite(StandardItems.ItemType.HullRepairs), "Hull Repairs", StandardItems.GetCost(StandardItems.ItemType.HullRepairs), 0);
        CreateStandardItemButton(StandardItems.ItemType.ArmorRepairs, StandardItems.GetSprite(StandardItems.ItemType.ArmorRepairs), "Armor Repairs", StandardItems.GetCost(StandardItems.ItemType.ArmorRepairs), 1);
        CreateStandardItemButton(StandardItems.ItemType.HardpointRepairs, StandardItems.GetSprite(StandardItems.ItemType.HardpointRepairs), "Hardpoint Repairs", StandardItems.GetCost(StandardItems.ItemType.HardpointRepairs), 2);
        CreateStandardItemButton(StandardItems.ItemType.Fighters, StandardItems.GetSprite(StandardItems.ItemType.Fighters), "Fighter", StandardItems.GetCost(StandardItems.ItemType.Fighters), 3);
        CreateStandardItemButton(StandardItems.ItemType.FighterRepairs, StandardItems.GetSprite(StandardItems.ItemType.FighterRepairs), "Fighter Repairs", StandardItems.GetCost(StandardItems.ItemType.FighterRepairs), 4);
        CreateStandardItemButton(StandardItems.ItemType.LightMunitions, StandardItems.GetSprite(StandardItems.ItemType.LightMunitions), "Light Munitions", StandardItems.GetCost(StandardItems.ItemType.LightMunitions), 5);
        CreateStandardItemButton(StandardItems.ItemType.MainGunMunitions, StandardItems.GetSprite(StandardItems.ItemType.MainGunMunitions), "Main Gun Munitions", StandardItems.GetCost(StandardItems.ItemType.MainGunMunitions), 6);
        CreateStandardItemButton(StandardItems.ItemType.Missiles, StandardItems.GetSprite(StandardItems.ItemType.Missiles), "Missiles", StandardItems.GetCost(StandardItems.ItemType.Missiles), 7);
        #endregion
    }

    //This function gets an item and information, then sets its position
    private void CreateStandardItemButton(StandardItems.ItemType itemType, Sprite itemSprite, string itemName, int itemCost, int positionIndex)
    {
        Transform shopItemTransform = Instantiate(shopItemTemplate, container);
        RectTransform shopItemRectTransform = shopItemTransform.GetComponent<RectTransform>();

        float shopItemHeight = 30f;
        shopItemRectTransform.anchoredPosition = new Vector2(0, -shopItemHeight * positionIndex);

        shopItemTransform.Find("itemName").GetComponent<TextMeshProUGUI>().SetText(itemName);
        shopItemTransform.Find("costText").GetComponent<TextMeshProUGUI>().SetText(itemCost.ToString());

        shopItemTransform.Find("itemImage").GetComponent<Image>().sprite = itemSprite;

        /*shopItemTransform.GetComponent<Button>().onClick
        {
            //Clicked on button
        }*/
    }

    #region Button Interactions
    void HullRepairButton()
    {

    }
    void ArmorRepairButton()
    {

    }
    void HardPointRepairButton()
    {

    }
    void FighterButton()
    {

    }
    void FighterRepairButton()
    {

    }
    void LightMunitionButton()
    {

    }
    void MainGunMunitionButton()
    {

    }
    void MissileButton()
    {

    }
    #endregion
}
