using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityTypes
{
    public enum UnityLayer
    {
        Default = 0,
        TransparentFX = 1,
        IgnoreRaycast = 2,
        Water = 4,
        UI = 5,
        Player = 10,
        NonPlayer = 11,
        Terrain = 20
    }

    public enum UnityTags
    {
        Untagged,
        Respawn,
        Finish,
        EditorOnly,
        MainCamera,
        Player,
        GameController,
        Canvas,
        Task,
        Terrain,
        TaskSelection,
        InteractUi,
        Tasks,
        PreviewTask,
        BossCamera,
        Enemy
    }

    public enum UnityScenes
    {
        StartMenu,
        Hub,
        Minotaur
    }
    
}