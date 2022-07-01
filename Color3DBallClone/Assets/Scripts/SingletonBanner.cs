using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonBanner : MonoBehaviour
{
    private static SingletonBanner obj = null;

    private void Awake()
    {
        if (obj == null)
        {
            obj = this;
            DontDestroyOnLoad(this);
        }
        else if(this !=obj)
        {
            Destroy(this.gameObject);
        }
    }
}
