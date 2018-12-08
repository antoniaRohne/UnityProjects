using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Boost")]
public class Boost : ScriptableObject
{
	public long Duration;
	public float Factor;
	public float Costs;
	public Sprite Icon;
}
