using ExitGames.Client.Photon;
using Photon.Realtime;
using UnityEngine;

public static class PlayerPropertiesExtensions
{
    private const string RankKey = "Rank"; //�����N��Key
    private const string ScoreKey = "Score"; //�X�R�A��Key
    private static readonly Hashtable propsToSet = new Hashtable(); //PlayerPropertiesExtensions�N���X���ŃJ�X�^���v���p�e�B��ݒ肷�邽�߂Ɏg�p
    private static readonly string[] ranks = { "A", "B", "C" }; // �v���C���[�̃����N�̔z��

    /// <summary>
    /// �v���C���[�̃X�R�A���擾����
    /// </summary>
    /// <param name="player">�������g</param>
    /// <returns></returns>
    public static int GetScore(this Player player)
    {
        return (player.CustomProperties[ScoreKey] is int score) ? score : 0;
    }

    /// <summary>
    /// �v���C���[�̃X�R�A�����Z����
    /// </summary>
    /// <param name="player">�������g</param>
    /// <param name="value">���Z�����X�R�A�̒l</param>
    public static void AddScore(this Player player, int value)
    {
        propsToSet[ScoreKey] = player.GetScore() + value;
        player.SetCustomProperties(propsToSet);
        propsToSet.Clear();
    }

    /// <summary>
    /// �v���C���[�̃����N���擾����
    /// </summary>
    /// <param name="player">�������g</param>
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
    /// �v���C���[�̃����N�������_���ɐݒ肷��
    /// </summary>
    /// <param name="player"></param>
    public static void SetRandomRank(this Player player)
    {
        propsToSet[RankKey] = ranks[Random.Range(0, ranks.Length)];
        player.SetCustomProperties(propsToSet);
        propsToSet.Clear();
    }
}
