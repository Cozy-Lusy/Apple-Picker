using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    [Header("Set in Inspector")]
    [SerializeField] private GameObject applePrefab = null; //Шаблон для создания яблок
    [SerializeField] private float speed = 1f; //Скорость движения яблони
    [SerializeField] private float leftAndRightEdge = 10f; //Расстояние, на котором должно изменяться направление движения яблони
    [SerializeField] private float chanceToChangeDerections = 0.1f; //Вероятность случайного изменения направления движения
    [SerializeField] private float secondsBetweenAppleDrops = 1f; //Частота создания экземпляров яблок

    private void Start()
    {
        //Сбрасывать яблоки раз в секунду
        Invoke("DropApple", 2f);
    }

    private void DropApple()
    {
        GameObject apple = Instantiate<GameObject>(applePrefab);
        apple.transform.position = transform.position;
        Invoke("DropApple", secondsBetweenAppleDrops);
    }

    private void Update()
    {
        //Простое перемещение
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;

        //Изменение направления
        if (pos.x < -leftAndRightEdge)
        {
            speed = Mathf.Abs(speed); //Начать движение вправо
        }
        else if (pos.x > leftAndRightEdge)
        {
            speed = -Mathf.Abs(speed); //Начать движение вправо
        }
    }

    private void FixedUpdate()
    {
        //Случайная смена привязана ко времени ибо выполняется в FixedUpdate()
        if (Random.value < chanceToChangeDerections)
        {
            speed *= -1; //Изменение направления
        }
    }
}
