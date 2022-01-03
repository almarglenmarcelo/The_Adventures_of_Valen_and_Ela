using System.IO;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem3
{

    public static void SavePlayer3(QuizManager3 quizManager3)
    {
        BinaryFormatter formatter = new BinaryFormatter();

        string path = Application.persistentDataPath + "/tavefloor3.tve";
        FileStream stream = new FileStream(path, FileMode.Create);

        FloorData3 data = new FloorData3(quizManager3);

        formatter.Serialize(stream, data);
        stream.Close();

    }

    public static FloorData3 LoadPlayer3()
    {

        string path = Application.persistentDataPath + "/tavefloor3.tve";
        //Debug.Log(Application.persistentDataPath);

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            FloorData3 data = formatter.Deserialize(stream) as FloorData3;

            stream.Close();

            return data;

        }
        else

        {
            QuizManager3 quizManager3 = new QuizManager3();
            quizManager3.SavePlayerReset3();

            //Debug.LogError("Save File not found in " + path);

            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            FloorData3 data = formatter.Deserialize(stream) as FloorData3;

            stream.Close();

            return data;
        }
    }

}
