using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

/// <summary>
/// ルームにプレイヤーが参加、退出したときに
/// 処理が実行される
/// </summary>
public class PlayerCallBack : MonoBehaviourPunCallbacks
{
    // 他プレイヤーがルームへ参加した時に呼ばれるコールバック
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.Log($"{newPlayer.NickName}が参加しました");
    }

    // 他プレイヤーがルームから退出した時に呼ばれるコールバック
    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        Debug.Log($"{otherPlayer.NickName}が退出しました");
    }
}

