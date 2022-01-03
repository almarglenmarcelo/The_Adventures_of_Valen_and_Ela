using System.IO;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem7
{

    public static void SavePlayer7(QuizManager7 quizManager7)
    {
        BinaryFormatter formatter = new BinaryFormatter();

        string path = Application.persistentDataPath + "/tavefloor7.tve";
        FileStream stream = new FileStream(path, FileMode.Create);

        FloorData7 data = new FloorData7(quizManager7);

        formatter.Serialize(stream, data);
        stream.Close();

    }

    public static FloorData7 LoadPlayer7()
    {

        string path = Application.persistentDataPath + "/tavefloor7.tve";
        //Debug.Log(Application.persistentDataPath);

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            FloorData7 data = formatter.Deserialize(stream) as FloorData7;

            stream.Close();

            return data;

        }
        else

        {
            QuizManager7 quizManager7 = new QuizManager7();
            quizManager7.SavePlayerReset7();

            //Debug.LogError("Save File not found in " + path);

            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            FloorData7 data = formatter.Deserialize(stream) as FloorData7;

            stream.Close();

            return data;
        }
    }

}
