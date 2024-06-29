using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

/// <summary>
/// ゲームプレイヤーのプレハブプールを管理するクラス
/// </summary>
public class GamePlayerPrefabPool : MonoBehaviour, IPunPrefabPool
{
    [SerializeField]
    private GamePlayer gamePlayerPrefab = default; // ゲームプレイヤープレハブ

    private void Start()
    {
        // PhotonNetworkのPrefabPoolをこのクラスに設定する
        PhotonNetwork.PrefabPool = this;
    }

    // IPunPrefabPoolのインターフェースメソッドの実装：ネットワークオブジェクトの生成
    GameObject IPunPrefabPool.Instantiate(string prefabId, Vector3 position, Quaternion rotation)
    {
        switch (prefabId)
        {
            case "GamePlayer":
                var player = Instantiate(gamePlayerPrefab, position, rotation);
                // 生成されたネットワークオブジェクトは非アクティブ状態で返す必要がある
                // （その後、PhotonNetworkの内部で正しく初期化されてから自動的にアクティブ状態に戻される）
                player.gameObject.SetActive(false);
                return player.gameObject;
        }
        return null;
    }

    // IPunPrefabPoolのインターフェースメソッドの実装：ネットワークオブジェクトの破棄
    void IPunPrefabPool.Destroy(GameObject gameObject)
    {
        Destroy(gameObject);
    }
}

/// <summary>
/// ゲームプレイヤーのクラス
/// </summary>
public class GamePlayer : MonoBehaviourPunCallbacks
{
    private void Awake()
    {
        // Object.Instantiateの後に一度だけ必要な初期化処理を行う
    }

    private void Start()
    {
        // 生成後に一度だけ（OnEnableの後に）呼ばれる、ここで初期化処理を行う場合は要注意
        // オブジェクト生成後に一度しか呼ばれないAwake()やStart()で何らかの初期化処理を行っていると、
        // オブジェクトが使い回された時に正しく初期化処理が行われない可能性があるため
    }

    // ネットワークオブジェクトが有効になった時に呼ばれるコールバック
    public override void OnEnable()
    {
        base.OnEnable();

        // PhotonNetwork.Instantiateの生成処理後に必要な初期化処理を行う
    }

    // ネットワークオブジェクトが無効になる直前に呼ばれるコールバック
    public override void OnDisable()
    {
        base.OnDisable();

        // PhotonNetwork.Destroyの破棄処理前に必要な終了処理を行う
    }
}