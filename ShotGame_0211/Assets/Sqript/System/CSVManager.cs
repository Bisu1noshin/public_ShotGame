using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class CSVExport
{
    TextAsset csvFile; // CSVファイル
    string csvFileName;
    List<string[]> csvDatas = new List<string[]>(); // CSVの中身を入れるリスト;

    /// <summary>
    /// ファイル読み込み()
    /// </summary>
    /// <param name="text_"></param>
    /// <param name="csvFileName"></param>
    public CSVExport(string csvFileName = null)
    {
        this.csvFileName = csvFileName;

        if (this.csvFileName == null) 
        {
            Debug.Log("ファイルパスが指定されていません");
        }
    }

    ~CSVExport() 
    {
        // pass
    }

    public List<string[]> CSVdataExport()
    {
        csvFile = Resources.Load(csvFileName + "/Exportcsv") as TextAsset; // Resouces下のCSV読み込み
        StringReader reader = new StringReader(csvFile.text);

        // , で分割しつつ一行ずつ読み込み
        // リストに追加していく
        while (reader.Peek() != -1) // reader.Peaekが-1になるまで
        {
            string line = reader.ReadLine(); // 一行ずつ読み込み
            csvDatas.Add(line.Split(',')); // , 区切りでリストに追加
        }

        return csvDatas;
    }
}
public class CSVInport
{
    TextAsset csvFile; // CSVファイル
    string csvFileName;
    List<string[]> csvDatas = new List<string[]>(); // CSVの中身を入れるリスト;

    /// <summary>
    /// フォルダ指定()
    /// </summary>
    /// <param name="text_"></param>
    /// <param name="csvFileName"></param>
    public CSVInport(List<string[]> csvDatas = null)
    {
        this.csvDatas = csvDatas;    
    }

    
    public void CSVdataCreate()
    {
        
    }

    public void CSVdataInport() 
    {

    }
}
