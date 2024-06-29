using Photon.Pun;
using TMPro;

/// <summary>
/// プレイヤーのの頭上に名前とIDを表示する
/// MonoBehaviourPunCallbacksを継承して、photonViewプロパティを使えるようにする
/// </summary>
public class AvatarNameDisplay : MonoBehaviourPunCallbacks
{
    private void Start()
    {
        //自身のTextMeshProを取得する
        var nameLabel = GetComponent<TextMeshPro>();

        //プレイヤー名とプレイヤーIDを表示する
        //NickName = プレイヤー名（変数として代入できるよ）、OwnerActorNr = プレイヤーのID
        // プレイヤー名とプレイヤーIDとプレイヤーのランクを表示する
        var nickName = photonView.Owner.NickName;
        var id = photonView.OwnerActorNr;
        var rank = photonView.Owner.GetRank();
        nameLabel.text = $"{nickName}({id})[{rank}]";
    }
}