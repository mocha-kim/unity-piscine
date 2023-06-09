using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform player;
    
    public LayerMask layerMask;
    public Transform[] obstructions;

    private int oldHitsNumber;

    void Start()
    {
        oldHitsNumber = 0;
    }

    private void LateUpdate()
    {
        viewObstructed();
    }

    void viewObstructed()
    {
        float characterDistance = Vector3.Distance(transform.position, player.transform.position);
        RaycastHit[] hits = Physics.RaycastAll(transform.position, transform.forward, characterDistance, layerMask);
        if (hits.Length > 0)
        {
            int newHits = hits.Length - oldHitsNumber;

            if (obstructions != null && obstructions.Length > 0 && newHits < 0)
            {
                for (int i = 0; i < obstructions.Length; i++)
                {
                    var renderer = obstructions[i].gameObject.GetComponent<MeshRenderer>();
                    if (renderer == null) continue;
                    renderer.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;
                }
            }
            obstructions = new Transform[hits.Length];
            
            for (int i = 0; i < hits.Length; i++)
            {
                Transform obstruction = hits[i].transform;
                obstructions[i] = obstruction;
                var renderer = obstruction.gameObject.GetComponent<MeshRenderer>();
                if (renderer == null) continue;
                renderer.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.ShadowsOnly;
            }
            oldHitsNumber = hits.Length;
        }
        else
        {
            if (obstructions != null && obstructions.Length > 0)
            {
                for (int i = 0; i < obstructions.Length; i++)
                {
                    var renderer = obstructions[i].gameObject.GetComponent<MeshRenderer>();
                    if (renderer == null) continue;
                    renderer.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;
                }
                oldHitsNumber = 0;
                obstructions = null;
            }
        }
    }
}
