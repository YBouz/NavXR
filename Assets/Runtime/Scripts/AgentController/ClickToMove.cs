// ClickToMove.cs
using UnityEngine;
using UnityEngine.AI;

[RequireComponent (typeof (NavMeshAgent))]
public class ClickToMove : MonoBehaviour {
	RaycastHit hitInfo = new RaycastHit();
	NavMeshAgent agent;

	void Start () {
		agent = GetComponent<NavMeshAgent> ();
	}
	void Update () {
		if(Input.GetMouseButtonDown(0)) {
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray.origin, ray.direction, out hitInfo))
				agent.destination = hitInfo.point;
		}
	}
}
