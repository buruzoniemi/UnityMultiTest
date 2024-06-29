using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

/// <summary>
/// 適切なタイミングでUpdate()メソッドやClear()メソッドを
/// 呼び出してルームリストを更新
/// </summary>
public class LobbyRoom : MonoBehaviourPunCallbacks
{
    private RoomList roomList = new RoomList(); // ロビー内のルームリスト


    /// <summary>
    /// ロビーに参加した時に呼び出されるコールバック。
    /// ルームリストをクリアする。
    /// </summary>
    public override void OnJoinedLobby()
    {
        roomList.Clear();
    }

    /// <summary>
    /// ルームリストが更新された時に呼び出されるコールバック。
    /// 変更されたルームリストを使用してルームリストを更新する。
    /// </summary>
    /// <param name="changedRoomList">変更されたルームリスト</param>
    public override void OnRoomListUpdate(List<RoomInfo> changedRoomList)
    {
        roomList.Update(changedRoomList);
    }

    /// <summary>
    /// ロビーから退出した時に呼び出されるコールバック。
    /// ルームリストをクリアする。
    /// </summary>
    public override void OnLeftLobby()
    {
        roomList.Clear();
    }
}
