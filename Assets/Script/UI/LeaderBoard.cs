using System;
using System.Text;
using Photon.Pun;
using TMPro;
using UnityEngine;

/// <summary>
/// ���[�_�[�{�[�h���Ǘ�����N���X
/// </summary>
public class LeaderBoard : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI label = default; //���[�_�[�{�[�h�̃e�L�X�g��\������TextMeshProUGUI

    private StringBuilder builder; //�e�L�X�g�������I�ɍ\�z���邽�߂�StringBuilder
    private float elapsedTime; //�e�L�X�g�̍X�V�Ԋu���Ǘ����邽�߂̌o�ߎ���

    private void Start()
    {
        builder = new StringBuilder();
        elapsedTime = 0f;
    }

    private void Update()
    {
        // �܂����[���ɎQ�����Ă��Ȃ��ꍇ�͍X�V���Ȃ�
        if (!PhotonNetwork.InRoom) { return; }

        // 0.1�b���Ƀe�L�X�g���X�V����
        elapsedTime += Time.deltaTime;
        if (elapsedTime > 0.1f)
        {
            elapsedTime = 0f;
            UpdateLabel();
        }
    }

    /// <summary>
    /// ���[�_�[�{�[�h�̃e�L�X�g���X�V
    /// </summary>
    private void UpdateLabel()
    {
        var players = PhotonNetwork.PlayerList;
        Array.Sort(
            players,
            (p1, p2) =>
            {
                // �X�R�A���������Ƀ\�[�g����
                int diff = p2.GetScore() - p1.GetScore();
                if (diff != 0)
                {
                    return diff;
                }
                // �X�R�A�������������ꍇ�́AID�����������Ƀ\�[�g����
                return p1.ActorNumber - p2.ActorNumber;
            }
        );

        builder.Clear();
        foreach (var player in players)
        {
            builder.AppendLine($"{player.NickName}({player.ActorNumber}) - {player.GetScore()}");
        }
        label.text = builder.ToString();
    }

}