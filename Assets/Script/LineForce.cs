using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineForce : MonoBehaviour
{
    [SerializeField] public float shotPower; //puissance du tir
    [SerializeField] public LineRenderer line; //affichage d'une ligne entre la balle et la souris

    private bool click; //peut-on tirer ?
    private bool aim; //clic gauche enclenché ?
    private Rigidbody rigidBody;
    public float ground = 0.1f;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
        aim = false;
        line.enabled = false;
        click = true;
    }

    private void Update()
    {
        if (rigidBody.velocity.magnitude > 0.1) //on ne peut pas tirer si la balle va trop vite
        {
            click = false;
        }
        else
        {
            click = true;
        }
        if(rigidBody.velocity.magnitude < 0.2 && IsGrounded()) //si la balle va lentement et qu'elle touche le sol
        {
            //on ralentit la balle en multipliant sa vitesse par un nombre < 1
            rigidBody.velocity = rigidBody.velocity.normalized * 0.01f;
            rigidBody.angularVelocity = Vector3.zero;
        }
        isAim();
    }

    bool IsGrounded() //la balle touche le sol ?
    {
        return Physics.Raycast(transform.position, -Vector3.up, GetComponent<Collider>().bounds.extents.y + ground); 
    }

    private void Stop() //arrêter la balle
        {
            rigidBody.velocity = Vector3.zero;
            rigidBody.angularVelocity = Vector3.zero;
        }

    private void OnMouseDown()
    {
        if (click)
        {
            aim = true; //le clic gauche est enclenché
        }
    }

    private void isAim()
    {
        if (!aim || !click)
        {
            return; //il ne se passe rien si on ne vise pas ou si la balle est en mouvement
        }
        Vector3? worldPoint = CastMouseClickRay();
        if (!worldPoint.HasValue)
        {
            return;
        }
        DrawLine(worldPoint.Value); //dessine une ligne entre la balle et la souris

        if (Input.GetMouseButtonUp(0)) //si on relâche le clic gauche
        {
            this.transform.Find("Line").gameObject.GetComponentInChildren<AudioSource>().Play(); //son du swing
            Shoot(worldPoint.Value); //tir de la balle vers la direction donnée
            strikemanager.instance.addShoot(); //appelle de la fonction addShoot du script strikemanager
        }
    }


    private void Shoot(Vector3 worldPoint)
    {
        aim = false;
        line.enabled = false;

        Vector3 horizontalWorldPoint = new Vector3(worldPoint.x, transform.position.y, worldPoint.z);
        Vector3 direction = (horizontalWorldPoint - transform.position).normalized;
        float strength = Vector3.Distance(transform.position, horizontalWorldPoint);
        //plus la souris est loin de la balle, plus on tire fort

        rigidBody.AddForce(-direction* strength * shotPower);
        //tir de la balle, direction en négatif car la balle part en sens inverse de la ligne tracée
    }

    private void DrawLine(Vector3 worldPoint)
    {
        //tracé de la ligne balle-souris
        Vector3[] positions =
        {
            transform.position,
            worldPoint };
        line.SetPositions(positions);
        line.enabled = true;
    }

    private Vector3? CastMouseClickRay() //évaluation de la position de la souris dans l'espace
    {
        Vector3 screenMousePosFar = new Vector3(
            Input.mousePosition.x,
            Input.mousePosition.y,
            Camera.main.farClipPlane);
        Vector3 screenMousePosNear = new Vector3(
            Input.mousePosition.x,
            Input.mousePosition.y,
            Camera.main.nearClipPlane);
        Vector3 worldMousePosFar = Camera.main.ScreenToWorldPoint(screenMousePosFar);
        Vector3 worldMousePosNear = Camera.main.ScreenToWorldPoint(screenMousePosNear);
        RaycastHit hit;
        if (Physics.Raycast(worldMousePosNear, worldMousePosFar - worldMousePosNear, out hit, float.PositiveInfinity))
        {
            return hit.point;
        }
        else
        {
            return null;
        }
    }
}