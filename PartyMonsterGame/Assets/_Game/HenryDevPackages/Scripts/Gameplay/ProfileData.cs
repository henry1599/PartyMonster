using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HenryDev.Utilities;
using UnityEngine.Pool;

namespace HenryDev.Gameplay
{
    [System.Serializable]
    public class ProfileData
    {
        public List<LevelSaveData> UnlockedLevels;
        public ProfileData()
        {
            UnlockedLevels = new List<LevelSaveData>()
            {
                new LevelSaveData(1, 1)
            };
        }
        public LevelSaveData GetLevelSaveData(int chapter, int level)
        {
            foreach (var unlockedLevel in UnlockedLevels)
            {
                if (unlockedLevel.ChapterID == chapter && unlockedLevel.LevelID == level)
                    return unlockedLevel;
            }
            return null;
        }
    }
    [System.Serializable]
    public class LevelSaveData
    {
        public int ChapterID;
        public int LevelID;
        public int CollectedObjectsRequirement;
        public int CollectedObjectsCount;
        public LevelSaveData() {}
        public LevelSaveData(int chapter, int level)
        {
            ChapterID = chapter;
            LevelID = level;
        }
        public override bool Equals(object obj)
        {
            return ChapterID == (obj as LevelSaveData).ChapterID && LevelID == (obj as LevelSaveData).LevelID;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
