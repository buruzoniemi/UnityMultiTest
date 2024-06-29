using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PhotonViewMonitoring : MonoBehaviourPunCallbacks, IPunObservable
{
    private Vector3 lastPosition; // ���߂̍��W

    private void Awake()
    {
        lastPosition = transform.position; // �ŏ��ɍ��W������������
    }

    /// <summary>
    /// IPunObservable�C���^�[�t�F�[�X�̎��� 
    /// </summary>
    /// <param name="stream">
    /// �f�[�^�̑���M���s�����߂̃X�g���[���ł��B���̃X�g���[�����g�p���āA
    /// �l�b�g���[�N�z���Ƀf�[�^�𑗐M������A��M�����肵�܂��B
    /// �������݃��[�h�Ɠǂݍ��݃��[�h�B���M���ł͏������݃��[�h���g�p���A��M���ł͓ǂݍ��݃��[�h���g�p���܂��B
    /// </param>
    /// <param name="info">
    /// ���b�Z�[�W�̑��M�҂⑗�M�����ȂǁA���b�Z�[�W�Ɋւ���ǉ������܂ރN���X�ł��B
    /// ���̃N���X�ɂ́A���b�Z�[�W�𑗐M�����N���C�A���g�̏���A���M���̃^�C���X�^���v�Ȃǂ��܂܂�Ă��܂��B
    /// </param>
    void IPunObservable.OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            // �������݃��[�h�̏ꍇ�A���W�����̋����ȏ�ω������瑗�M����
            if (Vector3.Distance(transform.position, lastPosition) > 0.01f)
            {
                stream.SendNext(transform.position); // ���W�𑗐M����
                lastPosition = transform.position; // ���M�������W�𒼋߂̍��W�Ƃ��ĕۑ�����
            }
        }
        else
        {
            // �ǂݍ��݃��[�h�̏ꍇ�A��M�������W��K�p����
            transform.position = (Vector3)stream.ReceiveNext();
        }
    }
}
