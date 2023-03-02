using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
  
    float x;
    float y;
    Vector3 targetpos;
    public Vector3 dir;
    public Vector3 viewtoworldpos;
    float segment=0f;
    public Vector3 cross;
    /*[SerializeField] GameObject dupgameobject;
    [SerializeField] GameObject dupgameobject1;*/
    public GameObject point;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0f, 0f, 0f);
        viewtoworldpos = new Vector3(0f, 0f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        
      
      if(Input.GetKeyDown(KeyCode.Space))
        {
          
            segment = 0;
            x = Random.Range(0,1f);
            y= Random.Range(0, 1f);
            viewtoworldpos = Camera.main.ViewportToWorldPoint(new Vector3(x, y,10f));
            Vector3 refdir = transform.InverseTransformPoint(viewtoworldpos);
            float refangle = Mathf.Atan2(refdir.x ,refdir.y) * Mathf.Rad2Deg;
            transform.Rotate(0f, 0f, -refangle);

        }
        point.transform.position = viewtoworldpos;
        transform.position = Vector3.MoveTowards(transform.position, viewtoworldpos, segment);
        segment += Time.deltaTime;
    }
}
