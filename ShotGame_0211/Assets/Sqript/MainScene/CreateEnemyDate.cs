using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class CreateEnemyDate 
{ 
    // 敵の生成用のデータ
    public struct CREATEENEMYDATE
    {
        public float    CreateTime;     // 敵の出現タイミング
        public Vector3  CreateVec;      // 敵の生成位置（X,Y）
        public int      EnemyValue;     // 敵の種類
        public int      isItem;         // アイテムの有無
    }

    //ENEMY構造体のcsvファイルを読み込む
    public static List<CREATEENEMYDATE> ENEMY_read_csv(string filePath)
    {
        //一時入力用で毎回初期化する構造体とリスト
        CREATEENEMYDATE ene = new CREATEENEMYDATE();
        List<CREATEENEMYDATE> ene_list = new List<CREATEENEMYDATE>();

        //ResourcesからCSVを読み込むのに必要
        TextAsset csvFile;

        //読み込んだCSVファイルを格納
        List<string[]> csvDatas = new List<string[]>();

        //CSVファイルの行数を格納
        int height = 0;

        //for文用。一行目は読み込まない
        int i = 1;

        /* Resouces/CSV下のCSV読み込み */
        csvFile = Resources.Load(filePath) as TextAsset;
        //読み込んだテキストをString型にして格納
        StringReader reader = new StringReader(csvFile.text);
        while (reader.Peek() > -1)
        {
            string line = reader.ReadLine();
            // ,で区切ってCSVに格納
            csvDatas.Add(line.Split(','));
            height++; // 行数加算
        }
        for (i = 1; i < height; i++)
        {
            //[i]は行数。[0]~[6]は列数
            //csvDatasはString型なのでそのまま格納できる
            ene.CreateTime  = Convert.ToSingle(csvDatas[i][0]); 
            ene.CreateVec.x = Convert.ToSingle(csvDatas[i][1]);
            ene.CreateVec.y = Convert.ToSingle(csvDatas[i][2]);
            ene.CreateVec.z = 0;
            ene.EnemyValue  = (int)Convert.ToSingle(csvDatas[i][3]);
            ene.isItem      = (int)Convert.ToSingle(csvDatas[i][4]);

            //戻り値のリストに加える
            ene_list.Add(ene);
        }

        return ene_list;
    }
}
