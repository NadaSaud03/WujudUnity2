using UnityEngine;

public class AutoSpawn : MonoBehaviour
{

    private Vector3 lastSafePosition = new Vector3(-11.31f, 1.5f, -7.68f);

    //private Vector3 lastSafePosition;

    void Update()
    {
        // äÍÏË ÂÎÑ ãæÞÚ Âãä ÝÞØ ÅÐÇ ÇááÇÚÈ ÝæÞ ÇáÃÑÖ ÇáãÚÞæáÉ
        if (transform.position.y > 0.5f && transform.position.y < 100f)
            lastSafePosition = transform.position;

        // ÅÐÇ ØÇÍ ãÑÉ ßËíÑ
        if (transform.position.y < -10f)
            transform.position = lastSafePosition;
    }
}