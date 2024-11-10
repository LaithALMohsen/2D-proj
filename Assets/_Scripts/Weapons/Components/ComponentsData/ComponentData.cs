using System;
using System.Collections;
using UnityEngine;

namespace Assets._Scripts.Weapons.Components
{

    [Serializable]
    public abstract class ComponentData
    {
        [SerializeField, HideInInspector] private string name;
        public Type ComponintDependency { get; protected set; }

        public  ComponentData()
        {

            SetComponentName();
            SetComponentDependency();

        }

        public void SetComponentName() => name = GetType().Name;

        protected abstract void SetComponentDependency();


        public virtual void SetAttackDataNames() { }

        public virtual void InitialzeAttackData(int numberOfAttack) { }
       
    }
    [Serializable]
    public abstract class ComponentData<T> :ComponentData  where T : AttackData
    {

        [SerializeField] private T[] attackData;
        public T[] AttackData { get => attackData; private set => attackData = value; }

        public override void SetAttackDataNames()
        {

            base.SetAttackDataNames();

            for (var i = 0; i < AttackData.Length; i++)
            {
                AttackData[i].SetAttackName(i + 1);
            }
        }

        public override void InitialzeAttackData(int numberOfAttack)
        {
            base.InitialzeAttackData(numberOfAttack);

            var oldLen = attackData != null ? attackData.Length : 0;

            if (oldLen == numberOfAttack)
                return;
           Array.Resize(ref attackData, numberOfAttack);

            if(oldLen < numberOfAttack)
            {

                for (var i = oldLen; i < attackData.Length; i++)
                {

                    var newObj = Activator.CreateInstance(typeof(T)) as T;

                    attackData[i] = newObj;
                }
            }
            SetAttackDataNames();

        }

    }
}