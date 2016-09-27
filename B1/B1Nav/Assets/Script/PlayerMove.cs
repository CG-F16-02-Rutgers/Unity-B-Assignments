using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {

    private Animator Anime;
    private NavMeshAgent Agent;
    private Transform Target;
    private bool Walking;

	// Use this for initialization
	void Awake () {
        Anime = GetComponent<Animator>();
        Agent = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Input.GetMouseButtonDown(1))
        {
            if (Physics.Raycast(ray, out hit))
            {
                Walking = true;
                Agent.destination = hit.point;
                Agent.Resume();
            }
        }
    }
}
