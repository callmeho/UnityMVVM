using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EagleEyes : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.E))
            StartCoroutine(EnableEyes());
    }
    Color buffer;
    GameObject[] propses;
    IEnumerator EnableEyes()
    {
        propses = GameObject.FindGameObjectsWithTag("Props");
        foreach (var item in propses)
        {
            buffer = item.GetComponent<Renderer>().material.color;
            Vector2 v2 = Camera.main.WorldToScreenPoint(item.transform.position);
            if (v2.x > 0 && v2.x < Screen.width && v2.y > 0 && v2.y < Screen.height)
            {
                    item.GetComponent<Renderer>().material.color = Color.red;
            }
        }
        yield return new WaitForSeconds(2);
        foreach (var item in propses)
        {
            item.GetComponent<Renderer>().material.color = buffer;

        }
    }
}
