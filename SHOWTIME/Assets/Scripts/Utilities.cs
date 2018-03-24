using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utilities : MonoBehaviour {

	// Utility functions
	public static bool TernaryXor(bool a, bool b, bool c)
	{
		//return ((a && !b && !c) || (!a && b && !c) || (!a && !b && c));
		//shorted version of function.
		return (!a && (b ^ c)) || (a && !(b || c));
	}
	
}