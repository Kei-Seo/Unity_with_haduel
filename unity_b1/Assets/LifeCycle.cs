using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeCycle : MonoBehaviour
{
    //�ʱ�ȭ ����
    void Awake()
    {
        Debug.Log("�÷��̾� �����Ͱ� �غ�Ǿ����ϴ�.");
    }

    //Ȱ��ȭ ����
    void OnEnable()
    {
        Debug.Log("�÷��̾ �α��� �߽��ϴ�.")
    }
    
    void Start()
    {
        Debug.Log("��� �غ� ���½��ϴ�.");
    }

    void FixedUpdate()
    {
        Debug.Log("�̵�~");
    }

    void Update()
    {
        Debug.Log("�̵�")
    }

    void OnDisable()
    {
        Debug.Log("�÷��̾ �α׾ƿ� �߽��ϴ�.")
    }

    void LateUpdate()
    {
        Debug.Log("����ġ ȹ��")
    }

    void onDestory()
    {
        Debug.Log("�÷��̾� �����͸� ��ü�ϰڽ��ϴ�.")
    }

}
