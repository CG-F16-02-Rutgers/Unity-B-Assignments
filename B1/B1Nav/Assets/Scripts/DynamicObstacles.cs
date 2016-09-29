using UnityEngine;
using System.Collections;

public class DynamicObstacles : MonoBehaviour {

    public int x;
    float y;
    void Start()
    {
        y = transform.position.y;
    }
	void Update () {
        transform.position=new Vector3(transform.position.x, y+ 10*Mathf.Sin(((x+Time.time)*100) * Mathf.PI / 180), transform.position.z);
	}
}
