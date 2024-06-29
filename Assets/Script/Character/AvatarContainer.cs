using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// AvatarContainer: �A�o�^�[���i�[����R���e�i
/// MonoBehaviour���p�����Ă��邽�߁AUnity��GameObject�Ƃ��Ďg�p�\
/// IEnumerable<AvatarContainerChild>���������Ă��邽�߁Aforeach���[�v�Ŏq�I�u�W�F�N�g�ɃA�N�Z�X�\
/// </summary>
public class AvatarContainer : MonoBehaviour, IEnumerable<AvatarContainerChild>
{
    // �A�o�^�[�̃��X�g
    private List<AvatarContainerChild> avatarList = new List<AvatarContainerChild>();

    // �C���f�N�T�[���g�p���ă��X�g�̗v�f�ɃA�N�Z�X�\
    public AvatarContainerChild this[int index] => avatarList[index];

    // ���X�g�̗v�f�����擾����v���p�e�B
    public int Count => avatarList.Count;
 
    /// <summary>
    /// �q�I�u�W�F�N�g���ύX���ꂽ�Ƃ��ɌĂяo����郁�\�b�h
    /// </summary>
    private void OnTransformChildrenChanged()
    {
        // ���X�g���N���A���Ă���q�I�u�W�F�N�g���擾���A���X�g�ɒǉ�
        avatarList.Clear();
        foreach (Transform child in transform)
        {
            avatarList.Add(child.GetComponent<AvatarContainerChild>());
        }
    }

    /// <summary>
    /// IEnumerable<AvatarContainerChild> �̎��� 
    /// ���X�g�̗v�f�ɑ΂���񋓎q���擾���郁�\�b�h </summary>
    /// <returns></returns>
    public IEnumerator<AvatarContainerChild> GetEnumerator()
    {
        return avatarList.GetEnumerator();
    }

    /// <summary>
    /// IEnumerable �̎��� 
    /// ���X�g�̗v�f�ɑ΂���񋓎q���擾���郁�\�b�h</summary>
    /// <returns></returns>
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
