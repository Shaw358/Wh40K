using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectEnabler : MonoBehaviour
{
    GameObject this_obj;

    private void Awake()
    {
        this_obj = gameObject;
    }

    public void SetEnabledState(bool value)
    {
        gameObject.SetActive(value);
    }
}
