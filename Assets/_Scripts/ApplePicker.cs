using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ApplePicker : MonoBehaviour
{
    [Header("Set In Inspector")]
    [SerializeField] private GameObject basketPrefab = null;
    [SerializeField] private List<GameObject> basketList;
    [SerializeField] private int numBaskets = 3;
    [SerializeField] private float basketBottomY = -14f;
    [SerializeField] private float basketSpacingY = 2f;
    [SerializeField] private string sceneGameOver = "GameOver";

    private void Start()
    {
        basketList = new List<GameObject>();
        for (int i=0; i<numBaskets; i++)
        {
            GameObject tBasketGO = Instantiate<GameObject>(basketPrefab);
            Vector3 pos = Vector3.zero;
            pos.y = basketBottomY + (basketSpacingY * i);
            tBasketGO.transform.position = pos;
            basketList.Add(tBasketGO);
        }
    }

    public void AppleDestroyed()
    {
        //Удалить все упавшие яблоки
        GameObject[] tAppleArray = GameObject.FindGameObjectsWithTag("Apple");
        foreach (GameObject tGO in tAppleArray)
        {
            Destroy(tGO);
        }

        //Удалить одну корзину
        //Получить индекс последней корзины в basketList
        int basketIndex = basketList.Count - 1;
        //Получить ссылку на этот игровой объект Basket
        GameObject tBasketGO = basketList[basketIndex];
        //Исключить корзину из списка и удалить сам игровой объект
        basketList.RemoveAt(basketIndex);
        Destroy(tBasketGO);

        //Если корзин не осталось, перезапустить игру
        if (basketList.Count == 0)
        {
            SceneManager.LoadScene(sceneGameOver);
        }
    }
}
