using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

/// <summary>
/// �}�X�^�[�T�[�o�[�֐ڑ���������APhoton�̃T�[�o�[����ؒf���ꂽ���̃R�[���o�b�N���󂯎�邱�Ƃ��ł���B
/// Photon�̃T�[�o�[����ؒf���ꂽ���ɂ́A�R�[���o�b�N�̈�������ؒf���ꂽ�����iDisconnectCause�j���擾�ł���B
/// </summary>
public class ConnectionCallbacks : MonoBehaviourPunCallbacks
{
    /// <summary>
    /// �}�X�^�[�T�[�o�[�ւ̐ڑ��������������ɌĂ΂��R�[���o�b�N
    /// </summary>
    public override void OnConnectedToMaster()
    {
        Debug.Log("�}�X�^�[�T�[�o�[�ɐڑ����܂���");
    }

    /// <summary>
    /// Photon�̃T�[�o�[����ؒf���ꂽ���ɌĂ΂��R�[���o�b�N
    /// </summary>
    /// <param name="cause"> </param>
    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.Log($"�T�[�o�[�Ƃ̐ڑ����ؒf����܂���: {cause.ToString()}");
    }
}
