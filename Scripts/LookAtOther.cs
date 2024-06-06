using UnityEngine;

public class LookAtOther : MonoBehaviour
{
    public Transform otherObject;

    void Update()
    {
        if (otherObject != null)
        {

            if (transform.position.x < otherObject.position.x)
            {

                transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            }
            else
            {

                transform.localScale = new Vector3(-0.5f, 0.5f, 0.5f);
            }
        }
    }
}

