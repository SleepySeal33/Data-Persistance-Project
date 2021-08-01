using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager UIInstance;
    [SerializeField] private GameObject inputField;

    private void Awake()
	{
        if(UIInstance != null)
		{
            Destroy(gameObject);
            return;
		}
		else
		{
            UIInstance = this;
            DontDestroyOnLoad(gameObject);
		}
	}

    public void InputFieldSelect()
	{
        inputField.GetComponent<TMP_InputField>().text = "";
    }
    public void InputFieldEnd()
	{
        DataManager.DataInstance.playerName = inputField.GetComponent<TMP_InputField>().text;
    }
    
    public void StartButtonClick()
	{
        SceneManager.LoadScene(1);
    }
}
