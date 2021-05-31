using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdgeCreate : MonoBehaviour
{
    public GameObject main;
    public Color color;
    GameObject Edge;
    // Start is called before the first frame update
    void Start()
    {
      for(int i = 0; i < 4; i++){
        Edge = Instantiate(main, transform);
        if(i == 0){
          Edge.transform.Translate(new Vector3(-0.175f, 0f, 0f));
        }
        else if(i == 1){
          Edge.transform.Translate(new Vector3(0.175f, 0f, 0f));
        }
        else if(i == 2){
          Edge.transform.Translate(new Vector3(0f, -0.175f, 0f));
        }
        else{
          Edge.transform.Translate(new Vector3(0f, 0.175f, 0f));
        }

        Edge.GetComponent<SpriteRenderer>().color = color;
        Edge.GetComponent<SpriteRenderer>().sortingOrder = Edge.GetComponent<SpriteRenderer>().sortingOrder-1;
        Destroy(Edge.GetComponent<Collider2D>());
        Destroy(Edge.GetComponent<platAlert1>());
      }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
