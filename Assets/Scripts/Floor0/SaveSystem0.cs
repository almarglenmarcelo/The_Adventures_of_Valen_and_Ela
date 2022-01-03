using System.IO;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem0
{

    public static void SavePlayer0(QuizManager0 quizManager0)
    {
        BinaryFormatter formatter = new BinaryFormatter();

        string path = Application.persistentDataPath + "/tavefloor0.tve";
        FileStream stream = new FileStream(path, FileMode.Create);

        FloorData0 data = new FloorData0(quizManager0);

        formatter.Serialize(stream, data);
        stream.Close();

    }

    public static FloorData0 LoadPlayer0()
    {

        string path = Application.persistentDataPath + "/tavefloor0.tve";
       // Debug.Log(Application.persistentDataPath);

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            FloorData0 data = formatter.Deserialize(stream) as FloorData0;

            stream.Close();

            return data;

        }
        else

        {
            QuizManager0 quizManager0 = new QuizManager0();
            quizManager0.SavePlayerReset0();

            //Debug.LogError("Save File not found in " + path);

            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            FloorData0 data = formatter.Deserialize(stream) as FloorData0;

            stream.Close();

            return data;
        }
    }

}
