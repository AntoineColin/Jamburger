using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utilities : MonoBehaviour {

	// Utility functions
	public static bool TernaryXor(bool a, bool b, bool c)
	{
		//return ((a && !b && !c) || (!a && b && !c) || (!a && !b && c));

		// taking into account Jim Mischel's comment, a faster solution would be:
		return (!a && (b ^ c)) || (a && !(b || c));
	}
	
}