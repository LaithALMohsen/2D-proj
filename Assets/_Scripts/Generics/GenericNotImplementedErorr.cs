using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GenericNotImplementedErorr<T>
{
   
    public static T TryGet(T value, string name)
    {
        if(value != null)
        {

            return value;
        }
        Debug.LogError(typeof(T) + "Not implemented on " + name);
        return default;
    }

}
