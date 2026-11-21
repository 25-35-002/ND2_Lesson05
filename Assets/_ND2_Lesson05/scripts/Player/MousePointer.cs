using UnityEngine;
using UnityEngine.InputSystem;


/// <summary>
/// マウスポインター
/// ----------------------------------------------
/// ｜・マウスの座標に合わせて動く　　　　　　　｜
/// ----------------------------------------------
/// </summary>

public class MousePointer : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();    //移動の実行
    }

    public void Movement()
    {
        //マウスの座標を取得
        Vector2 mousePosition = Mouse.current.position.value;

        //スクリーンの座標系を作る
        Vector3 screenPosition = mousePosition;
        screenPosition.z = 10;

        //マウスの座標をワールド座標に変換する
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);

        //オブジェクトの座標をマウスと合わせる
        transform.position = worldPosition;
    }
}
