/*
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
| FyWorld - A top down simulation game in a fantasy medieval world.    |
|                                                                      |
|    :copyright: © 2019 Florian Gasquez.                               |
|    :license: GPLv3, see LICENSE for more details.                    |
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
*/

using UnityEngine;

namespace Fy.Characters.AI {
    public class TaskSpellFire : TaskClass {
        public TaskSpellFire(BaseCharacter character, Task task) : base(character, task) {}

        public override bool Perform() {
            Debug.Log("Spell fire");
            
            return true;
        }
    }
}