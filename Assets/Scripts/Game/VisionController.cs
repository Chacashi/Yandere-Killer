using UnityEngine;

public class VisionController : MonoBehaviour
{
    [SerializeField] private float visionRange = 3f;
    [SerializeField] private float visionAngle;
    [SerializeField] private LayerMask interactableLayer;
    [SerializeField] private float chekInterval=0.2f;
    private float timer = 0;
    private float minDistance;
    IIteractable nearInteractable;
    IIteractable currentInteractable;
    
    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            CheckVision();
            timer = chekInterval;
        }
    }

    void CheckVision()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, visionRange, interactableLayer);
        minDistance = Mathf.Infinity;
        nearInteractable = null;

        for (int i = 0; i < hits.Length; i++)
        {

            Vector3 dirToTarget = (hits[i].transform.position - transform.position).normalized;
            float dot = Vector3.Dot(transform.forward, dirToTarget);
            float angleUmbral = Mathf.Cos(visionAngle * 0.5f * Mathf.Deg2Rad);
            if (dot >= angleUmbral)
            {
                float distance = Vector3.Distance(transform.position, hits[i].transform.position);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    nearInteractable = hits[i].GetComponent<IIteractable>();
                }
            }
        }
        if (nearInteractable != currentInteractable && currentInteractable != null)
            currentInteractable.HideUI();

        currentInteractable = nearInteractable;

        if (nearInteractable != null)
            currentInteractable.ShowUI();


    }

}
