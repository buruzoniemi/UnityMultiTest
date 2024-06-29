using Photon.Pun;
using TMPro;

/// <summary>
/// �v���C���[�̂̓���ɖ��O��ID��\������
/// MonoBehaviourPunCallbacks���p�����āAphotonView�v���p�e�B���g����悤�ɂ���
/// </summary>
public class AvatarNameDisplay : MonoBehaviourPunCallbacks
{
    private void Start()
    {
        //���g��TextMeshPro���擾����
        var nameLabel = GetComponent<TextMeshPro>();

        //�v���C���[���ƃv���C���[ID��\������
        //NickName = �v���C���[���i�ϐ��Ƃ��đ���ł����j�AOwnerActorNr = �v���C���[��ID
        // �v���C���[���ƃv���C���[ID�ƃv���C���[�̃����N��\������
        var nickName = photonView.Owner.NickName;
        var id = photonView.OwnerActorNr;
        var rank = photonView.Owner.GetRank();
        nameLabel.text = $"{nickName}({id})[{rank}]";
    }
}