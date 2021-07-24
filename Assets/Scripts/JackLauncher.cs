using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JackLauncher : MonoBehaviour
{
    public float maxLength;
    public Jack jackOb;
    public float power;

    public GameObject debug;
    public Jack deployedJack { get; set; }

    public JackAttach attached { get; set; }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        PrimaryJackControls();
        if (deployedJack)
        {
            maintainJack();
        }
    }

    private void maintainJack()
    {
        if ((deployedJack.transform.position - transform.position).magnitude > maxLength) deployedJack.MissedTargets();
    }

    private void PrimaryJackControls()
    {
        if (!deployedJack && Input.GetKeyDown(KeyCode.Mouse0))
        {
            LaunchJack();
        }
    }

    private void LaunchJack()
    {
        float aspect = (float)Screen.width / (float)Screen.height;
        Vector2 mousePos = new Vector2((Input.mousePosition.x / Screen.width - 0.5f) * (Camera.main.orthographicSize * aspect * 2f) + Camera.main.transform.position.x,
            (Input.mousePosition.y / Screen.height - 0.5f) * (Camera.main.orthographicSize * 2f) + Camera.main.transform.position.y);
        Vector2 charPos = new Vector2(transform.position.x, transform.position.y);
        Vector2 launchVector = (new Vector2(mousePos.x, mousePos.y) - charPos).normalized;
        Jack jack = Instantiate(jackOb, transform.position, transform.rotation);
        jack.assignVelocity((launchVector * power) + (Vector2)GetComponentInParent<Rigidbody2D>().velocity);
        jack.launcher = this;
        deployedJack = jack;
    }
}
