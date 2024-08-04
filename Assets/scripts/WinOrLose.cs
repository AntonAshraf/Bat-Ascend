using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class WinorLose : MonoBehaviour
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
        if (pm.lives < 1)
            textMesh.text = "You Lose!!!";
        if(pm.win == true)
            textMesh.text = "You Win!!!";
    }

}
