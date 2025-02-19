using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MatchmakingView : MonoBehaviourPunCallbacks
{
    [SerializeField] private TMP_InputField passwordInputField = default;
    [SerializeField] private Button joinRoomButton = default;
    private CanvasGroup canvasGroup;

    private void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        //マスターサーバーに接続するまでは、入力できないようにする
        canvasGroup.interactable = false;
        //パスワードを入力するまでは、ルーム参加ボタンを押させないようにする
        joinRoomButton.interactable = false;

        passwordInputField.onValueChanged.AddListener(OnPasswordInputFieldValueChanged);
        joinRoomButton.onClick.AddListener(OnJoinRoomButtonClick);
    }

    public override void OnConnectedToMaster()
    {
        //マスターサーバーに接続したら、入力できるようにする
        canvasGroup.interactable = true;
    }

    private void OnPasswordInputFieldValueChanged(string value)
    {
        //パスワードを6桁入力したときのみ、ルーム参加ボタンを押せるようにする
        joinRoomButton.interactable = (value.Length == 6);
    }

    private void OnJoinRoomButtonClick()
    {
        //ルーム参加処理中は、入力できないようにする
        canvasGroup.interactable = false;

        //ルームを非公開に設定する(新規でルームを作成する場合)
        var roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 5;
        roomOptions.IsVisible = false;

        //パスワードと同じ名前のルームに参加する(ルームが無ければ作成してから参加)
        PhotonNetwork.JoinOrCreateRoom(passwordInputField.text, roomOptions, TypedLobby.Default);
    }

    public override void OnJoinedRoom()
    {
        //ルームへの参加が成功したら、UIを非表示にする
        gameObject.SetActive(false);
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        //ルームへの参加が失敗したら、パスワードを再び入力できるようにする
        passwordInputField.text = string.Empty;
        canvasGroup.interactable = true;
    }
}
