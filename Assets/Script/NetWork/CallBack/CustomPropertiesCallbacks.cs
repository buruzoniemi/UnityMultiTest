using UnityEngine;
using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Realtime;

//Q.�J�X�^���v���p�e�B�Ƃ́H
//A.�v���C���[�I�u�W�F�N�g�iPlayer�j�⃋�[���I�u�W�F�N�g�iRoom�j�́A
//  �J�X�^���v���p�e�B�iCustom Properties�j�Ŏ��R�Ȓl��ݒ肵�ē������邱�Ƃ��ł���B

/// <summary>
/// �J�X�^���v���p�e�B���X�V���ꂽ�Ƃ��̃R�[���o�b�N���󂯎���
/// �R�[���o�b�N�̈����Ŏ󂯎���Hashtable�ɂ́A�X�V���ꂽ�y�A�݂̂��ǉ������B
/// </summary>
public class CustomPropertiesCallbacks : MonoBehaviourPunCallbacks
{
    public override void OnPlayerPropertiesUpdate(Player targetPlayer, Hashtable changedProps)
    {
        // �J�X�^���v���p�e�B���X�V���ꂽ�v���C���[�̃v���C���[����ID���R���\�[���ɏo�͂���
        Debug.Log($"{targetPlayer.NickName}({targetPlayer.ActorNumber})");

        // �X�V���ꂽ�v���C���[�̃J�X�^���v���p�e�B�̃y�A���R���\�[���ɏo�͂���
        foreach (var prop in changedProps)
        {
            Debug.Log($"{prop.Key}: {prop.Value}");
        }
    }

    public override void OnRoomPropertiesUpdate(Hashtable propertiesThatChanged)
    {
        // �X�V���ꂽ���[���̃J�X�^���v���p�e�B�̃y�A���R���\�[���ɏo�͂���
        foreach (var prop in propertiesThatChanged)
        {
            Debug.Log($"{prop.Key}: {prop.Value}");
        }
    }
}
