using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassGenerator : MonoBehaviour
{
    public Sprite[] grassTypes;
    public GameObject grassTemp;

    [Header("Grass Properties")]
    public float distanceBetweenGrass;
    public float totalLength;


    // Start is called before the first frame update
    void Start()
    {
        InstantiateGrass();
    }

    void InstantiateGrass()
    {
        for (int i = 0; i < totalLength; i++)
        {
            GameObject temp = Instantiate(grassTemp);
            temp.transform.SetParent(this.transform);

            var index = Random.Range(0, grassTypes.Length);
            temp.GetComponent<SpriteRenderer>().sprite = grassTypes[index];

            float xPos;
            xPos=transform.position.x+distanceBetweenGrass;
            temp.transform.position = new Vector2(xPos, transform.position.y);

            int range = Random.Range(1, 3);
            distanceBetweenGrass += range;
        }
    }

    private void OnValidate()
    {
        //InstantiateGrass();
    }


}
