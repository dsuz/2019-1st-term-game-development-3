using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject m_playerPrefab;

    void Start()
    {
        StartGame();
    }

    /// <summary>スタート地点（原点）にプレイヤーを生成する</summary>
    public void StartGame()
    {
        SpawnPlayer(0f, 0f);
    }

    /// <summary>場所を指定してプレイヤーを生成する。現在存在しているプレイヤーは破棄する</summary>
    /// <param name="posX">プレイヤーを生成するX座標</param>
    /// <param name="posY">プレイヤーを生成するY座標</param>
    void SpawnPlayer(float posX, float posY)
    {
        GameObject go = GameObject.FindGameObjectWithTag("Player");
        if (go)
        {
            Destroy(go);
        }
        go = Instantiate(m_playerPrefab);
        go.transform.position = new Vector2(posX, posY);
    }

    public void SaveGame()
    {
        // ここにコードを追加する
        SaveData data = new SaveData();
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        data.posX = player.transform.position.x;
        data.posY = player.transform.position.y;
        string json = JsonUtility.ToJson(data);
        PlayerPrefs.SetString("SaveData", json);
    }

    public void LoadGame()
    {
        // ここにコードを追加する
        string json = PlayerPrefs.GetString("SaveData");
        SaveData data = JsonUtility.FromJson<SaveData>(json);
        SpawnPlayer(data.posX, data.posY);
    }
}
