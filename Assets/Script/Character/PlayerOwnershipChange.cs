using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PlayerOwnershipChange : MonoBehaviourPunCallbacks, IPunOwnershipCallbacks
{
    // ���L���̃��N�G�X�g���s��ꂽ���ɌĂ΂��R�[���o�b�N
    public void OnOwnershipRequest(PhotonView targetView, Player requestingPlayer)
    {
        // ���g�����L�������C���X�^���X�ŏ��L���̃��N�G�X�g���s��ꂽ��A��ɋ����ď��L�����ڏ�����
        if (targetView.IsMine && targetView.ViewID == photonView.ViewID)
        {
            bool acceptsRequest = true;
            if (acceptsRequest)
            {
                targetView.TransferOwnership(requestingPlayer);
            }
            else
            {
                // ���N�G�X�g�����ۂ���ꍇ�́A�������Ȃ�
                return;
            }
        }
    }

    // ���L���̈ڏ����s��ꂽ���ɌĂ΂��R�[���o�b�N
    public void OnOwnershipTransfered(PhotonView targetView, Player previousOwner)
    {
        if (targetView.ViewID == photonView.ViewID)
        {
            string id = targetView.ViewID.ToString();
            string p1 = previousOwner.NickName;
            string p2 = targetView.Owner.NickName;
            Debug.Log($"ViewID {id} �̏��L���� {p1} ���� {p2} �Ɉڏ�����܂���");
        }
    }

    // ���L���̈ڏ������s�������ɌĂ΂��R�[���o�b�N
    public void OnOwnershipTransferFailed(PhotonView targetView, Player previousOwner)
    {
        // �����ɏ�����ǉ�����
        Debug.Log("���L���̏��n�Ɏ��s���܂����B");
        return;
    }
}
