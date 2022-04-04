using System.IO;
using Newtonsoft.Json;
using UnityEngine;

namespace DefaultNamespace
{
    public static class SaveLoadController
    {
        private const string PLAYER_PATH = "/player_save.json";
        private const string GAME_PATH = "/game_save.json";


        public static void SaveData(object [] data)
        {
            var json = JsonConvert.SerializeObject(data[0], Formatting.Indented);
            File.WriteAllText(Application.dataPath + PLAYER_PATH, json);
            json = JsonConvert.SerializeObject(data[1], Formatting.Indented);
            File.WriteAllText(Application.dataPath + GAME_PATH, json);
            
            //Debug.Log(Application.dataPath + PLAYER_PATH + " "+ json);
        }

        public static PlayerStatusModel LoadPlayerData()
        {
            var file = File.ReadAllText(Application.dataPath + PLAYER_PATH);
            return JsonConvert.DeserializeObject<PlayerStatusModel>(file);
        }
        
        public static GameModel LoadGameData()
        {
            var file = File.ReadAllText(Application.dataPath + GAME_PATH);
            return JsonConvert.DeserializeObject<GameModel>(file);
        }
    }
}