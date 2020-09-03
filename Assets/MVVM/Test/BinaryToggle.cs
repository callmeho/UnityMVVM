using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BinaryToggle : MonoBehaviour
{
    bool isOn;
    Material mat;

    Color bufferColor;

    private void Start()
    {
        mat = GetComponent<Renderer>().material;
        bufferColor = mat.color;
    }
    private void OnMouseDown()
    {
        isOn = !isOn;
        if (isOn)
            mat.color = Color.red;
        else
            mat.color = bufferColor;
    }
}
