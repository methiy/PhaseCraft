using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MapUI1 : UIBase
{
    // Start is called before the first frame update
    // Start is called before the first frame update
    private void Awake()
    {
        UIEventTrigger s3 = Register("bg/S3");
        UIEventTrigger s4 = Register("bg/S4");
        UIEventTrigger s6 = Register("bg/S6");
        UIEventTrigger s7 = Register("bg/S7");
        UIEventTrigger s8 = Register("bg/S8");
        //进入游戏
        s3.onClick = onStartS3;//引号内为开始游戏键的所在文件夹和名称
        s4.onClick = onStartS4;
        s6.onClick = onStartS6;
        s7.onClick = onStartS7;
        s8.onClick = onStartS8;


        if (SceneManager.GetActiveScene().name== "Map1")
        {
            s3.gameObject.SetActive(true);
            s4.gameObject.SetActive(false);
            s6.gameObject.SetActive(false);
            s7.gameObject.SetActive(false);
            s8.gameObject.SetActive(false);
        }
        else if (SceneManager.GetActiveScene().name == "Map2")
        {
            s3.gameObject.SetActive(true);
            s4.gameObject.SetActive(true);
            s6.gameObject.SetActive(false);
            s7.gameObject.SetActive(false);
            s8.gameObject.SetActive(false);
        }
        else if (SceneManager.GetActiveScene().name == "Map3")
        {
            s3.gameObject.SetActive(true);
            s4.gameObject.SetActive(true);
            s6.gameObject.SetActive(true);
            s7.gameObject.SetActive(false);
            s8.gameObject.SetActive(false);
        }
        else if (SceneManager.GetActiveScene().name == "Map4")
        {
            s3.gameObject.SetActive(false);
            s4.gameObject.SetActive(false);
            s6.gameObject.SetActive(false);
            s7.gameObject.SetActive(true);
            s8.gameObject.SetActive(false);
        }
        else if (SceneManager.GetActiveScene().name == "Map5")
        {
            s3.gameObject.SetActive(false);
            s4.gameObject.SetActive(false);
            s6.gameObject.SetActive(false);
            s7.gameObject.SetActive(false);
            s8.gameObject.SetActive(true);
        }
    }

    private void onStartS3(GameObject obj, PointerEventData pData)
    {
        //跳转到S3
        SceneManager.LoadScene("S3");
    }
    private void onStartS4(GameObject obj, PointerEventData pData)
    {
        //跳转到S3
        SceneManager.LoadScene("S4");
    }
    private void onStartS6(GameObject obj, PointerEventData pData)
    {
        //跳转到S3
        SceneManager.LoadScene("S6");
    }
    private void onStartS7(GameObject obj, PointerEventData pData)
    {
        //跳转到S3
        SceneManager.LoadScene("S7");
    }
    private void onStartS8(GameObject obj, PointerEventData pData)
    {
        //跳转到S3
        SceneManager.LoadScene("S8");
    }
}
