using Photon.Pun;
using UnityEngine;

/// <summary>
/// ���[�����̑��v���C���[���Ŏ��s���ē�������
/// 
/// ���ӁF
/// RPC�Ŏ��s���������\�b�h�����X�N���v�g�́A
/// PhotonView�R���|�[�l���g�Ɠ����Q�[���I�u�W�F�N�g�ɒǉ�����Ă���K�v������B
/// �q�v�f�̃Q�[���I�u�W�F�N�g�ɒǉ�����Ă���X�N���v�g�̃��\�b�h���A
/// �e�̃Q�[���I�u�W�F�N�g��PhotonView��RPC()����Ăяo���悤�Ȃ��Ƃ͂ł��܂���̂Œ��ӂ��ĂˁB
/// </summary>
public class RPC : MonoBehaviourPunCallbacks
{
    private void Update()
    {
        // �}�E�X�N���b�N���ɁA���[�����̃v���C���[�S���Ƀ��b�Z�[�W�𑗐M����
        if (Input.GetMouseButtonDown(0))
        {
            //�������͎��s���郁�\�b�h���A��������RPC�����s����ΏہA�����đ�O�����ȍ~�����s���郁�\�b�h�̈���
            photonView.RPC(nameof(RpcSendMessage), RpcTarget.All, "����ɂ���");
        }
    }

    /// <summary>
    /// ���[�����̑��v���C���[���ł����\�b�h�����s���邱�Ƃ��ł���
    /// </summary>
    /// <param name="message"></param>
    [PunRPC]
    private void RpcSendMessage(string message, PhotonMessageInfo info)
    {
        // ���b�Z�[�W�𑗐M�����v���C���[�����\������
        Debug.Log($"{info.Sender.NickName}: {message}");
    }
}