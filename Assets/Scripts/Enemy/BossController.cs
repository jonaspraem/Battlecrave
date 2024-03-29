﻿using System;
using UnityEngine;
using System.Collections;
using System.Diagnostics;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Debug = UnityEngine.Debug;

public class BossController : MonoBehaviour {
    public int startingHealth = 5500;
    private int currentHealth = 5500;
    private bool isDead = false;
    public GameObject deadhigh;
    public GameObject returnscreen;
	public GameObject canvas;

    private ParticleSystem hitParticles;

    public void Awake()
    {
        if (GameStats.difficult == "Easy") startingHealth = 5500;
         if (GameStats.difficult == "Medium") startingHealth = 5500 * 2;
                  if (GameStats.difficult == "Hard") startingHealth = 5500 * 5;
         currentHealth = startingHealth;


    }
    void Update()
    {
        if (currentHealth <= 0)
        {
            Death();
        }
    }
    public void TakeDamage(int amount, Vector3 hitPoint) {
        if (isDead) return;

        currentHealth -= amount;

        //hitParticles.transform.position = hitPoint;
        //hitParticles.Play();

        if (currentHealth <= 0) {
            Death();
        }

    }
    void Death() {
		canvas.SetActive (true);
        isDead = true;
		Destroy (gameObject);
        GameStats.timer = timer.gametime;
        Debug.Log("GS is now" + GameStats.timer);
        GameStats.status = "win";
        deadhigh.SetActive(true);
        returnscreen.SetActive(true);
        //SceneManager.LoadScene("EndScene");
        //Destroy(this.gameObject);
        //CapsuleCollider.isTrigger = true;

    }

	public int GetCurrentHealth (){
		return currentHealth;
	}
}
