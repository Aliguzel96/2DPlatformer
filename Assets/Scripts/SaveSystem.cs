using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveSystem
{

    public static void SavePlayer()
    {

        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream("player.bin", FileMode.Create);

        formatter.Serialize(stream, Data.score);
        stream.Close();

    }

    public static void LoadPlayer()
    {

        string dosyaAdi = "player.bin";
        if (File.Exists(dosyaAdi))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(dosyaAdi, FileMode.Open);

            Data.score = (int)formatter.Deserialize(stream);
            stream.Close();
        }

        else
        {
            Debug.LogError("DOSYA BULUNAMADI!!!");
        }


    }








}
