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
        // ���ӻ��°� Playing �϶��� ����ǵ���
        if(GameManager.Instance.m_State != GameManager.GameState.Playing)
        {
            return;
        }

        // ����� �Է¿� ���� �����¿�� �̵��ϰ� �ʹ�.
        // 1. ������� �Է¿� ����
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        // 2. ������ �ʿ�
        Vector3 dir = Vector3.right * h + Vector3.up * v;
        dir.Normalize();
        // 3. �̵��ϰ� �ʹ�.
        // P = P0 + vt
        Vector3 myPos = transform.position;
        myPos += dir * speed * Time.deltaTime;

        // �÷��̾��� x ��ġ�� -4.3 ���� ���� ��, +4.3 ���� Ŭ�� ȭ���� ����� �ʵ���
        // �ϰ� �ʹ�.
        myPos.x = Mathf.Clamp(myPos.x, -width, width);
        transform.position = myPos;
    }
}
