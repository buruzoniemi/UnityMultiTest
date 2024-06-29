using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

/// <summary>
/// �������Ǘ�����N���X
/// </summary>
public class StopSyncing : MonoBehaviourPunCallbacks, IPunObservable
{
    private bool isSyncing = true; // �����t���O

    /// <summary>
    /// �����̃t���O����Ē�~���邩���M���s�����\�b�h
    /// </summary>
    /// <param name="stream"></param>
    /// <param name="info"></param>
    void IPunObservable.OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            // �����t���O�������Ă���ꍇ�̂ݑ��M���s��
            if (isSyncing)
            {
                stream.SendNext(transform.position);
            }
            else
            {
                return;
            }
        }
        else
        {
            transform.position = (Vector3)stream.ReceiveNext();
        }
    }
}
