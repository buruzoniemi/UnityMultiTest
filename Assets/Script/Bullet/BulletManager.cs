using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class BulletManager : MonoBehaviourPunCallbacks
{
    //�e��ID���L�[�Ƃ��Ēe���Ǘ�
    private Dictionary<int, InGameBullet> bulletsById = new Dictionary<int, InGameBullet>();

    /// <summary>
    /// �e��ǉ����郁�\�b�h
    /// </summary>
    /// <param name="id">�e�����ʂ���ID</param>
    /// <param name="bullet">�e���g</param>
    public void AddBullet(int id, InGameBullet bullet)
    {
        if (!bulletsById.ContainsKey(id))
        {
            bulletsById.Add(id, bullet);
        }
    }

    /// <summary>
    /// �e���폜���郁�\�b�h
    /// </summary>
    /// <param name="id">�e�����ʂ���ID</param>
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
    /// �e���������郁�\�b�h
    /// </summary>
    /// <param name="id">�e�����ʂ���ID</param>
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
