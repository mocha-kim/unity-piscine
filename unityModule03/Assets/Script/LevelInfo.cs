using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LevelInfo
{
    private struct _Info
    {
        public int enemyIndex;
        public int totalCount;
        public float spawnDuration;

        public _Info(int e, int t, float s)
        {
            enemyIndex = e;
            totalCount = t;
            spawnDuration = s;
        }
    }

    private static _Info[] _information = { new _Info(0, 10, 2.0f), new _Info(0, 20, 1.5f), new _Info(1, 15, 1.5f) };

    public static void GetInfo(int level, out int enemyIndex, out int totalCount, out float spawnDuration)
    {
        enemyIndex = _information[level].enemyIndex;
        totalCount = _information[level].totalCount;
        spawnDuration = _information[level].spawnDuration;
    }
}
