using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StellarObjectGeneration : MonoBehaviour
{
    /// <summary>
    /// Our possible range for planets in a system goes from 800 - 5000
    /// 
    /// </summary>
    public enum PossibleStellarPositioning
    {
        NearStar,   //800 - 1000
        NS1,    //1200 - 1500
        NS2,    //1800 - 2100
        HabitableZone,  //2500 - 2800
        HZ1,    //3100 - 3400
        HZ2,    //3600 - 3800
        FarStar,    //4000 - 4200
        FS1,    //4500 - 4800
        FS2,    //5100 - 5400
        Exoplanet,  //6000+
    }
    public PossibleStellarPositioning stellarGenerationPosition;

    void OnZoneGeneration()
    {
         switch (stellarGenerationPosition)
        {
            case PossibleStellarPositioning.NearStar:
                {
                    bool canGenerate = false;
                    float chance = Random.Range(0, 100);
                    if (chance >= 0 && chance <= 33)
                    {
                        canGenerate = true;
                    }

                    if (canGenerate)
                    {
                        float generationPosition = Random.Range(800, 1000);
                    }
                    break;
                }
            case PossibleStellarPositioning.NS1:
                {
                    bool canGenerate;
                    break;
                }
            case PossibleStellarPositioning.NS2:
                {

                    break;
                }
            case PossibleStellarPositioning.HabitableZone:
                {

                    break;
                }
            case PossibleStellarPositioning.HZ1:
                {

                    break;
                }
            case PossibleStellarPositioning.HZ2:
                {

                    break;
                }
            case PossibleStellarPositioning.FarStar:
                {

                    break;
                }
            case PossibleStellarPositioning.FS1:
                {

                    break;
                }
            case PossibleStellarPositioning.FS2:
                {

                    break;
                }
            case PossibleStellarPositioning.Exoplanet:
                {

                    break;
                }
        }
    }
}
