using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Falling : MonoBehaviour
{
    // Start is called before the first frame update
    private float timer = 1.0f;
    public GameObject meteor;
    public GameObject redbull;
    System.Random rand = new System.Random();
    public Object mainCha;

    void Start()
    {
            
    }   

    // Update is called once per frame
    void Update()
    {
        // get position of player
        var charPosition = mainCha.GetComponent<Transform>().position;

        timer -= Time.deltaTime; 
        if(timer <= 0.0f)
        {
            timer = 0.250f;
            int x = rand.Next(1,10);
            if(x == 1){
                GameObject newredbull = Instantiate(redbull, charPosition + new Vector3(rand.Next(-50,50), 100, rand.Next(1,100)), Quaternion.identity);
                newredbull.GetComponent<Rigidbody>().velocity = Vector3.down * 30.0f;
                newredbull.name = "redbull";
            }else {
                GameObject newmeteor = Instantiate(meteor, charPosition + new Vector3(rand.Next(-50,50), 100, rand.Next(1,100)), Quaternion.identity);
                newmeteor.GetComponent<Rigidbody>().velocity = Vector3.down * 30.0f;
                newmeteor.name = "Meteor";

            }
            // newmeteor.hideFlags = HideFlags.HideInHierarchy;
            // newmeteor.GetComponent<Renderer>().material.color = new Color(rand.Next(1, 100) / 100.0f, rand.Next(1, 100) / 100.0f, rand.Next(1, 100) / 100.0f);

        }
    }
}
