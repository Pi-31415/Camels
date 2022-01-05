using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.Events;

/*
 This script monitors the coordinates of the camel
and when it is in fense, it destroys a camel and spawns a new one
 */

public class GetCamelPosition : MonoBehaviour
{
    public static int score = 0;
    public GameObject CamelPrefab;
    public GameObject CelebrateParticle;
    UnityEvent Camel_In_Fence;

    double x = 0;
    double y = 0;
    double z = 0;

    float x_new = 0;
    float y_new = 0;
    float z_new = 0;

    public bool replaced = false;
 
    // Start is called before the first frame update
    void Start()
    {
        if (Camel_In_Fence == null)
            Camel_In_Fence = new UnityEvent();
        Camel_In_Fence.AddListener(CamelIsIn);
    }

    // Update is called once per frame
    void Update()
    {
        x = Math.Round(transform.position.x*100);
        y = Math.Round(transform.position.y*100);
        z = Math.Round(transform.position.z*100);

        PlayerPrefs.SetInt("x", (int)x);
        PlayerPrefs.SetInt("y", (int)y);
        PlayerPrefs.SetInt("z", (int)z);

        if ((x <= 8 && x >= -5) && (z <= 55 && z >= 45) && (y <= -26 && y >= -31))
        {
            //In Fence
            //changingText.text = "Camel Position : (" + x + "," + y + "," + z + ") - In Fence";
            //Debug.Log("Camel Position : (" + x + "," + y + "," + z + ")");
            if(replaced == false)
            {
                //changingText.text = "Camel Position : (" + x + "," + y + "," + z + ") - In Fence";
                //changingText.text = "You Made it";
                Camel_In_Fence.Invoke();
                //Destroy(gameObject, 3);
                replaced = true;
            }
        }
        else
        {
            replaced = false;
            //changingText.text = "Camel Position : (" + x + "," + y + "," + z + ")";
            //Debug.Log("Camel Position : (" + x + "," + y + "," + z + ") , "+score);
        } 

    }

    void CamelIsIn()
    {
        score++;
        PlayerPrefs.SetInt("score", score);
        //Debug.Log("Camel Put In Fence");
        x_new = (float)Math.Round(transform.position.x * 100);
        y_new = (float)Math.Round(transform.position.y * 100);
        z_new = (float)Math.Round(transform.position.z * 100);
        GameObject celebrate = Instantiate(CelebrateParticle, new Vector3(x_new,y_new+10,z_new), Quaternion.identity);

        Destroy(celebrate, 5);
        Destroy(gameObject, 0.5f);
        x_new = UnityEngine.Random.Range(-22.0f, 22.0f) / 100;
        y_new = UnityEngine.Random.Range(-23.0f, -24.0f) / 100;
        z_new = UnityEngine.Random.Range(45.0f, 70.0f) / 100;

        if ((x_new <= 8 && x_new >= -5) && (z_new <= 55 && z_new >= 45) && (y_new <= -26 && y_new >= -31))
        {
            x_new = 0;
            y_new = -24;
            z_new = 65;
        }
            // Instantiate at position (0, 0, 0) and zero rotation.
            Instantiate(CamelPrefab, new Vector3(x_new, y_new, z_new), Quaternion.identity);
    }

}

