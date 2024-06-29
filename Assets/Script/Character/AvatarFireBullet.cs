using Photon.Pun;
using UnityEngine;

/// <summary>
/// Avatarが弾を撃つのを制御するクラス
/// </summary>
public class AvatarFireBullet : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private InGameBullet bulletPrefab = default; //弾のプレハブ

    private int nextBulletId = 0; //次の弾のID

    private void Update()
    {
        if (photonView.IsMine)
        {
            // 左クリックでカーソルの方向に弾を発射する
            if (Input.GetMouseButtonDown(0))
            {
                var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                var direction = mousePosition - transform.position;
                float angle = Mathf.Atan2(direction.y, direction.x);

                //弾を発射するたびに弾のIDを1ずつ増やしていく
                photonView.RPC(nameof(FireBullet), RpcTarget.All,nextBulletId++, angle);
            }
        }
    }

    /// <summary>
    /// 弾を発射するメソッド
    /// </summary>
    /// <param name="id"></param>
    /// <param name="angle"></param>
    /// <param name="info"></param>
    [PunRPC]
    private void FireBullet(int id, float angle, PhotonMessageInfo info)
    {
        var bullet = Instantiate(bulletPrefab);
        // PhotonMessageInfoから、RPCを送信した時刻を取得する
        // 弾を発射した時刻に50msのディレイをかける
        int timestamp = info.SentServerTimestamp;
        bullet.Init(id, photonView.OwnerActorNr, transform.position, angle, timestamp);
    }
}