using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{

	public static int Money;
	public int startMoney;

	public static int LIFE;
	public int startLIFE;

	public static int Rounds;

	void Start()
	{
		Money = startMoney;
		LIFE = startLIFE;

		Rounds = 0;
	}
}
