﻿using Assets._Scripts.Weapons.Components;
using Assets._Scripts.Weapons.Components.ComponentsData;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


namespace Assets.Weapons
{

    [CreateAssetMenu(fileName ="newWeaponData", menuName = "Data/Weapon Data/Basic Weapon Data",order =0)]
    public class WeaponDataSO : ScriptableObject
    {

        [field: SerializeField] public RuntimeAnimatorController AnimatorController { get; private set; }
        [field: SerializeField] public  int NumberOfAttacks { get; private set; }


     [field: SerializeReference]   public List<ComponentData> ComponentData { get; private set; }


        public T GetData<T>()
        {

            return ComponentData.OfType<T>().FirstOrDefault();
        
        }

        public List<Type> GetAllDependencies()
        {
            return ComponentData.Select(component => component.ComponintDependency).ToList();

        }

        public void AddData(ComponentData data)
        {

            if (ComponentData.FirstOrDefault(t => t.GetType() == data.GetType()) != null)
                return;

            ComponentData.Add(data);
        }


        //[ContextMenu("Add Sprite Data")]
        //private void AddSpriteData() => ComponentsData.Add(new WeaponSpriteData());



        //[ContextMenu("Add Movement Data")]
        //private void AddMovementData() => ComponentsData.Add(new MovementData());


    }


}