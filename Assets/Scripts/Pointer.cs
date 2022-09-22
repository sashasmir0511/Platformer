using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour
{
    public Transform Aim;
    public Transform PlayerBody;
    public Camera PlayerCamera;

    private float _yEuler;

    private void LateUpdate()
    {
        Ray ray = PlayerCamera.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction * 50, Color.yellow);
        Plane plane = new Plane(-Vector3.forward, Vector3.zero);

        float distance;
        plane.Raycast(ray, out distance);
        Vector3 pointAim = ray.GetPoint(distance);

        Aim.position = pointAim;

        Vector3 toAim = pointAim - transform.position;
        transform.rotation = Quaternion.LookRotation(toAim);

        if (transform.rotation.y < 0f)
        {
            _yEuler = Mathf.Lerp(_yEuler, 45f, Time.deltaTime * 8);
        }
        else
        {
            _yEuler = Mathf.Lerp(_yEuler, -45f, Time.deltaTime * 8);
        }
        PlayerBody.localEulerAngles = new Vector3(0f, _yEuler, 0f);

    }

}
