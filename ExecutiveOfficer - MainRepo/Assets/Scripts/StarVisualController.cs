using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarVisualController : MonoBehaviour
{
    private Light starLight; //Star bright
    private Renderer rend;
    private Color colorToSet;
    public SystemBehaviour sysBehavior; //Plug in color from system data here

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        //Need to check for the sys with isPlayerLocation = true
        colorToSet = sysBehavior.starColor;
        StarObjectGen();
    }

    void StarObjectGen()
    {
        starLight.color = colorToSet;
        rend.material.SetColor("MainColor", colorToSet);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
