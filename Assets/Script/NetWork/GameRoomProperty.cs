using ExitGames.Client.Photon;
using Photon.Realtime;

/// <summary>
/// ゲームの開始時刻を設定・取得する拡張メソッドの定義
/// </summary>
public static class GameRoomProperty
{
    private const string KeyStartTime = "StartTime";

    private static readonly Hashtable propsToSet = new Hashtable();

    // ゲームの開始時刻が設定されていれば取得する
    public static bool TryGetStartTime(this Room room, out int timestamp)
    {
        if (room.CustomProperties[KeyStartTime] is int value)
        {
            timestamp = value;
            return true;
        }
        else
        {
            timestamp = 0;
            return false;
        }
    }

    // ゲームの開始時刻を設定する
    public static void SetStartTime(this Room room, int timestamp)
    {
        propsToSet[KeyStartTime] = timestamp;
        room.SetCustomProperties(propsToSet);
        propsToSet.Clear();
    }
}
