using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table : MonoBehaviour
{
    private Plane plane;
    private Vector3 pointer = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        plane = new Plane(-transform.forward, transform.position);
    }

    void Update()
    {
        Vector3 pos = Input.mousePosition;
        Ray ray = Camera.main.ScreenPointToRay(pos);

        float t;
        if (plane.Raycast(ray, out t)) {
            pointer = ray.GetPoint(t);
        }
    }    

    private void OnDrawGizmos() {
        Gizmos.color = Color.yellow;

        Gizmos.DrawLine(Camera.main.transform.position, pointer);
    }
}
