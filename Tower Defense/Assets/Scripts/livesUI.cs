using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class livesUI : MonoBehaviour
{

    public Text livesText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(PlayerStats.Lives <= 0)
        {
            LoadScene("Lose Screen");
        }
        livesText.text = "Lives: " + PlayerStats.Lives.ToString();
    }

    public void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
    }
}
