using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class CSVExport
{
    TextAsset csvFile; // CSV�t�@�C��
    string csvFileName;
    List<string[]> csvDatas = new List<string[]>(); // CSV�̒��g�����郊�X�g;

    /// <summary>
    /// �t�@�C���ǂݍ���()
    /// </summary>
    /// <param name="text_"></param>
    /// <param name="csvFileName"></param>
    public CSVExport(string csvFileName = null)
    {
        this.csvFileName = csvFileName;

        if (this.csvFileName == null) 
        {
            Debug.Log("�t�@�C���p�X���w�肳��Ă��܂���");
        }
    }

    ~CSVExport() 
    {
        // pass
    }

    public List<string[]> CSVdataExport()
    {
        csvFile = Resources.Load(csvFileName + "/Exportcsv") as TextAsset; // Resouces����CSV�ǂݍ���
        StringReader reader = new StringReader(csvFile.text);

        // , �ŕ�������s���ǂݍ���
        // ���X�g�ɒǉ����Ă���
        while (reader.Peek() != -1) // reader.Peaek��-1�ɂȂ�܂�
        {
            string line = reader.ReadLine(); // ��s���ǂݍ���
            csvDatas.Add(line.Split(',')); // , ��؂�Ń��X�g�ɒǉ�
        }

        return csvDatas;
    }
}
public class CSVInport
{
    TextAsset csvFile; // CSV�t�@�C��
    string csvFileName;
    List<string[]> csvDatas = new List<string[]>(); // CSV�̒��g�����郊�X�g;

    /// <summary>
    /// �t�H���_�w��()
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
