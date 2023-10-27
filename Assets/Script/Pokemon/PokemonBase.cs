using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Pokemon", menuName ="Pokemon/Create new Pokemon")]

public class PokemonBase : ScriptableObject 
{
    [SerializeField] string name;


    [TextArea]
    [SerializeField] string description;

     [SerializeField] Sprite frontSprite;
    [SerializeField] Sprite backSprite;

    [SerializeField] PokemonType type1;
    [SerializeField] PokemonType type2;

    //Base stats
    [SerializeField] int maxHP;
    [SerializeField] int attack;
    [SerializeField] int defense;
    [SerializeField] int spAttack;
    [SerializeField] int spDefense;
    [SerializeField] int speed;
    //skill
    [SerializeField] List<LeanrnableMove> leanrnableMoves;

    public string Name
    {
        get { return name; }
    }

    public string Description
    {
        get { return description; }
    }
    public Sprite BackSprite
    {
        get { return backSprite; }
    }
    public Sprite FrontSprite
    {
        get { return frontSprite; }
    }
    //
    public int MaxHp
    {
        get { return maxHP; }
    }
    public int Attack
    {
        get { return attack; }
    }
    public int Defense
    {
        get { return defense; }
    }
    public int SpAttack
    {
        get { return spAttack; }
    }
    public int SpDefense
    {
        get { return spDefense; }
    }
    public int Speed
    {
        get { return speed; }
    }

    public List<LeanrnableMove> LeanrnableMoves
    {
        get { return leanrnableMoves; }
    }
    public PokemonType Type1
    {
        get { return type1; }
    }
    public PokemonType Type2
    {
        get { return type2; }
    }
}


[System.Serializable]

public class LeanrnableMove
{
    [SerializeField] MoveBase moveBase;
    [SerializeField] int level;

    public MoveBase Base
    {
        get { return moveBase; }
    }
    public int Level
    {
        get { return level; }
    }
}



public enum PokemonType
{
    None,
    Normal,
    Fire,
    Water,
    Electric,
    Grass,
    Ice,
    Fighting,
    Poison,
    Ground,
    Flying,
    Psychi,
    Bug,
    Rock,
    Ghost,
    Dragon
}
public class TypeChart
{
    static float[][] chart =
    {
        //                   NOR  FIR  WAT   ELE   GRA  ICE  PIG  POI
        /*NOR*/ new float[]{ 1f,  1f,   1f,   1f,  1f,  1f,  1f,  1f },
        /*FIR*/ new float[]{ 1f, 0.5f, 0.5f,  1f,  2f,  2f,  1f,  1f },
        /*WAT*/ new float[]{ 1f,  2f,  0.5f,  2f, 0.5f, 1f,  1f,  1f },
        /*ELE*/ new float[]{ 1f,  1f,   2f,  0.5f,0.5f, 2f,  1f,  1f },
        /*GRS*/ new float[]{ 1f, 0.5f,  2f,   2f, 0.5f, 1f,  1f, 0.5f },
        /*POI*/ new float[]{ 1f,  1f,   1f,   1f,  2f,  1f,  1f,  1f }
    };

    public static float GetEffectiveness(PokemonType attackType, PokemonType defenseType)
    {
        if (attackType == PokemonType.None || defenseType == PokemonType.None)
            return 1;

        int row = (int)attackType - 1;
        int col = (int)defenseType - 1;

        return chart[row][col];
    }

}
