using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;
	public static string name;
	public static int highScore;

	private void Awake()
	{
		if(Instance != null)
		{
			Destroy(gameObject);
			return;
		}
		else
		{
			Instance = this;
			DontDestroyOnLoad(gameObject);
		}
	}
}
