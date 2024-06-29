using UnityEngine;
using Photon.Pun;

/// <summary>
/// �e���A�o�^�[�ɓ����铖���蔻�����������N���X
/// </summary>
public class AvatarHitBullet : MonoBehaviourPunCallbacks
{
    /// <summary>
    /// ���R���C�_�[�ɏՓ˂����ۂɎ��s����鏈��
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter2D(Collider2D other)
    {
        //���g����Ȃ��ꍇ�����������ɕԂ�
        if (photonView.IsMine)
        {
            //InGameBullet�R���|�[�l���g���������`�F�b�N
            if (other.TryGetComponent<InGameBullet>(out var bullet))
            {
                //���̒e�̏��L�҂��������g�łȂ��ꍇ�ɂ̂�RPC���Ăяo���B
                if (bullet.OwnerId != PhotonNetwork.LocalPlayer.ActorNumber)
                {
                    photonView.RPC(nameof(HitBullet), RpcTarget.All, bullet.Id, bullet.OwnerId);
                }
            }
        }
    }

    /// <summary>
    /// �ق��̃v���C���[�̒e�������̃L�����ɓ����������Ƃ�ʒm���郁�\�b�h
    /// </summary>
    /// <param name="id"></param>
    /// <param name="ownerId"></param>
    [PunRPC]
    private void HitBullet(int id, int ownerId)
    {
        //InGameBullet�R���|�[�l���g�������ׂĂ̒e��FindObjectsOfType�Ō���
        var bullets = FindObjectsOfType<InGameBullet>();

        //�^����ꂽID�Ə��L��ID����v����e�������Ĕj��
        foreach (var bullet in bullets)
        {
            if (bullet.Equals(id, ownerId))
            {
                // ���g�����˂����e�����������ꍇ�ɂ́A���g�̃X�R�A�𑝂₷
                if (ownerId == PhotonNetwork.LocalPlayer.ActorNumber)
                {
                    PhotonNetwork.LocalPlayer.AddScore(10);
                }
                Destroy(bullet.gameObject);
                break;
            }
        }
    }
}
