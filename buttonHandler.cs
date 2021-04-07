using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonHandler : MonoBehaviour {
    public int buttonIdentifier;
    public GameObject Handler;
	// Use this for initialization
	public void createObject()
    {
        if(buttonIdentifier == 0)
        {
            Handler.SendMessage("CreateAIObject0");
        }
        else if (buttonIdentifier == 1)
        {
            Handler.SendMessage("CreateAIObject1");
        }
        else if (buttonIdentifier == 2)
        {
            Handler.SendMessage("CreateAIObject2");
        }
        else if (buttonIdentifier == 3)
        {
            Handler.SendMessage("CreateAIObject3");
        }
        else if (buttonIdentifier == 4)
        {
            Handler.SendMessage("CreateAIObject4");
        }
        else if (buttonIdentifier == 5)
        {
            Handler.SendMessage("CreateAIObject5");
        }
    }
}
