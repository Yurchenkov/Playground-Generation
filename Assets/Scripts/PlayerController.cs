using UnityEngine;

public class PlayerController : MonoBehaviour {

    GameObject playground;
    PlaygroundController playgroundController;

    void Start() {
        playground = GameObject.FindGameObjectWithTag("Playground");
        playgroundController = playground.GetComponent<PlaygroundController>();
    }

    void Update() {
        Move();
    }

    void Move() {
        if (Input.GetMouseButtonDown(0)) {
            UpdatePosition();
        }
    }

    void UpdatePosition() {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (!Physics.Raycast(ray, out hit)) return;      
        
        if (!playgroundController.IsInSpawnZone(hit.transform)) return;

        transform.position = new Vector3(hit.transform.position.x, transform.position.y, hit.transform.position.z);
        AfterMove();
    }

    void AfterMove() {
        playgroundController.GenerateTileSpawnZone();
        playgroundController.SpawnTile();
    }
}
