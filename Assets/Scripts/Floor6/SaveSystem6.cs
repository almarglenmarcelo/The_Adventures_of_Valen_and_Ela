using System.IO;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem6
{

    public static void SavePlayer6(QuizManager6 quizManager6)
    {
        BinaryFormatter formatter = new BinaryFormatter();

        string path = Application.persistentDataPath + "/tavefloor6.tve";
        FileStream stream = new FileStream(path, FileMode.Create);

        FloorData6 data = new FloorData6(quizManager6);

        formatter.Serialize(stream, data);
        stream.Close();

    }

    public static FloorData6 LoadPlayer6()
    {

        string path = Application.persistentDataPath + "/tavefloor6.tve";
        //Debug.Log(Application.persistentDataPath);

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            FloorData6 data = formatter.Deserialize(stream) as FloorData6;

            stream.Close();

            return data;

        }
        else

        {
            QuizManager6 quizManager6 = new QuizManager6();
            quizManager6.SavePlayerReset6();

            //Debug.LogError("Save File not found in " + path);

            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            FloorData6 data = formatter.Deserialize(stream) as FloorData6;

            stream.Close();

            return data;
        }
    }

}
