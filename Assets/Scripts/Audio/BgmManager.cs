using UnityEngine;

namespace ggj2018
{
    public class BgmManager : MonoSingleton<BgmManager>
    {

		[SerializeField]
		private AudioSource mainBGM;					//メインレベル
		[SerializeField]
		private AudioSource startBGM;					//スタート画面
		[SerializeField]
		private AudioSource charSelectBGM;			//キャラ洗濯画面
		[SerializeField]
		private AudioSource resultBGM;				//結果・評価画面
		[SerializeField]
		private AudioSource stage1Background;			//ステージ１背景音
		[SerializeField]
		private AudioSource stage2Background;			//ステージ２背景音
		[SerializeField]
		private AudioSource stage3Background;			//ステージ３背景音
		[SerializeField]
		private AudioSource stage4Background;			//ステージ４背景音


        public void PlayMainBGM()
        {
			mainBGM.Play ();
        }

		public void PlayStartMenu()
		{
			startBGM.Play ();
		}

		public void PlayCharSelect()
		{
			charSelectBGM.Play ();
		}

		public void ResultBGM()
		{
			resultBGM.Play ();
		}

		public void PlayStage1Background()
		{
			stage1Background.Play ();
		}

		public void PlayStage2Background()
		{
			stage2Background.Play ();
		}

		public void PlayStage3Background()
		{
			stage3Background.Play ();
		}

		public void PlayStage4Background()
		{
			stage4Background.Play ();
		}
    }
}

