using UnityEngine;
using Photon.Pun;

/// <summary>
/// 弾がアバターに当たる当たり判定を実装するクラス
/// </summary>
public class AvatarHitBullet : MonoBehaviourPunCallbacks
{
    /// <summary>
    /// 他コライダーに衝突した際に実行される処理
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter2D(Collider2D other)
    {
        //自身じゃない場合処理をせずに返す
        if (photonView.IsMine)
        {
            //InGameBulletコンポーネントを持つかをチェック
            if (other.TryGetComponent<InGameBullet>(out var bullet))
            {
                //その弾の所有者が自分自身でない場合にのみRPCを呼び出す。
                if (bullet.OwnerId != PhotonNetwork.LocalPlayer.ActorNumber)
                {
                    photonView.RPC(nameof(HitBullet), RpcTarget.All, bullet.Id, bullet.OwnerId);
                }
            }
        }
    }

    /// <summary>
    /// ほかのプレイヤーの弾が自分のキャラに当たったことを通知するメソッド
    /// </summary>
    /// <param name="id"></param>
    /// <param name="ownerId"></param>
    [PunRPC]
    private void HitBullet(int id, int ownerId)
    {
        //InGameBulletコンポーネントを持つすべての弾をFindObjectsOfTypeで検索
        var bullets = FindObjectsOfType<InGameBullet>();

        //与えられたIDと所有者IDが一致する弾を見つけて破壊
        foreach (var bullet in bullets)
        {
            if (bullet.Equals(id, ownerId))
            {
                // 自身が発射した弾が当たった場合には、自身のスコアを増やす
                if (ownerId == PhotonNetwork.LocalPlayer.ActorNumber)
                {
                    PhotonNetwork.LocalPlayer.AddScore(10);
                }
                Destroy(bullet.gameObject);
                break;
            }
        }
    }
}
