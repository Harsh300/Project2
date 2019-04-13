using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class killCount : MonoBehaviour
{
    public static int Count = 0;
    public Text Kill_Count;

    // Start is called before the first frame update
    void Start()
    {
        Kill_Count.text = "Kill Count: " + PlayerPrefs.GetInt("KillCount", 0).ToString();
    }

    private void Update()
    {
        Kill_Count.text = "Kill Count: " + Count.ToString();
    }

    // Update is called once per frame
    public void changeKillCount()
    {
       Count += 1;
        PlayerPrefs.SetInt("KillCount", Count);
        Kill_Count.text = "Kill Count: " + Count.ToString();
    }
}