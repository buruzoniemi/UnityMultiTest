using Photon.Pun;
using TMPro;
using UnityEngine;

/// <summary>
/// �V�[����ɃQ�[���̌o�ߎ��Ԃ�\������UI���쐬���āA�o�ߎ��Ԃ��X�V����
/// </summary>
public class GameRoomTimeDisplay : MonoBehaviour
{
    private TextMeshProUGUI timeLabel; //���Ԃ�������e�L�X�g���b�V��

    private void Start()
    {
        timeLabel = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        // �܂����[���ɎQ�����Ă��Ȃ��ꍇ�͍X�V���Ȃ�
        if (!PhotonNetwork.InRoom) { return; }
        // �܂��Q�[���̊J�n�������ݒ肳��Ă��Ȃ��ꍇ�͍X�V���Ȃ�
        if (!PhotonNetwork.CurrentRoom.TryGetStartTime(out int timestamp)) { return; }

        // �Q�[���̌o�ߎ��Ԃ����߂āA�������ʂ܂ŕ\������
        float elapsedTime = Mathf.Max(0f, unchecked(PhotonNetwork.ServerTimestamp - timestamp) / 1000f);
        timeLabel.text = elapsedTime.ToString("f1");
    }
}
