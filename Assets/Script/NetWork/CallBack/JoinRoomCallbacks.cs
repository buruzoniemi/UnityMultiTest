using Photon.Pun;
using UnityEngine;

public class JoinRoomCallbacks : MonoBehaviourPunCallbacks
{
    // ルームへの参加が成功した時に呼ばれるコールバック
    public override void OnJoinedRoom()
    {
        Debug.Log("ルームへ参加しました");
    }

    // ルーム名を指定したルームへの参加が失敗した時に呼ばれるコールバック
    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        Debug.Log($"ルームへの参加に失敗しました: {message}");
    }

    // ランダムなルームへの参加が失敗した時に呼ばれるコールバック
    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        // ランダムで参加できるルームが存在しないなら、新規でルームを作成する
        PhotonNetwork.CreateRoom(null);
    }
}
