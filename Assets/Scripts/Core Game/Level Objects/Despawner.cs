using UnityEngine;

public class Despawner : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D other)
    {
        Destroy(other.gameObject);
    }
}
