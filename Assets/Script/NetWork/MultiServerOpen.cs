using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

// MonoBehaviourPunCallbacksを継承して、PUNのコールバックを受け取れるようにする
public class MultiServerOpen : MonoBehaviourPunCallbacks
{
    private void Start()
    {
        // プレイヤー自身の名前を"Player"に設定する
        PhotonNetwork.NickName = "Player";

        // プレイヤーのカスタムプロパティに、ランダムなランクを設定する
        PhotonNetwork.LocalPlayer.SetRandomRank();

        // PhotonServerSettingsの設定内容を使ってマスターサーバーへ接続する
        PhotonNetwork.ConnectUsingSettings();

        // 1秒間にメッセージ送信を行う回数
        PhotonNetwork.SendRate = 20;

        // 1秒間にオブジェクト同期を行う回数
        PhotonNetwork.SerializationRate = 10; 
    }

    // マスターサーバーへの接続が成功した時に呼ばれるコールバック
    //public override void OnConnectedToMaster()
    //{
    //    // "Room"という名前のルームに参加する（ルームが存在しなければ作成して参加する）
    //    // PhotonNetwork.JoinOrCreateRoom("Room", new RoomOptions(), TypedLobby.Default);
    //    // ランダムなルームに参加する
    //    //PhotonNetwork.JoinRandomRoom();
    //
    //    var expectedProps = new Hashtable();
    //    expectedProps.SetPlayerRank(PhotonNetwork.LocalPlayer);
    //
    //    // 自身と同じランクのプレイヤーが作成したルームへランダムに参加する
    //    PhotonNetwork.JoinRandomRoom(expectedProps, 2);
    //}

    /// <summary>
    /// ランダムで参加できるルームが存在しないなら、新規でルームを作成する
    /// </summary>
    /// <param name="returnCode"></param>
    /// <param name="message"></param>
    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        // ルームのカスタムプロパティの初期値に、自身と同じランクを設定する
        var initialProps = new Hashtable();
        initialProps.SetPlayerRank(PhotonNetwork.LocalPlayer);

        // ルーム設定を行う
        // ルームの参加人数を5人に設定する
        var roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 5;

        roomOptions.CustomRoomProperties = initialProps;
        roomOptions.CustomRoomPropertiesForLobby = initialProps.KeysForLobby();

        PhotonNetwork.CreateRoom(null, roomOptions);
    }

    // ゲームサーバーへの接続が成功した時に呼ばれるコールバック
    public override void OnJoinedRoom()
    {
        // ランダムな座標に自身のアバター（ネットワークオブジェクト）を生成する
        var position = new Vector3(Random.Range(-3f, 3f), Random.Range(-3f, 3f));
        PhotonNetwork.Instantiate("Avatar", position, Quaternion.identity);
        // ルームを作成したプレイヤーは、現在のサーバー時刻をゲームの開始時刻に設定する
        if (PhotonNetwork.IsMasterClient)
        {
            PhotonNetwork.CurrentRoom.SetStartTime(PhotonNetwork.ServerTimestamp);
        }
        // ルームが満員になったら、以降そのルームへの参加を不許可にする
        if (PhotonNetwork.CurrentRoom.PlayerCount == PhotonNetwork.CurrentRoom.MaxPlayers)
        {
            PhotonNetwork.CurrentRoom.IsOpen = false;
        }
    }
}