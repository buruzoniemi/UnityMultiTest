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
        //���[���Q�����́A���ׂĂ̎Q���{�^���������Ȃ��悤�ɂ���
        fixedRoomLobbyView.OnJoiningRoom();

        //�{�^���ɑΉ��������[�����̃��[���ɎQ������(���[�������݂��Ȃ���΍쐬���Ă���Q������)
        var roomOprions = new RoomOptions();
        roomOprions.MaxPlayers = MaxPlayers;
        PhotonNetwork.JoinOrCreateRoom(RoomName, roomOprions, TypedLobby.Default);
    }

    public void SetPlayerCount(int playerCount)
    {
        label.text = $"{RoomName}\n{playerCount} / {MaxPlayers}";

        //���[���������łȂ��Ƃ��̂݁A���[���Q���{�^����������悤�ɂ���
        button.interactable = (playerCount < MaxPlayers);
    }
}
