using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// データベースの操作をする
/// </summary>
public class UseSQLite : MonoBehaviour
{
    /// <summary>データベースのファイル名</summary>
    [SerializeField] string m_databaseName = "data.db";
    /// <summary>クエリ文字列のフィールド</summary>
    [SerializeField] InputField m_queryInput;
    /// <summary>SQL文字列（非クエリ）のフィールド</summary>
    [SerializeField] InputField m_sqlInput;
    /// <summary>結果を表示するためのテキスト</summary>
    [SerializeField] Text m_console;
    /// <summary>データベースオブジェクト</summary>
    SqliteDatabase sqlDb;

    void Start()
    {
        InitDb();
    }

    void Update()
    {

    }

    /// <summary>
    /// データベースファイルを開く。既に開かれている場合は一旦閉じてまた開く。
    /// </summary>
    void InitDb()
    {
        if (sqlDb != null)
        {
            sqlDb = null;
        }
        sqlDb = new SqliteDatabase(m_databaseName);
    }

    /// <summary>
    /// クエリを実行し、結果をコンソールに出力する
    /// </summary>
    public void ExecQuery()
    {
        ExecQuery(m_queryInput.text);
    }

    /// <summary>
    /// クエリを実行し、結果をコンソールに出力する
    /// </summary>
    /// <param name="sql">クエリ文字列</param>
    void ExecQuery(string sql)
    {
        DataTable dt = null;

        try
        {
            dt = sqlDb.ExecuteQuery(sql);   // クエリを実行し、結果を取得する
        }
        catch (SqliteException ex)
        {
            m_console.text = ex.ToString();
            InitDb();
        }

        if (dt == null) // 例外が発生していた場合は抜ける
            return;

        // 結果のテーブルを文字列にして、コンソールに出力する
        System.Text.StringBuilder builder = new System.Text.StringBuilder();

        foreach (var r in dt.Rows)
        {
            foreach (var column in dt.Columns)
            {
                object o;
                if (r.TryGetValue(column, out o))
                {
                    string data = (o == null) ? "" : o.ToString();  // 値が null の場合は空文字を、値が入っていたらその文字列を表示する
                    builder.Append(data + ", ");
                }
            }
            builder.Append("\r\n");
        }
        Debug.Log(builder.ToString());
        m_console.text = builder.ToString();
    }

    /// <summary>
    /// クエリでない SQL を実行する
    /// </summary>
    public void ExecSQL()
    {
        ExecSQL(m_sqlInput.text);
    }

    /// <summary>
    /// クエリでない SQL を実行する
    /// </summary>
    /// <param name="sql">SQL 文字列</param>
    void ExecSQL(string sql)
    {
        try
        {
            sqlDb.ExecuteNonQuery(sql);
            m_console.text = "Success.";
        }
        catch(SqliteException ex)
        {
            m_console.text = ex.ToString();
            InitDb();
        }
    }
}
