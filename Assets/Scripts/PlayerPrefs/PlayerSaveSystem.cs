using System.IO;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;

public static class PlayerSaveSystem
{

    public static void SavePlayer(WardrobeToggle wardrobeToggle)
    {
        BinaryFormatter formatter = new BinaryFormatter();

        string path = Application.persistentDataPath + "/taveplayerdata.tve";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(wardrobeToggle);

        formatter.Serialize(stream, data);
        stream.Close();

    }

    public static PlayerData LoadPlayer()
    {

        string path = Application.persistentDataPath + "/taveplayerdata.tve";
        //Debug.Log(Application.persistentDataPath);

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData data = formatter.Deserialize(stream) as PlayerData;

            stream.Close();

            return data;

        }
        else

        {

            WardrobeToggle wardrobeToggle = new WardrobeToggle();

            wardrobeToggle.SaveNewPlayer();

            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData data = formatter.Deserialize(stream) as PlayerData;

            stream.Close();

            return data;
        }
    }

}
