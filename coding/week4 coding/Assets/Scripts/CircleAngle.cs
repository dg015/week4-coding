using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleAngle : MonoBehaviour
{

    [SerializeField] private List<float> angles;

    [SerializeField] private float radius = 3f;
    public float delayInSeconds = 0.5f;

    [SerializeField] private Vector3 offset = Vector3.zero;
    private float elapsedTime = 0f;
    private int currentAngle = 0;

    // Start is called before the first frame update
    void Start()
    {
        GetAngles();
    }


    private void GetAngles()
    {
        angles = new List<float>();
        for (int i = 0; i < 10; i ++)
        {
            angles.Add(Random.value * 360);
        }
        transform.position += offset;
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
       // if(Input.GetKeyDown(KeyCode.Space))
       if(elapsedTime > delayInSeconds)
        {
            currentAngle = (currentAngle + 1) % angles.Count;
            elapsedTime = 0f;
        }

        float radians = Mathf.Deg2Rad * angles[currentAngle];
        float xPos = Mathf.Cos(angles[currentAngle]);
        float yPos = Mathf.Sin(angles[currentAngle]);

        Vector3 endPoint =transform.position + new Vector3(xPos, yPos, 0f) * radius;

        Debug.DrawLine(transform.position, endPoint, Color.magenta);
    }
}
