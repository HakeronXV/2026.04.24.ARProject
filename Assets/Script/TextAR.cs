using UnityEngine;
using UnityEngine.XR.ARFoundation;
using TMPro;

public class TexteAR : MonoBehaviour
{
    private ARTrackedImage trackedImage;
    [SerializeField] private TextMeshPro textComponent;

    void Awake()
    {
        trackedImage = GetComponent<ARTrackedImage>();
    }

    void Update()
    {
        // Met à jour le texte avec le nom de l'image de référence
        textComponent.text = trackedImage.referenceImage.name;
    }
}