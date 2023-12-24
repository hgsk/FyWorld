using UnityEngine;
using Fy.Helpers;
using System.Collections.Generic;
using System.Collections;

namespace Fy.Visuals
{
	public class EffectController : MonoBehaviour
	{
		public ParticleSystem particleSystemPrefab;
		private Queue<ParticleSystem> particleSystemPool = new Queue<ParticleSystem>();

		internal void Spawn(string v, Vector2Int position)
		{
			ParticleSystem particleSystem;

			// プールからパーティクルシステムを取得、なければ新規作成
			if (particleSystemPool.Count > 0)
			{
				particleSystem = particleSystemPool.Dequeue();
				particleSystem.transform.position = new Vector3(position.x, position.y, 0);
			}
			else
			{
				ParticleSystem particleSystemInstance = Instantiate(particleSystemPrefab, new Vector3(position.x, position.y, 0), Quaternion.identity);
				particleSystem = particleSystemInstance.GetComponent<ParticleSystem>();
			}

			// パーティクルシステムを開始
			var main = particleSystem.main;
			main.duration = 1f;

			// パーティクルシステムの再利用をスケジュール
			StartCoroutine(RecycleParticleSystem(particleSystem));
		}

		private IEnumerator RecycleParticleSystem(ParticleSystem particleSystem)
		{
			// パーティクルシステムの再生が終了するまで待つ
			yield return new WaitWhile(() => particleSystem.isPlaying);

			// パーティクルシステムをプールに戻す
			particleSystemPool.Enqueue(particleSystem);
		}

	}
}