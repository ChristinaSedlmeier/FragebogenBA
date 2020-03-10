using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Globalization;

public class DataController : MonoBehaviour
{

    public RoundData[] allRoundData;
    public string userName;
    public string filepath = @"C:\Users\sedlm\Desktop\";
    private List<string[]> rowData = new List<string[]>();
    // Start is called before the first frame update
    void Start()
    {

        DontDestroyOnLoad(gameObject); //when Loading new scene this Data will persist

        SceneManager.LoadScene ("MenuScene");

        
    }

    private String getDatetime()
    {
        return string.Format("{0:dd-MM_hh-mm}", DateTime.Now);


        //ToString("M/yy", DateTimeFormatInfo.InvariantInfo);
    }

    public RoundData GetCurrentRoundData()
    {
        return allRoundData[0];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void saveData(QAClass07[] qa)
    {

        try
        {
            using (StreamWriter file = File.CreateText(@"C:\Users\User\Desktop\" + userName + getDatetime()+ ".csv"))
            {


                string[] rowDataTemp = new string[3];
                rowDataTemp[0] = "Question";
                rowDataTemp[1] = "Answer";

                rowData.Add(rowDataTemp);

                for (int i = 0; i < qa.Length; i++)
                {
                    rowDataTemp = new string[2];
                    rowDataTemp[0] = qa[i].Question;
                    rowDataTemp[1] = qa[i].Answer;

                    rowData.Add(rowDataTemp);
                }

                string[][] output = new string[rowData.Count][];

                for (int i = 0; i < output.Length; i++)
                {
                    output[i] = rowData[i];
                }

                int length = output.GetLength(0);
                string delimiter = ",";

                StringBuilder sb = new StringBuilder();

                for (int index = 0; index < length; index++)
                    sb.AppendLine(string.Join(delimiter, output[index]));



                file.WriteLine(sb);
                file.Close();

                //ile.WriteLine(qa[i].Answer);
            }



        }
        catch (Exception ex)
        {
            throw new ApplicationException("This program did an oopsie: " + ex);

        }


    }
}
