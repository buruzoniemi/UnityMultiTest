using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PhotonViewMonitoring : MonoBehaviourPunCallbacks, IPunObservable
{
    private Vector3 lastPosition; // 直近の座標

    private void Awake()
    {
        lastPosition = transform.position; // 最初に座標を初期化する
    }

    /// <summary>
    /// IPunObservableインターフェースの実装 
    /// </summary>
    /// <param name="stream">
    /// データの送受信を行うためのストリームです。このストリームを使用して、
    /// ネットワーク越しにデータを送信したり、受信したりします。
    /// 書き込みモードと読み込みモード。送信側では書き込みモードを使用し、受信側では読み込みモードを使用します。
    /// </param>
    /// <param name="info">
    /// メッセージの送信者や送信時刻など、メッセージに関する追加情報を含むクラスです。
    /// このクラスには、メッセージを送信したクライアントの情報や、送信時のタイムスタンプなどが含まれています。
    /// </param>
    void IPunObservable.OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            // 書き込みモードの場合、座標が一定の距離以上変化したら送信する
            if (Vector3.Distance(transform.position, lastPosition) > 0.01f)
            {
                stream.SendNext(transform.position); // 座標を送信する
                lastPosition = transform.position; // 送信した座標を直近の座標として保存する
            }
        }
        else
        {
            // 読み込みモードの場合、受信した座標を適用する
            transform.position = (Vector3)stream.ReceiveNext();
        }
    }
}
