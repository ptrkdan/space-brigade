using UnityEngine;

public class Attacker : MonoBehaviour
{
    float currentSpeed = 1f;
    GameObject currentTarget;

    private void Awake()
    {
        FindObjectOfType<LevelController>().AttackerSpawned();
    }

    private void Update()
    {
        transform.Translate(Vector2.left * Time.deltaTime * currentSpeed);
        UpdateAnimationState();
    }

    private void OnDestroy()
    {
        FindObjectOfType<LevelController>().AttackerKilled();
    }

    public void SetMovementSpeed(float newSpeed)
    {
        currentSpeed = newSpeed;
    }

    public void Attack(GameObject target)
    {
        GetComponent<Animator>().SetBool("isAttacking", true);
        currentTarget = target;
    }

    public void StrikeCurrenTarget(float damage)
    {
        if (!currentTarget) return;

        Health health = currentTarget.GetComponent<Health>();
        if (health)
        {
            health.DealDamage(damage);
        }
    }

    private void UpdateAnimationState()
    {
        if (!currentTarget)
        {
            GetComponent<Animator>().SetBool("isAttacking", false);
        }
    }
}
