using UnityEngine;

public class SelectLightScript : MonoBehaviour
{

    public GameObject selectorLight;
    public bool isClicked = false;
    private Vector3 lightPos;

    private LayerMask layerMask;
    public GameObject hitObject;

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Input.GetMouseButtonDown(0))
        {

            layerMask = LayerMask.GetMask("Ground", "UI");
            int excludeMask = ~layerMask;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, excludeMask))
            {
                lightPos = hit.transform.position;
                selectorLight.transform.position = lightPos;
                isClicked = true;

                hitObject = hit.transform.gameObject;
            }
        }

        if(isClicked)
        {
            selectorLight.transform.position = lightPos;
        }
    }
}
