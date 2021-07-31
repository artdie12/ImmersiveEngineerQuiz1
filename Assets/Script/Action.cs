using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action : MonoBehaviour
{

    public GameObject objAction;
    Vector3 scaleStart;
    public float minScale;

    
    // Start is called before the first frame update
    void Start()
    {
        scaleStart = objAction.transform.localScale;
    }

    Vector2 t1start, t0start;
    Vector2 rotationStart;
    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {



            if (Input.touchCount == 1)
            {
                Touch t = Input.GetTouch(0);

                if (t.phase == TouchPhase.Moved)
                {
                    objAction.transform.Rotate(new Vector3( t.deltaPosition.y, t.deltaPosition.x,0),90,Space.World);


                }

            }
            else if (Input.touchCount == 2)
            {

                Touch t0 = Input.GetTouch(0);
                Touch t1 = Input.GetTouch(1);

                if (t0.phase == TouchPhase.Began)
                {
                    t0start = t0.position;
                }
                if (t1.phase == TouchPhase.Began)
                {
                    t1start = t1.position;
                }


                if (t0.phase == TouchPhase.Moved || t1.phase == TouchPhase.Moved)
                {
                    float selisih= t1.position.x + t1.position.y - (t0.position.x - t0.position.y);
                    float selisihStart = t1start.x - t0start.x + t1start.y - t0start.y;
                    float deltaselisih = (t0.deltaPosition.x + t0.deltaPosition.y) - (t1.deltaPosition.x + t1.deltaPosition.y);
                    if (selisih > 0)
                    {  
                        objAction.transform.localScale += new Vector3 (deltaselisih,deltaselisih,deltaselisih );
                    }
                    else if (selisih<0)
                    {
                        objAction.transform.localScale -= new Vector3(deltaselisih, deltaselisih, deltaselisih);
                    }
                    
                    Vector2 distanceTouchStart = new Vector2(Mathf.Abs(t1start.x - t0start.x), Mathf.Abs(t1start.y - t0start.y));
                    Vector2 distanceTouch = new Vector2(Mathf.Abs(t1.position.x - t0.position.x), Mathf.Abs(t1.position.y - t0.position.y));
                    float totalDistance = distanceTouch.x + distanceTouch.y - (distanceTouchStart.x + distanceTouchStart.y);

                    if (objAction.transform.localScale.x > scaleStart.x * minScale)
                    {
                       objAction.transform.localScale = scaleStart +  (scaleStart * totalDistance*0.1f);
                    }

                }

            }

        }

        

    }



    //blinking 

    float blinktime;
    public float blinkDuration,blinkdistence;
    bool isBlinking = false;
    public void doBlink()
    {

        if (isBlinking)
        {
            if (blinktime < blinkDuration)
            {
                blinktime += Time.deltaTime;
            }
            else
            {
                objAction.SetActive(true);
                blinktime = 0;
                isBlinking = false;
            }
        }
        else
        {
            if (blinktime < blinkdistence)
            {
                blinktime += Time.deltaTime;
            }
            else
            {
                objAction.SetActive(false);
                blinktime = 0;
                isBlinking = true;
            }
        }


    
    }


   
}

