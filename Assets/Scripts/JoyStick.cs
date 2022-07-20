using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoyStick : MonoBehaviour
{
    // �����̴� �� ���� ����
    public Vector3 dir;

    // ���̽�ƽ ��� �̹���
    public RectTransform joyStickBG;
    // ���̽�ƽ ��ƽ
    public RectTransform stick;

    // ó�� ���콺�� ���� ��ġ
    Vector3 basePos;
    // �巡�� �� ���� ��ġ
    Vector3 currentPos;

    void Start()
    {
        // ���̽�ƽ�� ���̰� �����Ѵ�.
        joyStickBG.gameObject.SetActive(false);
        stick.gameObject.SetActive(false);
    }

    // ó�� ���콺�� ������ ��
    public void OnStickDown()
    {
        // �� ��ġ�� ���������� ���
        basePos = Input.mousePosition;

        // ���̽�ƽ�� �� ��ġ�� �����Ѵ�.
        joyStickBG.anchoredPosition = basePos;
        stick.anchoredPosition = basePos;

        // ���̽�ƽ�� ���̰� �����Ѵ�.
        joyStickBG.gameObject.SetActive(true);
        stick.gameObject.SetActive(true);

        // ������ �ʱ�ȭ�Ѵ�.
        dir = Vector3.zero;
    }

    // �巡���ϸ�
    public void OnStickDrag()
    {
        // ���� ��ġ�� �����ϰ�
        currentPos = Input.mousePosition;

        // ���������κ����� �Ÿ��� 80���� �����Ѵ�.
        Vector3 v = Vector3.ClampMagnitude(currentPos - basePos, 80f);

        // ��ƽ�� ��ġ�� ���������� v �� ���� ��ġ�� �����Ѵ�.
        stick.anchoredPosition = basePos + v;
        
        // ������ �����Ѵ�.
        dir = v.normalized;
    }

    public void OnStickUp()
    {
        // ���̽�ƽ�� ������ �ʰ� �����Ѵ�.
        joyStickBG.gameObject.SetActive(false);
        stick.gameObject.SetActive(false);

        // ������ �ʱ�ȭ�Ѵ�.
        dir = Vector3.zero;
    }
}
