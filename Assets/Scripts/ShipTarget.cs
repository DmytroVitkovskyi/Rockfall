using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipTarget : MonoBehaviour
{
    // Спрайт для использования в качестве прицельной сетки.
    public Sprite targetImage;

    // Start is called before the first frame update
    void Start()
    {
        // Зарегистрировать новый индикатор, соответствующий
        // данному объекту, использовать желтый цвет и нестандартный спрайт.
        var ind = IndicatorManager.instance.AddIndicator(gameObject, Color.yellow, targetImage);
        
        // Уменьшить размер целеуказателя
        //Vector3 scale = new Vector3(0.2f, 0.2f, 0.2f);
        //ind.transform.localScale = scale;
    }
}
