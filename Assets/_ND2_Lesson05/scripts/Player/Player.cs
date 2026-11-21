
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// プレイヤー
/// -----------------------------------------------------------
/// ・操作方法
/// 　　-WASD：上下左右に移動
/// 　　-マウス：向きを変える（マウスの方向を見る）
/// 　　-左クリック：ショット
///
/// ・敵との接触で「死ぬ」
/// </summary>
public class Player : MonoBehaviour
{
    [Header("* * * 移動速度 * * *")]
    [SerializeField] private float _moveSpeed = 5.0f; //移動速度

    private Vector3 _moveVector = new Vector3(0, 0, 0);

    [Header("* * * 振り向き設定 * * *")]
    [SerializeField] private Transform _lookTarget; //向くターゲット

    [Header("* * * ショット設定 * * *")]
    [SerializeField] private GameObject _bulletprefab;
    [SerializeField] private Transform _shotPoint;
    [SerializeField] private float _shotpower;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Movement(); //移動の実行

        LookAt();

        Shot();

    }

    public void Movement()
    {
        _moveVector = new Vector3(0, 0, 0);

        if (Keyboard.current.wKey.IsPressed())
        {
            _moveVector = new Vector3(0, 0, 1);
        }

        if (Keyboard.current.aKey.IsPressed())
        {
            _moveVector = new Vector3(-1, 0, 0);
        }

        if (Keyboard.current.sKey.IsPressed())
        {
            _moveVector = new Vector3(0, 0, -1);
        }

        if (Keyboard.current.dKey.IsPressed())
        {
            _moveVector = new Vector3(1, 0, 0);
        }

        //移動
        transform.Translate(_moveVector * _moveSpeed * Time.deltaTime, Space.World);

        //移動ベクトルの可視化
        Debug.DrawRay(transform.position, _moveVector, Color.green, 0, false);
    }

    /// <summary>
    /// 方向を向くメソッド
    /// </summary>
    public void LookAt()
    {
        //振り向く
        transform.LookAt(_lookTarget, Vector3.up);

        //向きベクトルの可視化
        Debug.DrawRay(transform.position, transform.forward, Color.blue, 0, false);
    }

    /// <summary>
    /// 攻撃メソッド
    /// </summary>
    public void Shot()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {

            GameObject bullet = Instantiate(_bulletprefab, _shotPoint.position, _shotPoint.rotation);

            Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
            bulletRb.AddForce(_shotPoint.forward * _shotpower, ForceMode.Impulse);

            Destroy(bullet, 5.0f);
        }
    }
}
