using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jack : MonoBehaviour
{
    public float gravity;
    public float drag;
    public Vector2 velocity { get; set; }
    public JackLauncher launcher { get; set; }
    public JackAttach attached { get; set; }
    public Transform cordAttach;


    public LineRenderer cord { get; set; }

    // Start is called before the first frame update
    void Awake()
    {
        cord = GetComponentInChildren<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!attached)
        {
            RayCheck();
            if (!attached)
            {
                Move();
                AddForces();
                SetRotation();
            }
        }
    }

    private void SetRotation()
    {
        transform.LookAt(transform.position + new Vector3(velocity.x, velocity.y, 0f));
    }

    private void RayCheck()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, velocity.normalized, velocity.magnitude * Time.deltaTime);
        if (hit.collider != null)
        {
            if (hit.collider.gameObject.GetComponent<JackAttach>())
            {
                AttachJack(hit.collider.gameObject.GetComponent<JackAttach>());
            }
            else MissedTargets();
        }
    }

    private void AttachJack(JackAttach jackAttach)
    {
        attached = jackAttach;
        transform.position = jackAttach.attachPoint.position;
        transform.position += new Vector3(0f, 0f, 0.03f);
        transform.rotation = jackAttach.attachPoint.rotation;
        launcher.restrainedLength = (launcher.transform.position - jackAttach.attachPoint.position).magnitude;
        launcher.GetComponent<PlayerController>().speaker.PlayOneShot(AudioManager.instance._lock);
    }

    public void DetachJack()
    {
        launcher.deployedJack = null;
        attached = null;
        launcher.GetComponent<PlayerController>().speaker.PlayOneShot(AudioManager.instance._unlock);
        Destroy(this.gameObject, 0f);
    }

    public void MissedTargets()
    {
        launcher.deployedJack = null;
        launcher.GetComponent<PlayerController>().speaker.PlayOneShot(AudioManager.instance.zap);
        Destroy(this.gameObject, 0f);
    }

    private void AddForces()
    {
        assignVelocity(new Vector2(0f, gravity * Physics2D.gravity.y * Time.deltaTime), true);
        assignVelocity(velocity * (1f - drag));
    }

    public void assignVelocity(Vector2 _vel, bool add=false)
    {
        if (add) velocity += _vel;
        else velocity = _vel;
    }

    private void Move()
    {
        transform.Translate(velocity.x * Time.deltaTime, velocity.y * Time.deltaTime, 0f, Space.World);
    }
}
