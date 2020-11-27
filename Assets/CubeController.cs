using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    //キューブの移動速度
    private float speed = -12;

    //消滅位置
    private float deadLine = -10;
 
    // AudioSource を se として設定
    AudioSource se;

    // Start is called before the first frame update
    void Start()
    {
        // ゲームオブジェクトにアタッチされている AudioSource を se に格納（初期化）
        se = GetComponent<AudioSource> ();
    }

    // Update is called once per frame
    void Update()
    {
        //キューブを移動させる
        transform.Translate (this.speed * Time.deltaTime, 0, 0);

        //画面外に出たら破棄する
        if (transform.position.x < this.deadLine)
        {
            Destroy (gameObject);
        }
    }
    //OnCollisionEnter2D は MonoBehaviour クラスを継承しているので呼び出しは不要
    //Pinballを参考に2D版のOnCollisionEnter2Dを設定
    private void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        // CubeTag(生成されるcubePrefab)同士がぶつかった場合の処理
        if (collisionInfo.transform.tag == "CubeTag")
        {
            //AudioSource には block　がアタッチされていて、ぶつかった場合にPlayする
            se.Play();
        }
        // Cube が地面にぶつかった時も block の音を鳴らす
        if(collisionInfo.transform.tag =="GroundTag")
        {
            se.Play();
        }
    }
}
