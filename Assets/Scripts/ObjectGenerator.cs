using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ObjectGenerator : ScriptableObject
{
    public GameObject circle;
    public void Generate(){
        int objectCount = Random.Range(3,8);
        for (; objectCount > 0; objectCount--){
            GameObject t = Instantiate(circle, new Vector2(Random.Range(-8f, 8f), Random.Range(-4f, 4f)), Quaternion.identity);
            RaycastHit2D hit = Physics2D.Raycast(t.transform.position, Vector2.zero);
            if (hit.collider != null){
                t.transform.position = new Vector2(Random.Range(-8f, 8f), Random.Range(-4f, 4f));
            }
        }
    }
}
