using Photon.Pun;
using UnityEngine;

/// <summary>
/// Avatar���e�����̂𐧌䂷��N���X
/// </summary>
public class AvatarFireBullet : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private InGameBullet bulletPrefab = default; //�e�̃v���n�u

    private int nextBulletId = 0; //���̒e��ID

    private void Update()
    {
        if (photonView.IsMine)
        {
            // ���N���b�N�ŃJ�[�\���̕����ɒe�𔭎˂���
            if (Input.GetMouseButtonDown(0))
            {
                var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                var direction = mousePosition - transform.position;
                float angle = Mathf.Atan2(direction.y, direction.x);

                //�e�𔭎˂��邽�тɒe��ID��1�����₵�Ă���
                photonView.RPC(nameof(FireBullet), RpcTarget.All,nextBulletId++, angle);
            }
        }
    }

    /// <summary>
    /// �e�𔭎˂��郁�\�b�h
    /// </summary>
    /// <param name="id"></param>
    /// <param name="angle"></param>
    /// <param name="info"></param>
    [PunRPC]
    private void FireBullet(int id, float angle, PhotonMessageInfo info)
    {
        var bullet = Instantiate(bulletPrefab);
        // PhotonMessageInfo����ARPC�𑗐M�����������擾����
        // �e�𔭎˂���������50ms�̃f�B���C��������
        int timestamp = info.SentServerTimestamp;
        bullet.Init(id, photonView.OwnerActorNr, transform.position, angle, timestamp);
    }
}