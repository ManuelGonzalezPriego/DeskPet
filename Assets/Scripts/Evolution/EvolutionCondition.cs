using System.Collections.Generic;

[System.Serializable]
public class EvolutionCondition
{
    public int? min;
    public int? max;
    public Gender gender;
}

[System.Serializable]
public class Evolution
{
    public string target;
    public EvolutionCondition conditions;
}

[System.Serializable]
public class EvolutionNode
{
    public string id;
    public string spritePath;
    public List<Evolution> evolutions;
}

[System.Serializable]
public class EvolutionTree
{
    public List<EvolutionNode> nodes;
}
