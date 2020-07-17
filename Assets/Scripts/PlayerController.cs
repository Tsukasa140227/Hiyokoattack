using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    public float speed = 8f;
    [SerializeField]
    public float movableRange = 5.5f;
    [SerializeField]
    public float power = 1000f;
    [SerializeField]
    public GameObject cannonBall;
    [SerializeField]
    public Transform spawnPoint;


    // Update is called once per frame
    void Update()
    {
        transform.Translate(Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime, 0, 0);
        transform.position = new Vector2(
            Mathf.Clamp(transform.position.x, -movableRange, movableRange),
            transform.position.y);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }
    void Shoot()
    {
        GameObject newBullet = Instantiate(
            cannonBall, spawnPoint.position, Quaternion.identity) as GameObject;
        newBullet.GetComponent<Rigidbody2D>().AddForce(Vector3.up * power);
    }
}
