using Photon.Pun;
using UnityEngine;

/// <summary>
/// ���[����ޏo�������ɌĂ΂�鏈������
/// </summary>
public class LeftRoomCallBack : MonoBehaviourPunCallbacks
{
    // ���[������ޏo�������ɌĂ΂��R�[���o�b�N
    public override void OnLeftRoom()
    {
        Debug.Log("���[������ޏo���܂���");
    }
}
