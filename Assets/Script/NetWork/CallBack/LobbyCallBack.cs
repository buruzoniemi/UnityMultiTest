using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;


/// <summary>
/// ロビー参加時のコールバック
/// </summary>
public class LobbyCallBack : MonoBehaviourPunCallbacks
{
    // ロビーへ参加した時に呼ばれるコールバック
    public override void OnJoinedLobby()
    {
        Debug.Log("ロビーへ参加しました");
    }

    // ルームリストが更新された時に呼ばれるコールバック
    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        foreach (var info in roomList)
        {
            if (!info.RemovedFromList)
            {
                Debug.Log($"ルーム更新: {info.Name}({info.PlayerCount}/{info.MaxPlayers})");
            }
            else
            {
                Debug.Log($"ルーム削除: {info.Name}");
            }
        }
    }

    // ロビーから退出した時に呼ばれるコールバック
    public override void OnLeftLobby()
    {
        Debug.Log("ロビーから退出しました");
    }
}
