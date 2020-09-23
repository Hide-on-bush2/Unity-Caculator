using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caculator : MonoBehaviour
{

    private string res = "";
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private bool reset = false;

    void OnGUI()
    {
        // 创建背景板 
        GUI.Box(new Rect(200, 10, 230, 310), "");

        // 创建显示区域
        GUI.TextField(new Rect(215, 15, 205, 25), res);

        // 创建数字 
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (GUI.Button(new Rect(210 + 50 * j + j * 5, 260 - 50 * (i + 1) - i * 5, 50, 50),
                    "" + (i * 3 + j + 1)))
                {
                    if (reset)
                    {
                        res = "";
                        reset = false;
                    }
                    res += "" + (i * 3 + j + 1);
                }
            }
        }

        // 创建C, <, /, X
        if (GUI.Button(new Rect(210, 45, 50, 50), "C"))
        {
            res = "";
        }

        if (GUI.Button(new Rect(265, 45, 50, 50), "<"))
        {
            res = res.Substring(0, res.Length - 1);
        }

        if (GUI.Button(new Rect(320, 45, 50, 50), "/"))
        {
            res += "/";
        }

        if (GUI.Button(new Rect(375, 45, 50, 50), "X"))
        {
            res += "X";
        }

        // 创建-, +, =
        if (GUI.Button(new Rect(375, 100, 50, 50), "-"))
        {
            res += "-";
        }

        if (GUI.Button(new Rect(375, 155, 50, 50), "+"))
        {
            res += "+";
        }

        if (GUI.Button(new Rect(375, 210, 50, 105), "="))
        {
            int tmp = Cal(res);
            res = Convert.ToString(tmp);
            reset = true;
        }

        // 创建0, .
        if (GUI.Button(new Rect(210, 265, 100, 50), "0"))
        {
            if (reset)
            {
                res = "";
                reset = false;
            }
            res += "0";
        }

        if (GUI.Button(new Rect(320, 265, 50, 50), "."))
        {
            res += ".";
        }
    }

    private bool isNumber(string str)
    {
        foreach (char c in str)
        {
            if ((c < '0' || c > '9') && c != '.')
            {
                return false;
            }
        }

        return true;
    }


    private class node
    {
        public string val;
        public node left;
        public node right;

        public node(string v)
        {
            val = v;
            left = null;
            right = null;
        }
    }

    private node createTree(string str)
    {

        if (isNumber(str))
        {
            return new node(str);
        }

        if (str == "")
        {
            return null;
        }

        string left = "";
        string right = "";

        for (int i = 0; i < str.Length; i++)
        {
            if (str[i] == '+' || str[i] == '-')
            {
                for (int j = 0; j < i; j++)
                {
                    left += str[j];
                }

                for (int j = i + 1; j < str.Length; j++)
                {
                    right += str[j];
                }

                node new_node = new node(str[i].ToString());
                new_node.left = createTree(left);
                new_node.right = createTree(right);
                return new_node;
            }
        }

        for (int i = 0; i < str.Length; i++)
        {
            if (str[i] == 'X' || str[i] == '/')
            {
                for (int j = 0; j < i; j++)
                {
                    left += str[j];
                }

                for (int j = i + 1; j < str.Length; j++)
                {
                    right += str[j];
                }

                node new_node = new node(str[i].ToString());
                new_node.left = createTree(left);
                new_node.right = createTree(right);
                return new_node;
            }
        }

        return null;
    }



    private int calculate(node root)
    {
        if (root == null)
        {
            return 0;
        }

        if (isNumber(root.val))
        {
            return int.Parse(root.val);
        }

        if (root.val == "+")
        {
            return calculate(root.left) + calculate(root.right);
        }

        if (root.val == "-")
        {
            return calculate(root.left) - calculate(root.right);
        }

        if (root.val == "X")
        {
            return calculate(root.left) * calculate(root.right);
        }

        if (root.val == "/")
        {
            return calculate(root.left) / calculate(root.right);
        }

        return 0;
    }

    private int Cal(string str)
    {
        return calculate(createTree(str));
    }
}
