using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;


/// <summary>
/// ���r�[�Q�����̃R�[���o�b�N
/// </summary>
public class LobbyCallBack : MonoBehaviourPunCallbacks
{
    // ���r�[�֎Q���������ɌĂ΂��R�[���o�b�N
    public override void OnJoinedLobby()
    {
        Debug.Log("���r�[�֎Q�����܂���");
    }

    // ���[�����X�g���X�V���ꂽ���ɌĂ΂��R�[���o�b�N
    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        foreach (var info in roomList)
        {
            if (!info.RemovedFromList)
            {
                Debug.Log($"���[���X�V: {info.Name}({info.PlayerCount}/{info.MaxPlayers})");
            }
            else
            {
                Debug.Log($"���[���폜: {info.Name}");
            }
        }
    }

    // ���r�[����ޏo�������ɌĂ΂��R�[���o�b�N
    public override void OnLeftLobby()
    {
        Debug.Log("���r�[����ޏo���܂���");
    }
}
