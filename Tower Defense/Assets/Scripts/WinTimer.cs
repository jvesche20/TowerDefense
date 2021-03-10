using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinTimer : MonoBehaviour
{

    public Text text1;
    private float timer = 300f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (timer <= 0)
        {
            LoadScene("Win Screen 1");

        }
        Debug.Log(timer);
        timer -= Time.deltaTime;

        timer = Mathf.Clamp(timer, 0f, Mathf.Infinity);
        text1.text = "Time Left: " + string.Format("{0:00.00}", timer);

    }

    public void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
    }
}
