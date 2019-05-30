using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// タッチした場所にプレハブを生成するコンポーネント
/// 適当なオブジェクトにアタッチして使う
/// </summary>
public class PointerEffectController : MonoBehaviour
{
    /// <summary>表示したいエフェクトのプレハブ</summary>
    [SerializeField] GameObject m_effectPrefab;

    void Update()
    {
        // Input.GetMouseButtonDown(0) のみで判定した場合、以下の問題が起きる
        // 1. 一か所をタッチ＆ホールドしたままもう一か所をタップしても動かない
        // 2．同時に二か所以上をタップした場合、各タップの中間地点がタッチポジションになる
        if (Input.touchCount > 1)
        {
            foreach (Touch t in Input.touches)
            {
                if (t.phase == TouchPhase.Began)    // タップした時だけ処理する
                {
                    SpawnEffect(Camera.main.ScreenToWorldPoint(t.position));
                }
            }
        }
        else if (Input.GetMouseButtonDown(0))
        {
            SpawnEffect(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        }
    }

    /// <summary>
    /// 指定した場所にプレハブを生成する
    /// </summary>
    /// <param name="worldPosition"></param>
    void SpawnEffect(Vector3 worldPosition)
    {
        Vector3 pos = worldPosition;
        pos = new Vector3(pos.x, pos.y, Camera.main.transform.position.z + 1f);    // カメラに映るように Z 座標を調整する
        GameObject go = Instantiate(m_effectPrefab);    // エフェクトのオブジェクトを生成する
        go.transform.position = pos;    // エフェクトの位置を移動する
        go.transform.SetParent(gameObject.transform);   // Hierarchy 上で邪魔なので自分の子オブジェクトにする
    }
}
