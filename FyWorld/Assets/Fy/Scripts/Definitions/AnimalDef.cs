/*
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
| FyWorld - A top down simulation game in a fantasy medieval world.    |
|                                                                      |
|    :copyright: © 2019 Florian Gasquez.                               |
|    :license: GPLv3, see LICENSE for more details.                    |
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
*/
using System.Collections.Generic;
using UnityEngine;

namespace Fy.Definitions {
	/// Definition for an animal

	[System.Serializable]
	public class LivingDef : Def {
		public string shortDesc;
		public GraphicDef graphics;
		// describe this class
		public override string ToString() {
			return string.Format(
				"AnimalDef: {0} - {1}",
				this.uid,
				this.shortDesc
			);
		}
	}

	[System.Serializable]
	public class AnimalDef : LivingDef {
		
	}
}