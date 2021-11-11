using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MasterSceneStoryScript : MonoBehaviour
{
    public TextMeshProUGUI text_standFast;   //Stand Fast
    public TextMeshProUGUI text_Alert;   //Alert
    public TextMeshProUGUI text_SystemType;   //System Type
    public TextMeshProUGUI text_Initialization;   //Initialization/OS&Faction

    public List<TextMeshProUGUI> flavorTexts = new List<TextMeshProUGUI>();
    //foreach text in list, ienum timer + text.position?
    //foreach char in text 

    public float timeForTextToFadeIn = 4.0f;
    public float timeBetweenTextPops = 0.1f;
    public float imageFadeIn = 6.0f;
    public GameObject button;
    public GameObject canvas;
    public PlayerManager manager;
    public GameObject classImage;

    public float textScrollSpeed;

    private void Awake()
    {
        text_standFast.alpha = 0;
        text_Alert.alpha = 0;
        text_SystemType.alpha = 0;
        button.SetActive(false);
        classImage.SetActive(false);
        //manager = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>();
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FirstTextSplash());
        if (manager != null)
        {
            manager.menuActive = true;
        }
        else
        {
            GameObject managerTemp = GameObject.FindGameObjectWithTag("Player");
            Debug.Log("Manager Missing! - Found: " + managerTemp.GetComponent<PlayerManager>() as string);
        }
        foreach (GameObject g in GameObject.FindGameObjectsWithTag("FlavorText"))
        {
            flavorTexts.Add(g.GetComponent<TextMeshProUGUI>());
            foreach(TextMeshProUGUI setupTMP in flavorTexts)
            {
                setupTMP.alpha = 0;
            }
        }
    }
    public void StartUpSequence()
    {
        foreach(TextMeshProUGUI tmp in flavorTexts)
        {
            StartCoroutine(TypeText(tmp.GetComponent<TextMeshProUGUI>(), flavorTexts.IndexOf(tmp) * .1f));
        }
    }
    public IEnumerator TypeText(TextMeshProUGUI textObjects, float timerAdjustment)
    {
        yield return new WaitForSeconds(timerAdjustment);
        textObjects.alpha = Mathf.Lerp(0, 255, timeForTextToFadeIn);
        yield return null;
    }

    public IEnumerator FirstTextSplash()
    {
        yield return new WaitForSeconds(2.0f);
        text_standFast.alpha = Mathf.Lerp(0, 255, timeForTextToFadeIn);
        StartCoroutine(SecondTextSplash());
        yield return new WaitForSeconds(2.0f);
        StartUpSequence();
    }
    public IEnumerator SecondTextSplash()
    {
        yield return new WaitForSeconds(4.5f);
        text_Alert.alpha = Mathf.Lerp(0, 255, timeForTextToFadeIn);
        text_Initialization.text = "Colonial Defense Force";
        text_SystemType.alpha = Mathf.Lerp(0, 255, timeForTextToFadeIn);
        classImage.SetActive(true);
        StartCoroutine(InitializeButton());
    }
    public IEnumerator InitializeButton()
    {
        yield return new WaitForSeconds(2.0f);
        button.SetActive(true);
        StartCoroutine(ButtonColorSwapping());
    }

    public IEnumerator ButtonColorSwapping()
    {
        while (true)
        {
            var colors = button.GetComponent<Button>().colors;

            yield return new WaitForSeconds(2);
            colors.normalColor = Color.red;
            button.GetComponent<Button>().colors = colors;

            yield return new WaitForSeconds(2);
            colors.normalColor = Color.yellow;
            button.GetComponent<Button>().colors = colors;
        }
    }

    public void ButtonInitialization()
    {
        canvas.SetActive(false);
        manager.menuActive = false; 
    }
}
