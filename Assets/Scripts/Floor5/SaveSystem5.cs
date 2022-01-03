using System.IO;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem5
{

    public static void SavePlayer5(QuizManager5 quizManager5)
    {
        BinaryFormatter formatter = new BinaryFormatter();

        string path = Application.persistentDataPath + "/tavefloor5.tve";
        FileStream stream = new FileStream(path, FileMode.Create);

        FloorData5 data = new FloorData5(quizManager5);

        formatter.Serialize(stream, data);
        stream.Close();

    }

    public static FloorData5 LoadPlayer5()
    {

        string path = Application.persistentDataPath + "/tavefloor5.tve";
        //Debug.Log(Application.persistentDataPath);

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            FloorData5 data = formatter.Deserialize(stream) as FloorData5;

            stream.Close();

            return data;

        }
        else

        {
            QuizManager5 quizManager5 = new QuizManager5();
            quizManager5.SavePlayerReset5();

            //Debug.LogError("Save File not found in " + path);

            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            FloorData5 data = formatter.Deserialize(stream) as FloorData5;

            stream.Close();

            return data;
        }
    }

}
