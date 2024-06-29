using Photon.Pun;
using UnityEngine;

/// <summary>
/// 
/// </summary>
public class CreateRoomCallbacks : MonoBehaviourPunCallbacks
{
    /// <summary>
    /// ルームの作成が成功した時に呼ばれるコールバック
    /// </summary>
    public override void OnCreatedRoom()
    {
        Debug.Log("ルームの作成に成功しました");
    }

    /// <summary>
    /// ルームの作成が失敗した時に呼ばれるコールバック
    /// </summary>
    /// <param name="returnCode"></param>
    /// <param name="message"></param>
    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log($"ルームの作成に失敗しました: {message}");
    }
}
