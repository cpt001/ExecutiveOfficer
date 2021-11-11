using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Tutorial : MonoBehaviour
{
    public float timeToHold;
    public float timeHeld;
    public TextMeshProUGUI tutorialText;
    public bool backCompleted;
    public bool yawCompleted;
    public bool rollCompleted;
    public bool pitchCompleted;
    //public bool maneuverCompleted;
    //public bool basicTutorialFinished;
    public GameObject tutorialPanel;

    private void Start()
    {
        tutorialText.text = "Hold S to accelerate backward";
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.S) && !backCompleted)    //Ship moves out of dock
        {
            timeHeld += Time.deltaTime;
            if (timeHeld >= timeToHold)
            {
                tutorialText.text = "Hold A or D to swing your yaw";
                timeHeld = 0;
                backCompleted = true;
            }
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) && !yawCompleted && backCompleted)   //Swing yaw
        {
            timeHeld += Time.deltaTime;
            if (timeHeld >= timeToHold / 2)
            {
                tutorialText.text = "Hold Q or E to roll your ship";
                timeHeld = 0;
                yawCompleted = true;
            }
        }
        if (Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.E) && !rollCompleted && yawCompleted)   //Roll
        {
            timeHeld += Time.deltaTime;
            if (timeHeld >= timeToHold)
            {
                tutorialText.text = "Hold Space or C to pitch your ship";
                timeHeld = 0;
                rollCompleted = true;
            }
        }
        if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.C) && !pitchCompleted && rollCompleted)   //Pitch
        {
            timeHeld += Time.deltaTime;
            if (timeHeld >= timeToHold)
            {
                tutorialText.text = "Try combining pitch, yaw, and roll to aim your ship at the waypoint";
                timeHeld = 0;
                pitchCompleted = true;
                StartCoroutine(PostTutorialSequence());
            }
        }
        /*if (Physics.Raycast(GameObject.FindWithTag("Player").transform.position, Vector3.forward, Mathf.Infinity, layerMask: 18) && pitchCompleted && !basicTutorialFinished)
        {
            if (GameObject.FindWithTag("JumpSite"))
            {
                tutorialText.text = "Hold W to accelerate forward";
                maneuverCompleted = true;
                StartCoroutine(PostTutorialSequence());
            }
        }*/
    }

    public IEnumerator PostTutorialSequence()
    {
        //Temporary
        yield return new WaitForSeconds(8.0f);
        tutorialText.text = "Hold W to accelerate forward";

        //basicTutorialFinished = true;
        yield return new WaitForSeconds(15.0f);
        tutorialText.text = "Weapons are enabled. Press ~ to enter targeting mode.";
        yield return new WaitForSeconds(8.0f);
        tutorialText.text = "Press 1-0, or tab to cycle between weapon groups.";
        yield return new WaitForSeconds(8.0f);
        tutorialText.text = "Have fun shooting ships! This panel will disappear shortly.";
        yield return new WaitForSeconds(12.0f);
        tutorialPanel.SetActive(false);
        yield return null;
    }
}
