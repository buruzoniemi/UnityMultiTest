using ExitGames.Client.Photon;
using Photon.Realtime;

/// <summary>
/// �v���C���[�̃J�X�^���v���p�e�B�Ɋւ���g�����\�b�h���
/// </summary>
public static class TestPlayerPropertiesExtensions
{
    private const string ScoreKey = "Score"; //�v���C���[�̃X�R�A��\���L�[
    private const string MessageKey = "Message"; //�v���C���[�̃��b�Z�[�W��\���L�[

    private static readonly Hashtable propsToSet = new Hashtable(); //�ݒ肷��v���p�e�B��ێ����邽�߂̃n�b�V���e�[�u

    /// <summary>
    /// �v���C���[�̃X�R�A���擾����
    /// </summary>
    /// <param name="player">�v���C���[�̃C���X�^���X</param>
    /// <returns></returns>
    public static int TestGetScore(this Player player)
    {
        return (player.CustomProperties[ScoreKey] is int score) ? score : 0;
    }

    /// <summary>
    /// �v���C���[�̃��b�Z�[�W���擾����
    /// </summary>
    /// <param name="player">�v���C���[�̃C���X�^���X</param>
    /// <returns></returns>
    public static string TestGetMessage(this Player player)
    {
        return (player.CustomProperties[MessageKey] is string message) ? message : string.Empty;
    }

    /// <summary>
    /// �v���C���[�̃X�R�A��ݒ肷��
    /// </summary>
    /// <param name="player">�v���C���[�̃C���X�^���X</param>
    /// <param name="score">�ݒ肷��X�R�A</param>
    public static void TestSetScore(this Player player, int score)
    {
        propsToSet[ScoreKey] = score;
        player.SetCustomProperties(propsToSet);
        propsToSet.Clear();
    }

    /// <summary>
    /// �v���C���[�̃��b�Z�[�W��ݒ肷��
    /// </summary>
    /// <param name="player">�v���C���[�̃C���X�^���X</param>
    /// <param name="message">�ݒ肷�郁�b�Z�[�W</param>
    public static void TestSetMessage(this Player player, string message)
    {
        propsToSet[MessageKey] = message;
        player.SetCustomProperties(propsToSet);
        propsToSet.Clear();
    }
}
