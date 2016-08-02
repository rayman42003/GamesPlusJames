﻿using UnityEngine;
using System.Collections;

public class Killer: MonoBehaviour {
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D obj)
    {
        Killable killable = obj.gameObject.GetComponentInChildren<Killable>();
        if (killable != null)
        {
            killable.Kill(obj.gameObject);
        }
    }
}
