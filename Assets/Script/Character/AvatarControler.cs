using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// �ړ������n��������ł�N���X
/// �X�^�~�i��UI�������ŊǗ���������Ă�悧��
/// </summary>
public class AvatarControler : MonoBehaviourPunCallbacks, IPunObservable
{
    private static readonly float MaxStamina = 6f; //�X�^�~�i�̏���l
    [SerializeField]
    private Image staminaBar = default;
    private float currentStamina = MaxStamina;

    private void Update()
    {
        //�����̑���L�����̊m�F
        if (photonView.IsMine)
        {
            StaminaIncreaseDecrease();
        }

        // �X�^�~�i���Q�[�W�ɔ��f����
        StaminaReflection();
    }

    void IPunObservable.OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            // ���g�̃A�o�^�[�̃X�^�~�i�𑗐M����
            stream.SendNext(currentStamina);
        }
        else
        {
            // ���v���C���[�̃A�o�^�[�̃X�^�~�i����M����
            currentStamina = (float)stream.ReceiveNext();
        }
    }

    /// <summary>
    /// �X�^�~�i�̑���
    /// </summary>
    void StaminaIncreaseDecrease()
    {
        var input = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0f);
        if (input.sqrMagnitude > 0f)
        {
            // ���͂���������A�X�^�~�i������������
            currentStamina = Mathf.Max(0f, currentStamina - Time.deltaTime);
            transform.Translate(6f * Time.deltaTime * input.normalized);
        }
        else
        {
            // ���͂��Ȃ�������A�X�^�~�i���񕜂�����
            currentStamina = Mathf.Min(currentStamina + Time.deltaTime * 2, MaxStamina);
        }
    }

    /// <summary>
    /// �X�^�~�i�̔��f
    /// </summary>
    void StaminaReflection()
    {
        staminaBar.fillAmount = currentStamina / MaxStamina;
    }
}
