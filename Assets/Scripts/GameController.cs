using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {

    public Text dialogue;
    public Text momDialogue;
    public Button dimLights;
    public Button raiseLights;
    public Light lights;
    public GameObject dialoguebox;

    private string dialogueText;
    private string momText;
    private char[] dialogueArr;
    private ArrayList dialogueList;

    private float seconds;
    int i; 
    // Use this for initialization
    void Start () {

        dialogue.text = "";
        momDialogue.text = "";
        /*dimLights.GetComponent <Image>().enabled = false;
        dimLights.GetComponent<Button>().enabled = false;
        dimLights.GetComponentInChildren<Text>().enabled = false;

        raiseLights.GetComponent<Image>().enabled = false;
        raiseLights.GetComponent<Button>().enabled = false;
        raiseLights.GetComponentInChildren<Text>().enabled = false;*/
        ToggleDimLights();
        ToggleRaiseLights();

        dialogueList = new ArrayList();
        dialogueText = "It's time for bed. Again. I'm never ready for Mom to turn out the " +
            "lights. The monsters come out when she turns out the lights.";
        dialogueList.Add(dialogueText);
        dialogueText= "Goodnight sweetie. Have pleasent dreams.";
        dialogueList.Add(dialogueText);

        dialogueArr = ((string)dialogueList[0]).ToCharArray();

        seconds = .08f;
        StartCoroutine(WriteToBox());
       

    }


    IEnumerator WriteToBox()
    {
        for(int i =0; i< dialogueArr.Length; i++) {
            dialogue.text = dialogue.text + dialogueArr[i];
            yield return new WaitForSeconds(seconds);
        }

        StartCoroutine(MomTurn());
    }

    IEnumerator MomTurn()
    {
        yield return new WaitForSeconds(2);
        dialogue.text = "";
        dialogueArr = ((string)dialogueList[1]).ToCharArray();
        for (int i = 0; i < dialogueArr.Length; i++)
        {
            momDialogue.text = momDialogue.text + dialogueArr[i];
            yield return new WaitForSeconds(seconds);
        }
        ToggleDimLights();
        
    }
    

    //Turn the lights on and off. AdjustLights is a wrapper for the other function. 
    public void AdjustLights()
    {
        print("successful");
        StartCoroutine(LightAdjust());
    
    }
    IEnumerator LightAdjust()
    {
        while (lights.intensity >= .38)
        {
            yield return new WaitForSeconds(seconds);

            lights.intensity -= .01f;
        }
        dialoguebox.GetComponent<SpriteRenderer>().enabled = false;
        ToggleDimLights();
        momDialogue.text = "";
        ToggleRaiseLights();


    }


    void ToggleDimLights()
    {
        if (dimLights.GetComponent<Image>().enabled)
        {
            dimLights.GetComponent<Image>().enabled = false;
            dimLights.GetComponent<Button>().enabled = false;
            dimLights.GetComponentInChildren<Text>().enabled = false;
        }
        else {
            dimLights.GetComponent<Image>().enabled = true;
            dimLights.GetComponent<Button>().enabled = true;
            dimLights.GetComponentInChildren<Text>().enabled = true;
        }
    }

    void ToggleRaiseLights()
    {
        if (raiseLights.GetComponent<Image>().enabled)
        {
            raiseLights.GetComponent<Image>().enabled = false;
            raiseLights.GetComponent<Button>().enabled = false;
            raiseLights.GetComponentInChildren<Text>().enabled = false;
        }
        else {
            raiseLights.GetComponent<Image>().enabled = true;
            raiseLights.GetComponent<Button>().enabled = true;
            raiseLights.GetComponentInChildren<Text>().enabled = true;
        }
    }

}

