using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager DataInstance;
	public string playerName;
	public int highScore;
	public string highScoreText;

	private void Awake()
	{
		if (DataInstance != null)
		{
			Destroy(gameObject);
			return;
		}
		else
		{
			DataInstance = this;
			DontDestroyOnLoad(gameObject);
		}
		highScore = 0;
	}

	[Serializable]
	public class HighScoreData
	{
		public int highScore;
		public string highScoreText;
	}

	public void SaveHighScore()
	{
		HighScoreData data = new HighScoreData();
		data.highScore = highScore;
		data.highScoreText = highScoreText;
		string json = JsonUtility.ToJson(data);
		File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
	}

	public void LoadHighScore()
	{
		string path = Application.persistentDataPath + "/savefile.json";
		if (File.Exists(path))
		{
			string json = File.ReadAllText(path);
			HighScoreData data = JsonUtility.FromJson<HighScoreData>(json);
			highScore = data.highScore;
			highScoreText = data.highScoreText;


		}
	}

	public void HighScoreSet(int points)
	{
		highScore = points;
		highScoreText = "Best score: " + playerName + " - " + highScore;
		SaveHighScore();
		MainManager.Instance.highScoreTextUI.text = highScoreText;
	}
}
