using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class UpdateLives : MonoBehaviour
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
        textMesh.text = "Lives:";
        textMesh.text += pm.lives.ToString();
        textMesh.text += "\nspeed:";
        textMesh.text += pm.controller.velocity.magnitude.ToString("F0");
    }
}
