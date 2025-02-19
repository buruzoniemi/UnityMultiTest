using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

/// <summary>
/// 操作しているキャラのTransform情報を
/// ほかのプレイヤーに送信して同期させる
/// </summary>
public class TransformView : MonoBehaviourPunCallbacks, IPunObservable
{
    void IPunObservable.OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            // Transformの値をストリームに書き込んで送信する
            stream.SendNext(transform.localPosition);
            stream.SendNext(transform.localRotation);
            stream.SendNext(transform.localScale);
        }
        else
        {
            // 受信したストリームを読み込んでTransformの値を更新する
            transform.localPosition = (Vector3)stream.ReceiveNext();
            transform.localRotation = (Quaternion)stream.ReceiveNext();
            transform.localScale = (Vector3)stream.ReceiveNext();
        }
    }
}
