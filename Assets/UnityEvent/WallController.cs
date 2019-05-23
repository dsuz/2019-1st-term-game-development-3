using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Wall に Ball がぶつかってきたらイベントを呼ぶ
/// </summary>
[RequireComponent(typeof(Collider2D))]
public class WallController : MonoBehaviour
{
    /// <summary>Wall に Ball がぶつかった時に呼ばれるイベント</summary>
    public UnityEvent m_onCrash = new UnityEvent();
    public OnCrashWithParams m_onCrashWithParams = new OnCrashWithParams();
   
    private void OnCollisionEnter(Collision collision)
    {
        // ぶつかってきたのが Ball (Player タグのついたオブジェクト)だったら、イベントを呼び出す
        if (collision.gameObject.tag == "Player")
        {
            m_onCrash.Invoke();
            m_onCrashWithParams.Invoke(Vector3.up + Vector3.right, 3f); // パラメータ付きのイベントはこう呼び出す
        }
    }
}

/// <summary>
/// パラメータ付きのイベントを呼び出すためのクラス
/// </summary>
[System.Serializable]
public class OnCrashWithParams : UnityEvent<Vector3, float>
{
}

