using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class MeteorPistol : MonoBehaviour
{
	[SerializeField] ParticleSystem particles;
	
	[SerializeField] LayerMask layerMask;
	[SerializeField] Transform shootSource;
	[SerializeField] float distance = 10;
	
	private bool rayActivate = false;
	
	// Start is called before the first frame update
	void Start()
	{
		XRGrabInteractable grabInteractable = GetComponent<XRGrabInteractable>();
		grabInteractable.activated.AddListener(x => StartShoot());
		grabInteractable.deactivated.AddListener(x => StopShoot());
	}
	
	public void StartShoot()
	{
		particles.Play();
		rayActivate = true;
	}
	
	public void StopShoot() 
	{
		particles.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
		rayActivate = false;
	}

	// Update is called once per frame
	void Update()
	{
		if(rayActivate)
			RaycastCheck();
	}
	
	void RaycastCheck() 
	{
		RaycastHit hit;
		bool hasHit = Physics.Raycast(shootSource.position, shootSource.forward, 
			out hit, distance, layerMask);
			
		if(hasHit) 
		{
			hit.transform.gameObject.SendMessage("Break", SendMessageOptions.DontRequireReceiver);
		}
	}
}
