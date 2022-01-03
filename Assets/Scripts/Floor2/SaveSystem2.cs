using System.IO;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem2
{

    public static void SavePlayer2(QuizManager2 quizManager2)
    {
        BinaryFormatter formatter = new BinaryFormatter();

        string path = Application.persistentDataPath + "/tavefloor2.tve";
        FileStream stream = new FileStream(path, FileMode.Create);

        FloorData2 data = new FloorData2(quizManager2);

        formatter.Serialize(stream, data);
        stream.Close();

    }

    public static FloorData2 LoadPlayer2()
    {

        string path = Application.persistentDataPath + "/tavefloor2.tve";
        //Debug.Log(Application.persistentDataPath);

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            FloorData2 data = formatter.Deserialize(stream) as FloorData2;

            stream.Close();

            return data;

        }
        else

        {
            QuizManager2 quizManager2 = new QuizManager2();
            quizManager2.SavePlayerReset2();

            //Debug.LogError("Save File not found in " + path);

            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            FloorData2 data = formatter.Deserialize(stream) as FloorData2;

            stream.Close();

            return data;
        }
    }

}
