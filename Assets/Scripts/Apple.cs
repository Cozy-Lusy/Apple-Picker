using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    public static float bottomY = -20f;
    
    void Update()
    {
        if (transform.position.y < bottomY)
        {
            Destroy(this.gameObject);

            //Получить ссылку на компонент ApplePicker главной камеры MainCamera
            ApplePicker apScript = Camera.main.GetComponent<ApplePicker>();
            //Вызвать общедоступный метод AppleDstroye из apScript
            apScript.AppleDestroyed();
        }
    }
}
