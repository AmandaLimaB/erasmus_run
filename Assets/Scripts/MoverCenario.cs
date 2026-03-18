using UnityEngine;

public class MoverCenario : MonoBehaviour
{
    public float velocidade = 5f;

    void Update()
    {
        transform.Translate(0, 0, -velocidade * Time.deltaTime);

        if (transform.position.z < -10f)
        {
            transform.position = new Vector3(
            transform.position.x,
            transform.position.y,
            10f
            );
        }
    }
}


