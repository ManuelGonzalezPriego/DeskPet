using UnityEngine;

public class EvolutionLoader : MonoBehaviour
{
    public EvolutionTree LoadEvolutionTree()
    {
        TextAsset jsonText = Resources.Load<TextAsset>("Data/Pets/Pets");
        return JsonUtility.FromJson<EvolutionTree>(jsonText.text);
    }
}
