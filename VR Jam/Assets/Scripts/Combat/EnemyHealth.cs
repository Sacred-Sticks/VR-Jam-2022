using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    // Start is called before the first frame update
    // add sfx for being hit
    // add other fx

    public float hp;
    [SerializeField] bool ragdoll;
    Rigidbody[] rb; 
    Animator anim;
    [SerializeField] EnemyShooting es;
    [SerializeField] EnemyMovement em;
    void Start()
    {
        
            if (ragdoll)
        {
            anim = GetComponentInParent<Animator>();
            rb = CollectRagdollColliders();

            foreach (Rigidbody r in rb)
            {
                r.isKinematic = true;
            }
        }
    }
    
    public void TakeDamage(float dmg)
    {
        Debug.Log(gameObject.name + " took " + dmg + " dmg");
        hp -= dmg;

        if (hp <= 0)
            DeathRoutine();
    }

    private Rigidbody[] CollectRagdollColliders()
    {
        Rigidbody [] x = GetComponentsInChildren<Rigidbody>();
        return x;
    }
    private void DeathRoutine()
    {
        if (em)
            em.enabled = false;

        if (es)
            es.enabled = false;

        if (ragdoll)
        {
            foreach (Rigidbody r in rb)
            {
                r.isKinematic = false;
            }
            anim.StopPlayback();

        }

        if (ragdoll)
            Destroy(gameObject.transform.parent.parent.gameObject, 10f);
        else
            Destroy(gameObject);
    }
}
