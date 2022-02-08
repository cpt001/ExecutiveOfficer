using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorTest : MonoBehaviour
{
    public GameObject testObject = null;
    public Color originalColor;
    public float maxColorShiftPercentage = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            ShiftObjectColor();
        }
    }

    private void ShiftObjectColor() {
        testObject.GetComponent<Renderer>().material.color = GenerateShiftedColor(originalColor);
    }

    private Color GenerateShiftedColor(Color starColor) {
        print("Starting color: " + starColor + "!");
        float colorHue;
        float colorSaturation;
        float colorBrightness;
        float colorValueMin = 0.00f;
        float colorValueMax = 1.00f;
        //Convert rgb color to hsv values
        Color.RGBToHSV(starColor, out colorHue, out colorSaturation, out colorBrightness);
        print("Color HSV values: " + colorHue + ", " + colorSaturation + ", " + colorBrightness + "!");
        //modify color hue by percentage
        float colorModificationPercentage = UnityEngine.Random.Range(-maxColorShiftPercentage, maxColorShiftPercentage);
        colorModificationPercentage = (float)System.Math.Round(colorModificationPercentage, 2);
        print("Color mod percentage: " + colorModificationPercentage);
        print("Modified hue value: " + colorHue + "!");
        colorHue += colorModificationPercentage;
        colorHue = Mathf.Clamp(colorHue, colorValueMin, colorValueMax);
        //convert color to rgb
        starColor = Color.HSVToRGB(colorHue, colorSaturation, colorBrightness);
        return starColor;
    }
}
