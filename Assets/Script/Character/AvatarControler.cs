using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 移動処理系をつっこんでるクラス
/// スタミナのUIもここで管理しちゃってるよぉん
/// </summary>
public class AvatarControler : MonoBehaviourPunCallbacks, IPunObservable
{
    private static readonly float MaxStamina = 6f; //スタミナの上限値
    [SerializeField]
    private Image staminaBar = default;
    private float currentStamina = MaxStamina;

    private void Update()
    {
        //自分の操作キャラの確認
        if (photonView.IsMine)
        {
            StaminaIncreaseDecrease();
        }

        // スタミナをゲージに反映する
        StaminaReflection();
    }

    void IPunObservable.OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            // 自身のアバターのスタミナを送信する
            stream.SendNext(currentStamina);
        }
        else
        {
            // 他プレイヤーのアバターのスタミナを受信する
            currentStamina = (float)stream.ReceiveNext();
        }
    }

    /// <summary>
    /// スタミナの増減
    /// </summary>
    void StaminaIncreaseDecrease()
    {
        var input = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0f);
        if (input.sqrMagnitude > 0f)
        {
            // 入力があったら、スタミナを減少させる
            currentStamina = Mathf.Max(0f, currentStamina - Time.deltaTime);
            transform.Translate(6f * Time.deltaTime * input.normalized);
        }
        else
        {
            // 入力がなかったら、スタミナを回復させる
            currentStamina = Mathf.Min(currentStamina + Time.deltaTime * 2, MaxStamina);
        }
    }

    /// <summary>
    /// スタミナの反映
    /// </summary>
    void StaminaReflection()
    {
        staminaBar.fillAmount = currentStamina / MaxStamina;
    }
}
