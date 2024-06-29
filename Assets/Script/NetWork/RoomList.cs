using System.Collections;
using System.Collections.Generic;
using Photon.Realtime;

/// <summary>
/// ���[�����X�g���L���b�V������N���X
/// ���r�[�ɎQ�����Ă���Ԃ͂��ł����[�����X�g�S�̂��擾�ł���
/// </summary>
// IEnumerable�iRoomInfo�j�C���^�[�t�F�[�X���������āA
// foreach�Ń��[������񋓂ł���悤�ɂ���
public class RoomList : IEnumerable<RoomInfo>
{
    private Dictionary<string, RoomInfo> dictionary = new Dictionary<string, RoomInfo>(); //���[������ێ����鎫��

    /// <summary>
    /// ���[�����X�g���X�V����B
    /// </summary>
    /// <param name="changedRoomList">�ύX���ꂽ���[�����X�g</param>
    public void Update(List<RoomInfo> changedRoomList)
    {
        foreach(var info in changedRoomList)
        {
            if(!info.RemovedFromList)
            {
                dictionary[info.Name] = info;
            }
            else
            {
                dictionary.Remove(info.Name);
            }
        }
    }

    /// <summary>
    /// �����^�̒��g����ɂ���
    /// </summary>
    public void Clear()
    {
        dictionary.Clear();
    }

    /// <summary>
    /// �w�肵�����[�����̃��[����񂪂���Ύ擾����
    /// </summary>
    /// <param name="roomName">���[���̖��O</param>
    /// <param name="roomInfo">���[���̏��</param>
    /// <returns>���[����񂪂��邩�ǂ����������^�U�l</returns>
    public bool TryGetRoomInfo(string roomName, out RoomInfo roomInfo)
    {
        return dictionary.TryGetValue(roomName, out roomInfo);
    }

    /// <summary>
    /// ���[������񋓂��邽�߂�IEnumerator<RoomInfo>��Ԃ��B
    /// </summary>
    /// <returns>���[�����̗񋓎q</returns>
    public IEnumerator<RoomInfo>GetEnumerator()
    {
        foreach(var kvp in dictionary)
        {
            yield return kvp.Value;
        }
    }

    /// <summary>
    /// ���[������񋓂��邽�߂�IEnumerator��Ԃ��B
    /// </summary>
    /// <returns>���[�����̗񋓎q</returns>
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
