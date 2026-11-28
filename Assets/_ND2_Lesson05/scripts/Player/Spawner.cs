using UnityEngine;

/// <summary>
/// スポナークラス
/// --------------------------------------
/// 指定したオブジェクトを、
/// 一定間隔でランダムな位置に出現させる。
/// </summary>
public class Spawner : MonoBehaviour
{
    [Header("出現設定")]
    [SerializeField] private GameObject _prefab;
    [SerializeField] private float _spawnInterval = 2.0f;

    [Header("出現範囲")]
    [SerializeField] private float _rangeX = 5.0f;
    [SerializeField] private float _rangeZ = 5.0f;

    private float _timer = 0.0f;

    void Start()
    {

    }

    void Update()
    {
        // 経過時間を加算
        _timer += Time.deltaTime;

        // 指定した時間が経過したら生成
        if (_timer >= _spawnInterval)
        {
            Spawn();
            _timer = 0.0f;
        }
    }

    /// <summary>
    /// オブジェクトを生成する
    /// </summary>
    private void Spawn()
    {
        float x = Random.Range(-_rangeX, _rangeX);
        float z = Random.Range(-_rangeZ, _rangeZ);

        Vector3 spawnPosition = transform.position + new Vector3(x, 0, z);

        Instantiate(_prefab, spawnPosition, Quaternion.identity);
    }
}