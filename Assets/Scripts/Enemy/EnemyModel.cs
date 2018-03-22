using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

namespace CCG
{
	public class EnemyModel
	{
		public EnemyModel(EnemyMaster master)
		{
			Name = master.Name;
			Health = master.Health;
		}

		public string Name { get; set; }
		public int Health { get; set; }

		public EnemyAIType AIType { get; private set; } = EnemyAIType.None;

		public ItemID[] DropItemIDs { get; private set; } = new ItemID[0];

		public ItemID GetDropItemIDAtRandom()
		{
			if (DropItemIDs == null) return ItemID.None;
			if (DropItemIDs.Length == 0) return ItemID.None;

			var random = UnityEngine.Random.Range(0, DropItemIDs.Length);
			return DropItemIDs[random];
		}
	}

	public class BadClass
	{
		public float A;
		public float B;
		public float C;

		// このクラス外からのみ参照、変更されており変数名も意味不明
		public bool g;

		// 一時変数名が適当
		public void Hage()
		{
			float d = 0;

			// dを引っ張り回して加算やらなんやら

			C += d;
		}

		// どこから出てきた変数a
		public void Hoge(Image unknownImage)
		{
			// privateなaは、この関数外でも変更される
			unknownImage.color = a;
		}

		// このあたりにつらつらと実装がある
		// このあたりにつらつらと実装がある
		// このあたりにつらつらと実装がある
		// このあたりにつらつらと実装がある
		// このあたりにつらつらと実装がある
		// このあたりにつらつらと実装がある
		// このあたりにつらつらと実装がある
		// このあたりにつらつらと実装がある
		// たくさんある
		// たくさんある
		// たくさんある
		// たくさんある
		// たくさんある
		// たくさんある
		// たくさんある
		// たくさんある
		// たくさんある

		Color a;
		public void Huge()
		{
			// なんとかかんとか
		}

		// マジックナンバー
		public void Huga(Transform tf)
		{
			tf.localScale = new Vector3(A * 5, B * 20, C * 20);
		}
	}
}