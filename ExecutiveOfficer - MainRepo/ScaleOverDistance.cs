using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleOverDistance : MonoBehaviour
{
    /// <summary>
    /// This script is a visual enhancement script. It enlarges stellar bodies as the player approaches them.
    /// -Takes player distance to object
    /// -Scales based on distance, up to a max scale.
    /// </summary>

    public float targetScale;
    public float timeToLerp = 0.25f;
    float scaleModifier = 5;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LerpObjectSize(targetScale, timeToLerp));
    }

    IEnumerator LerpObjectSize(float endValue, float duration)
    {
        float time = 0;
        float startValue = scaleModifier;
        Vector3 startScale = transform.localScale;

        while (time < duration)
        {
            scaleModifier = Mathf.Lerp(startValue, endValue, time / duration);
            transform.localScale = startScale * scaleModifier;
            time += Time.deltaTime;
            yield return null;
        }
        transform.localScale = startScale * targetScale;
        scaleModifier = targetScale;
    }
}
