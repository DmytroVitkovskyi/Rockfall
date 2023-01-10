using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipSteering : MonoBehaviour
{
    // �������� �������� �������
    public float turnRate = 6.0f;
    
    // ���� ������������ �������
    public float levelDamping = 1.0f;

    // Update is called once per frame
    void Update()
    {
        // ������� ����� �������, ������� ������ ����������� ���������
        // �� turnRate, � ���������� ��������� 90 % �� �������� �����.
        // ������� �������� ���� ������������.
        var steeringInput = InputManager.instance.steering.delta;

        // ��� ��� ��� ������� ����� � ����������
        // print(steeringInput);
        // InputAxis();
        if (steeringInput.x == 0 && steeringInput.y == 0)
        {
            float xAxis = Input.GetAxis("Horizontal");
            float yAxis = Input.GetAxis("Vertical");
            steeringInput = new Vector2(xAxis, yAxis);
        }
        
        // ������ ������� ������ ��� ���������� ��������.
        var rotation = new Vector2();
        rotation.y = steeringInput.x;
        rotation.x = steeringInput.y * -1.0f;

        // �������� �� turnRate, ����� �������� �������� ��������.
        rotation *= turnRate;

        // ������������� � �������, ������� �� 90 % �������� �����
        rotation.x = Mathf.Clamp(rotation.x, -Mathf.PI * 0.9f, Mathf.PI * 0.9f);
        
        // � ������������� ������� � ���������� ��������!
        var newOrientation = Quaternion.Euler(rotation);
        
        // ���������� ������� � ������� �����������
        transform.rotation *= newOrientation;

        // ����� ���������� �������������� �������!
        // ������� ����������, ����� ���� �� ���������� � ���������� �������� ������������ ��� Z
        var levelAngles = transform.eulerAngles;
        levelAngles.z = 0.0f;
        var levelOrientation = Quaternion.Euler(levelAngles);

        // ���������� ������� ���������� � ��������� ���������
        // ���� ���������� "��� ��������"; ����� ��� ����������
        // �� ���������� ���������� ������, ������ ��������
        // ������������� ��� ������������
        transform.rotation = Quaternion.Slerp(transform.rotation, levelOrientation,
            levelDamping * Time.deltaTime);
    }

    void InputAxis()
    {
        // ������ ���������� �� ������ Input
        float xAxis = Input.GetAxis("Horizontal");
        float yAxis = Input.GetAxis("Vertical");
        print($"Input Axis: {xAxis}, {yAxis}");
    }
}