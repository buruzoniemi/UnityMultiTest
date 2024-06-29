using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

/// <summary>
/// 同期を管理するクラス
/// </summary>
public class StopSyncing : MonoBehaviourPunCallbacks, IPunObservable
{
    private bool isSyncing = true; // 同期フラグ

    /// <summary>
    /// 同期のフラグよって停止するか送信を行うメソッド
    /// </summary>
    /// <param name="stream"></param>
    /// <param name="info"></param>
    void IPunObservable.OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            // 同期フラグが立っている場合のみ送信を行う
            if (isSyncing)
            {
                stream.SendNext(transform.position);
            }
            else
            {
                return;
            }
        }
        else
        {
            transform.position = (Vector3)stream.ReceiveNext();
        }
    }
}
