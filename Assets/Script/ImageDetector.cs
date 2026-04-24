using System;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using TMPro;
using UnityEngine.UI;

public class ImageDetector : MonoBehaviour
{
    private Camera _camera;
    private ARTrackedImageManager _trackedImageManager;
    [SerializeField]private GameObject textComponent;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        _trackedImageManager = GetComponent<ARTrackedImageManager>();
    }

    private void Start()
    {
        _camera = Camera.main;
    }

    private void OnEnable()
    {
       _trackedImageManager.trackablesChanged.AddListener(OnChanged);
    }

    private void OnDisable()
    {
        _trackedImageManager.trackablesChanged.RemoveListener(OnChanged);
    }

    private void OnChanged(ARTrackablesChangedEventArgs<ARTrackedImage> eventArgs)
    {
        var text = textComponent.GetComponent<TextMesh>();
        foreach (ARTrackedImage image in eventArgs.added)
        {
            string imageName = image.referenceImage.name;
            Vector3 spawnPosition = image.transform.position;
            Debug.Log("Image Added: "+imageName);
            switch (imageName)
            {
                case "one":
                    text.text = "Test one ";
                    
                    break;
                case "two":
                    text.text = "Test two ";
                    
                    break;
                case "Rafflesia":
                    text.text = "Test rafflesia ";
                    
                    break;
                case "QRCode":
                    text.text = "Test QRCode ";
                    
                    break;
                case "unitylogowhiteonblack":
                    text.text = "Test unitylogowhiteonblack ";
                    
                    break;

                default:
                    Debug.Log("Prefab Not Found");
                    break;
                
            }
            
            //continue
            
            
        }

        foreach (ARTrackedImage image in eventArgs.updated)
        {
            
        }

        foreach (var image in eventArgs.removed)
        {
            Debug.Log("Image Removed");
        }


    }


    // Update is called once per frame
    void Update()
    {
        Vector3 direction = textComponent.transform.position - _camera.transform.position;
        direction = Vector3.ProjectOnPlane(direction, Vector3.up);
        Quaternion targetRotation = Quaternion.LookRotation(direction);
    }
    

}
