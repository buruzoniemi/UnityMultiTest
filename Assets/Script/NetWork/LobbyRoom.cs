using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

/// <summary>
/// �K�؂ȃ^�C�~���O��Update()���\�b�h��Clear()���\�b�h��
/// �Ăяo���ă��[�����X�g���X�V
/// </summary>
public class LobbyRoom : MonoBehaviourPunCallbacks
{
    private RoomList roomList = new RoomList(); // ���r�[���̃��[�����X�g


    /// <summary>
    /// ���r�[�ɎQ���������ɌĂяo�����R�[���o�b�N�B
    /// ���[�����X�g���N���A����B
    /// </summary>
    public override void OnJoinedLobby()
    {
        roomList.Clear();
    }

    /// <summary>
    /// ���[�����X�g���X�V���ꂽ���ɌĂяo�����R�[���o�b�N�B
    /// �ύX���ꂽ���[�����X�g���g�p���ă��[�����X�g���X�V����B
    /// </summary>
    /// <param name="changedRoomList">�ύX���ꂽ���[�����X�g</param>
    public override void OnRoomListUpdate(List<RoomInfo> changedRoomList)
    {
        roomList.Update(changedRoomList);
    }

    /// <summary>
    /// ���r�[����ޏo�������ɌĂяo�����R�[���o�b�N�B
    /// ���[�����X�g���N���A����B
    /// </summary>
    public override void OnLeftLobby()
    {
        roomList.Clear();
    }
}
