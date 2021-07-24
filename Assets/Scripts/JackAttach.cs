using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JackAttach : MonoBehaviour
{
    public Transform attachPoint;

    private void Start()
    {
        if (attachPoint == null) attachPoint = transform;
    }
}
