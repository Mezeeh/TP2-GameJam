using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionLevel
{

	public static int buts = 0;
	public static int vies = 3;
	public static int level = 1;
	public static bool victorieux = false;

	public static void reset()
	{
		buts = 0;
		vies = 3;
		level = 1;
		victorieux = false;
	}
}
