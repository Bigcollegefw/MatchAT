using UnityEngine;

[CreateAssetMenu(fileName = "GameConfig", menuName = "MatchThree/GameConfig")]
public class GameConfig : ScriptableObject
{
    public float gameDuration = 30f;
    public int targetScore = 5000;

    public int pointsMatch3 = 100;
    public int pointsMatch4 = 200;
    public int pointsMatch5 = 500;
    public float cascadeMultiplier = 1.5f;
}
