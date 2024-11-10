using _Scripts.Weapons;
using Assets.Weapons;
using Laith.Weapons.Components;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.Search;
using UnityEngine;

namespace Assets._Scripts.Weapons
{
    public class WeaponGenerator : MonoBehaviour
    {


        [SerializeField] private Weapon weapon;
        [SerializeField] private WeaponDataSO data;


        private List<WeaponComponents> componentAlReadyOnWeapon = new List<WeaponComponents>();

        private List<WeaponComponents> componentsAddedToWeapon = new List<WeaponComponents>();

        private List<Type> componentDependencies = new List<Type>();

        private Animator anim; 


        private void Start()
        {
            anim = GetComponentInChildren<Animator>();
            GenerateWeapon(data);
        }

        [ContextMenu("test Generate")]
        private void TestGeneration()
        {

            GenerateWeapon(data);
        }
        public void GenerateWeapon(WeaponDataSO data)
        {
            weapon.SetData(data);


            componentAlReadyOnWeapon.Clear();
            componentsAddedToWeapon.Clear();
            componentDependencies.Clear();


            componentAlReadyOnWeapon = GetComponents<WeaponComponents>().ToList();


            componentDependencies = data.GetAllDependencies();


            foreach (var dependency in componentDependencies)
            {

                if (componentsAddedToWeapon.FirstOrDefault(component => component.GetType() == dependency))
                    continue;

                var weaponComponent = componentAlReadyOnWeapon.FirstOrDefault(component => component.GetType() == dependency);


                if(weaponComponent == null)
                {

                  weaponComponent =   gameObject.AddComponent(dependency) as WeaponComponents;

                }weaponComponent.Init();
                    componentsAddedToWeapon.Add(weaponComponent);

                var componentsToRemove = componentAlReadyOnWeapon.Except(componentsAddedToWeapon);


                foreach (var weapomComponent in componentsToRemove)
                {
                    Destroy(weapomComponent);
                }

                anim.runtimeAnimatorController = data.AnimatorController;
            }
        }
       
    }
}