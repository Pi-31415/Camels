using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    // Reference to the Prefab. Drag a Prefab into this field in the Inspector.
    public GameObject myPrefab;
    GameObject camelInstance;
    public static int Previous_score = 0;
    public Text ScoreText;
    int random_text_id = 0;
    int random_text_id2 = 0;
    string[] congrats_text_front = { "Yay! ", "Congrats!", "Woo! ", "Wow !", "Good job! ", "Nice. ", "Bravo. ", "Hooray! ", "Well done! ", "", "" };
    string[] congrats_text_back = { "are collected now.", "collected!", "are here.", "! This is a lot!", "! Keep it up.", "! You've got this.", "are ours now.", "are yours to keep!", "are secured.", "are yours.", "!" };
    string[] congrats_text_back_singular = { "is collected now.", "collected!", "is here.", "is a nice start!", "! Keep it up.", "! You've got this.", "is ours now.", "is yours to keep!", "is secured.", "is yours.", "!" };
    float x_new = 0;
    float y_new = 0;
    float z_new = 0;
    string singular_plural = " camel ";

    // This script will simply instantiate the Prefab when the game starts.
    void Start()
    {
        //Reset Score
        PlayerPrefs.SetInt("score", 0);

        x_new = UnityEngine.Random.Range(-22.0f, 22.0f) / 100;
        y_new = UnityEngine.Random.Range(-23.0f, -24.0f) / 100;
        z_new = UnityEngine.Random.Range(60.0f, 70.0f) / 100;
        // Instantiate at position (0, 0, 0) and zero rotation.
        camelInstance = Instantiate(myPrefab, new Vector3(x_new, y_new, z_new), Quaternion.identity);
    }
    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("score", 0) != Previous_score)
        {
            random_text_id = Random.Range(1, 10);
            random_text_id2 = Random.Range(1, 10);
        }
        
        if(PlayerPrefs.GetInt("score", 0) <= 0)
        {
            ScoreText.text = "You have no camels now." +PlayerPrefs.GetString("Debug", "");
        }
        else if(PlayerPrefs.GetInt("score", 0) == 1)
        {
            singular_plural = " camel ";
            ScoreText.text = congrats_text_front[random_text_id] +" "+ PlayerPrefs.GetInt("score", 0).ToString() + singular_plural + congrats_text_back_singular[random_text_id] +PlayerPrefs.GetString("Debug", "");
        }
        else
        {
            singular_plural = " camels ";
            ScoreText.text = congrats_text_front[random_text_id] + " " + PlayerPrefs.GetInt("score", 0).ToString() + singular_plural + congrats_text_back[random_text_id] + PlayerPrefs.GetString("Debug", "");
        }


        //ScoreText.text += PlayerPrefs.GetInt("x", 0) + ", " + PlayerPrefs.GetInt("y", 0) + ", " + PlayerPrefs.GetInt("z", 0);

        Previous_score = PlayerPrefs.GetInt("score", 0);
    }
}
