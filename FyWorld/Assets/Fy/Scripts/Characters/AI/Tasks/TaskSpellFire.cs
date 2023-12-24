using System.Collections.Generic;
using Fy.Entities;
using Fy.World;
using UnityEngine;

namespace Fy.Characters.AI
{
    public class TaskSpellFire : TaskClass
    {
        public TaskSpellFire(BaseCharacter character, Task task) : base(character, task) { }

        public override bool Perform()
        {
            if (this.character == null)
            {
                Debug.LogError("Character is null");
                return false;
            }
            CustomDebug.Log(character + ": Spell fire");
            // get target tileable from sowLinear

            Loki.effect.Spawn("fire", this.character.position);

            return true;
        }
    }
}