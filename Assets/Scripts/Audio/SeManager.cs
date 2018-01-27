using UnityEngine;

namespace ggj2018
{
    public class SeManager : MonoSingleton<SeManager>
    {
		[SerializeField]
		private AudioSource sgoat;					//やぎ
		[SerializeField]
		private AudioSource sgoat2;					//怒っているやぎ
		[SerializeField]
		private AudioSource spigeon;				//ハタ
		[SerializeField]
		private AudioSource spigeon2;				//怒っているハタ
		[SerializeField]
		private AudioSource spenguin;				//ペンギン
		[SerializeField]
		private AudioSource spenguin2;				//怒っているペンギン
		[SerializeField]
		private AudioSource scat;					//猫
		[SerializeField]
		private AudioSource scat2;					//怒っている猫
		[SerializeField]
		private AudioSource sstage1Comp;			//ステージ１の完成SE[SerializeField]
		[SerializeField]
		private AudioSource sstage2Comp;			//ステージ１の完成SE
		[SerializeField]
		private AudioSource sstage3Comp;			//ステージ１の完成SE
		[SerializeField]
		private AudioSource sstage4Comp;			//ステージ１の完成SE
		[SerializeField]
		private AudioSource sstage3Heli;			//ヘリコプターSE
		[SerializeField]
		private AudioSource sstage3Poli;			//パトカーのサイレンSE
		[SerializeField]
		private AudioSource struck;					//トラック
		[SerializeField]
		private AudioSource scar;					//車
		[SerializeField]
		private AudioSource spolicecar;				//パトカー
		[SerializeField]
		private AudioSource scrashCar;				//車と衝突すると
		[SerializeField]
		private AudioSource scrashRival;			//ライバルと衝突すると
		[SerializeField]
		private AudioSource smenuSelect;			//何かを洗濯してボタンを押す音
		[SerializeField]
		private AudioSource sscreenChange;			//違うシーンになる音

			
		public void PlayGoat()
        {
			sgoat.Play ();
        }

		public void PlayAngryGoat()
		{
			sgoat2.Play ();
		}

		public void PlayPigeon()
		{
			spigeon.Play ();
		}

		public void PlayAngryPigeon()
		{
			spigeon2.Play ();
		}

		public void PlayPenguin()
		{
			spenguin.Play ();
		}

		public void PlayAngryPenguin()
		{
			spenguin2.Play ();
		}

		public void PlayCat()
		{
			scat.Play ();
		}

		public void PlayAngryCat()
		{
			scat.Play ();
		}

		public void PlayStageOneComplete()
		{
			sstage1Comp.Play ();
		}

		public void PlayStageTwoComplete()
		{
			sstage2Comp.Play ();
		}

		public void PlayStageThreeComplete()
		{
			sstage3Comp.Play ();
		}

		public void PlayStageFourComplete()
		{
			sstage4Comp.Play ();
		}

		public void PlayHeli()
		{
			sstage3Heli.Play ();
		}

		public void PlayStageThreePolice()
		{
			sstage3Poli.Play ();
		}

		public void PlayTruck()
		{
			struck.Play ();
		}

		public void PlayCar()
		{
			scar.Play ();
		}

		public void PlayPoliceCar()
		{
			spolicecar.Play ();
		}

		public void PlayCrashCar()
		{
			scrashCar.Play ();
		}

		public void PlayCrashRival()
		{
			scrashRival.Play ();
		}

		public void PlayMenuSelect()
		{
			smenuSelect.Play ();
		}

		public void PlayScreenChange()
		{
			sscreenChange.Play ();
		}

    }
}

