using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RoomButton : MonoBehaviour
{
    private const int MaxPlayers = 4;
    [SerializeField]
    private TextMeshProUGUI label = default;

    private FixedRoomLobbyView fixedRoomLobbyView;
    private Button button;

    public string RoomName { get; private set;}

    public void Init(FixedRoomLobbyView parentView, int roomId)
    {
        fixedRoomLobbyView = parentView;
        RoomName = $"Room{roomId}";

        button = GetComponent<Button>();
        button.interactable = false;
        button.onClick.AddListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        //ルーム参加中は、すべての参加ボタンを押せないようにする
        fixedRoomLobbyView.OnJoiningRoom();

        //ボタンに対応したルーム名のルームに参加する(ルームが存在しなければ作成してから参加する)
        var roomOprions = new RoomOptions();
        roomOprions.MaxPlayers = MaxPlayers;
        PhotonNetwork.JoinOrCreateRoom(RoomName, roomOprions, TypedLobby.Default);
    }

    public void SetPlayerCount(int playerCount)
    {
        label.text = $"{RoomName}\n{playerCount} / {MaxPlayers}";

        //ルームが満員でないときのみ、ルーム参加ボタンを押せるようにする
        button.interactable = (playerCount < MaxPlayers);
    }
}
