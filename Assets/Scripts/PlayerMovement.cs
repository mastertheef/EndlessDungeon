using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour {

    [SerializeField]
    private float speed = 10f;

    [SerializeField]
    private LayerMask LayerMask;

    private Animator anim;
    private Vector3 position;
    private NavMeshAgent nav;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        nav = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {

        RaycastHit hit;

        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Input.GetMouseButton(0))
        {
            if (Physics.Raycast(ray, out hit, 100, LayerMask))
            {
                nav.destination = hit.point;
            }
        }

        else if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit, 100, LayerMask))
            {
                nav.destination = hit.point;
            }
        }

        anim.SetBool("IsRunning", nav.remainingDistance > nav.stoppingDistance);
    }
}
