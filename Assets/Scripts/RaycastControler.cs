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
    public Camera cameraDistrib;
    public PlayerControler playerControler;
    public GameObject Ath;



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
            else if (selection.name == "Digicode_00")
            {
                if (Input.GetKeyDown(KeyCode.G) && !playerControler.isPause)
                {

                    
                    StartCoroutine(toDigicode(selection));
                    

                }
                
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

    System.Collections.IEnumerator toDigicode(Transform selection)
    {
        Vector3 CameraPosition = transform.position;
        Ath.SetActive(false);




        selection.GetComponent<Collider>().enabled = false;
        gameObject.GetComponent<Animator>().SetTrigger("moveCamera");
        yield return new WaitForEndOfFrame();
        playerControler.isPause = true;
        //transform.rotation = cameraDistrib.transform.rotation;
        
        while (transform.rotation != cameraDistrib.transform.rotation)
        {
            transform.position = Vector3.MoveTowards(transform.position, cameraDistrib.transform.position, 0.05f);
            transform.rotation = Quaternion.Lerp(transform.rotation, cameraDistrib.transform.rotation, 0.05f);
            yield return new WaitForEndOfFrame();
        }
        

        yield return new WaitForSeconds(0.1f);
        Cursor.visible = true;
        Cursor.lockState = 0;


        gameObject.SetActive(false);
        cameraDistrib.gameObject.SetActive(true); //problème (il faut appuyer 2 fois)
        transform.position = CameraPosition;
        gameObject.GetComponent<Camera>().fieldOfView = 71.2266f;
        Debug.Log("digicode");
    }
}
