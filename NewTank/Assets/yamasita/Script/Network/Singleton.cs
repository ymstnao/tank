using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// シングルトン基底クラス
/// </summary>
public class Singleton : MonoBehaviour
{

	public static Singleton Instance
	{
		get;
		private set;
	}

	/*　↓を継承先で実装してください（****はクラス名）
    
    public new static **** Instance
    {
        get;
        private set;
    }

    private void SetInstance()
    {
        if (Instance == null)
        {
            Instance = (****)this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Awake()
    {
        SetInstance();
    }

    */




	/*
    /// ↓参考サイト
    /// http://www.hondarer-soft.com/japan/log/archives/2016/06/c.shtml

    /// <summary>
    /// SingletonSampleBase クラスのシングルトン インスタンスを保持します。
    /// </summary>
    protected static Singleton instance = null;

    /// <summary>
    /// SingletonSampleBase クラスのシングルトン管理用ロックオブジェクトを保持します。
    /// </summary>
    protected static object lockForSingleton = new object();

    /// <summary>
    /// SingletonSampleBase クラスのシングルトン インスタンスを取得します。
    /// </summary>
    /// <value>
    /// SingletonSampleBase クラスのシングルトン インスタンス。
    /// 生成されていない場合は、インスタンスを生成して返します。
    /// </value>
    public static Singleton Instance
    {
        get
        {
            if (instance == null)
            {
                lock (lockForSingleton)
                {
                    // ダブルチェックロッキングとすることで、パフォーマンスの確保と
                    // インスタンス生成が複数発生しないことを両立する。
                    if (instance == null)
                    {
                        instance = new Singleton();
                    }
                }
            }
            return instance;
        }
    }

    /// <summary>
    /// SingletonSampleBase クラスのシングルトン インスタンスを初期化します。 
    /// </summary>
    /// <remarks>
    /// シングルトンパターンを採用するため、コンストラクタは公開しません。
    /// 継承を考え、protected としています。
    /// </remarks>
    protected Singleton()
    {
        // NOP

        // protected とすることで、外部からのインスタンス生成を防いでいるので、
        // 何もないからといってコンストラクタを削除してはならない。
    }
    */
}



/*　↓を継承先で実装してください（****はクラス名）

/// <summary>
/// SingletonSample クラスのシングルトン インスタンスを取得します。
/// このプロパティは、基底クラスの実装を隠します。
/// instance フィールドは基底クラス型なので、本クラス内での参照では
/// キャストされたこのプロパティを利用してください。
/// </summary>
/// <value>
/// SingletonSample クラスのシングルトン インスタンス。
/// 生成されていない場合は、インスタンスを生成して返します。
/// </value>
public new static **** Instance
{
    get
    {
        if (instance == null)
        {
            lock (lockForSingleton)
            {
                if (instance == null)
                {
                    // ダブルチェックロッキングとすることで、パフォーマンスの確保と
                    // インスタンス生成が複数発生しないことを両立する。
                    instance = new ****();
                }
            }
        }
        // instance フィールドに格納されている型は基底クラスのため、
        // 派生クラスにキャストして返す。
        return (****)instance;
    }

}

/// <summary>
/// **** クラスのシングルトン インスタンスを初期化します。 
/// </summary>
/// <remarks>
/// シングルトンパターンを採用するため、コンストラクタは公開しません。
/// 継承を考え、protected としています。
/// </remarks>
protected **** ()
    {
        // NOP

        // protected とすることで、外部からのインスタンス生成を防いでいるので、
        // 何もないからといってコンストラクタを削除してはならない。
    }


*/
