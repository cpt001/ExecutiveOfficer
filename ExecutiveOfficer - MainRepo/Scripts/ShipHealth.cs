using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipHealth : MonoBehaviour
{
    public GameObject[] HullSections;       //Setting these up as arrays should allow us to manage/examine health by component
    public GameObject[] ArmorSections;
    public GameObject[] HardpointHealths;
}
