using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

/// <summary>
/// �Ǘ��҂��ǂ����̊m�F������
/// </summary>
public class Ownership : MonoBehaviourPunCallbacks
{
    private void Start()
    {
        // ���g���Ǘ��҂��ǂ����𔻒肷��
        if (photonView.IsMine)
        {
            // ���L�҂��擾����
            Player owner = photonView.Owner;
            // ���L�҂̃v���C���[����ID���R���\�[���ɏo�͂���
            Debug.Log($"{owner.NickName}({photonView.OwnerActorNr})");
        }
    }
}
