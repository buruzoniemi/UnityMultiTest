using Photon.Pun;
using UnityEngine;

public class JoinRoomCallbacks : MonoBehaviourPunCallbacks
{
    // ���[���ւ̎Q���������������ɌĂ΂��R�[���o�b�N
    public override void OnJoinedRoom()
    {
        Debug.Log("���[���֎Q�����܂���");
    }

    // ���[�������w�肵�����[���ւ̎Q�������s�������ɌĂ΂��R�[���o�b�N
    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        Debug.Log($"���[���ւ̎Q���Ɏ��s���܂���: {message}");
    }

    // �����_���ȃ��[���ւ̎Q�������s�������ɌĂ΂��R�[���o�b�N
    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        // �����_���ŎQ���ł��郋�[�������݂��Ȃ��Ȃ�A�V�K�Ń��[�����쐬����
        PhotonNetwork.CreateRoom(null);
    }
}
