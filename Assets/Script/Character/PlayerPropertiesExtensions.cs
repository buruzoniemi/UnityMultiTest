using ExitGames.Client.Photon;
using Photon.Realtime;
using UnityEngine;

public static class PlayerPropertiesExtensions
{
    private const string RankKey = "Rank"; //ランクのKey
    private const string ScoreKey = "Score"; //スコアのKey
    private static readonly Hashtable propsToSet = new Hashtable(); //PlayerPropertiesExtensionsクラス内でカスタムプロパティを設定するために使用
    private static readonly string[] ranks = { "A", "B", "C" }; // プレイヤーのランクの配列

    /// <summary>
    /// プレイヤーのスコアを取得する
    /// </summary>
    /// <param name="player">自分自身</param>
    /// <returns></returns>
    public static int GetScore(this Player player)
    {
        return (player.CustomProperties[ScoreKey] is int score) ? score : 0;
    }

    /// <summary>
    /// プレイヤーのスコアを加算する
    /// </summary>
    /// <param name="player">自分自身</param>
    /// <param name="value">加算されるスコアの値</param>
    public static void AddScore(this Player player, int value)
    {
        propsToSet[ScoreKey] = player.GetScore() + value;
        player.SetCustomProperties(propsToSet);
        propsToSet.Clear();
    }

    /// <summary>
    /// プレイヤーのランクを取得する
    /// </summary>
    /// <param name="player">自分自身</param>
    /// <returns></returns>
    public static string GetRank(this Player player)
    {
        if (player.CustomProperties[RankKey] is string rank)
        {
            return rank;
        }
        else
        {
            return ranks[ranks.Length - 1];
        }
    }

    /// <summary>
    /// プレイヤーのランクをランダムに設定する
    /// </summary>
    /// <param name="player"></param>
    public static void SetRandomRank(this Player player)
    {
        propsToSet[RankKey] = ranks[Random.Range(0, ranks.Length)];
        player.SetCustomProperties(propsToSet);
        propsToSet.Clear();
    }
}
