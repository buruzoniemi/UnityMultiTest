using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

/// <summary>
/// 管理者かどうかの確認をする
/// </summary>
public class Ownership : MonoBehaviourPunCallbacks
{
    private void Start()
    {
        // 自身が管理者かどうかを判定する
        if (photonView.IsMine)
        {
            // 所有者を取得する
            Player owner = photonView.Owner;
            // 所有者のプレイヤー名とIDをコンソールに出力する
            Debug.Log($"{owner.NickName}({photonView.OwnerActorNr})");
        }
    }
}
