﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateLobster : MonoBehaviour {
    public GameObject lobster;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player") lobster.SetActive(true);
    }
}
