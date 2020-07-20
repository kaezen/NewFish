using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcRendeer : MonoBehaviour
{
    LineRenderer arc;
    public float velocity;
    public float angle;
    public int resolution = 10;
    float gravity;
    float radianAngle;
     void OnValidate()
    {
        if(arc != null && Application.isPlaying)
        {
            RenderArc();
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        arc =  GetComponent<LineRenderer>();
        gravity = Mathf.Abs(Physics.gravity.y);

        RenderArc();
    }

    // Update is called once per frame
   void RenderArc()
    {
        arc.positionCount = (resolution + 1);
        arc.SetPositions(CalculateArcArray());
    }
    Vector3[] CalculateArcArray()
    {
        Vector3[] arcArray = new Vector3[resolution + 1];
        radianAngle = Mathf.Deg2Rad * angle;
        float maxDistance = (velocity * velocity * Mathf.Sin(2 * radianAngle)) / gravity;
        for(int i = 0; i <= resolution; i++)
        {
            float t = (float)i / (float)resolution;
            arcArray[i] = CaluclateArcPoint(t,maxDistance);
        }
        return arcArray;
    }
    Vector3 CaluclateArcPoint(float t, float maxDistance)
    {
        float x = t * maxDistance;
        float y = x * Mathf.Tan(radianAngle) - ((gravity * x * x) / (2 * velocity * velocity * Mathf.Cos(radianAngle) * Mathf.Cos(radianAngle)));
        return new Vector3(x, y);
    }

}
