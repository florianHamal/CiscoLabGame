using Microsoft.MixedReality.Toolkit.Input;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Grap : MonoBehaviour
{
    private bool isGrabbed = false;
    private Vector3 grabOffset;

    private void Start()
    {
        var grabbable = gameObject.AddComponent<NearInteractionGrabbable>();
        var pointerHandler = gameObject.AddComponent<PointerHandler>();
        var rb = gameObject.GetComponent<Rigidbody>();

        // Set rigidbody properties
        if (rb != null)
        {
            rb.interpolation = RigidbodyInterpolation.None;
        }

        pointerHandler.OnPointerDown.AddListener((e) =>
        {
            isGrabbed = true;
            if (rb != null)
            {
                rb.useGravity = false;
                rb.velocity = Vector3.zero;
            }
            grabbable.enabled = false;
            grabOffset = transform.position - e.Pointer.Position;
        });

        pointerHandler.OnPointerDragged.AddListener((e) =>
        {
            if (isGrabbed && e.Pointer is SpherePointer)
            {
                Vector3 newPosition = e.Pointer.Position + grabOffset;
                transform.position = newPosition;
            }
        });

        pointerHandler.OnPointerUp.AddListener((e) =>
        {
            isGrabbed = false;
            if (rb != null)
            {
                rb.useGravity = true;
            }
            grabbable.enabled = true;

            // Find the closest point on any collider the prefab is touching and adjust its position.
            Collider[] colliders = Physics.OverlapBox(transform.position, transform.localScale / 2, transform.rotation);
            foreach (var collider in colliders)
            {
                Vector3 closestPoint = collider.ClosestPoint(transform.position);
                transform.position = closestPoint;
            }
        });
    }




    // Update is called once per frame
    void Update()
    {

    }
}