using System;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using TMPro;
using UnityEngine.UI;
using UnityEngine.XR.ARSubsystems;

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
        var text = textComponent.GetComponentInChildren<TMP_Text>();
        foreach (ARTrackedImage image in eventArgs.added)
        {
            /*textComponent.SetActive(true);
            string imageName = image.referenceImage.name;
            Vector3 spawnPosition = image.transform.position;
            textComponent.transform.SetParent(image.transform);
            textComponent.transform.localPosition = Vector3.zero+new Vector3(1,0,0);
            Debug.Log("Image Added: "+imageName);
            switch (imageName)
            {
                case "one":
                    text.text = "Ceci est un 1 ";
                    
                    break;
                case "two":
                    text.text = "Ceci est un 2 ";
                    
                    break;
                case "Rafflesia":
                    text.text = "Magnifique fleur ";
                    
                    break;
                case "QRCode":
                    text.text = "Ce QR Code ne sert à rien ";
                    
                    break;
                case "unitylogowhiteonblack":
                    text.text = "Beau moteur ! ";
                    
                    break;
                case "GoldenTrumpet":
                    text.text = "J'ai pas compris ce que c'était ";
                    
                    break;

                default:
                    Debug.Log("Prefab Not Found");
                    break;
                
            }
            
            //continue
            
            */
        }

        foreach (ARTrackedImage image in eventArgs.updated)
        {
            if (image.trackingState == TrackingState.Tracking)
            {
                textComponent.SetActive(true);
                string imageName = image.referenceImage.name;
                textComponent.transform.SetParent(image.transform);
                textComponent.transform.localPosition = Vector3.zero+new Vector3(1,0,0);
                Debug.Log("Image Added: "+imageName);
                switch (imageName)
                {
                    case "one":
                        text.text = "Ceci est un 1 ";
                    
                        break;
                    case "two":
                        text.text = "Ceci est un 2 ";
                    
                        break;
                    case "Rafflesia":
                        text.text = "Magnifique fleur ";
                    
                        break;
                    case "QRCode":
                        text.text = "Ce QR Code ne sert à rien ";
                    
                        break;
                    case "unitylogowhiteonblack":
                        text.text = "Beau moteur ! ";
                    
                        break;
                    case "GoldenTrumpet":
                        text.text = "J'ai pas compris ce que c'était ";
                    
                        break;

                    default:
                        Debug.Log("Prefab Not Found");
                        break;
                
                }
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 direction = textComponent.transform.position - _camera.transform.position;
        direction = Vector3.ProjectOnPlane(direction, Vector3.up);
        textComponent.transform.rotation = Quaternion.LookRotation(direction);
    }
}
