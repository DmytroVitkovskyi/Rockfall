using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipSteering : MonoBehaviour
{
    // Скорость поворота корабля
    public float turnRate = 6.0f;
    
    // Сила выравнивания корабля
    public float levelDamping = 1.0f;

    // Update is called once per frame
    void Update()
    {
        // Создать новый поворот, умножив вектор направления джойстика
        // на turnRate, и ограничить величиной 90 % от половины круга.
        // Сначала получить ввод пользователя.
        var steeringInput = InputManager.instance.steering.delta;

        // мой код для отладки ввода с клавиатуры
        // print(steeringInput);
        // InputAxis();
        if (steeringInput.x == 0 && steeringInput.y == 0)
        {
            float xAxis = Input.GetAxis("Horizontal");
            float yAxis = Input.GetAxis("Vertical");
            steeringInput = new Vector2(xAxis, yAxis);
        }
        
        // Теперь создать вектор для вычисления поворота.
        var rotation = new Vector2();
        rotation.y = steeringInput.x;
        rotation.x = steeringInput.y * -1.0f;

        // Умножить на turnRate, чтобы получить величину поворота.
        rotation *= turnRate;

        // Преобразовать в радианы, умножив на 90 % половины круга
        rotation.x = Mathf.Clamp(rotation.x, -Mathf.PI * 0.9f, Mathf.PI * 0.9f);
        
        // И преобразовать радианы в кватернион поворота!
        var newOrientation = Quaternion.Euler(rotation);
        
        // Объединить поворот с текущей ориентацией
        transform.rotation *= newOrientation;

        // Далее попытаться минимизировать поворот!
        // Сначала определить, какой была бы ориентация в отсутствие вращения относительно оси Z
        var levelAngles = transform.eulerAngles;
        levelAngles.z = 0.0f;
        var levelOrientation = Quaternion.Euler(levelAngles);

        // Объединить текущую ориентацию с небольшой величиной
        // этой ориентации "без вращения"; когда это происходит
        // на протяжении нескольких кадров, объект медленно
        // выравнивается над поверхностью
        transform.rotation = Quaternion.Slerp(transform.rotation, levelOrientation,
            levelDamping * Time.deltaTime);
    }

    void InputAxis()
    {
        // Извлеч информацию из класса Input
        float xAxis = Input.GetAxis("Horizontal");
        float yAxis = Input.GetAxis("Vertical");
        print($"Input Axis: {xAxis}, {yAxis}");
    }
}
