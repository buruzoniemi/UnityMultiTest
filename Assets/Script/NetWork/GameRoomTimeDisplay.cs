using Photon.Pun;
using TMPro;
using UnityEngine;

/// <summary>
/// シーン上にゲームの経過時間を表示するUIを作成して、経過時間を更新する
/// </summary>
public class GameRoomTimeDisplay : MonoBehaviour
{
    private TextMeshProUGUI timeLabel; //時間を代入するテキストメッシュ

    private void Start()
    {
        timeLabel = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        // まだルームに参加していない場合は更新しない
        if (!PhotonNetwork.InRoom) { return; }
        // まだゲームの開始時刻が設定されていない場合は更新しない
        if (!PhotonNetwork.CurrentRoom.TryGetStartTime(out int timestamp)) { return; }

        // ゲームの経過時間を求めて、小数第一位まで表示する
        float elapsedTime = Mathf.Max(0f, unchecked(PhotonNetwork.ServerTimestamp - timestamp) / 1000f);
        timeLabel.text = elapsedTime.ToString("f1");
    }
}
