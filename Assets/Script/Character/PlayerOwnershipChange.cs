using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PlayerOwnershipChange : MonoBehaviourPunCallbacks, IPunOwnershipCallbacks
{
    // 所有権のリクエストが行われた時に呼ばれるコールバック
    public void OnOwnershipRequest(PhotonView targetView, Player requestingPlayer)
    {
        // 自身が所有権を持つインスタンスで所有権のリクエストが行われたら、常に許可して所有権を移譲する
        if (targetView.IsMine && targetView.ViewID == photonView.ViewID)
        {
            bool acceptsRequest = true;
            if (acceptsRequest)
            {
                targetView.TransferOwnership(requestingPlayer);
            }
            else
            {
                // リクエストを拒否する場合は、何もしない
                return;
            }
        }
    }

    // 所有権の移譲が行われた時に呼ばれるコールバック
    public void OnOwnershipTransfered(PhotonView targetView, Player previousOwner)
    {
        if (targetView.ViewID == photonView.ViewID)
        {
            string id = targetView.ViewID.ToString();
            string p1 = previousOwner.NickName;
            string p2 = targetView.Owner.NickName;
            Debug.Log($"ViewID {id} の所有権が {p1} から {p2} に移譲されました");
        }
    }

    // 所有権の移譲が失敗した時に呼ばれるコールバック
    public void OnOwnershipTransferFailed(PhotonView targetView, Player previousOwner)
    {
        // ここに処理を追加する
        Debug.Log("所有権の譲渡に失敗しました。");
        return;
    }
}
