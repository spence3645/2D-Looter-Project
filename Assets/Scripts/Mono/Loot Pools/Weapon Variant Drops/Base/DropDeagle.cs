﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropDeagle : MonoBehaviour
{
    public GameObject base_deagle;

    GameObject droppedWeapon;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Drop(float chance)
    {
        droppedWeapon = Instantiate(base_deagle, this.transform.position, Quaternion.identity, null);
        droppedWeapon.GetComponent<WeaponBehavior>().CreateGun(chance);
    }
}