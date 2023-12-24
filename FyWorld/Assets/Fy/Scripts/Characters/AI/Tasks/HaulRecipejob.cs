/*
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
| FyWorld - A top down simulation game in a fantasy medieval world.    |
|                                                                      |
|    :copyright: © 2019 Florian Gasquez.                               |
|    :license: GPLv3, see LICENSE for more details.                    |
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
*/
using System.Collections.Generic;
using Fy.Entities;
using Fy.Characters;
using Fy.Definitions;

namespace Fy.Characters.AI {
	// what is haul
	// haul is a job that will take a tilable and put it in the inventory
	// 「Haul」は英語で「運ぶ」や「引きずる」などの意味を持つ単語です。
	// プログラミングの文脈では、特定のタスクを遂行するためにアイテムを一か所から別の場所に運ぶことを指すことが多いです。
	public class HaulRecipeJob : JobClass {
		public HaulRecipeJob(BaseCharacter character, Task task) : base(character, task) {
			this.jobs = HaulRecipeJob.Haul(character, task);
			this.OnEnd += this.character.DropOnTheFloor;
			this.Next(false);
		}

		public static Queue<Job> Haul(BaseCharacter character, Task task) {
			Queue<Job> jobs = new Queue<Job>();
			Job let = new Job(
				delegate {
					return character.inventory.count > 0;
				}
			);

			// 説明
			// このジョブは、キャラクターがアイテムを持っている場合にのみ実行されます。
			let.OnEnd = delegate {
				// 説明
				// キャラクターがアイテムを持っている場合、そのアイテムを建物に置きます。
				Building building = (Building)Loki.map.GetTilableAt(task.targets.current.position, Layer.Building);
				Recipe recipe = building.recipe;

				if (recipe.needs[character.inventory.def].full == false) {
					// 説明
					// キャラクターが持っているアイテムを建物に置きます。
					character.inventory.TransfertTo(recipe.needs[character.inventory.def], recipe.needs[character.inventory.def].max);
				}
			};

			HaulResult res = HaulJob.Get(character, task, character.inventory.free);
			jobs.Enqueue(res.get);

			// 説明
			// タスクのターゲットをループします。
			List<Target> targetList = task.targets.ToList();
			foreach (Target target in targetList) {
				// 説明
				// ターゲットがスタック可能な場合、キャラクターはスタック可能なアイテムを取得します。
				if (target.tilable is Stackable) {
					// 説明
					res = HaulJob.Get(character, task, character.inventory.free);
					jobs.Enqueue(res.get);
				} else {
					jobs.Enqueue(let);
				}
			}

			return jobs;
		}
	}
}
