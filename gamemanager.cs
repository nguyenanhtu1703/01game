using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gamemanager : MonoBehaviour {

	// Use this for initializationpublic 
	public string[] countries = {
		"AFGHANISTAN",
		"ALBANIA",
		"ALGERIA",
		"ANDORRA",
		"ANGOLA",
		"ANTIGUA",
		"ARGENTINA",
		"ARMENIA",
		"AUSTRALIA",
		"AUSTRIA",
		"AZERBAIJAN",

		"BAHAMAS",
		"BAHRAIN",
		"BANGLADESH",
		"BARBADOS",
		"BELARUS",
		"BELGIUM",
		"BELIZE",
		"BENIN",
		"BHUTAN",
		"BOLIVIA",
		"BOSNIA",
		"BOTSWANA",
		"BRAZIL",
		"BRUNEI",
		"BULGARIA",
		"BURKINA FASO",
		"BURUNDI",

		"CABO VERDE",
		"CAMBODIA",
		"CAMEROON",
		"CANADA",
		"CAR",
		"CHAD",
		"CHILE",
		"CHINA",
		"COLOMBIA",
		"COMOROS",
		"DEMOCRATIC CONGO",
		"REPUBLIC CONGO",
		"COSTA RICA",
		"COTE D'IVOIRE",
		"CROATIA",
		"CUBA",
		"CYPRUS",
		"CZECH REPUBLIC",

		"DENMARK",
		"DJIBOUTI",
		"DOMINICA",
		"DOMINICAN REPUBLIC",

		"ECUADOR",
		"EGYPT",
		"EL SALVADOR",
		"EQUATORIAL GUINEA",
		"ERITREA",
		"ESTONIA",
		"ETHIOPIA",

		"FIJI",
		"FINLAND",
		"FRANCE",

		"GABON",
		"GAMBIA",
		"GEORGIA",
		"GERMANY",
		"GHANA",
		"GREECE",
		"GRENADA",
		"GUATEMALA",
		"GUINEA",
		"GUINEA-BISSAU",
		"GUYANA",

		"HAITI",
		"HONDURAS",
		"HUNGARY",

		"ICELAND",
		"INDIA",
		"INDONESIA",
		"IRAN",
		"IRAQ",
		"IRELAND",
		"ISRAEL",
		"ITALY",

		"JAMAICA",
		"JAPAN",
		"JORDAN",

		"KAZAKHSTAN",
		"KENYA",
		"KIRIBATI",
		"KOSOVO",
		"KUWAIT",
		"KYRGYZSTAN",

		"LAOS",
		"LATVIA",
		"LEBANON",
		"LESOTHO",
		"LIBERIA",
		"LIBYA",
		"LIECHTENSTEIN",
		"LITHUANIA",
		"LUXEMBOURG",

		"MACEDONIA",
		"MADAGASCAR",
		"MALAWI",
		"MALAYSIA",
		"MALDIVES",
		"MALI",
		"MALTA",
		"MARSHALL ISLANDS",
		"MAURITANIA",
		"MAURITIUS",
		"MEXICO",
		"MICRONESIA",
		"MOLDOVA",
		"MONACO",
		"MONGOLIA",
		"MONTENEGRO",
		"MOROCCO",
		"MOZAMBIQUE",
		"MYANMAR",

		"NAMIBIA",
		"NAURU",
		"NEPAL",
		"NETHERLANDS",
		"NEW ZEALAND",
		"NICARAQUA",
		"NIGER",
		"NIGERIA",
		"NORTH KOREA",
		"NORWAY",

		"OMAN",

		"PAKISTAN",
		"PALAU",
		"PALESTINE",
		"PANAMA",
		"PAPUA NEW GUINEA",
		"PARAGUAY",
		"PERU",
		"PHILIPPINES",
		"POLAND",
		"PORTUGAL",

		"QATAR",

		"ROMANIA",
		"RUSSIA",
		"RWANDA",

		"SAINT KITTS",
		"SAINT LUCIA",
		"SAINT VINCENT",
		"SAMOA",
		"SAN MARINO",
		"SAO TOME AND PRINCIPE",
		"SAUDI ARABIA",
		"SENEGAL",
		"SERBIA",
		"SEYCHELLES",
		"SIERRA LEONE",
		"SINGAPORE",
		"SLOVAKIA",
		"SLOVENIA",
		"SOLOMON ISLANDS",
		"SOMALIA",
		"SOUTH AFRICA",
		"SOUTH KOREA",
		"SOUTH SUDAN",
		"SPAIN",
		"SRI LANKA",
		"SUDAN",
		"SURINAME",
		"SWAZILAND",
		"SWEDEN",
		"SWITZERLAND",
		"SYRIA",

		"TAIWAN",
		"TAJIKISTAN",
		"TANZANIA",
		"THAILAND",
		"TIMOR-LESTE",
		"TOGO",
		"TONGA",
		"TRINIDAD AND TOBAGO",
		"TUNISIA",
		"TURKEY",
		"TURKMENISTAN",
		"TUVALU",

		"UGANDA",
		"UKRAINE",
		"UAE",
		"UK",
		"USA",
		"URUGUAY",
		"UZBEKISTAN",

		"VANUATU",
		"VATICAN CITY",
		"VENEZUELA",
		"VIETNAM",

		"YEMEN",

		"ZAMBIA",
		"ZIMBABWE"
	};
	bool isstarted;
	public Text scoretxt, scorenow, scorenow2, myhighscore, myhighscore2, panel2moneyearnedtext,  numberoftrytext, loadingtext;
	public Text menuhighscoretext, menumoneyearnedtext;
	public GameObject statuspanel, infopanel, statuspanel2, agepanel;
	public GameObject GOOGLEADMOBS;
	public Text name1st, country1st, myname, mycountry, myage;
	public InputField mycountryinp;
	public Image flag;
	public Text t1, t2, myid;
	int moneyearned;
	int highestscore;
	int bought;
	public int totalmoney;
	public string identitycheck;
	public int whichdatabasecheck, whichpositioncheck;
	int score;
	public Text nameswrong;
	int enterinfo;
	int key1, key2, key3, key4, key5, key6, key7, key8, key9, key10, key11, key12, key13, scoreidentity, highestscoreidentity, moneynearnedidentity;
	int h1, h2, h3, h4, key21, key22, key23, key24, key25, key26, key27, key28, key29, key210, key211, key212, key213;
	int key31, key32, key33, key34, key35, key36, key37, key38, key39, key310, key311, key312, key313;
	public int  numberoftry,  numberoftry2, numofround, whichdatabase;
	public bool stop, firsttime, firsttime2 = false, win = false;
	public Text bonustext;
	public float timecounterbutton;
	public Text timecountertext, placeholdertxt;
	public bool didstartco;
	public bool kkk;
	public GameObject[] fx;
	public GameObject[] fx2;
	public Text wdtbtxt, wpsttxt, resulttxtcheck, totalmoneytxt;
	public GameObject votePanel, buttonDiamion, howToPlayPanel, randomFindingPanel, mainRandomFindingPanel;
	public int whoIAm;

	public static gamemanager instance = null;

	public int GetBought(){
		return bought;
	}

	public void OnChangedSlideValue(){
		foreach (Touch t in Input.touches) {
			if (t.phase == TouchPhase.Began) {
				audiomanager.instance.PLAYPOS ();
			}
		}
	}

	public void HowToPlay(){
		if (moneyearned <= 20) {
			howToPlayPanel.gameObject.SetActive (true);
			buttonDiamion.gameObject.SetActive (false);
		}
	}

	public void SetBought(int i){
		bought = i;
	}

	public void showEarn(){
		AdMobBannerInterstitial.instance.ShowBanner ();
	}

	public void showSimpleAds(){
		if (moneyearned <= 25)
			return;
		AdMobBannerInterstitial.instance.ShowBanner ();
	}

	void Awake(){
		stop = false;
		if (instance == null) {
			instance = this;
		} else {
			Destroy (this.gameObject);
		}
		DontDestroyOnLoad (this.gameObject);
	}

	public void showVotePanel(){
		if (moneyearned <= 50)
			return;
		if (PlayerPrefs.GetInt ("voted") == 1)
			return;
		votePanel.gameObject.SetActive (true);
	}

	public void voted(){
		PlayerPrefs.SetInt ("voted", 1);
	}

	public void Check(){
		if (wdtbtxt.text.Length < 1)
			return;
		if (wpsttxt.text.Length < 1)
			return;
		whichdatabasecheck = int.Parse (wdtbtxt.text);
		whichpositioncheck = int.Parse (wpsttxt.text);
		mydatabasecontroller.instance.Check ();
	}

	public void GetTotalMoneyAdmin(){
		mydatabasecontroller.instance.GetTotalMoney ();
	}

	public void SetHighScore(int ttt){
		highestscore = ttt;
	}

	public int GetHighScore(){
		return highestscore;
	}

	public void add100(){
		 numberoftry += 100;
		 numberoftrytext.text = numberoftry.ToString();
	}

	public void setfalse(){
		win = false;
	}

	void MakeRandom(){
		key1 = Random.Range (1, 1000);
		key2 = Random.Range (1, 1000);
		key3 = Random.Range (1, 1000);
		key4 = Random.Range (1, 1000);
		key5 = Random.Range (1, 1000);
		key6 = Random.Range (1, 1000);
		key7 = Random.Range (1, 1000);
		key8 = Random.Range (1, 1000);
		key9 = Random.Range (1, 1000);
		key10 = Random.Range (1, 1000);
		key11 = Random.Range (1, 1000);
		key12 = Random.Range (1, 1000);
		key13 = Random.Range (1, 1000);

		key21 = Random.Range (1, 1000);
		key22 = Random.Range (1, 1000);
		key23 = Random.Range (1, 1000);
		key24 = Random.Range (1, 1000);
		key25 = Random.Range (1, 1000);
		key26 = Random.Range (1, 1000);
		key27 = Random.Range (1, 1000);
		key28 = Random.Range (1, 1000);
		key29 = Random.Range (1, 1000);
		key210 = Random.Range (1, 1000);
		key211 = Random.Range (1, 1000);
		key212 = Random.Range (1, 1000);
		key213 = Random.Range (1, 1000);

		key31 = Random.Range (1, 1000);
		key32 = Random.Range (1, 1000);
		key33 = Random.Range (1, 1000);
		key34 = Random.Range (1, 1000);
		key35 = Random.Range (1, 1000);
		key36 = Random.Range (1, 1000);
		key37 = Random.Range (1, 1000);
		key38 = Random.Range (1, 1000);
		key39 = Random.Range (1, 1000);
		key310 = Random.Range (1, 1000);
		key311 = Random.Range (1, 1000);
		key312 = Random.Range (1, 1000);
		key313 = Random.Range (1, 1000);

	}

	public void SetSecurity1(){
		h1 = (key1 - key2 - key3 + key4 - key5 - key6 + key7 - key8 - key9 + key10 + key11 - key12 - key13) * 10000 * score % 1997;
	}

	public void SetSecurity2(){
		h2 = (key1 + key2 - key3 - key4 + key5 + key6 + key7 + key8 - key9 - key10 - key11 + key12 + key13) * 10000 * highestscore % 1995;
	}
	public void SetSecurity3(){
		h3 = (key1 + key2 - key3 - key4 - key5 + key6 - key7 + key8 - key9 - key10 + key11 + key12 + key13) * 10000 * moneyearned % 1991;
	}
	public void SetSecurity4(){
		h4 = (key1 + key2 + key3 - key4 - key5 + key6 + key7 + key8 - key9 - key10 + key11 - key12 + key13) * 10000 * bought % 1991;
	}

	public void CheckSecurity(){
		if (h1 != (key1 - key2 - key3 + key4 - key5 - key6 + key7 - key8 - key9 + key10 + key11 - key12 - key13) * 10000 * score % 1997){
			Debug.Log ("wow");
			Application.Quit ();
		}
		if (h2 != (key1 + key2 - key3 - key4 + key5 + key6 + key7 + key8 - key9 - key10 - key11 + key12 + key13) * 10000 * highestscore % 1995) {
			Debug.Log ("wow");
			Application.Quit ();
		}
		if (h3 != (key1 + key2 - key3 - key4 - key5 + key6 - key7 + key8 - key9 - key10 + key11 + key12 + key13) * 10000 * moneyearned % 1991) {
			Debug.Log ("wow");
			Application.Quit ();
		}
		if (h4 != (key1 + key2 + key3 - key4 - key5 + key6 + key7 + key8 - key9 - key10 + key11 - key12 + key13) * 10000 * bought % 1991) {
			Debug.Log ("wow");
			Application.Quit ();
		}
	}

	public void SetUI(){
		menumoneyearnedtext.text = System.Math.Round (moneyearned * 0.1f, 1).ToString () +  "$";
	}

	public void SetAll(){
		SetSecurity1();
		SetSecurity2 ();
		SetSecurity3 ();
		SetSecurity4 ();
	}

	void Start () {
		score = 0;
		highestscore = 0;
		moneyearned = 0;
		bought = 0;
		kkk = true;
		MakeRandom ();
		SetAll ();

		int ismyfirstime = PlayerPrefs.GetInt ("my1stime");
		if (ismyfirstime == 0) {
			numberoftry2 = 6;
			myname.text = "Player" + Random.Range (0, 1000000);
			name1st.text = myname.text;
			placeholdertxt.text = myname.text;
			PlayerPrefs.SetInt ("noft2", numberoftry2);
			numofround = 10;
			firsttime = true;
			firsttime2 = true;
			menuhighscoretext.text = "0";
			menumoneyearnedtext.text = "0.0$";
			whichdatabase = Random.Range (1, 10);
			infopanel.gameObject.SetActive (true);
			numberoftry = 0;
			mydatabasecontroller.instance.TakeAPlace ();
			bonustext.text = "This is your first time, We give you 1$ bonus, and today 500 rounds";
		} else {
			menumoneyearnedtext.text = "0.0$";
			numberoftry2 = PlayerPrefs.GetInt ("noft2");
			numberoftry = PlayerPrefs.GetInt ("noft");
			numberoftrytext.text = numberoftry.ToString ();
			firsttime = false;
			numofround = 10;
			myname.text = PlayerPrefs.GetString ("myname");
			mycountry.text = "- " + PlayerPrefs.GetString ("mycountry");
			if (PlayerPrefs.GetInt ("pos1") == 0) {
				whichdatabase = Random.Range (1, 10);
				mydatabasecontroller.instance.TakeAPlace ();
				mydatabasecontroller.instance.RegisterStuff_RegisterButtonPressed(myname.text + "^$" + myid.ToString(), myid.ToString());
			} else mydatabasecontroller.instance.LoginStuff_LoginButtonPressed (myname.text + "^$" + PlayerPrefs.GetInt("myid").ToString(), PlayerPrefs.GetInt("myid").ToString());
			infopanel.gameObject.SetActive (false);
		}
	}

	public void FindingRandomMatch(){
		StartCoroutine ("FindingRandomMatchCo");
	}

	IEnumerator FindingRandomMatchCo(){
		randomFindingPanel.gameObject.SetActive (true);
		yield return new WaitForSeconds (0.3f);
		MultiplayerManager.instance.ReSet ();
		MultiplayerManager.instance.IWILLFINDRANDOM ();
	}

	public void startgame(){
		isstarted = true;
		score = 0;
		SetSecurity1 ();
		enterinfo = 0;
	}

	IEnumerator namesWrong(){
       if (string.Compare (country1st.text, "YOUR COUNTRY") != 0) {
			if (string.Compare (myage.text, "YOUR AGE") == 0) {
				nameswrong.text = "You must choose your age!";
			}
		} else {
				nameswrong.text = "You must choose your country";
		}
		nameswrong.gameObject.SetActive (true);
		yield return new WaitForSeconds (2);
		nameswrong.gameObject.GetComponent<Text> ().CrossFadeAlpha (0, 1, true);
		yield return new WaitForSeconds (1);
		nameswrong.gameObject.SetActive (false);
	}

	public void done(){
		if (string.Compare(country1st.text, "YOUR COUNTRY") == 0 || string.Compare(myage.text, "YOUR AGE") == 0 ) {
			StartCoroutine ("namesWrong");
		} else {
			if (myage.text [myage.text.Length - 1] > '9' || myage.text [myage.text.Length - 1] < '0') {
				//agepanel.gameObject.SetActive (true);
			} else {
				int age = int.Parse (myage.text);
				if (age <= -1) {
					agepanel.gameObject.SetActive (true);
					return;
				}
			}
			infopanel.gameObject.SetActive (false);
			PlayerPrefs.SetInt ("my1stime", 1);;
			PlayerPrefs.SetInt ("myid", Random.Range (0, 99999999));
			int myid = PlayerPrefs.GetInt ("myid");
			if (name1st.text.Length > 1) myname.text = name1st.text;
			mycountry.text = "- " + country1st.text;
			PlayerPrefs.SetString ("myname", myname.text);
			PlayerPrefs.SetString ("mycountry", country1st.text);
			mydatabasecontroller.instance.RegisterStuff_RegisterButtonPressed(myname.text + "^$" + myid.ToString(), myid.ToString());
		}
	}

	public void settimeocounterbuton(){
	}

	IEnumerator showtext(){
		timecountertext.gameObject.SetActive (true);
		yield return new WaitForSeconds (0.5f);
		timecountertext.gameObject.SetActive (false);
	}

	public void Quit(){
		Application.Quit ();
	}

	public int GetMoney(){
		return moneyearned;
	}

	public void SetMoney(int tmp){
		moneyearned = tmp;
	}

	string modifyname(string tmp){
		string result = "";
		for (int i = 0; i <= tmp.Length - 1; i++)
			if (tmp [i] >= 'a' && tmp[i] <= 'z')
				result = result +(tmp[i] - 32).ToString();
			else result = result + tmp [i].ToString ();
		return result;

	}

	string modify(string tmp){
		string result = "";
		for (int i = 0; i <= tmp.Length - 1; i++)
			if (tmp [i] == ' ')
				result = result + "+";
			else if((int)tmp[i] > 250) 
				result = result + "@";
			else
				result = result + tmp [i].ToString ();
		return result;
	}

	void modifyf2(){
		numberoftry2 = 50;
	}

	public void pressed0(){
		if ( numberoftry <= 0) {
			kkk = false;
			audiomanager.instance.PLAYNEG ();
			return;
		}
		if (( numberoftry == 485 && score <= 6) || ( numberoftry2 == 4 && score <= 6) || (Random.Range (0, 1f) < 0.5f)) {
			audiomanager.instance.PLAYPOS ();
			settimeocounterbuton ();

			CheckSecurity ();
			score++;
			SetSecurity1 ();
		} else {
			kkk = false;
			numberoftry--;
			PlayerPrefs.SetInt ("noft", numberoftry);

			numberoftry2--;
			numofround--;
			if (numberoftry2 <= 0)
				modifyf2 ();

			PlayerPrefs.SetInt ("noft2",  numberoftry2);
			numberoftrytext.text = numberoftry.ToString ();

			CheckSecurity ();
			if (score <= 6) {
				if (score > highestscore) {
					highestscore = score;
					SetSecurity2 ();

					audiomanager.instance.PLAYYELL ();
					statuspanel2.gameObject.SetActive (true);
					scorenow2.text = score.ToString ();
					myhighscore2.text = highestscore.ToString ();
					menuhighscoretext.text = highestscore.ToString ();
					panel2moneyearnedtext.text = "0$";
					menumoneyearnedtext.text = System.Math.Round (moneyearned * 0.1f, 1).ToString () + "$";

					CheckSecurity ();
					mydatabasecontroller.instance.Save ();
				} else {
					audiomanager.instance.PLAYDIS ();
					statuspanel.gameObject.SetActive (true);
					scorenow.text = score.ToString ();
					myhighscore.text = highestscore.ToString ();
					menuhighscoretext.text = highestscore.ToString ();
					menumoneyearnedtext.text = System.Math.Round (moneyearned * 0.1f, 1).ToString () +  "$";
				}
			} else {
				win = true;
				audiomanager.instance.PLAYYELL ();
				statuspanel2.gameObject.SetActive (true);
				scorenow2.text = score.ToString ();

				CheckSecurity ();
				if (score > highestscore) {
					highestscore = score;
					SetSecurity2 ();
				}

				myhighscore2.text = highestscore.ToString ();
				menuhighscoretext.text = highestscore.ToString ();

				panel2moneyearnedtext.text = estimated();
				SetSecurity3 ();
			
				menumoneyearnedtext.text = System.Math.Round (moneyearned * 0.1f, 2).ToString () + "$";

				CheckSecurity ();
				mydatabasecontroller.instance.Save ();
			}
		}
	}
		
	public void watch() {
		if (numofround == 0) {
			numofround = 10;
		}
	}

	public void pressed1(){
		if (numberoftry <= 0) {
			kkk = false;
			audiomanager.instance.PLAYNEG ();
			return;
		}
		if ((numberoftry == 485 && score <= 6) || (numberoftry2 == 4 && score <= 6) || (Random.Range (0, 1f) < 0.5f)) {
			audiomanager.instance.PLAYPOS ();

			CheckSecurity ();
			score++;
			SetSecurity1 ();

			settimeocounterbuton ();
		} else {
			kkk = false;
		//	AdMobBanner.instance.ShowBanner ();
			numberoftry--;
			PlayerPrefs.SetInt ("noft", numberoftry);

			numberoftry2--;
			if (numberoftry2 <= 0)
				modifyf2 ();
			
			numofround--;

			PlayerPrefs.SetInt ("noft2", numberoftry2);
		    numberoftrytext.text = numberoftry.ToString ();
			if (score <= 6) {
				if (score > highestscore) {
					
					CheckSecurity ();
					highestscore = score;
					SetSecurity2 ();

					CheckSecurity ();
					mydatabasecontroller.instance.Save ();

				    audiomanager.instance.PLAYYELL ();
					statuspanel2.gameObject.SetActive (true);
					scorenow2.text = score.ToString ();
					myhighscore2.text = highestscore.ToString ();
					menuhighscoretext.text = highestscore.ToString ();
					panel2moneyearnedtext.text = "0$";
					menumoneyearnedtext.text = System.Math.Round (moneyearned * 0.1f, 1).ToString () + "$";

					CheckSecurity ();
					mydatabasecontroller.instance.Save ();
				} else {
					audiomanager.instance.PLAYDIS ();
					statuspanel.gameObject.SetActive (true);
					scorenow.text = score.ToString ();
					myhighscore.text = highestscore.ToString ();
					menuhighscoretext.text = highestscore.ToString ();
					menumoneyearnedtext.text = System.Math.Round (moneyearned * 0.1f, 1).ToString () + "$";
				}
			} else {
				win = true;
			    audiomanager.instance.PLAYYELL ();
				statuspanel2.gameObject.SetActive (true);
				scorenow2.text = score.ToString ();

				CheckSecurity ();
				if (score > highestscore) {
					highestscore = score;
					SetSecurity2 ();
				}

				myhighscore2.text = highestscore.ToString ();
				menuhighscoretext.text = highestscore.ToString ();
				panel2moneyearnedtext.text = estimated();




				SetSecurity3 ();
				CheckSecurity ();
				mydatabasecontroller.instance.Save ();

				menumoneyearnedtext.text = System.Math.Round (moneyearned * 0.1f, 1).ToString () + "$";
			}
		}
	}

	public void SetNOFT(int tmp){
		numberoftry = tmp;
	}

	public int GetNOFT(){
		return numberoftry;
	}

	string estimated(){
		if (score <= 8) {
			moneyearned += score - 6;
			return "0." + (score - 6).ToString() + "$";
		} else if (score == 9) {
			moneyearned += 4;
			return "0.4$";
		} if (score == 10) {
			moneyearned += 7;
			return "0.7$";
		} if (score == 11) {
			moneyearned += 10;
			return "1.0$";
		} if (score == 12) {
			moneyearned += 13;
			return "1.3$";
		} if (score == 13) {
			moneyearned += 17;
			return "1.7$";
		} else {
			moneyearned += 30;
			return "3.0$";
		}
	}

	void Update () {

		CheckSecurity ();
		
		if (Input.GetKeyDown (KeyCode.Escape)) {
			Application.Quit ();
		}
		scoretxt.text = score.ToString ();
	}
	public void quit(){
		Application.Quit ();
	}

	void OnApplicationQuit(){
		//PlayerPrefs.SetInt ("// numberoftry", // numberoftry);
	}

	public void showid(){
		myid.text = PlayerPrefs.GetInt ("myid").ToString();
		myid.gameObject.SetActive (true);
	}


}
