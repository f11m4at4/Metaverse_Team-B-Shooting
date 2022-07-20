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

    public JoyStick JS;

    void Start()
    {
        // 1 p -> ? m
        float height = Camera.main.orthographicSize * 2;
        float meterPerPixel = height / Screen.height;
        width = Screen.width * meterPerPixel * 0.5f - 0.5f;
    }

    //초기 위치
    Vector2 startPoint;
    Vector2 movePoint;
    Vector3 moveDir;

    public GameObject startPoint_UI;
    public GameObject movePoint_UI;

    // Update is called once per frame
    void Update()
    {
        // 게임상태가 Playing 일때만 실행되도록
        if(GameManager.Instance.m_State != GameManager.GameState.Playing)
        {
            return;
        }


        // 플레이어를 움직이게
        // 방향
        // 움직이는 마우스 포인트 - 시작점 방향

        // 클릭을 했을 때
        if (Input.GetButtonDown("Fire1"))
        {
            // 시작점이 발생(조이스틱의 시작점)
            startPoint = Input.mousePosition;

            // 시작점 UI가 나오게
            startPoint_UI.SetActive(true);
            startPoint_UI.transform.position = startPoint;

            // 움직이는 점 UI가 나오게
            movePoint_UI.SetActive(true);
            movePoint_UI.transform.position = startPoint;
        }

        //클릭을 하고있는 동안
        if (Input.GetButton("Fire1"))
        { 

            movePoint = Input.mousePosition;

            //UI 가 마우스를 따라다니게
            movePoint_UI.transform.position = movePoint;
            // 방향
            moveDir = movePoint - startPoint;
            moveDir.Normalize();

            //만약에 시작점과 움직이는 점의 거리가 30이 넘으면, 
            if (Vector3.Magnitude(movePoint - startPoint) >= 30)
            {
                //거리를 30으로 제한
                movePoint_UI.transform.position = startPoint_UI.transform.position + moveDir * 30f;

            }    

        }




        transform.position += moveDir * 5f * Time.deltaTime;








        // 사용자 입력에 따라 상하좌우로 이동하고 싶다.
        // 1. 사용자의 입력에 따라
        /*float h = HOJoystick.GetAxis("Horizontal");
        float v = HOJoystick.GetAxis("Vertical");*/
        // 2. 방향이 필요
        /*Vector3 dir = Vector3.right * h + Vector3.up * v;
        dir.Normalize();*/
        // 3. 이동하고 싶다.
        // P = P0 + vt
        //Vector3 myPos = transform.position;
        //myPos += dir * speed * Time.deltaTime;

        // 플레이어의 x 위치가 -4.3 보다 작을 때, +4.3 보다 클때 화면을 벗어나지 않도록
        // 하고 싶다.
        //myPos.x = Mathf.Clamp(myPos.x, -width, width);
        //transform.position = myPos;
    }
}
