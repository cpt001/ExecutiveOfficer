using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MasterSceneStoryScript : MonoBehaviour
{
    public TextMeshProUGUI text1;
    public TextMeshProUGUI text2;
    public float timeForTextToFadeIn = 4.0f;
    public GameObject button;
    public GameObject canvas;
    public PlayerManager manager;

    private void Awake()
    {
        text1.alpha = 0;
        text2.alpha = 0;
        button.SetActive(false);
        manager = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>();
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FirstTextSplash());
        manager.menuActive = true;
    }

    public IEnumerator FirstTextSplash()
    {
        yield return new WaitForSeconds(2.0f);
        text1.alpha = Mathf.Lerp(0, 255, timeForTextToFadeIn);
        StartCoroutine(SecondTextSplash());
    }
    public IEnumerator SecondTextSplash()
    {
        yield return new WaitForSeconds(2.0f);
        text2.alpha = Mathf.Lerp(0, 255, timeForTextToFadeIn);
        StartCoroutine(InitializeButton());
    }
    public IEnumerator InitializeButton()
    {
        yield return new WaitForSeconds(3.0f);
        button.SetActive(true);
    }

    public void ButtonInitialization()
    {
        canvas.SetActive(false);
        manager.menuActive = false; 
    }
}
