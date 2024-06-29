using System.Collections;
using System.Collections.Generic;
using Photon.Realtime;

/// <summary>
/// ルームリストをキャッシュするクラス
/// ロビーに参加している間はいつでもルームリスト全体を取得できる
/// </summary>
// IEnumerable（RoomInfo）インターフェースを実装して、
// foreachでルーム情報を列挙できるようにする
public class RoomList : IEnumerable<RoomInfo>
{
    private Dictionary<string, RoomInfo> dictionary = new Dictionary<string, RoomInfo>(); //ルーム情報を保持する辞書

    /// <summary>
    /// ルームリストを更新する。
    /// </summary>
    /// <param name="changedRoomList">変更されたルームリスト</param>
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
    /// 辞書型の中身を空にする
    /// </summary>
    public void Clear()
    {
        dictionary.Clear();
    }

    /// <summary>
    /// 指定したルーム名のルーム情報があれば取得する
    /// </summary>
    /// <param name="roomName">ルームの名前</param>
    /// <param name="roomInfo">ルームの情報</param>
    /// <returns>ルーム情報があるかどうかを示す真偽値</returns>
    public bool TryGetRoomInfo(string roomName, out RoomInfo roomInfo)
    {
        return dictionary.TryGetValue(roomName, out roomInfo);
    }

    /// <summary>
    /// ルーム情報を列挙するためのIEnumerator<RoomInfo>を返す。
    /// </summary>
    /// <returns>ルーム情報の列挙子</returns>
    public IEnumerator<RoomInfo>GetEnumerator()
    {
        foreach(var kvp in dictionary)
        {
            yield return kvp.Value;
        }
    }

    /// <summary>
    /// ルーム情報を列挙するためのIEnumeratorを返す。
    /// </summary>
    /// <returns>ルーム情報の列挙子</returns>
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
