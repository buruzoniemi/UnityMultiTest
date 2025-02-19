using Photon.Pun;
using UnityEngine;

/// <summary>
/// 弾のクラス
/// </summary>
public class InGameBullet : MonoBehaviour
{
    private Vector3 origin; // 弾を発射した時刻の座標
    private Vector3 velocity; //加速度
    private int timestamp; // 弾を発射した時刻

    public int Id { get; private set;} //弾のIDを返すプロパティ
    public int OwnerId { get; private set; } //弾を発射したプレイヤーのIDを返すプロパティ

    /// <summary>
    /// 同じ弾かどうかをIDで判定するメソッド
    /// </summary>
    /// <param name="id"></param>
    /// <param name="ownerId"></param>
    /// <returns></returns>
    public bool Equals(int id, int ownerId) => id == Id && ownerId == OwnerId;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="origin"></param>
    /// <param name="angle"></param>
    public void Init(int id, int ownerId, Vector3 origin, float angle, int timestamp)
    {
        Id = id;
        OwnerId = ownerId;
        this.origin = origin;
        velocity = 9f * new Vector3(Mathf.Cos(angle), Mathf.Sin(angle));
        this.timestamp = timestamp;

        // 一度だけ直接Update()を呼んで、transform.positionの初期値を決める
        Update();
    }

    private void Update()
    {
        // 弾を発射した時刻から現在時刻までの経過時間を求める
        float elapsedTime = Mathf.Max(0f, unchecked(PhotonNetwork.ServerTimestamp - timestamp) / 1000f);
        // 弾を発射した時刻での座標・速度・経過時間から現在の座標を求める
        transform.position = origin + velocity * elapsedTime;
    }

    /// <summary>
    /// 画面外に移動したら削除する
    ///（Unityのエディター上ではシーンビューの画面も影響するので注意）
    /// </summary>
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}