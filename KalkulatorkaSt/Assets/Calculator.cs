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


        foreach (var VARIABLE in elements)
        {
            if (VARIABLE.Contains('*') || VARIABLE.Contains('/'))
            {
                string _num1 = null;
                string _num2 = null;
                string _operator = null;
                float _localResult = 0;
                List<string> exampleList = new List<string>();

                /*for(int i = 0; i < VARIABLE.Length; i++)
                    exampleList.Add(VARIABLE[i].ToString());*/

                for (int i = 0; i < VARIABLE.Length; i++)
                {
                    if (char.IsDigit(VARIABLE[i]))
                    {
                        if (_num1 == null)
                        {
                            _num1 += VARIABLE[i];
                            exampleList.Add(_num1);
                        }
                        else if (_num2 == null)
                        {
                            _num2 += VARIABLE[i];
                        }
                        else
                        {
                            switch (_operator)
                            {
                                case "*":
                                    _localResult = float.Parse(_num1) * float.Parse(_num2);
                                    break;
                                case "/":
                                    _localResult = float.Parse(_num1) / float.Parse(_num2);
                                    break;
                            }
                            exampleList.Add(_operator);
                            exampleList.Add(_num2);
                            
                            exampleList.RemoveRange(i - 2, 3);
                            elements.Insert(0, _localResult.ToString());
                            i -= 2;
                        }
                        
                    }
                    else
                    {
                        _operator = VARIABLE[i].ToString();
                    }
                }

                foreach (var k in exampleList)
                {
                    Debug.Log(k);
                }
            }
        }
       
           
        
        for (int i = 0; i < elements.Count; i++)
        {
            int num1;
            int num2;

            switch (elements[i])
            { 
                case "+":
                    num1 = int.Parse(elements[i - 1]);
                    num2 = int.Parse(elements[i + 1]);
                    
                    _result = num1 + num2;
                    elements.RemoveRange(i - 1, 3);
                    elements.Insert(0, _result.ToString());

                    i -= 2;
                    break;
                    
                case "-":
                    num1 = int.Parse(elements[elements.IndexOf(elements[i]) - 1]);
                    num2 = int.Parse(elements[elements.IndexOf(elements[i]) + 1]);

                    _result = num1 - num2;
                    elements.RemoveRange(i - 1, 3);
                    elements.Insert(0, _result.ToString());
                    i -= 2;
                    break;
                default:
                    //_result = float.Parse(elements[i]);
                    break;
            }
        }


        elements.Clear();
        _dysplayText.text = _result.ToString();
        _result = 0;

    }
}
