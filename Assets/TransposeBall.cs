using UnityEngine;

public class TransposeBall : MonoBehaviour
{
    public GameObject player;

    public void TransposePlayer()
    {
        if(player != null)
        {
            player.transform.position = transform.position;
            player.GetComponent<TransposeController>().FinishTransposed();
        }
    }
}
