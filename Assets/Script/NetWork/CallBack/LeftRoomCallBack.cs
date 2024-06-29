using Photon.Pun;
using UnityEngine;

/// <summary>
/// ルームを退出した時に呼ばれる処理たち
/// </summary>
public class LeftRoomCallBack : MonoBehaviourPunCallbacks
{
    // ルームから退出した時に呼ばれるコールバック
    public override void OnLeftRoom()
    {
        Debug.Log("ルームから退出しました");
    }
}
