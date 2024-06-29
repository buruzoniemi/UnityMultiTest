using System;
using System.Text;
using Photon.Pun;
using TMPro;
using UnityEngine;

/// <summary>
/// リーダーボードを管理するクラス
/// </summary>
public class LeaderBoard : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI label = default; //リーダーボードのテキストを表示するTextMeshProUGUI

    private StringBuilder builder; //テキストを効率的に構築するためのStringBuilder
    private float elapsedTime; //テキストの更新間隔を管理するための経過時間

    private void Start()
    {
        builder = new StringBuilder();
        elapsedTime = 0f;
    }

    private void Update()
    {
        // まだルームに参加していない場合は更新しない
        if (!PhotonNetwork.InRoom) { return; }

        // 0.1秒毎にテキストを更新する
        elapsedTime += Time.deltaTime;
        if (elapsedTime > 0.1f)
        {
            elapsedTime = 0f;
            UpdateLabel();
        }
    }

    /// <summary>
    /// リーダーボードのテキストを更新
    /// </summary>
    private void UpdateLabel()
    {
        var players = PhotonNetwork.PlayerList;
        Array.Sort(
            players,
            (p1, p2) =>
            {
                // スコアが多い順にソートする
                int diff = p2.GetScore() - p1.GetScore();
                if (diff != 0)
                {
                    return diff;
                }
                // スコアが同じだった場合は、IDが小さい順にソートする
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