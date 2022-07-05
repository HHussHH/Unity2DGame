using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleHUDs : MonoBehaviour
{
	
		public Text nameText;
		public Slider hpSlider;

		public void SetHUD(Units unit)
		{
			nameText.text = unit.unitName;
			hpSlider.maxValue = unit.maxHP;
			hpSlider.value = unit.currentHP;
		}

		public void SetHP(int hp)
		{
			hpSlider.value = hp;
		}


}
