using Photon.Pun;
using Photon.Realtime;

/// <summary>
/// AvatarContainerChild: アバターコンテナの子オブジェクトを表すクラス
/// MonoBehaviourPunCallbacksを継承しているため、PUN2のコールバックを使用可能
/// </summary>
public class AvatarContainerChild : MonoBehaviourPunCallbacks
{
    public Player Owner => photonView.Owner; // 所有者のプレイヤーを取得するプロパティ

    /// <summary>
    /// オブジェクトが有効になったときに呼び出されるメソッド
    /// </summary>
    public override void OnEnable()
    {
        base.OnEnable();

        // AvatarContainerを探して、見つかった場合はこのオブジェクトをその子に設定する
        var container = FindObjectOfType<AvatarContainer>();
        if (container != null)
        {
            transform.SetParent(container.transform);
        }
    }
}
