using UnityEngine;

public class Despawner : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D other)
    {
        FindObjectOfType<PlayerHealthManager>().ReduceHealth();
        Destroy(other.gameObject);
    }
}
