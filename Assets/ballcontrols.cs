using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;

public class ballcontrols : MonoBehaviour
{
    public GameObject arrow;
    private float lenScale = 1;
    private float maxScale = 10;
    private float maxDistance = 10;
    private float minDistance = 1;
    private float forVel = 1;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        transform.RotateAround(transform.position, Vector3.up, mouseX * 5);

        float distance = Vector3.Distance(transform.position, Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10)));
        lenScale = Mathf.Clamp(distance / maxDistance, 0, 1) * maxScale;
        arrow.transform.localScale = new Vector3(10, lenScale, 10);

        forVel = Mathf.Lerp(1, 10, (distance - minDistance) / (maxDistance - minDistance));

        // Shoot ball on mouse click
        if (Input.GetMouseButtonDown(0))
        {
            arrow.GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<Rigidbody>().velocity = transform.forward * forVel;
        }
    }
}
