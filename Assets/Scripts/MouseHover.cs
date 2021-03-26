using UnityEngine;

public class MouseHover : MonoBehaviour {

    GameObject playground;
    Color startColor;
    PlaygroundController playgroundController;

    void Start() {
        playground = GameObject.FindGameObjectWithTag("Playground");
        startColor = GetComponent<Renderer>().material.color;
        playgroundController = playground.GetComponent<PlaygroundController>();
    }

    void OnMouseEnter() {
        GetComponent<Renderer>().material.color = playgroundController.IsInSpawnZone(transform) ? Color.green : Color.red;
    }

    void OnMouseExit() {
        GetComponent<Renderer>().material.color = startColor;
    }
}
