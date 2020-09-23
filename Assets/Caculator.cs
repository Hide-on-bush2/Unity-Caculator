using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caculator : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnGUI()
    {
        // 创建背景框
        GUI.Box(new Rect(200, 10, 225, 270), "Loader Menu");

        //创建数字
        for(int i = 0;i < 3; i++)
        {
            for(int j = 0;j < 3; j++)
            {
                //GUI.Button(new Rect(200 + 50*i + (i-1)*5, 425 - 100*j - (j-1)*5, 200 + 50*(i+1) + (i-1)*5, 425 - 100*(j+1) - (j-1)*5), "" + (i*3+j));
                GUI.Button(new Rect(210 + 50*j + j*5, 225 - 50*i - i*5, 50, 50), "" + (i*3 + j + 1));
            }
        }

        
    }
}
