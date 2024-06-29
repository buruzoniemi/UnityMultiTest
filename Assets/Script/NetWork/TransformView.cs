using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

/// <summary>
/// ���삵�Ă���L������Transform����
/// �ق��̃v���C���[�ɑ��M���ē���������
/// </summary>
public class TransformView : MonoBehaviourPunCallbacks, IPunObservable
{
    void IPunObservable.OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            // Transform�̒l���X�g���[���ɏ�������ő��M����
            stream.SendNext(transform.localPosition);
            stream.SendNext(transform.localRotation);
            stream.SendNext(transform.localScale);
        }
        else
        {
            // ��M�����X�g���[����ǂݍ����Transform�̒l���X�V����
            transform.localPosition = (Vector3)stream.ReceiveNext();
            transform.localRotation = (Quaternion)stream.ReceiveNext();
            transform.localScale = (Vector3)stream.ReceiveNext();
        }
    }
}
