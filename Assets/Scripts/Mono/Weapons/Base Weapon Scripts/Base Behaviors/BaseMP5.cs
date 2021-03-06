﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseMP5 : WeaponBehavior
{
    public GameObject gripPrefab;
    public GameObject rapidFirePrefab;
    public GameObject baseStockPrefab;
    public GameObject shortStockPrefab;
    public GameObject ironSightPrefab;
    public GameObject scopePrefab;
    public GameObject barrelPrefab;
    public GameObject silencerPrefab;
    public GameObject extendedMagazinePrefab;
    public GameObject baseMagazinePrefab;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Physics2D.IgnoreCollision(player.GetComponent<BoxCollider2D>(), bulletType.GetComponent<CircleCollider2D>());

        CheckFire();

        CheckReload();

        CheckAim();
    }

    public override void CreateGun(float chance)
    {
        GunStats();

        //Roll for underbarrel
        float roll = Random.Range(0f, 1f);
        if (roll <= chance)
        {
            if (roll <= chance / 2)
            {
                Instantiate(gripPrefab, this.transform.Find("Grip Slot"));
                accuracy += 0.1f;
                rarity += 1;
                hasGrip = true;
            }
            else if (roll > chance / 2 && roll <= chance)
            {
                Instantiate(rapidFirePrefab, this.transform.Find("Rapid Fire Slot"));
                fireRate -= 0.05f;
                rarity += 1;
                hasRapid = true;
            }
        }

        //Roll for scope
        roll = Random.Range(0f, 1f);
        if (roll <= chance)
        {
            Instantiate(scopePrefab, this.transform.Find("Scope Slot"));
            accuracy += 0.15f;
            rarity += 1;
            hasScope = true;
        }
        else
        {
            Instantiate(ironSightPrefab, this.transform.Find("Iron Sight Slot")); //If no scope, add the iron sights
        }

        //Roll for barrel
        roll = Random.Range(0f, 1f);
        if (roll <= chance)
        {
            Instantiate(silencerPrefab, this.transform.Find("Silencer Slot"));
            gunBarrel = this.transform.Find("Silencer Slot").transform.GetChild(0).transform.GetChild(0).gameObject; //Gun barrel must be added first
            projectileSpeed += 500;
            rarity += 1;
            hasSilencer = true;
        }
        else
        {
            Instantiate(barrelPrefab, this.transform.Find("Base Barrel Slot"));
            gunBarrel = this.transform.Find("Base Barrel Slot").transform.GetChild(0).transform.GetChild(0).gameObject;
        }

        //Roll for stock
        roll = Random.Range(0f, 1f);
        if (roll <= chance)
        {
            Instantiate(shortStockPrefab, this.transform.Find("Short Stock Slot"));
            reloadSpeed -= 0.5f;
            rarity += 1;
            hasShortStock = true;
        }
        else
        {
            Instantiate(baseStockPrefab, this.transform.Find("Base Stock Slot"));
        }

        //Roll for magazine
        roll = Random.Range(0f, 1f);
        if (roll <= chance)
        {
            Instantiate(extendedMagazinePrefab, this.transform.Find("Extended Magazine Slot"));
            reloadSpeed += 0.25f;
            magazineSize += 20;
            magazineTracker = magazineSize;
            rarity += 1;
            hasExtended = true;
        }
        else
        {
            Instantiate(baseMagazinePrefab, this.transform.Find("Base Magazine Slot"));
        }

        ChooseColor();
        NameWeapon();
    }

    public override void GunStats()
    {
        weaponModel = "M5";
        fireRate = Random.Range(0.09f, 0.12f);
        accuracy = Random.Range(0.65f, 0.7f);
        reloadSpeed = Random.Range(1.2f, 1.5f);
        damage = 4;
        projectileSpeed = 1000f;
        magazineSize = 25;
        magazineTracker = magazineSize;
    }
}
