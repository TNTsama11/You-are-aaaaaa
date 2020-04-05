using System;
using System.Collections.Generic;

[Serializable]
public class LevelCardData
{
    public List<LevelCard> LevelList;

    public LevelCardData()
    {
        LevelList= new List<LevelCard>();
    }
}

