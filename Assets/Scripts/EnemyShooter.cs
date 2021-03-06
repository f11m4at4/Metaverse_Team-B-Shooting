using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 아래로 계속 이동하고 싶다.
// 필요속성 : 이동속도
// 타겟를 따라다니기
// 필요속성 : 타겟

// 죽을 때 폭발효과 발생시키고 싶다.
// 필요속성 : 폭발효과 공장
public class EnemyShooter : MonoBehaviour
{
    // 필요속성 : 이동속도
    public float speed = 5;
    // 필요속성 : 타겟
    public Transform target;
    Vector3 dir;
    // 필요속성 : 폭발효과 공장
    GameObject explosionFactory;
    // Start is called before the first frame update
    void Start()
    {
        // 동적으로 폭발효과를 로딩하고 싶다.
        explosionFactory = (GameObject)Resources.Load("Prefabs/Explosion");

        // 방향 설정하기
        SetDirection();

        // 총알 쏘기
        ShootBullet();
    }

    void SetDirection()
    {
        GameObject player = GameObject.Find("Player");
        // 만약 타겟이 있다면
        //if(player != null)
        if (player)
        {
            target = player.transform;
            //70 % 확률로 아래로 방향을 잡고
            // 1. 확률을 구해야 한다.
            int randomic = Random.Range(0, 10);

            // 타겟 방향으로 설정하기
            // 2. 확률이 70% 에 속했으니까
            if (randomic < 7)
            {
                // 3. 방향을 아래로 설정하고 싶다.
                dir = Vector3.down;
            }
            //그렇지않으면 
            else
            {
                //타겟쪽으로
                dir = target.position - transform.position;
                dir.Normalize();
            }

        }
        // 그렇지 않다면
        else
        {
            // 그냥 방향을 아래로
            dir = Vector3.down;
        }
    }

    // 타겟쪽으로 총알을 발사하고 싶다.
    // 필요속성 : 총알공장
    public GameObject bulletFactory;

    void ShootBullet()
    {
        if (GameManager.Instance.m_State != GameManager.GameState.Playing)
        {
            return;
        }
        // 만약 타겟이 없으면 총알 안쏜다.
        if (target == null)
        {
            return;
        }

        // 타겟쪽으로 총알을 발사하고 싶다.
        GameObject bullet = Instantiate(bulletFactory);
        Vector3 dir = target.position - transform.position;
        // 총알을 타겟 방향으로 회전시켜주기
        bullet.transform.up = dir;
        // 총알이 생성될 위치 지정
        bullet.transform.position = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.m_State != GameManager.GameState.Playing)
        {
            return;
        }
        // 타겟를 따라다니기
        // P = P0 + vt
        // 1. 방향이필요
        // direction = target - me
        // 2. 이동하고싶다.
        transform.position += dir * speed * Time.deltaTime;
    }

    // 다른 물체와 부딪혔을 때 갸도 죽고 나도 죽고... 
    private void OnCollisionEnter(Collision collision)
    {
        EnemyBullet.CollisionEnemy(explosionFactory, transform, collision, gameObject);

        // 점수 올리기
        ScoreManager.Instance.CurScore++;
    }
}
