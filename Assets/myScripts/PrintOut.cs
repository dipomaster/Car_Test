using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PrintOut : MonoBehaviour
{
    public GameObject[] container;
    public string tmp;
    public GameObject toast;

    public void PrintBill()
    {

        // Saves the username and score to a text file
        for (int i = 0; i < container.Length; i++)
        {
            tmp += container[i].GetComponent<Cars>().modelName + container[i].GetComponent<Cars>().modelDescription + "\n";
        }
        System.Text.UnicodeEncoding encode = new System.Text.UnicodeEncoding();
            byte[] byteData = encode.GetBytes(tmp);
            Debug.Log(tmp);
            if (!File.Exists(Application.absoluteURL + @"\allCars.txt"))
            {
                FileStream oFileStream = null;
                oFileStream = new FileStream(Application.dataPath + @"\allCars.txt", FileMode.Create);
                oFileStream.Write(byteData, 0, byteData.Length);
                oFileStream.Close();
            }
            else
            {
                using (StreamWriter stream = File.AppendText(Application.dataPath + @"\allCars.txt"))
                {
                    stream.WriteLine(tmp);
                }
            }
        toast.SetActive(true);
    }
}
