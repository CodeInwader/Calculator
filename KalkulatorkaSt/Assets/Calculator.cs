using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Calculator : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _dysplayText;
    private List<string> elements = new List<string>();
    private float _result;

    public void WriteOnDysplay(string input)
    {
        _dysplayText.text += input;
    }

    public void CountExample()
    {
        string input = _dysplayText.text;

        if (input.Contains(" "))
        {
            elements = input.Split(' ').ToList();
        }
        else
        {
            elements.Add(input);
        }

        string num = null;
        List<string> exampleList = new List<string>();
        float _localResult = 0;
        
        for (int j = 0; j < elements.Count; j++)
            {
                if (elements[j].Contains('*') || elements[j].Contains('/'))
                {
                    foreach (var element in elements[j])
                    {
                        if (element == '*' || element == '/' )
                        {
                            exampleList.Add(num);
                            exampleList.Add(element.ToString());
                            num = null;
                        }
                        else
                        {
                            num += element.ToString();
                        }
                    }
                    exampleList.Add(num);
                
                    for (int i = 0; i < exampleList.Count; i++)
                    {
                        float num1;
                        float num2;

                        switch (exampleList[i])
                        { 
                            case "*":
                                num1 = float.Parse(exampleList[i - 1]);
                                num2 = float.Parse(exampleList[i + 1]);
                    
                                _localResult = num1 * num2;
                                exampleList.RemoveRange(i - 1, 3);
                                exampleList.Insert(0, _localResult.ToString());
                
                                i -= 2;
                                break;
                    
                            case "/":
                                num1 = float.Parse(exampleList[exampleList.IndexOf(exampleList[i]) - 1]);
                                num2 = float.Parse(exampleList[exampleList.IndexOf(exampleList[i]) + 1]);

                                _localResult = num1 / num2;
                                exampleList.RemoveRange(i - 1, 3);
                                exampleList.Insert(0, _localResult.ToString());
                                i -= 2;
                                break;
                        }
                    }
                    
                    elements[j] = exampleList[0];
                }
                
                //Debug.Log(exampleList[j]);
            }

            foreach (var VARIABLE in elements)
            {
                Debug.Log(VARIABLE);
            }

        for (int i = 0; i < elements.Count; i++)
        {
            float num1;
            float num2;

            switch (elements[i])
            { 
                case "+":
                    num1 = float.Parse(elements[i - 1]);
                    num2 = float.Parse(elements[i + 1]);
                    
                    _result = num1 + num2;
                    elements.RemoveRange(i - 1, 3);
                    elements.Insert(0, _result.ToString());

                    i -= 2;
                    break;
                    
                case "-":
                    num1 = float.Parse(elements[elements.IndexOf(elements[i]) - 1]);
                    num2 = float.Parse(elements[elements.IndexOf(elements[i]) + 1]);

                    _result = num1 - num2;
                    elements.RemoveRange(i - 1, 3);
                    elements.Insert(0, _result.ToString());
                    i -= 2;
                    break;
                default:
                    _result = float.Parse(elements[i]);
                    break;
            }
        }


        elements.Clear();
        _dysplayText.text = _result.ToString();
        _result = 0;

    }

    public void ResetNumbers()
    {
        _dysplayText.text = "";
    }

    public void Backspace()
    {
        string text = "";

        for (int i = 0; i < _dysplayText.text.Length - 1; i++)
        {
            text += _dysplayText.text[i];
        }
        _dysplayText.text = text;
    }
}
