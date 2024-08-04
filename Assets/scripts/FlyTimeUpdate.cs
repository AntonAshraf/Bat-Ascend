using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class FlyTimeUpdate : MonoBehaviour
{
    public Object mainCha;
    TextMeshProUGUI textMesh;
    // Start is called before the first frame update
    void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement pm =  mainCha.GetComponent<Movement>();
        if(pm.lives > 0 && pm.flytimer > 0.5)
            textMesh.text = "Fly Time:" + pm.flytimer.ToString("F0");
    }
}
