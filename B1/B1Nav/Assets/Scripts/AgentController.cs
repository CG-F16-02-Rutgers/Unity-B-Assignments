using UnityEngine;
using System.Collections;

public class AgentController : MonoBehaviour {

    NavMeshAgent agent;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }
	void Update () {
        Ray ray1 = new Ray(transform.position, agent.steeringTarget - transform.position);
        RaycastHit hit1;
        if(Physics.Raycast(ray1,out hit1)&&hit1.transform.GetComponent<NavMeshAgent>()&&Vector3.Distance(hit1.point,transform.position)<4)
        {
            agent.velocity = Vector3.zero;
        }
        Debug.DrawRay(ray1.origin, ray1.direction * 10);


        Ray ray2 = new Ray(transform.position, Vector3.Cross(Vector3.up,ray1.direction));
        RaycastHit hit2;
        if (Physics.Raycast(ray2, out hit2) && hit2.transform.GetComponent<NavMeshAgent>() && Vector3.Distance(hit2.point, transform.position) < 4)
        {
            agent.velocity = Vector3.zero;
        }
        Debug.DrawRay(ray2.origin, ray2.direction*10);
    }
}
