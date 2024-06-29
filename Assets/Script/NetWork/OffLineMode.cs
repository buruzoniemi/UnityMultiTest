using Photon.Pun;
using UnityEngine;

/// <summary>
/// オフライン状態でオンラインと同じ事ができるようにする処理
/// </summary>
public class OffLineMode : MonoBehaviourPunCallbacks
{
    public bool isOffline = false; //現在の状態

    /// <summary>
    /// 接続をする
    /// </summary>
    public void Connect()
    {
        if (!isOffline)
        {
            PhotonNetwork.ConnectUsingSettings();
        }
        else
        {
            PhotonNetwork.OfflineMode = true;
        }
    }

    /// <summary>
    /// 接続の解除
    /// </summary>
    public void Disconnect()
    {
        if (!isOffline)
        {
            PhotonNetwork.Disconnect();
        }
        else
        {
            PhotonNetwork.OfflineMode = false;
        }
    }
}
