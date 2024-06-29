using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

/// <summary>
/// マスターサーバーへ接続した時や、Photonのサーバーから切断された時のコールバックを受け取ることができる。
/// Photonのサーバーから切断された時には、コールバックの引数から切断された原因（DisconnectCause）を取得できる。
/// </summary>
public class ConnectionCallbacks : MonoBehaviourPunCallbacks
{
    /// <summary>
    /// マスターサーバーへの接続が成功した時に呼ばれるコールバック
    /// </summary>
    public override void OnConnectedToMaster()
    {
        Debug.Log("マスターサーバーに接続しました");
    }

    /// <summary>
    /// Photonのサーバーから切断された時に呼ばれるコールバック
    /// </summary>
    /// <param name="cause"> </param>
    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.Log($"サーバーとの接続が切断されました: {cause.ToString()}");
    }
}
