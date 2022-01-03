using System.IO;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem4
{

    public static void SavePlayer4(QuizManager4 quizManager4)
    {
        BinaryFormatter formatter = new BinaryFormatter();

        string path = Application.persistentDataPath + "/tavefloor4.tve";
        FileStream stream = new FileStream(path, FileMode.Create);

        FloorData4 data = new FloorData4(quizManager4);

        formatter.Serialize(stream, data);
        stream.Close();

    }

    public static FloorData4 LoadPlayer4()
    {

        string path = Application.persistentDataPath + "/tavefloor4.tve";
        //Debug.Log(Application.persistentDataPath);

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            FloorData4 data = formatter.Deserialize(stream) as FloorData4;

            stream.Close();

            return data;

        }
        else

        {
            QuizManager4 quizManager4 = new QuizManager4();
            quizManager4.SavePlayerReset4();

            //Debug.LogError("Save File not found in " + path);

            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            FloorData4 data = formatter.Deserialize(stream) as FloorData4;

            stream.Close();

            return data;
        }
    }

}
