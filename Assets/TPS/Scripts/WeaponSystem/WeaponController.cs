using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class WeaponController : MonoBehaviour
{
    
    Weapon currentWeapon;
    List<Weapon> weapons;

    [SerializeField]
    private GameObject normalCrosshair;

    [SerializeField]
    private GameObject reloadCrosshair;

    [SerializeField]
    private Image reloadImage;

    private void Start()
    {
        weapons = GetComponentsInChildren<Weapon>(true).ToList();
        changeWeapon(weapons.First());
    }

    private void changeWeapon(Weapon weapon)
    {
        if(currentWeapon == weapon) return;
        if(currentWeapon != null)
        {
            currentWeapon.PossibleToAttackChanged -= OnPossibleToAttackChanged;
            if(currentWeapon.GetReloadProgress() > 0)
            {
                currentWeapon.ResetReloadProgress();
            }
            currentWeapon.gameObject.SetActive(false);
        }

        currentWeapon = weapon;
        currentWeapon.PossibleToAttackChanged += OnPossibleToAttackChanged;
        currentWeapon.gameObject.SetActive(true);

        OnPossibleToAttackChanged(currentWeapon.GetReloadProgress() <= 0);
    }

    private void OnPossibleToAttackChanged(bool isPossible)
    {
       

        normalCrosshair.SetActive(isPossible);
        
        reloadCrosshair.SetActive(!isPossible);
    }


    void Update()
    {   
        if(currentWeapon.GetReloadProgress() > 0)
        {
            reloadImage.fillAmount = currentWeapon.GetReloadProgress();
        }


        if(currentWeapon.ControlFunction("Fire1"))
        {
            currentWeapon.Attack();
        }

        if(Input.GetKeyDown(KeyCode.Alpha1)) {
            changeWeapon(weapons.ElementAt(0));
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            changeWeapon(weapons.ElementAt(1));

        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            changeWeapon(weapons.ElementAt(2));
        }

    }
}
