using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Direct : MonoBehaviour {

    public NavMeshAgent[] agent;
    public NavMeshObstacle[] obstacles;
    int obIndex=1;
    Vector2 startPoint, endPoint;
    List<NavMeshAgent> selectedAgent;
    Material defaultMat, selectMat;
    void Start()
    {
        defaultMat = Resources.Load<Material>("Materials/DefaultMat");
        selectMat = Resources.Load<Material>("Materials/SelectedMat");
        for (int i = 0; i < agent.Length; i++) agent[i].GetComponent<Renderer>().material = defaultMat;
        selectedAgent = new List<NavMeshAgent>();
    }
    void OnRenderObject()
    {
        if (startPoint != Vector2.zero && endPoint != Vector2.zero)
        {
            defaultMat.SetPass(0);
            GL.PushMatrix();
            GL.LoadPixelMatrix();
            GL.Begin(GL.QUADS);
            GL.Color(new Color(1f, 1f, 1f, 0.1f));
            GL.Vertex(startPoint);
            GL.Vertex3(endPoint.x, startPoint.y, 0);
            GL.Vertex(endPoint);
            GL.Vertex3(startPoint.x, endPoint.y, 0);
            GL.End();
            GL.PopMatrix();
        }

    }
    void Update()
    {
        //select agent
        if (Input.GetMouseButtonDown(0))
        {
            selectedAgent = new List<NavMeshAgent>();
            startPoint = Input.mousePosition;

        }
        else if (Input.GetMouseButton(0))
        {
            endPoint = Input.mousePosition;

            Rect rect = new Rect();
            rect.max = startPoint;
            rect.min = endPoint;
            for (int i = 0; i < agent.Length; i++)
            {
                Vector2 pos = Camera.main.WorldToScreenPoint(agent[i].transform.position);
                if (rect.Contains(pos,true))
                {
                    agent[i].GetComponent<Renderer>().material = selectMat;
                    selectedAgent.Add(agent[i]);
                }
                else agent[i].GetComponent<Renderer>().material = defaultMat;
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            startPoint = endPoint = Vector2.zero;
        }
        //move agent
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        bool isHit = Physics.Raycast(ray, out hit);
        if (!Input.anyKey&&Input.GetMouseButtonUp(1) && isHit)
        {
            for (int i = 0; i < selectedAgent.Count; i++)
            {
                selectedAgent[i].SetDestination(hit.point);
            }
        }



        //a/d choose the obstacle
        if (Input.GetKeyDown(KeyCode.Space))
        {
            obstacles[obIndex].transform.localScale.Set(transform.localScale.x - 0.2f, transform.localScale.y - 0.2f, transform.localScale.z - 0.2f);
            obIndex = (obIndex + 1) % obstacles.Length;
            obstacles[obIndex].transform.localScale.Set(transform.localScale.x + 0.2f, transform.localScale.y + 0.2f, transform.localScale.z + 0.2f);
        }
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        if (x != 0 || z != 0)
        {
            obstacles[obIndex].transform.Translate(x, 0, z);
        }
    }


}
