using Photon.Pun;
using UnityEngine;

/// <summary>
/// 
/// </summary>
public class CreateRoomCallbacks : MonoBehaviourPunCallbacks
{
    /// <summary>
    /// ���[���̍쐬�������������ɌĂ΂��R�[���o�b�N
    /// </summary>
    public override void OnCreatedRoom()
    {
        Debug.Log("���[���̍쐬�ɐ������܂���");
    }

    /// <summary>
    /// ���[���̍쐬�����s�������ɌĂ΂��R�[���o�b�N
    /// </summary>
    /// <param name="returnCode"></param>
    /// <param name="message"></param>
    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log($"���[���̍쐬�Ɏ��s���܂���: {message}");
    }
}
