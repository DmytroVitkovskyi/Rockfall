using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipTarget : MonoBehaviour
{
    // ������ ��� ������������� � �������� ���������� �����.
    public Sprite targetImage;

    // Start is called before the first frame update
    void Start()
    {
        // ���������������� ����� ���������, ���������������
        // ������� �������, ������������ ������ ���� � ������������� ������.
        var ind = IndicatorManager.instance.AddIndicator(gameObject, Color.yellow, targetImage);
        
        // ��������� ������ �������������
        //Vector3 scale = new Vector3(0.2f, 0.2f, 0.2f);
        //ind.transform.localScale = scale;
    }
}
