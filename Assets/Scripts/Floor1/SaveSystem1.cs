using System.IO;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem1
{

    public static void SavePlayer1(QuizManager1 quizManager1)
    {
        BinaryFormatter formatter = new BinaryFormatter();

        string path = Application.persistentDataPath + "/tavefloor1.tve";
        FileStream stream = new FileStream(path, FileMode.Create);

        FloorData1 data = new FloorData1(quizManager1);

        formatter.Serialize(stream, data);
        stream.Close();

    }

    public static FloorData1 LoadPlayer1()
    {

        string path = Application.persistentDataPath + "/tavefloor1.tve";
        //Debug.Log(Application.persistentDataPath);

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            FloorData1 data = formatter.Deserialize(stream) as FloorData1;

            stream.Close();

            return data;

        }
        else

        {
            QuizManager1 quizManager1 = new QuizManager1();
            quizManager1.SavePlayerReset1();


            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            FloorData1 data = formatter.Deserialize(stream) as FloorData1;

            stream.Close();

            return data;
        }
    }

}
