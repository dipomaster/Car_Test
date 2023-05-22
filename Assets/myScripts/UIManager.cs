using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public GameObject[] UIcomponents;
    private Camera cam;
    public GameObject currentCar;
    private int total;
    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Back()
    {
        cam.GetComponent<Animator>().SetBool("Colour_Cam", false);
    }

    public void Colour()
    {
        cam.GetComponent<Animator>().SetBool("Colour_Cam", true);
    }

    public void carDesc(Cars selectedCar)
    {
        UIcomponents[2].gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = selectedCar.modelName;
        UIcomponents[2].gameObject.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = selectedCar.modelDescription;
        UIcomponents[3].gameObject.transform.GetComponent<TextMeshProUGUI>().text = selectedCar.basePrice.ToString();
        currentCar = selectedCar.car;
        total = selectedCar.basePrice;
        UIcomponents[4].gameObject.transform.GetComponent<TextMeshProUGUI>().text = "0";
        UIcomponents[5].gameObject.transform.GetComponent<TextMeshProUGUI>().text = total.ToString();
    }

    public void addColour(PriceTag pricing)
    {
        UIcomponents[4].gameObject.transform.GetComponent<TextMeshProUGUI>().text = pricing.price.ToString();
        total += pricing.price;
        UIcomponents[5].gameObject.transform.GetComponent<TextMeshProUGUI>().text = total.ToString();
        currentCar.GetComponentInChildren<MeshRenderer>().material=pricing.mat;
    }

    public void Quit() 
    {
        Application.Quit();
    }
}
