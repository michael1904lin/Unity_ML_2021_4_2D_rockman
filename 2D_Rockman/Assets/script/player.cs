using UnityEngine;

public class player : MonoBehaviour
{
    #region 欄位
    [Header("移動速度"), Range(0, 1000)]
    public float speed = 10.5f;
    [Header("跳躍高度"), Range(0, 3000)]
    public int jump = 100;
    [Range(0, 200)]
    public float hp = 100;
    [Header("是否在地板上"), Tooltip("儲存角色是否在地板上面")]
    public bool isGrounded;
    [Header("移動速度"), Tooltip("角色要發射的子彈物件")]
    public GameObject bullet;
    [Header("移動速度"), Tooltip("生成子彈的位置")]
    public Transform bulletpoint;
    [Range(0, 5000)]
    public int bulletSpeed = 800;
    [Header("開槍音效"), Tooltip("開槍的聲音")]
    public AudioClip bulletSound;

    private AudioSource aud;
    private Rigidbody2D rig;
    private Animator ani;
    #endregion

    #region 事件
    private void Start()
    {
        // 利用程式取得元件
        // 傳回原件 取得元件<元件名稱>() - <泛型>
        // 取得跟此腳本同一層的元件
        rig = GetComponent<Rigidbody2D>();
    }

    // 一秒約執行60次
    private void Update()
    {
        Move();
    }
    #endregion

    #region 方法
    /// <summary>
    ///  移動
    /// </summary>
    private void Move()
    {
        // 1. 要抓到玩家按下左右鍵的資訊 INPUT
        float h = Input.GetAxis("Horizontal");
        print("水平的值:" + h);
        // 2. 使用左右鍵的資訊控制角色移動
        // 剛體.加速度 = 二維向量(水平 * 速度, 一蒸的時間, 指定 回原本的 Y 軸加速度)
        // 一蒸的時間 - 解決不同效能的裝置速度差問題
        rig.velocity = new Vector2(h * speed * Time.deltaTime, rig.velocity.y);
    }
}
#endregion