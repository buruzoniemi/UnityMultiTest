using Photon.Pun;
using UnityEngine;

/// <summary>
/// 値をできるだけ一つのHashtableにまとめてからSetCustomProperties()を呼ぶクラス
/// </summary>
public class SendPlayerProperties : MonoBehaviour
{
    private void LateUpdate()
    {
        //PhotonNetwork.LocalPlayer.SendPlayerProperties();
    }
}
