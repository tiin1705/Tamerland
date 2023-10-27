using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleHud : MonoBehaviour
{
    [SerializeField] Text NameText;
    [SerializeField] Text LevelText;
    [SerializeField] HPBar hpBar;

    Pokemon _pokemon;

    public void setData(Pokemon pokemon)
    {
        _pokemon = pokemon;
        NameText.text = pokemon.Base.Name;
        LevelText.text = "Lvl " + pokemon.Level;
        hpBar.setHP((float) pokemon.HP / pokemon.MaxHp);
    }

    public IEnumerator UpdateHP()
    {
        yield return hpBar.setHPsmooth((float)_pokemon.HP / _pokemon.MaxHp);
    }
}
