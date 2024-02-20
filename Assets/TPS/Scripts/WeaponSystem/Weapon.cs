using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using Unity.IO.LowLevel.Unsafe;

public abstract class Weapon : MonoBehaviour
{
    public Func<string, bool> ControlFunction;

    public event Action<bool> PossibleToAttackChanged;

    protected void RaisePossibleToAttackChanged(bool possibleToAttack)
    {
        PossibleToAttackChanged?.Invoke(possibleToAttack);
    }

    public virtual float GetReloadProgress()
    {
        return 0;
    }


    public abstract void Attack();

    protected virtual void Start()
    {
        
    }


    public virtual void ResetReloadProgress()
    {

    }
    
        
    
}
