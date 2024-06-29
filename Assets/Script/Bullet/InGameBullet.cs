using Photon.Pun;
using UnityEngine;

/// <summary>
/// �e�̃N���X
/// </summary>
public class InGameBullet : MonoBehaviour
{
    private Vector3 origin; // �e�𔭎˂��������̍��W
    private Vector3 velocity; //�����x
    private int timestamp; // �e�𔭎˂�������

    public int Id { get; private set;} //�e��ID��Ԃ��v���p�e�B
    public int OwnerId { get; private set; } //�e�𔭎˂����v���C���[��ID��Ԃ��v���p�e�B

    /// <summary>
    /// �����e���ǂ�����ID�Ŕ��肷�郁�\�b�h
    /// </summary>
    /// <param name="id"></param>
    /// <param name="ownerId"></param>
    /// <returns></returns>
    public bool Equals(int id, int ownerId) => id == Id && ownerId == OwnerId;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="origin"></param>
    /// <param name="angle"></param>
    public void Init(int id, int ownerId, Vector3 origin, float angle, int timestamp)
    {
        Id = id;
        OwnerId = ownerId;
        this.origin = origin;
        velocity = 9f * new Vector3(Mathf.Cos(angle), Mathf.Sin(angle));
        this.timestamp = timestamp;

        // ��x��������Update()���Ă�ŁAtransform.position�̏����l�����߂�
        Update();
    }

    private void Update()
    {
        // �e�𔭎˂����������猻�ݎ����܂ł̌o�ߎ��Ԃ����߂�
        float elapsedTime = Mathf.Max(0f, unchecked(PhotonNetwork.ServerTimestamp - timestamp) / 1000f);
        // �e�𔭎˂��������ł̍��W�E���x�E�o�ߎ��Ԃ��猻�݂̍��W�����߂�
        transform.position = origin + velocity * elapsedTime;
    }

    /// <summary>
    /// ��ʊO�Ɉړ�������폜����
    ///�iUnity�̃G�f�B�^�[��ł̓V�[���r���[�̉�ʂ��e������̂Œ��Ӂj
    /// </summary>
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}