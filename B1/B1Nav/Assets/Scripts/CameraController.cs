using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    Vector3 offset;
    Vector3 PreMouseMPos;
    float zoomSpeed = 500;
    void Update()
    {
        if (Input.mouseScrollDelta.y != 0)
        {
            float step = zoomSpeed * Time.deltaTime;
            transform.Translate(transform.forward * step * Input.GetAxis("Mouse ScrollWheel"), Space.World);
        }
        //right button
        if (Input.GetKey(KeyCode.LeftAlt) && Input.GetMouseButton(1))
        {
            if (PreMouseMPos.x == 0)
            {
                PreMouseMPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0.0f);
            }
            else
            {
                Vector3 CurMouseMPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0.0f);
                Vector3 offset = CurMouseMPos - PreMouseMPos;
                offset.Set(-offset.y * 0.08f, offset.x * 0.04f, 0);
                transform.Rotate(offset);
                PreMouseMPos = CurMouseMPos;
            }
        }
        //middle button
        else if (Input.GetMouseButton(2))
        {

            if (PreMouseMPos.x == 0)
            {
                PreMouseMPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0.0f);
            }
            else
            {
                Vector3 CurMouseMPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0.0f);
                Vector3 offset = CurMouseMPos - PreMouseMPos;
                offset = -offset * 0.04f;
                transform.Translate(offset);
                PreMouseMPos = CurMouseMPos;
            }
        }
        else
        {
            PreMouseMPos = new Vector3(0.0f, 0.0f, 0.0f);
        }
    }

}
