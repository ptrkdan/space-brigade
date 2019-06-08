using UnityEngine;

public class Despawner : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<Attacker>())
        {
            FindObjectOfType<PlayerHealthManager>().ReduceHealth();
        }
        Destroy(other.gameObject);
    }
}
