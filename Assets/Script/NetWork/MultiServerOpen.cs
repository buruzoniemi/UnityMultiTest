using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

// MonoBehaviourPunCallbacks���p�����āAPUN�̃R�[���o�b�N���󂯎���悤�ɂ���
public class MultiServerOpen : MonoBehaviourPunCallbacks
{
    private void Start()
    {
        // �v���C���[���g�̖��O��"Player"�ɐݒ肷��
        PhotonNetwork.NickName = "Player";

        // �v���C���[�̃J�X�^���v���p�e�B�ɁA�����_���ȃ����N��ݒ肷��
        PhotonNetwork.LocalPlayer.SetRandomRank();

        // PhotonServerSettings�̐ݒ���e���g���ă}�X�^�[�T�[�o�[�֐ڑ�����
        PhotonNetwork.ConnectUsingSettings();

        // 1�b�ԂɃ��b�Z�[�W���M���s����
        PhotonNetwork.SendRate = 20;

        // 1�b�ԂɃI�u�W�F�N�g�������s����
        PhotonNetwork.SerializationRate = 10; 
    }

    // �}�X�^�[�T�[�o�[�ւ̐ڑ��������������ɌĂ΂��R�[���o�b�N
    //public override void OnConnectedToMaster()
    //{
    //    // "Room"�Ƃ������O�̃��[���ɎQ������i���[�������݂��Ȃ���΍쐬���ĎQ������j
    //    // PhotonNetwork.JoinOrCreateRoom("Room", new RoomOptions(), TypedLobby.Default);
    //    // �����_���ȃ��[���ɎQ������
    //    //PhotonNetwork.JoinRandomRoom();
    //
    //    var expectedProps = new Hashtable();
    //    expectedProps.SetPlayerRank(PhotonNetwork.LocalPlayer);
    //
    //    // ���g�Ɠ��������N�̃v���C���[���쐬�������[���փ����_���ɎQ������
    //    PhotonNetwork.JoinRandomRoom(expectedProps, 2);
    //}

    /// <summary>
    /// �����_���ŎQ���ł��郋�[�������݂��Ȃ��Ȃ�A�V�K�Ń��[�����쐬����
    /// </summary>
    /// <param name="returnCode"></param>
    /// <param name="message"></param>
    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        // ���[���̃J�X�^���v���p�e�B�̏����l�ɁA���g�Ɠ��������N��ݒ肷��
        var initialProps = new Hashtable();
        initialProps.SetPlayerRank(PhotonNetwork.LocalPlayer);

        // ���[���ݒ���s��
        // ���[���̎Q���l����5�l�ɐݒ肷��
        var roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 5;

        roomOptions.CustomRoomProperties = initialProps;
        roomOptions.CustomRoomPropertiesForLobby = initialProps.KeysForLobby();

        PhotonNetwork.CreateRoom(null, roomOptions);
    }

    // �Q�[���T�[�o�[�ւ̐ڑ��������������ɌĂ΂��R�[���o�b�N
    public override void OnJoinedRoom()
    {
        // �����_���ȍ��W�Ɏ��g�̃A�o�^�[�i�l�b�g���[�N�I�u�W�F�N�g�j�𐶐�����
        var position = new Vector3(Random.Range(-3f, 3f), Random.Range(-3f, 3f));
        PhotonNetwork.Instantiate("Avatar", position, Quaternion.identity);
        // ���[�����쐬�����v���C���[�́A���݂̃T�[�o�[�������Q�[���̊J�n�����ɐݒ肷��
        if (PhotonNetwork.IsMasterClient)
        {
            PhotonNetwork.CurrentRoom.SetStartTime(PhotonNetwork.ServerTimestamp);
        }
        // ���[���������ɂȂ�����A�ȍ~���̃��[���ւ̎Q����s���ɂ���
        if (PhotonNetwork.CurrentRoom.PlayerCount == PhotonNetwork.CurrentRoom.MaxPlayers)
        {
            PhotonNetwork.CurrentRoom.IsOpen = false;
        }
    }
}