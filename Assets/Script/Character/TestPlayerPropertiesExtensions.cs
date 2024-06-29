using ExitGames.Client.Photon;
using Photon.Realtime;

/// <summary>
/// プレイヤーのカスタムプロパティに関する拡張メソッドを提供
/// </summary>
public static class TestPlayerPropertiesExtensions
{
    private const string ScoreKey = "Score"; //プレイヤーのスコアを表すキー
    private const string MessageKey = "Message"; //プレイヤーのメッセージを表すキー

    private static readonly Hashtable propsToSet = new Hashtable(); //設定するプロパティを保持するためのハッシュテーブ

    /// <summary>
    /// プレイヤーのスコアを取得する
    /// </summary>
    /// <param name="player">プレイヤーのインスタンス</param>
    /// <returns></returns>
    public static int TestGetScore(this Player player)
    {
        return (player.CustomProperties[ScoreKey] is int score) ? score : 0;
    }

    /// <summary>
    /// プレイヤーのメッセージを取得する
    /// </summary>
    /// <param name="player">プレイヤーのインスタンス</param>
    /// <returns></returns>
    public static string TestGetMessage(this Player player)
    {
        return (player.CustomProperties[MessageKey] is string message) ? message : string.Empty;
    }

    /// <summary>
    /// プレイヤーのスコアを設定する
    /// </summary>
    /// <param name="player">プレイヤーのインスタンス</param>
    /// <param name="score">設定するスコア</param>
    public static void TestSetScore(this Player player, int score)
    {
        propsToSet[ScoreKey] = score;
        player.SetCustomProperties(propsToSet);
        propsToSet.Clear();
    }

    /// <summary>
    /// プレイヤーのメッセージを設定する
    /// </summary>
    /// <param name="player">プレイヤーのインスタンス</param>
    /// <param name="message">設定するメッセージ</param>
    public static void TestSetMessage(this Player player, string message)
    {
        propsToSet[MessageKey] = message;
        player.SetCustomProperties(propsToSet);
        propsToSet.Clear();
    }
}
