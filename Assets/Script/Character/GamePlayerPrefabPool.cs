using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

/// <summary>
/// �Q�[���v���C���[�̃v���n�u�v�[�����Ǘ�����N���X
/// </summary>
public class GamePlayerPrefabPool : MonoBehaviour, IPunPrefabPool
{
    [SerializeField]
    private GamePlayer gamePlayerPrefab = default; // �Q�[���v���C���[�v���n�u

    private void Start()
    {
        // PhotonNetwork��PrefabPool�����̃N���X�ɐݒ肷��
        PhotonNetwork.PrefabPool = this;
    }

    // IPunPrefabPool�̃C���^�[�t�F�[�X���\�b�h�̎����F�l�b�g���[�N�I�u�W�F�N�g�̐���
    GameObject IPunPrefabPool.Instantiate(string prefabId, Vector3 position, Quaternion rotation)
    {
        switch (prefabId)
        {
            case "GamePlayer":
                var player = Instantiate(gamePlayerPrefab, position, rotation);
                // �������ꂽ�l�b�g���[�N�I�u�W�F�N�g�͔�A�N�e�B�u��ԂŕԂ��K�v������
                // �i���̌�APhotonNetwork�̓����Ő���������������Ă��玩���I�ɃA�N�e�B�u��Ԃɖ߂����j
                player.gameObject.SetActive(false);
                return player.gameObject;
        }
        return null;
    }

    // IPunPrefabPool�̃C���^�[�t�F�[�X���\�b�h�̎����F�l�b�g���[�N�I�u�W�F�N�g�̔j��
    void IPunPrefabPool.Destroy(GameObject gameObject)
    {
        Destroy(gameObject);
    }
}

/// <summary>
/// �Q�[���v���C���[�̃N���X
/// </summary>
public class GamePlayer : MonoBehaviourPunCallbacks
{
    private void Awake()
    {
        // Object.Instantiate�̌�Ɉ�x�����K�v�ȏ������������s��
    }

    private void Start()
    {
        // ������Ɉ�x�����iOnEnable�̌�Ɂj�Ă΂��A�����ŏ������������s���ꍇ�͗v����
        // �I�u�W�F�N�g������Ɉ�x�����Ă΂�Ȃ�Awake()��Start()�ŉ��炩�̏������������s���Ă���ƁA
        // �I�u�W�F�N�g���g���񂳂ꂽ���ɐ������������������s���Ȃ��\�������邽��
    }

    // �l�b�g���[�N�I�u�W�F�N�g���L���ɂȂ������ɌĂ΂��R�[���o�b�N
    public override void OnEnable()
    {
        base.OnEnable();

        // PhotonNetwork.Instantiate�̐���������ɕK�v�ȏ������������s��
    }

    // �l�b�g���[�N�I�u�W�F�N�g�������ɂȂ钼�O�ɌĂ΂��R�[���o�b�N
    public override void OnDisable()
    {
        base.OnDisable();

        // PhotonNetwork.Destroy�̔j�������O�ɕK�v�ȏI���������s��
    }
}