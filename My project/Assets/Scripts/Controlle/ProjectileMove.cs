using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMove : MonoBehaviour
{
    public Vector3 launchDirection;
    //발사체 방향성 선언

    private void FixedUpdate()
    {
        float moveAmount = 3 * Time.fixedDeltaTime;
        //발사체 이동 속도
        transform.Translate(launchDirection * moveAmount);
        //해당 방향으로 이동

    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);

        if (collision.gameObject.name != "Player")
        {
            GameObject temp = this.gameObject;
            Destroy(temp);
            //총알이 충돌하면 제거

            if (collision.gameObject.name == "Monster")
            {
                collision.gameObject.GetComponent<MonsterController>().Monster_Damaged(1);
            }
        }
    }

}
