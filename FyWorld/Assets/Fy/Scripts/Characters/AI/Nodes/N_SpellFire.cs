/*
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
| FyWorld - A top down simulation game in a fantasy medieval world.    |
|                                                                      |
|    :copyright: © 2019 Florian Gasquez.                               |
|    :license: GPLv3, see LICENSE for more details.                    |
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
*/
using UnityEngine;
using System;
using Fy.Definitions;
using Fy.World;

namespace Fy.Characters.AI {
    // |------------> Spell ---------> Fire
    // []**[]
    // **()**
    // []**[]
	public class N_SpellFire : BrainNode {
        public override Task GetTask() {
            return new Task(
                Defs.tasks["task_spell_fire"],
                new TargetList(Target.GetRandomTargetInRange(this.character.position, 3)),
                UnityEngine.Random.Range(100, 250)
            );
        }
	}
}