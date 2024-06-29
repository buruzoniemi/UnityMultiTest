using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class BulletManager : MonoBehaviourPunCallbacks
{
    //弾のIDをキーとして弾を管理
    private Dictionary<int, InGameBullet> bulletsById = new Dictionary<int, InGameBullet>();

    /// <summary>
    /// 弾を追加するメソッド
    /// </summary>
    /// <param name="id">弾を識別するID</param>
    /// <param name="bullet">弾自身</param>
    public void AddBullet(int id, InGameBullet bullet)
    {
        if (!bulletsById.ContainsKey(id))
        {
            bulletsById.Add(id, bullet);
        }
    }

    /// <summary>
    /// 弾を削除するメソッド
    /// </summary>
    /// <param name="id">弾を識別するID</param>
    public void RemoveBullet(int id)
    {
        if (bulletsById.ContainsKey(id))
        {
            var bullet = bulletsById[id];
            if (bullet != null)
            {
                Destroy(bullet.gameObject);
            }
            bulletsById.Remove(id);
        }
    }

    /// <summary>
    /// 弾を検索するメソッド
    /// </summary>
    /// <param name="id">弾を識別するID</param>
    /// <returns></returns>
    public InGameBullet FindBullet(int id)
    {
        if (bulletsById.ContainsKey(id))
        {
            return bulletsById[id];
        }
        return null;
    }
}
