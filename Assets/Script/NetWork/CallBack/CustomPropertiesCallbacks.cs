using UnityEngine;
using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Realtime;

//Q.カスタムプロパティとは？
//A.プレイヤーオブジェクト（Player）やルームオブジェクト（Room）は、
//  カスタムプロパティ（Custom Properties）で自由な値を設定して同期することができる。

/// <summary>
/// カスタムプロパティが更新されたときのコールバックを受け取れる
/// コールバックの引数で受け取れるHashtableには、更新されたペアのみが追加される。
/// </summary>
public class CustomPropertiesCallbacks : MonoBehaviourPunCallbacks
{
    public override void OnPlayerPropertiesUpdate(Player targetPlayer, Hashtable changedProps)
    {
        // カスタムプロパティが更新されたプレイヤーのプレイヤー名とIDをコンソールに出力する
        Debug.Log($"{targetPlayer.NickName}({targetPlayer.ActorNumber})");

        // 更新されたプレイヤーのカスタムプロパティのペアをコンソールに出力する
        foreach (var prop in changedProps)
        {
            Debug.Log($"{prop.Key}: {prop.Value}");
        }
    }

    public override void OnRoomPropertiesUpdate(Hashtable propertiesThatChanged)
    {
        // 更新されたルームのカスタムプロパティのペアをコンソールに出力する
        foreach (var prop in propertiesThatChanged)
        {
            Debug.Log($"{prop.Key}: {prop.Value}");
        }
    }
}
