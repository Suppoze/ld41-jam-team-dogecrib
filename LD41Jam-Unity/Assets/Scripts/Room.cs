using UnityEngine;

public class Room : MonoBehaviour
{
    public GameObject Wall;
    public float XSize;
    public float YSize;

    private void Start()
    {
        var topWall = Instantiate(Wall, transform.position, Quaternion.identity)
            .GetComponent<SpriteRenderer>();
        topWall.size = new Vector2(XSize, 1);
        topWall.transform.position = new Vector2(0, YSize / 2F);

        var bottomWall = Instantiate(Wall, transform.position, Quaternion.identity)
            .GetComponent<SpriteRenderer>();
        bottomWall.size = new Vector2(XSize, 1);
        bottomWall.transform.position = new Vector2(0, -YSize / 2);

        var leftWall = Instantiate(Wall, transform.position, Quaternion.identity)
            .GetComponent<SpriteRenderer>();
        leftWall.size = new Vector2(1, YSize);
        leftWall.transform.position = new Vector2(-XSize / 2, 0);

        var rightWall= Instantiate(Wall, transform.position, Quaternion.identity)
            .GetComponent<SpriteRenderer>();
        rightWall.size = new Vector2(1, YSize);
        rightWall.transform.position = new Vector2(XSize / 2, 0);
    }

}