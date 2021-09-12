using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateItem : MonoBehaviour
{
    public GameObject[] prefabs;            //�� ���� ������Ʈ�� �־��
                                            //�迭�� ���� ������ ���� ������Ʈ��
                                            //�پ��ϰ� ���� ���ؼ� �Դϴ�

    public int[,] map = new int[8, 8];      //���� �� 8x8�� ��ġ�� �����ۿ� ���� �迭
    public int count = 10;                  //�� ������Ʈ ����
    void Start()
    {
        for (int i = 0; i < count; i++)     //count �� ��ŭ �����Ѵ�.
        {
            Spawn();
        }
    }

    private void Spawn()
    {
        int posX;
        int posY;
        int selection;
        GameObject selectedPrefab;

        while(true)
        {
            posX = Random.Range(0, 8);
            posY = Random.Range(0, 8);

            if (map[posX, posY] == 0)           // map �迭�� ���� 0�̸� �ش� ��ġ���� �������� ���ٴ� ��
            {
                selection = Random.Range(1, prefabs.Length+1);
                selectedPrefab = prefabs[selection-1];

                map[posX, posY] = selection;    // map �迭�� ������ ������ ���� ����
                break;
            }
        }

        Vector3 spawnPos = new Vector3(posX * 2, 0, posY * 2);

        GameObject instance = Instantiate(selectedPrefab, spawnPos, Quaternion.identity);
        Debug.Log(posX + " " + posY);
    }
}
