﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//High damage, lower rate of fire
public class AKBaseWeaponBehavior : WeaponBehavior
{
    // Start is called before the first frame update
    void Start()
    {
        fireRate = Random.Range(0.12f, 0.15f);
        accuracy = Random.Range(0.5f, 0.6f);
        reloadSpeed = Random.Range(1.5f, 2f);
        damage = 5;
        projectileSpeed = 1000f;
        numOfProjectiles = 1;
        magazineSize = 30;
        magazineTracker = magazineSize;
    }

    // Update is called once per frame
    void Update()
    {
        Physics2D.IgnoreCollision(player.GetComponent<BoxCollider2D>(), bulletType.GetComponent<CircleCollider2D>());

        CheckFire();

        CheckReload();

        CheckAim();
    }

    void FixedUpdate()
    {

    }

    public override void WhiteStats()
    {
        fireRate = Random.Range(0.12f, 0.15f);
        accuracy = Random.Range(0.5f, 0.6f);
        reloadSpeed = Random.Range(1.5f, 2f);
        damage = 5;
    }

    public override void GreenStats()
    {
        fireRate = Random.Range(0.1f, 0.12f);
        accuracy = Random.Range(0.6f, 0.7f);
        reloadSpeed = Random.Range(1.2f, 1.5f);
        damage = 6;
    }

    public override void BlueStats()
    {
        fireRate = Random.Range(0.08f, 0.1f);
        accuracy = Random.Range(0.7f, 0.8f);
        reloadSpeed = Random.Range(1f, 1.2f);
        damage = 7;
    }
}
