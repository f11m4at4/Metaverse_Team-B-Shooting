using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

// 사용자 입력에 따라 상하좌우로 이동하고 싶다.
// 필요속성 : 이동속도
public class PlayerMove : MonoBehaviour
{
    // 필요속성 : 이동속도
    public float speed = 5;

    float width;
    // Start is called before the first frame update
    void Start()
    {
        // 1 p -> ? m
        float height = Camera.main.orthographicSize * 2;
        float meterPerPixel = height / Screen.height;
        width = Screen.width * meterPerPixel * 0.5f - 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        // 게임상태가 Playing 일때만 실행되도록
        if(GameManager.Instance.m_State != GameManager.GameState.Playing)
        {
            return;
        }

        // 사용자 입력에 따라 상하좌우로 이동하고 싶다.
        // 1. 사용자의 입력에 따라
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        // 2. 방향이 필요
        Vector3 dir = Vector3.right * h + Vector3.up * v;
        dir.Normalize();
        // 3. 이동하고 싶다.
        // P = P0 + vt
        Vector3 myPos = transform.position;
        myPos += dir * speed * Time.deltaTime;

        // 플레이어의 x 위치가 -4.3 보다 작을 때, +4.3 보다 클때 화면을 벗어나지 않도록
        // 하고 싶다.
        myPos.x = Mathf.Clamp(myPos.x, -width, width);
        transform.position = myPos;
    }
}
