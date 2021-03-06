﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Respawn : MonoBehaviour {

	public TrackNode respawnPoint;
	public bool respawnPlayer = false;
	public float verticalRespawnPoint = -50f;

	void Start () 
	{	
		RespawnPlayer ();
	}	
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		if (respawnPlayer || transform.position.y < verticalRespawnPoint) 
		{
			respawnPlayer = false;
			RespawnPlayer ();
		}
	}

	public void RespawnPlayer()
	{

		if (respawnPoint.GetNodeCount () <= 1) 
		{return;}

		float minDistance = float.MaxValue;
		int minDistanceNode = 0;
		int count = 0;

		for (int index = 0 ; index < respawnPoint.GetNodeCount() ; index++)
		{
			if (Vector3.Distance (transform.position, respawnPoint.GetNode(index)) < minDistance) 
			{
				minDistance = Vector3.Distance (transform.position, respawnPoint.GetNode(index));
				minDistanceNode = count;
			}
			count++;
		}

		if (minDistanceNode >= respawnPoint.GetNodeCount()) 
		{minDistanceNode = 0;}

		GetComponent<Rigidbody> ().velocity = Vector3.zero;
		GetComponent<Rigidbody> ().angularVelocity  = Vector3.zero;


		transform.position = respawnPoint.GetNode(minDistanceNode);
		transform.forward = respawnPoint.GetNode(minDistanceNode + 1) - transform.position;



	}



}
