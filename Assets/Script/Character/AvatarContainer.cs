using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// AvatarContainer: アバターを格納するコンテナ
/// MonoBehaviourを継承しているため、UnityのGameObjectとして使用可能
/// IEnumerable<AvatarContainerChild>を実装しているため、foreachループで子オブジェクトにアクセス可能
/// </summary>
public class AvatarContainer : MonoBehaviour, IEnumerable<AvatarContainerChild>
{
    // アバターのリスト
    private List<AvatarContainerChild> avatarList = new List<AvatarContainerChild>();

    // インデクサーを使用してリストの要素にアクセス可能
    public AvatarContainerChild this[int index] => avatarList[index];

    // リストの要素数を取得するプロパティ
    public int Count => avatarList.Count;
 
    /// <summary>
    /// 子オブジェクトが変更されたときに呼び出されるメソッド
    /// </summary>
    private void OnTransformChildrenChanged()
    {
        // リストをクリアしてから子オブジェクトを取得し、リストに追加
        avatarList.Clear();
        foreach (Transform child in transform)
        {
            avatarList.Add(child.GetComponent<AvatarContainerChild>());
        }
    }

    /// <summary>
    /// IEnumerable<AvatarContainerChild> の実装 
    /// リストの要素に対する列挙子を取得するメソッド </summary>
    /// <returns></returns>
    public IEnumerator<AvatarContainerChild> GetEnumerator()
    {
        return avatarList.GetEnumerator();
    }

    /// <summary>
    /// IEnumerable の実装 
    /// リストの要素に対する列挙子を取得するメソッド</summary>
    /// <returns></returns>
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
