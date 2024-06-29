using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

/// <summary>
/// ���[���Ƀv���C���[���Q���A�ޏo�����Ƃ���
/// ���������s�����
/// </summary>
public class PlayerCallBack : MonoBehaviourPunCallbacks
{
    // ���v���C���[�����[���֎Q���������ɌĂ΂��R�[���o�b�N
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.Log($"{newPlayer.NickName}���Q�����܂���");
    }

    // ���v���C���[�����[������ޏo�������ɌĂ΂��R�[���o�b�N
    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        Debug.Log($"{otherPlayer.NickName}���ޏo���܂���");
    }
}

