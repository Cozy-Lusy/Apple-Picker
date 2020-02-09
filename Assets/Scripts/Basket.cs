using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Basket : MonoBehaviour
{
    [Header("Set Dynamically")]
    public Text scoreGT;

    private void Start()
    {
        GameObject scoreGO = GameObject.Find("ScoreCounter");   //Получить ссылку на игровой объект ScoreCounter
        
        scoreGT = scoreGO.GetComponent<Text>();                 //Получить компонент Text этого игрового объекта
        scoreGT.text = "0";                                     //Установить начальное число очков равным 0
    }

    void Update()
    {
        Vector3 mousePos2D = Input.mousePosition;               //Получить текущие координаты указателя мыши на экране из Input
        mousePos2D.z = -Camera.main.transform.position.z;       //Координата Z камеры определяет, как далеко в трехмерном пространстве находится курсор мыши        
        
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D); //Показать точку на двумерной плоскости экрана в трехмерные координаты игры

        Vector3 pos = this.transform.position;                  //Переместить корзину вдоль оси Х в координату Х указателя мыши
        pos.x = mousePos3D.x;
        this.transform.position = pos;
    }

    private void OnCollisionEnter(Collision coll)
    {
        //Отыскать яблоко, попавшее в корзину
        GameObject collidedWith = coll.gameObject;
        if (collidedWith.tag == "Apple")
        {
            Destroy(collidedWith);
            
            int score = int.Parse(scoreGT.text);                //Преобразовать текст ScoreGT в целое число
            score += 100;                                       //Добавить очки за пойманное яблоко
            scoreGT.text = score.ToString();                    //Преобразовать число очков обратно в строку и вывести ее на экран

            //Запомнить высшее достижение
            if (score > HighScore.score)
            {
                HighScore.score = score;
            }
        }
    }
}
