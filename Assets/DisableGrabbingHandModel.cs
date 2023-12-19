using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

// This script makes the right or left hand invisible (by tag) upon grabbing an object in the scene.
public class DisableGrabbingHandModel : MonoBehaviour
{
	
	public GameObject leftHandModel;
	public GameObject rightHandModel;
	// Start is called before the first frame update
	void Start()
	{
		XRGrabInteractable grabInteractable = GetComponent<XRGrabInteractable>();
		//Observers or listeners below.
		grabInteractable.selectEntered.AddListener(HideGrabbingHand);
		grabInteractable.selectExited.AddListener(ShowGrabbingHand);
	}
	
	// Observables or events goes under here.
	public void HideGrabbingHand(SelectEnterEventArgs args) 
	{
		if(args.interactorObject.transform.tag == "Left Hand") 
		{
			leftHandModel.SetActive(false);
		}
		else if(args.interactorObject.transform.tag == "Right Hand") 
		{
			rightHandModel.SetActive(false);
		}
	}

	public void ShowGrabbingHand(SelectExitEventArgs args) 
	{
		if(args.interactorObject.transform.tag == "Left Hand") 
		{
			leftHandModel.SetActive(true);
		}
		else if(args.interactorObject.transform.tag == "Right Hand") 
		{
			rightHandModel.SetActive(true);
		}
	}

}
