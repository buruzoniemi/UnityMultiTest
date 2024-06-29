using Photon.Pun;
using UnityEngine;

/// <summary>
/// ルーム内の他プレイヤー側で実行して同期する
/// 
/// 注意：
/// RPCで実行したいメソッドを持つスクリプトは、
/// PhotonViewコンポーネントと同じゲームオブジェクトに追加されている必要がある。
/// 子要素のゲームオブジェクトに追加されているスクリプトのメソッドを、
/// 親のゲームオブジェクトのPhotonViewのRPC()から呼び出すようなことはできませんので注意してね。
/// </summary>
public class RPC : MonoBehaviourPunCallbacks
{
    private void Update()
    {
        // マウスクリック毎に、ルーム内のプレイヤー全員にメッセージを送信する
        if (Input.GetMouseButtonDown(0))
        {
            //第一引数は実行するメソッド名、第二引数はRPCを実行する対象、そして第三引数以降が実行するメソッドの引数
            photonView.RPC(nameof(RpcSendMessage), RpcTarget.All, "こんにちは");
        }
    }

    /// <summary>
    /// ルーム内の他プレイヤー側でもメソッドを実行することができる
    /// </summary>
    /// <param name="message"></param>
    [PunRPC]
    private void RpcSendMessage(string message, PhotonMessageInfo info)
    {
        // メッセージを送信したプレイヤー名も表示する
        Debug.Log($"{info.Sender.NickName}: {message}");
    }
}