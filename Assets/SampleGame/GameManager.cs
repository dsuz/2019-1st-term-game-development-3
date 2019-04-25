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
    }

    public void LoadGame()
    {
        // ここにコードを追加する
    }
}
