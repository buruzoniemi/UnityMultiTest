using Photon.Pun;
using UnityEngine;

/// <summary>
/// �I�t���C����ԂŃI�����C���Ɠ��������ł���悤�ɂ��鏈��
/// </summary>
public class OffLineMode : MonoBehaviourPunCallbacks
{
    public bool isOffline = false; //���݂̏��

    /// <summary>
    /// �ڑ�������
    /// </summary>
    public void Connect()
    {
        if (!isOffline)
        {
            PhotonNetwork.ConnectUsingSettings();
        }
        else
        {
            PhotonNetwork.OfflineMode = true;
        }
    }

    /// <summary>
    /// �ڑ��̉���
    /// </summary>
    public void Disconnect()
    {
        if (!isOffline)
        {
            PhotonNetwork.Disconnect();
        }
        else
        {
            PhotonNetwork.OfflineMode = false;
        }
    }
}
