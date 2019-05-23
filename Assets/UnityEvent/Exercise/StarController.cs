using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StarController : MonoBehaviour
{
    // 課題 1. ここにイベントを設定し、Star が減るごとに Star があと何個残っているのか Console に出力されるように設定せよ。
    // 残り個数が Console に出力される処理は Manager.cs に実装されている。
    public UnityEvent m_eventsOnDeath = new UnityEvent();

    private void OnCollisionEnter2D(Collision2D collision)
    {
        ShellController shell = collision.gameObject.GetComponent<ShellController>();
        if (shell)
        {
            Destroy(collision.gameObject);
            Death();
        }
    }

    void Death()
    {
        m_eventsOnDeath.Invoke();
        Destroy(gameObject);
    }
}
