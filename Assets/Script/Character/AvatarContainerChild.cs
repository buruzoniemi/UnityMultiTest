using Photon.Pun;
using Photon.Realtime;

/// <summary>
/// AvatarContainerChild: �A�o�^�[�R���e�i�̎q�I�u�W�F�N�g��\���N���X
/// MonoBehaviourPunCallbacks���p�����Ă��邽�߁APUN2�̃R�[���o�b�N���g�p�\
/// </summary>
public class AvatarContainerChild : MonoBehaviourPunCallbacks
{
    public Player Owner => photonView.Owner; // ���L�҂̃v���C���[���擾����v���p�e�B

    /// <summary>
    /// �I�u�W�F�N�g���L���ɂȂ����Ƃ��ɌĂяo����郁�\�b�h
    /// </summary>
    public override void OnEnable()
    {
        base.OnEnable();

        // AvatarContainer��T���āA���������ꍇ�͂��̃I�u�W�F�N�g�����̎q�ɐݒ肷��
        var container = FindObjectOfType<AvatarContainer>();
        if (container != null)
        {
            transform.SetParent(container.transform);
        }
    }
}
