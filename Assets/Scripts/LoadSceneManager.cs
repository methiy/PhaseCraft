using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadSceneManager:MonoBehaviour
{
    public static void LoadS0()
    {
        SceneManager.LoadScene("S0");
    }
    public static void LoadOOdinaryCombatA()
    {
        SceneManager.LoadScene("Ordinary combat A");
    }
}
