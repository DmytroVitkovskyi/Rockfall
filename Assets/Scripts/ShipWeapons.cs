using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipWeapons : MonoBehaviour
{
    // ������ ��� �������� ��������
    public GameObject shotPrefab;
    
    // ������ ����� ��� ��������
    public Transform[] firePoints;
    
    // ������ � firePoints, ����������� �� ��������� �����
    private int firePointIndex;
    
    // ���������� ����������� ����� InputManager.
    public void Fire()
    {
        // ���� ����� �����������, �����
        if (firePoints.Length == 0)
            return;
        
        // ���������� ��������� ����� ��� ��������
        var firePointToUse = firePoints[firePointIndex];
        
        // ������� ����� ������ � �����������, ��������������� �����
        Instantiate(shotPrefab, firePointToUse.position, firePointToUse.rotation);

        // ���� ����� ����� ��������� ��������� �����,
        // ������������� �������� ������
        var audio = firePointToUse.GetComponent<AudioSource>();
        if (audio)
        {
            audio.Play();
        }

        // ������� � ��������� �����
        firePointIndex++;
        
        // ���� ��������� ����� �� ������� �������, ��������� � ��� ������
        if (firePointIndex >= firePoints.Length)
            firePointIndex = 0;
    }

    private void Awake()
    {
        // ����� ������ ������ �����������, �������� ���������� �����, ����� ������������ ���
        // ��� ������� �������� ���������� �������
        InputManager.instance.SetWeapons(this);
    }

    // ���������� ��� �������� �������
    private void OnDestroy()
    {
        // ������ �� ������, ���� ���������� �� � ������ ����
        if (Application.isPlaying == true)
        {
            InputManager.instance.RemoveWeapons(this);
        }
    }
    
    // �������� �� ������� ������� ��� �������
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            InputManager.instance.StartFiring();
        }
        else
        {
            InputManager.instance.StopFiring();
        }
    }
}
