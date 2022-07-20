using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

// ����� �Է¿� ���� �����¿�� �̵��ϰ� �ʹ�.
// �ʿ�Ӽ� : �̵��ӵ�
public class PlayerMove : MonoBehaviour
{
    // �ʿ�Ӽ� : �̵��ӵ�
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

    //�ʱ� ��ġ
    Vector2 startPoint;
    Vector2 movePoint;
    Vector3 moveDir;

    public GameObject startPoint_UI;
    public GameObject movePoint_UI;

    // Update is called once per frame
    void Update()
    {
        // ���ӻ��°� Playing �϶��� ����ǵ���
        if(GameManager.Instance.m_State != GameManager.GameState.Playing)
        {
            return;
        }


        // �÷��̾ �����̰�
        // ����
        // �����̴� ���콺 ����Ʈ - ������ ����

        // Ŭ���� ���� ��
        if (Input.GetButtonDown("Fire1"))
        {
            // �������� �߻�(���̽�ƽ�� ������)
            startPoint = Input.mousePosition;

            // ������ UI�� ������
            startPoint_UI.SetActive(true);
            startPoint_UI.transform.position = startPoint;

            // �����̴� �� UI�� ������
            movePoint_UI.SetActive(true);
            movePoint_UI.transform.position = startPoint;
        }

        //Ŭ���� �ϰ��ִ� ����
        if (Input.GetButton("Fire1"))
        { 

            movePoint = Input.mousePosition;

            //UI �� ���콺�� ����ٴϰ�
            movePoint_UI.transform.position = movePoint;
            // ����
            moveDir = movePoint - startPoint;
            moveDir.Normalize();

            //���࿡ �������� �����̴� ���� �Ÿ��� 30�� ������, 
            if (Vector3.Magnitude(movePoint - startPoint) >= 30)
            {
                //�Ÿ��� 30���� ����
                movePoint_UI.transform.position = startPoint_UI.transform.position + moveDir * 30f;

            }    

        }




        transform.position += moveDir * 5f * Time.deltaTime;








        // ����� �Է¿� ���� �����¿�� �̵��ϰ� �ʹ�.
        // 1. ������� �Է¿� ����
        /*float h = HOJoystick.GetAxis("Horizontal");
        float v = HOJoystick.GetAxis("Vertical");*/
        // 2. ������ �ʿ�
        /*Vector3 dir = Vector3.right * h + Vector3.up * v;
        dir.Normalize();*/
        // 3. �̵��ϰ� �ʹ�.
        // P = P0 + vt
        //Vector3 myPos = transform.position;
        //myPos += dir * speed * Time.deltaTime;

        // �÷��̾��� x ��ġ�� -4.3 ���� ���� ��, +4.3 ���� Ŭ�� ȭ���� ����� �ʵ���
        // �ϰ� �ʹ�.
        //myPos.x = Mathf.Clamp(myPos.x, -width, width);
        //transform.position = myPos;
    }
}
