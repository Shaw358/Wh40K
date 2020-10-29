using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugStuffs : MonoBehaviour
{
    private void Start()
    {
        transform.LookAt(transform.position);
        //transform.rotation = new Vector3(transform.eulerAngles.x, 1, 1);
    }
}
