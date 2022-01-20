using UnityEngine;

public class RaycastControler : MonoBehaviour
{
    
    [SerializeField] private string selectableTag = "Selectable";
    [SerializeField] private Material diffMaterial;
    [SerializeField] private Material defaultMaterial;
    public GameObject inventory;
    private Transform _selection;
    private bool beingCarried = false;
    public Material testMaterial;


    

    void Update()
    {
        if (_selection != null)
        {
            
            
            //defaultMaterial = _selection.GetComponent<Material>();
            var selectionRenderer = _selection.GetComponent<Renderer>();
            selectionRenderer.material = testMaterial;
            _selection = null;
        }

        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        Debug.DrawRay(transform.position, transform.forward * 3.5f, Color.red);

        if (Physics.Raycast(transform.position, transform.forward, out hit, 3.5f))
        {
            var selection = hit.transform;
            if (selection.CompareTag(selectableTag))
            {
                var selectionRenderer = selection.GetComponent<Renderer>();
                if (testMaterial == null)
                {
                    testMaterial = selection.GetComponent<Renderer>().material;
                }
                if (selectionRenderer != null)
                {
                    

                    selectionRenderer.material = diffMaterial;
                }
                if (Input.GetKey(KeyCode.E))
                {
                    inventory.GetComponent<Inventory>().AddInventory(selection.gameObject);
                }

                _selection = selection;
            } 
            else if (selection.name == "Digicode_00" && Input.GetKeyDown(KeyCode.G))
            {
                print("digicode");
                Cursor.visible = true;
                Cursor.lockState = 0;
                gameObject.SetActive(false);
            }
            

            if (selection.CompareTag("CanBeCarried") && Input.GetMouseButtonDown(0) && !beingCarried)
            {
                selection.parent = transform;
                selection.GetComponent<Rigidbody>().isKinematic = true;
                beingCarried = true;
            }

            if (selection.CompareTag("CanBeCarried") && Input.GetKeyDown(KeyCode.A) && beingCarried)
            {
                selection.parent = null;
                selection.GetComponent<Rigidbody>().isKinematic = false;
                beingCarried = false;
            }

            if (selection.CompareTag("CanBeCarried") && Input.GetMouseButtonDown(1) && beingCarried)
            {
                selection.parent = null;
                selection.GetComponent<Rigidbody>().isKinematic = false;
                beingCarried = false;
                selection.GetComponent<Rigidbody>().AddForce(transform.forward * 350);
            }


        }
    }
}
