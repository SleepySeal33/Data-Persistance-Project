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
	public string highScorePlayer;
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
			highScore = 0;
			LoadHighScore();
		}
	}

	[Serializable]
	public class HighScoreData
	{
		public int highScore;
		public string highScorePlayer;
		public string highScoreText;
	}

	public void SaveHighScore()
	{
		HighScoreData data = new HighScoreData();
		data.highScore = highScore;
		data.highScoreText = highScoreText;
		data.highScorePlayer = highScorePlayer;
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
			highScorePlayer = data.highScorePlayer;
			HighScoreSet(highScore, highScorePlayer);
		}
	}

	public void HighScoreSet(int points, string player)
	{
		highScore = points;
		highScorePlayer = player;
		highScoreText = "Best score: " + highScorePlayer + " - " + highScore;
		SaveHighScore();
	}
}
