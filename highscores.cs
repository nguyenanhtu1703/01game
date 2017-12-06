using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class highscores : MonoBehaviour {
	string[] countries = {
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

	public string privateCode;
	public string privatecode1;
	public string p2 = "GxNa8QERq0mlIUgDe_qUaAqyIgFw8XSEO23GE7baI8hg";
	const string publicCode = "58bc05cd68fc0c0c4c89a42a";
	const string webURL = "http://dreamlo.com/lb/";

	public Highscore[] highscoresList;
	DisplayHighscores highscoreDisplay;
	public static highscores instance = null;
	public bool didupmyscore = false;
	public bool paymentrequestvar = false;
	public Text errorTxt;
	bool[] amiplay;
	int[] time, now;
	float[] earnremember;
	bool isAR, isSM = false;
	public GameObject tmp;
	public Text donetxt, uptxt, coldown;
	public Text email;
	public GameObject adminpanel;
	public GameObject buyingPanel;
	float tc;

	void Awake(){
		if (instance == null) {
			instance = this;
		} else if (instance != this) {
			Destroy (this.gameObject);
		}	
		highscoreDisplay = GetComponent<DisplayHighscores> ();
	}

	void Update(){
		tc -= Time.deltaTime;
		coldown.text = tc.ToString ();
	}

	public void RunIt2(){
		StartCoroutine (RunItCo(1));
	}

	public void RunIt(){
		StartCoroutine (RunItCo(0));
	}

	IEnumerator RunItCo(int d){
		if (d == 1) {
			for (int i = 1; i <= 189; i++) {
				float t = UnityEngine.Random.Range (8f, 15f);
				int earntmp = 0;
				string name, country;
				int em, hs;
				name = PlayerPrefs.GetString ("p" + i.ToString () + "nam");
				country = PlayerPrefs.GetString ("p" + i.ToString () + "cou");
				em = PlayerPrefs.GetInt ("p" + i.ToString () + "mon");
				hs = PlayerPrefs.GetInt ("p" + i.ToString () + "hs");
				if (t >= 8) {
					earntmp = 7;
				}
				if (t >= 10) {
					earntmp = 10;
				} 
				if (t >= 12) {
					earntmp = 13;
				} 	
				if (t >= 14) {
					earntmp = 15;
				} 
				em += earntmp;
				PlayerPrefs.SetInt ("p" + i.ToString () + "mon", em);
				PlayerPrefs.SetInt ("p" + i.ToString () + "hs", hs);
				Debug.Log (PlayerPrefs.GetString ("p" + i.ToString () + "nam") + " " + em + " " + hs);
			}
		}
		while (true) {
			isSM = true;
			tmp.gameObject.SetActive (true);
			tc = 60;
			yield return new WaitForSeconds (60f);

			for (int i = 1; i <= 189; i++) {

				float t = UnityEngine.Random.Range (-4f, 17f);
				int earntmp = 0;
				string name, country;
				int em, hs;

				name = PlayerPrefs.GetString ("p" + i.ToString () + "nam");
				country = PlayerPrefs.GetString ("p" + i.ToString () + "cou");
				em = PlayerPrefs.GetInt ("p" + i.ToString () + "mon");
				hs = PlayerPrefs.GetInt ("p" + i.ToString () + "hs");
				if (t >= -4) {
					earntmp = 1;
				} 
				if (t >= 4) {
					earntmp = 2;
				}
				if (t >= 6) {
					earntmp = 4;
				}
				if (t >= 8) {
					earntmp = 7;
				}
				if (t >= 10) {
					earntmp = 10;
				} 
				if (t >= 12) {
					earntmp = 13;
				} 	
				if (t >= 14) {
					earntmp = 15;
					hs = Math.Max (hs, UnityEngine.Random.Range (10, 12));
				} 
				if (t >= 16) {
					earntmp = 3;
					hs = Math.Max (hs, UnityEngine.Random.Range (13, 17));
				}
				if (t >= 16.6) {
					hs = Math.Max (hs, UnityEngine.Random.Range (15, 20));
				}
				if (t >= 16.8) {
					hs = Math.Max (hs, UnityEngine.Random.Range (15, 25));
				}

				em += earntmp;
				PlayerPrefs.SetInt ("p" + i.ToString () + "mon", em);
				PlayerPrefs.SetInt ("p" + i.ToString () + "hs", hs);
				Debug.Log (PlayerPrefs.GetString ("p" + i.ToString () + "nam") + " " + em + " " + hs);
			}
			//StartCoroutine (upscoreai());
			Debug.Log ("just up");

		}
		isSM = false;
		tmp.gameObject.SetActive (false);
	}

	public void requestpayment(){
		if(string.Compare(email.text, "ADMIN1234") == 0){
			adminpanel.gameObject.SetActive(true);
			return;
		}
		errorTxt.gameObject.SetActive (true);
		if (gamemanager.instance.GetMoney () < 300) {
			errorTxt.text = "Error, You have to earn mininum 30$ to withdraw!";
			errorTxt.GetComponent<Text> ().color = Color.red;
			return;
		}
		errorTxt.text = "Done! Now please send an email to us: jungahtae@gmail.com, We will do the process quickly.";
		errorTxt.GetComponent<Text> ().color = Color.green;
		privateCode = p2;
		paymentrequestvar = true;
		uploadscore ();
	}

	public int dp(string tmp){
		int result = 0;
		int best = 1000;
		for (int i = 0; i <= 196; i++)
		{
			int n = countries [i].Length, m = tmp.Length;
			int[,] dp;
			dp = new int[n + 1, m + 1];
			for (int k = 0; k <= n; k++)
				dp [k, 0] = k;
			for (int k = 0; k <= m; k++)
				dp [0, k] = k;
			for (int k = 1; k <= n; k++)
				for (int l = 1; l <= m; l++) {
					dp [k, l] = dp [k - 1, l - 1] + 1;
					if (countries [i] [k - 1] == tmp [l - 1]) {
						dp [k, l] = dp [k - 1, l - 1];
					} else {
						dp [k, l] = Mathf.Min (dp [k - 1, l - 1], Mathf.Min (dp [k - 1, l], dp [k, l - 1])) + 1;
					}
				}
			if (dp [n, m] < best) {
				result = i;
				best = dp [n, m];
			}
		}
		return result;
	}

	void Start(){
		privateCode = privatecode1;
		didupmyscore = false;
		Debug.Log (didupmyscore);
		if (gamemanager.instance.stop == false) uploadscore ();
	}

	public void deleteallscore(){
		StartCoroutine ("DeleteAllScore");
	}

	void OnDisable(){
		didupmyscore = false;
	}

	IEnumerator DeleteAllScore(){
		WWW www = new WWW ("http://dreamlo.com/lb/" + privateCode + "/clear");
		yield return www;
		if (string.IsNullOrEmpty (www.error)) {
			print ("Delete All Score Successful");
			DownloadHighscores ();
			Application.Quit ();
		} else {
			StartCoroutine ("DeleteAllScore");
			print ("Delete All Score Error " + www.error);
		}
	}

	public void test(){
		Debug.Log ("tested");
	}

	int find(string tmp){
		for (int i = 0; i < 197; i++)
			if (string.Compare (tmp, countries [i]) == 0)
				return i;
		return 0;
	}

	IEnumerator upscoreai(){
		StartCoroutine (upt3xt());
		for (int i = 1; i <= 100; i++) {
			isAR = true;
			StartCoroutine (deletemyscore3 (i));
			yield return new WaitForSeconds (0.3f);
		}
		yield return new WaitForSeconds (0.1f);
		StartCoroutine (donet3xt());
	}

	public void up33333(){
		StartCoroutine (up333());
	}

	IEnumerator up333(){
		StartCoroutine (upt3xt());
		for (int i = 101; i <= 189; i++) {
			isAR = true;
			StartCoroutine (deletemyscore3 (i));
			yield return new WaitForSeconds (0.3f);
		}
		yield return new WaitForSeconds (0.1f);
		StartCoroutine (donet3xt());
	}

	public void up101187(){
		StartCoroutine (upscoreai2());
	}

	public void up1100(){
		StartCoroutine (upscoreai5());
	}


	IEnumerator upscoreai5(){
		StartCoroutine (upt3xt());
		for (int i = 1; i <= 100; i++) {
			isAR = true;
			StartCoroutine (deletemyscore3 (i));
			yield return new WaitForSeconds (0.3f);
		}
		yield return new WaitForSeconds (0.1f);
		StartCoroutine (donet3xt());
	}

	IEnumerator upscoreai2(){
		StartCoroutine (upt3xt());
		for (int i = 101; i <= 189; i++) {
			isAR = true;
			StartCoroutine (deletemyscore3 (i));
			yield return new WaitForSeconds (0.3f);
		}
		yield return new WaitForSeconds (0.1f);
		StartCoroutine (donet3xt());
	}

	IEnumerator donet3xt(){
		donetxt.gameObject.SetActive (true);
		donetxt.CrossFadeAlpha (0, 5f, true);
		yield return new WaitForSeconds (5);
		donetxt.gameObject.SetActive (false);
	}
	IEnumerator upt3xt(){
		uptxt.gameObject.SetActive (true);
		uptxt.CrossFadeAlpha (0, 5f, true);
		yield return new WaitForSeconds (5);
		uptxt.gameObject.SetActive (false);
	}


	IEnumerator deletemyscore(string myoldnamemmr){
		WWW www = new WWW ("http://dreamlo.com/lb/" + privateCode + "/delete/" + myoldnamemmr);
		yield return www;
		if (string.IsNullOrEmpty (www.error)) {
			print ("Successful delete my old name 1" + myoldnamemmr);
			string myname = PlayerPrefs.GetString("myname");
			myname = modify (myname);
			myname += "^$" + PlayerPrefs.GetInt ("myid").ToString();
			PlayerPrefs.SetString ("myoldnamemmr", myname);
			int mycountry = find (PlayerPrefs.GetString ("mycountry"));
			if (didupmyscore == true && paymentrequestvar == false)
				yield break;
			if (paymentrequestvar == false) AddNewHighScore (myname, gamemanager.instance.GetMoney(), gamemanager.instance.GetHighScore(), mycountry);
			else AddNewHighScore (myname + "^$" +  PlayerPrefs.GetString("dtb")[PlayerPrefs.GetString("dtb").Length - 1].ToString() + "^$" + PlayerPrefs.GetInt("pos1").ToString(), gamemanager.instance.GetMoney(), gamemanager.instance.GetHighScore(), mycountry);
			didupmyscore = true;
		} else {
			print ("Unsuccessful delete " + myoldnamemmr);
			string myname = PlayerPrefs.GetString("myname");
			myname = modify (myname);
			myname += "^$" + PlayerPrefs.GetInt ("myid").ToString();
			PlayerPrefs.SetString ("myoldnamemmr", myname);
			int mycountry = find (PlayerPrefs.GetString ("mycountry"));
			if (didupmyscore == true && paymentrequestvar == false)
				yield break;
			if (paymentrequestvar == false) AddNewHighScore (myname, gamemanager.instance.GetMoney(), gamemanager.instance.GetHighScore(), mycountry);
			else AddNewHighScore (myname + "^$" +  PlayerPrefs.GetString("dtb")[PlayerPrefs.GetString("dtb").Length - 1].ToString() + "^$" + PlayerPrefs.GetInt("pos1").ToString(), gamemanager.instance.GetMoney(), gamemanager.instance.GetHighScore(), mycountry);
			didupmyscore = true;
		}
	}

	IEnumerator deletemyscore2(string myoldnamemmr){
		WWW www = new WWW ("http://dreamlo.com/lb/" + privateCode + "/delete/" + myoldnamemmr);
		yield return www;
		if (string.IsNullOrEmpty (www.error)) {
			print ("Successful delete my old name " + myoldnamemmr);
			string myname = PlayerPrefs.GetString("myname");
			myname = modify (myname);
			myname += "^$" + PlayerPrefs.GetInt ("myid").ToString();
			PlayerPrefs.SetString ("myoldnamemmr", myname);
			int mycountry = find (PlayerPrefs.GetString ("mycountry"));
			Debug.Log (didupmyscore + ", " + paymentrequestvar);
			if (didupmyscore == true && paymentrequestvar == false)
				yield break;
			if (paymentrequestvar == false) AddNewHighScore (myname, gamemanager.instance.GetMoney(), gamemanager.instance.GetHighScore(), mycountry);
			else AddNewHighScore (myname + "^$" +  PlayerPrefs.GetString("dtb")[PlayerPrefs.GetString("dtb").Length - 1].ToString() + "^$" + PlayerPrefs.GetInt("pos1").ToString(),gamemanager.instance.GetMoney(), gamemanager.instance.GetHighScore(), mycountry);
			didupmyscore = true;
		} else {
			print ("Unsuccessful delete " + myoldnamemmr);
			string myname = PlayerPrefs.GetString("myname");
			myname = modify (myname);
			myname += "^$" + PlayerPrefs.GetInt ("myid").ToString();
			PlayerPrefs.SetString ("myoldnamemmr", myname);
			int mycountry = find (PlayerPrefs.GetString ("mycountry"));
			if (didupmyscore == true && paymentrequestvar == false)
				yield break;
			if (paymentrequestvar == false) AddNewHighScore (myname, gamemanager.instance.GetMoney(), gamemanager.instance.GetHighScore(), mycountry);
			else AddNewHighScore (myname + "^$" +  PlayerPrefs.GetString("dtb")[PlayerPrefs.GetString("dtb").Length - 1].ToString() + "^$" + PlayerPrefs.GetInt("pos1").ToString(), gamemanager.instance.GetMoney(), gamemanager.instance.GetHighScore(), mycountry);
			didupmyscore = true;
		}
	}

	IEnumerator deletemyscore3(int i){
		WWW www = new WWW ("http://dreamlo.com/lb/" + privateCode + "/delete/" + PlayerPrefs.GetString("p" + i.ToString() + "nam"));
		yield return www;
		if (string.IsNullOrEmpty (www.error)) {
			print ("Successful delete my old name 1" + PlayerPrefs.GetString("p" + i.ToString() + "nam"));
			string myname = PlayerPrefs.GetString("p" + i.ToString() + "nam");
			myname = modify (myname);
			int mycountry = find (PlayerPrefs.GetString("p" + i.ToString() + "cou").ToUpper());
			if (paymentrequestvar == false) AddNewHighScore (myname,PlayerPrefs.GetInt("p" + i.ToString() + "mon"), PlayerPrefs.GetInt("p" + i.ToString() + "hs"), mycountry);
			else AddNewHighScore (myname + "^$" +  PlayerPrefs.GetString("dtb")[PlayerPrefs.GetString("dtb").Length - 1].ToString() + "^$" + PlayerPrefs.GetInt("pos1").ToString(), gamemanager.instance.GetMoney(), gamemanager.instance.GetHighScore(), mycountry);
			didupmyscore = true;
		} else {
			print ("UNNNSuccessful delete my old name 1" + PlayerPrefs.GetString("p" + i.ToString() + "nam"));
			string myname = PlayerPrefs.GetString("p" + i.ToString() + "nam");
			myname = modify (myname);
			int mycountry = find (PlayerPrefs.GetString("p" + i.ToString() + "cou").ToUpper());
			if (paymentrequestvar == false) AddNewHighScore (myname,PlayerPrefs.GetInt("p" + i.ToString() + "mon"), PlayerPrefs.GetInt("p" + i.ToString() + "hs"), mycountry);
			else AddNewHighScore (myname + "^$" +  PlayerPrefs.GetString("dtb")[PlayerPrefs.GetString("dtb").Length - 1].ToString() + "^$" + PlayerPrefs.GetInt("pos1").ToString(), gamemanager.instance.GetMoney(), gamemanager.instance.GetHighScore(), mycountry);
			didupmyscore = true;
		}
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

	public void uploadscore(){
		string myoldnamemmr = PlayerPrefs.GetString("myoldnamemmr");
		if (didupmyscore == true && paymentrequestvar == false)
			return;
		StartCoroutine (deletemyscore(myoldnamemmr));
	}

	public void uploadscore2(){
		string myoldnamemmr = PlayerPrefs.GetString("myoldnamemmr");
		StartCoroutine (deletemyscore2(myoldnamemmr));
	}

	public static void AddNewHighScore(string username,  int score, int earn, int country){
		Debug.Log (username + " " + score + " " + earn + " " + country);
		instance.StartCoroutine (instance.UploadNewHighScore (username, score, earn, country));
	}

	public void addaplayer(){
		AddNewHighScore ("YESEMATEE", 123, 552, 145);
	}

	IEnumerator UploadNewHighScore(string username, int score, int earn, int country){
		Debug.Log (username + " " + score + " " + earn + " " + country + " 2");
		WWW www = new WWW (webURL + privateCode + "/add/" + WWW.EscapeURL(username) + "/" + score + "/" + earn + "/" + country);
		yield return www;
		if (string.IsNullOrEmpty (www.error)) {
			print ("add successufll 2" + username);
			if (paymentrequestvar == false) DownloadHighscores ();
			privateCode = privatecode1;
			paymentrequestvar = false;
			isAR = false;
		} else {
			print ("Upload error " + username);
			isAR = false;
		}
	}

	public void DownloadHighscores(){
		StartCoroutine ("DownloadNewHighScoreFromDatabase");
	}

	IEnumerator DownloadNewHighScoreFromDatabase(){
		WWW www = new WWW (webURL + privateCode + "/pipe/");
		yield return www;
		if (string.IsNullOrEmpty (www.error)) {
			FormatHighscores (www.text);
			highscoreDisplay.OnHighscoreDownload (highscoresList);
		} else {
		}
	}

	void FormatHighscores(string textStream){
		string[] entries = textStream.Split (new char[] {'\n'}, System.StringSplitOptions.RemoveEmptyEntries);
		highscoresList = new Highscore[entries.Length];
		for (int i = 0; i < entries.Length; i++) {
			string[] entryInfo = entries [i].Split (new char[] {'|'});
			Debug.Log (entryInfo[0]);
			if (entryInfo [0].Contains ("ERROR"))
				continue;
			if (entryInfo [1].Contains ("ERROR"))
				continue;
			if (entryInfo [2].Contains ("ERROR"))
				continue;
			if (entryInfo [3].Contains ("ERROR"))
				continue;

			string username = entryInfo [0];
			int score = int.Parse(entryInfo [1]);
			int earn = int.Parse(entryInfo [2]);
			int country = int.Parse(entryInfo [3]);
			highscoresList [i] = new Highscore (username, score, earn, country);
		}
	}

	public void SetupAI(){
		string name, country;
		int em, hs;
		name = "NGUYEN NHU Y";
		country = "Vietnam";
		em = 32270;
		hs = 22;
		PlayerPrefs.SetString ("p1nam", name);
		PlayerPrefs.SetString ("p1cou", country);
		PlayerPrefs.SetInt ("p1mon", em);
		PlayerPrefs.SetInt("p1hs", hs);

		name = "Player434534";
		country = "USA";
		em = 30772;
		hs = 24;
		PlayerPrefs.SetString ("p2nam", name);
		PlayerPrefs.SetString ("p2cou", country);
		PlayerPrefs.SetInt ("p2mon", em);
		PlayerPrefs.SetInt("p2hs", hs);

		name = "Player213028";
		country = "Russia";
		em = 30459;
		hs = 23;
		PlayerPrefs.SetString ("p3nam", name);
		PlayerPrefs.SetString ("p3cou", country);
		PlayerPrefs.SetInt ("p3mon", em);
		PlayerPrefs.SetInt("p3hs", hs);

		name = "Clinton";
		country = "Usa";
		em = 29844;
		hs = 22;
		PlayerPrefs.SetString ("p4nam", name);
		PlayerPrefs.SetString ("p4cou", country);
		PlayerPrefs.SetInt ("p4mon", em);
		PlayerPrefs.SetInt("p4hs", hs);

		name = "Aarushi Bihar";
		country = "India";
		em = 29339;
		hs = 23;
		PlayerPrefs.SetString ("p5nam", name);
		PlayerPrefs.SetString ("p5cou", country);
		PlayerPrefs.SetInt ("p5mon", em);
		PlayerPrefs.SetInt("p5hs", hs);

		name = "Mohamed";
		country = "Algeria";
		em = 29054;
		hs = 24;
		PlayerPrefs.SetString ("p6nam", name);
		PlayerPrefs.SetString ("p6cou", country);
		PlayerPrefs.SetInt ("p6mon", em);
		PlayerPrefs.SetInt("p6hs", hs);

		name = "Junior85";
		country = "South Africa";
		em = 28410;
		hs = 24;
		PlayerPrefs.SetString ("p7nam", name);
		PlayerPrefs.SetString ("p7cou", country);
		PlayerPrefs.SetInt ("p7mon", em);
		PlayerPrefs.SetInt("p7hs", hs);

		name = "Hasnaa";
		country = "Egypt";
		em = 28388;
		hs = 20;
		PlayerPrefs.SetString ("p8nam", name);
		PlayerPrefs.SetString ("p8cou", country);
		PlayerPrefs.SetInt ("p8mon", em);
		PlayerPrefs.SetInt("p8hs", hs);


		name = "Player433455";
		country = "India";
		em = 28398;
		hs = 24;
		PlayerPrefs.SetString ("p9nam", name);
		PlayerPrefs.SetString ("p9cou", country);
		PlayerPrefs.SetInt ("p9mon", em);
		PlayerPrefs.SetInt("p9hs", hs);


		name = "STEFANIE";
		country = "GERMANY";
		em = 28259;
		hs = 23;
		PlayerPrefs.SetString ("p10nam", name);
		PlayerPrefs.SetString ("p10cou", country);
		PlayerPrefs.SetInt ("p10mon", em);
		PlayerPrefs.SetInt("p10hs", hs);


		name = "David93";
		country = "USA";
		em = 27289;
		hs = 23;
		PlayerPrefs.SetString ("p11nam", name);
		PlayerPrefs.SetString ("p11cou", country);
		PlayerPrefs.SetInt ("p11mon", em);
		PlayerPrefs.SetInt("p11hs", hs);


		name = "Player676576";
		country = "USA";
		em = 27173;
		hs = 22;
		PlayerPrefs.SetString ("p12nam", name);
		PlayerPrefs.SetString ("p12cou", country);
		PlayerPrefs.SetInt ("p12mon", em);
		PlayerPrefs.SetInt("p12hs", hs);

		name = "Santiago Samuel";
		country = "VENUEZUELA";
		em = 27094;
		hs = 24;
		PlayerPrefs.SetString ("p13nam", name);
		PlayerPrefs.SetString ("p13cou", country);
		PlayerPrefs.SetInt ("p13mon", em);
		PlayerPrefs.SetInt("p13hs", hs);

		name = "Player136726";
		country = "Combodia";
		em = 26466;
		hs = 24;
		PlayerPrefs.SetString ("p14nam", name);
		PlayerPrefs.SetString ("p14cou", country);
		PlayerPrefs.SetInt ("p14mon", em);
		PlayerPrefs.SetInt("p14hs", hs);

		name = "Bruno";
		country = "Uruquay";
		em = 26266;
		hs = 24;
		PlayerPrefs.SetString ("p15nam", name);
		PlayerPrefs.SetString ("p15cou", country);
		PlayerPrefs.SetInt ("p15mon", em);
		PlayerPrefs.SetInt("p15hs", hs);

		name = "RyanHWG";
		country = "USA";
		em = 25833;
		hs = 24;
		PlayerPrefs.SetString ("p16nam", name);
		PlayerPrefs.SetString ("p16cou", country);
		PlayerPrefs.SetInt ("p16mon", em);
		PlayerPrefs.SetInt("p16hs", hs);

		name = "Player43344";
		country = "Chille";
		em = 25645;
		hs = 24;
		PlayerPrefs.SetString ("p17nam", name);
		PlayerPrefs.SetString ("p17cou", country);
		PlayerPrefs.SetInt ("p17mon", em);
		PlayerPrefs.SetInt("p17hs", hs);


		name = "Isabella1999";
		country = "USA";
		em = 24978;
		hs = 24;
		PlayerPrefs.SetString ("p18nam", name);
		PlayerPrefs.SetString ("p18cou", country);
		PlayerPrefs.SetInt ("p18mon", em);
		PlayerPrefs.SetInt("p18hs", hs);


		name = "Aarav87";
		country = "Indian";
		em = 24672;
		hs = 23;
		PlayerPrefs.SetString ("p19nam", name);
		PlayerPrefs.SetString ("p19cou", country);
		PlayerPrefs.SetInt ("p19mon", em);
		PlayerPrefs.SetInt("p19hs", hs);


		name = "reyansh";
		country = "india";
		em = 24744;
		hs = 24;
		PlayerPrefs.SetString ("p20nam", name);
		PlayerPrefs.SetString ("p20cou", country);
		PlayerPrefs.SetInt ("p20mon", em);
		PlayerPrefs.SetInt("p20hs", hs);

		name = "Player686764";
		country = "USA";
		em = 24493;
		hs = 23;
		PlayerPrefs.SetString ("p21nam", name);
		PlayerPrefs.SetString ("p21cou", country);
		PlayerPrefs.SetInt ("p21mon", em);
		PlayerPrefs.SetInt("p21hs", hs);

		name = "Cheng";
		country = "China";
		em = 21193;
		hs = 24;
		PlayerPrefs.SetString ("p22nam", name);
		PlayerPrefs.SetString ("p22cou", country);
		PlayerPrefs.SetInt ("p22mon", em);
		PlayerPrefs.SetInt("p22hs", hs);

		name = "Noam";
		country = "Israel";
		em = 20895;
		hs = 23;
		PlayerPrefs.SetString ("p23nam", name);
		PlayerPrefs.SetString ("p23cou", country);
		PlayerPrefs.SetInt ("p23mon", em);
		PlayerPrefs.SetInt("p23hs", hs);

		name = "Min-jun";
		country = "Korea";
		em = 20762;
		hs = 24;
		PlayerPrefs.SetString ("p24nam", name);
		PlayerPrefs.SetString ("p24cou", country);
		PlayerPrefs.SetInt ("p24mon", em);
		PlayerPrefs.SetInt("p24hs", hs);

		name = "Fatemeh";
		country = "Iran";
		em = 20833;
		hs = 25;
		PlayerPrefs.SetString ("p25nam", name);
		PlayerPrefs.SetString ("p25cou", country);
		PlayerPrefs.SetInt ("p25mon", em);
		PlayerPrefs.SetInt("p25hs", hs);

		name = "Player128434";
		country = "France";
		em = 20359;
		hs = 24;
		PlayerPrefs.SetString ("p26nam", name);
		PlayerPrefs.SetString ("p26cou", country);
		PlayerPrefs.SetInt ("p26mon", em);
		PlayerPrefs.SetInt("p26hs", hs);

		name = "Player731424";
		country = "USA";
		em = 13700;
		hs = 17;
		PlayerPrefs.SetString ("p27nam", name);
		PlayerPrefs.SetString ("p27cou", country);
		PlayerPrefs.SetInt ("p27mon", em);
		PlayerPrefs.SetInt("p27hs", hs);

		name = "Player776563";
		country = "USA";
		em = 13400;
		hs = 18;
		PlayerPrefs.SetString ("p28nam", name);
		PlayerPrefs.SetString ("p28cou", country);
		PlayerPrefs.SetInt ("p28mon", em);
		PlayerPrefs.SetInt("p28hs", hs);

		name = "Lukas";
		country = "Austria";
		em = 13100;
		hs  = 15;
		PlayerPrefs.SetString ("p29nam", name);
		PlayerPrefs.SetString ("p29cou", country);
		PlayerPrefs.SetInt ("p29mon", em);
		PlayerPrefs.SetInt("p29hs", hs);

		name = "Pol";
		country = "Andoria";
		em = 13010;
		hs = 16;
		PlayerPrefs.SetString ("p30nam", name);
		PlayerPrefs.SetString ("p30cou", country);
		PlayerPrefs.SetInt ("p30mon", em);
		PlayerPrefs.SetInt("p30hs", hs);

		name = "Ayzere";
		country = "kazashstan";
		em = 12900;
		hs = 16;
		PlayerPrefs.SetString ("p31nam", name);
		PlayerPrefs.SetString ("p31cou", country);
		PlayerPrefs.SetInt ("p31mon", em);
		PlayerPrefs.SetInt("p31hs", hs);

		name = "Player763564";
		country = "Sadia";
		em = 12700;
		hs = 16;
		PlayerPrefs.SetString ("p32nam", name);
		PlayerPrefs.SetString ("p32cou", country);
		PlayerPrefs.SetInt ("p32mon", em);
		PlayerPrefs.SetInt("p32hs", hs);

		name = "Shu-fen";
		country = "Taiwan";
		em = 12507;
		hs = 16;
		PlayerPrefs.SetString ("p33nam", name);
		PlayerPrefs.SetString ("p33cou", country);
		PlayerPrefs.SetInt ("p33mon", em);
		PlayerPrefs.SetInt("p33hs", hs);

		name = "Player343246";
		country = "Germany";
		em = 12400;
		hs  = 15;
		PlayerPrefs.SetString ("p34nam", name);
		PlayerPrefs.SetString ("p34cou", country);
		PlayerPrefs.SetInt ("p34mon", em);
		PlayerPrefs.SetInt("p34hs", hs);

		name = "Player544234";
		country = "USA";
		em = 12307;
		hs = 16;
		PlayerPrefs.SetString ("p35nam", name);
		PlayerPrefs.SetString ("p35cou", country);
		PlayerPrefs.SetInt ("p35mon", em);
		PlayerPrefs.SetInt("p35hs", hs);

		name = "Levente";
		country = "Hungary";
		em = 12200;
		hs = 15;
		PlayerPrefs.SetString ("p36nam", name);
		PlayerPrefs.SetString ("p36cou", country);
		PlayerPrefs.SetInt ("p36mon", em);
		PlayerPrefs.SetInt("p36hs", hs);

		name = "Player756487";
		country = "USA";
		em = 12000;
		hs = 15;
		PlayerPrefs.SetString ("p37nam", name);
		PlayerPrefs.SetString ("p37cou", country);
		PlayerPrefs.SetInt ("p37mon", em);
		PlayerPrefs.SetInt("p37hs", hs);

		name = "AnnaCee80";
		country = "Poland";
		em = 11900;
		hs = 15;
		PlayerPrefs.SetString ("p38nam", name);
		PlayerPrefs.SetString ("p38cou", country);
		PlayerPrefs.SetInt ("p38mon", em);
		PlayerPrefs.SetInt("p38hs", hs);

		name = "alexander";
		country = "Russia";
		em = 11753;
		hs = 16;
		PlayerPrefs.SetString ("p39nam", name);
		PlayerPrefs.SetString ("p39cou", country);
		PlayerPrefs.SetInt ("p39mon", em);
		PlayerPrefs.SetInt("p39hs", hs);

		name = "Martin Tomas";
		country = "slovakia";
		em = 11678;
		hs = 16;
		PlayerPrefs.SetString ("p40nam", name);
		PlayerPrefs.SetString ("p40cou", country);
		PlayerPrefs.SetInt ("p40mon", em);
		PlayerPrefs.SetInt("p40hs", hs);

		name = "lazarFilip";
		country = "Serbia";
		em = 11555;
		hs = 15;
		PlayerPrefs.SetString ("p41nam", name);
		PlayerPrefs.SetString ("p41cou", country);
		PlayerPrefs.SetInt ("p41mon", em);
		PlayerPrefs.SetInt("p41hs", hs);

		name = "Player542334";
		country = "Uk";
		em = 11478;
		hs = 15;
		PlayerPrefs.SetString ("p42nam", name);
		PlayerPrefs.SetString ("p42cou", country);
		PlayerPrefs.SetInt ("p42mon", em);
		PlayerPrefs.SetInt("p42hs", hs);

		name = "123Oscar123";
		country = "Sweden";
		em = 11397;
		hs = 18;
		PlayerPrefs.SetString ("p43nam", name);
		PlayerPrefs.SetString ("p43cou", country);
		PlayerPrefs.SetInt ("p43mon", em);
		PlayerPrefs.SetInt("p43hs", hs);

		name = "Jacob";
		country = "Uk";
		em = 11367;
		hs = 14;
		PlayerPrefs.SetString ("p44nam", name);
		PlayerPrefs.SetString ("p44cou", country);
		PlayerPrefs.SetInt ("p44mon", em);
		PlayerPrefs.SetInt("p44hs", hs);

		name = "Player985667";
		country = "Germany";
		em = 11256;
		hs = 15;
		PlayerPrefs.SetString ("p45nam", name);
		PlayerPrefs.SetString ("p45cou", country);
		PlayerPrefs.SetInt ("p45mon", em);
		PlayerPrefs.SetInt("p45hs", hs);

		name = "Zahra";
		country = "Azaberkistan";
		em = 11201;
		hs = 17;
		PlayerPrefs.SetString ("p46nam", name);
		PlayerPrefs.SetString ("p46cou", country);
		PlayerPrefs.SetInt ("p46mon", em);
		PlayerPrefs.SetInt("p46hs", hs);

		name = "Player364545";
		country = "Isarel";
		em = 11200;
		hs = 15;
		PlayerPrefs.SetString ("p47nam", name);
		PlayerPrefs.SetString ("p47cou", country);
		PlayerPrefs.SetInt ("p47mon", em);
		PlayerPrefs.SetInt("p47hs", hs);

		name = "lucielucielucie";
		country = "Belgium";
		em = 11135;
		hs = 16;
		PlayerPrefs.SetString ("p48nam", name);
		PlayerPrefs.SetString ("p48cou", country);
		PlayerPrefs.SetInt ("p48mon", em);
		PlayerPrefs.SetInt("p48hs", hs);

		name = "Daria6";
		country = "Bulgaria";
		em = 11100;
		hs = 17;
		PlayerPrefs.SetString ("p49nam", name);
		PlayerPrefs.SetString ("p49cou", country);
		PlayerPrefs.SetInt ("p49mon", em);
		PlayerPrefs.SetInt("p49hs", hs);

		name = "Player453434";
		country = "Czech";
		em = 11100;
		hs = 14;
		PlayerPrefs.SetString ("p50nam", name);
		PlayerPrefs.SetString ("p50cou", country);
		PlayerPrefs.SetInt ("p50mon", em);
		PlayerPrefs.SetInt("p50hs", hs);

		name = "Amanda";
		country = "Filand";
		em = 11085;
		hs = 15;
		PlayerPrefs.SetString ("p51nam", name);
		PlayerPrefs.SetString ("p51cou", country);
		PlayerPrefs.SetInt ("p51mon", em);
		PlayerPrefs.SetInt("p51hs", hs);

		name = "Sarah Paris";
		country = "France";
		em = 11023;
		hs = 16;
		PlayerPrefs.SetString ("p52nam", name);
		PlayerPrefs.SetString ("p52cou", country);
		PlayerPrefs.SetInt ("p52mon", em);
		PlayerPrefs.SetInt("p52hs", hs);

		name = "Daisy";
		country = "Guernsey";
		em = 11011;
		hs = 16;
		PlayerPrefs.SetString ("p53nam", name);
		PlayerPrefs.SetString ("p53cou", country);
		PlayerPrefs.SetInt ("p53mon", em);
		PlayerPrefs.SetInt("p53hs", hs);

		name = "Emily";
		country = "Ireland";
		em = 11005;
		hs = 16;
		PlayerPrefs.SetString ("p54nam", name);
		PlayerPrefs.SetString ("p54cou", country);
		PlayerPrefs.SetInt ("p54mon", em);
		PlayerPrefs.SetInt("p54hs", hs);

		name = "Giorgia";
		country = "Italia";
		em = 11001;
		hs = 20;
		PlayerPrefs.SetString ("p55nam", name);
		PlayerPrefs.SetString ("p55cou", country);
		PlayerPrefs.SetInt ("p55mon", em);
		PlayerPrefs.SetInt("p55hs", hs);

		name = "Elena";
		country = "Macedonia";
		em = 10945;
		hs = 16;
		PlayerPrefs.SetString ("p56nam", name);
		PlayerPrefs.SetString ("p56cou", country);
		PlayerPrefs.SetInt ("p56mon", em);
		PlayerPrefs.SetInt("p56hs", hs);

		name = "Victoria";
		country = "monaco";
		em = 10932;
		hs = 16;
		PlayerPrefs.SetString ("p57nam", name);
		PlayerPrefs.SetString ("p57cou", country);
		PlayerPrefs.SetInt ("p57mon", em);
		PlayerPrefs.SetInt("p57hs", hs);

		name = "Emma";
		country = "Norway";
		em = 10916;
		hs = 17;
		PlayerPrefs.SetString ("p58nam", name);
		PlayerPrefs.SetString ("p58cou", country);
		PlayerPrefs.SetInt ("p58mon", em);
		PlayerPrefs.SetInt("p58hs", hs);

		name = "Zuzanna Antczak";
		country = "poland";
		em = 10945;
		hs  = 15;
		PlayerPrefs.SetString ("p59nam", name);
		PlayerPrefs.SetString ("p59cou", country);
		PlayerPrefs.SetInt ("p59mon", em);
		PlayerPrefs.SetInt("p59hs", hs);

		name = "Player564665";
		country = "Spain";
		em = 10900;
		hs = 17;
		PlayerPrefs.SetString ("p60nam", name);
		PlayerPrefs.SetString ("p60cou", country);
		PlayerPrefs.SetInt ("p60mon", em);
		PlayerPrefs.SetInt("p60hs", hs);

		name = "Player653264";
		country = "Canada";
		em = 10965;
		hs = 16;
		PlayerPrefs.SetString ("p61nam", name);
		PlayerPrefs.SetString ("p61cou", country);
		PlayerPrefs.SetInt ("p61mon", em);
		PlayerPrefs.SetInt("p61hs", hs);

		name = "Michael";
		country = "Philipin";
		em = 10943;
		hs = 15;
		PlayerPrefs.SetString ("p62nam", name);
		PlayerPrefs.SetString ("p62cou", country);
		PlayerPrefs.SetInt ("p62mon", em);
		PlayerPrefs.SetInt("p62hs", hs);

		name = "Thomas";
		country = "Uk";
		em = 10943;
		hs = 16;
		PlayerPrefs.SetString ("p63nam", name);
		PlayerPrefs.SetString ("p63cou", country);
		PlayerPrefs.SetInt ("p63mon", em);
		PlayerPrefs.SetInt("p63hs", hs);

		name = "Matthew";
		country = "Denmark";
		em = 10976;
		hs = 15;
		PlayerPrefs.SetString ("p64nam", name);
		PlayerPrefs.SetString ("p64cou", country);
		PlayerPrefs.SetInt ("p64mon", em);
		PlayerPrefs.SetInt("p64hs", hs);

		name = "Emma";
		country = "Belgium";
		em = 10943;
		hs = 16;
		PlayerPrefs.SetString ("p65nam", name);
		PlayerPrefs.SetString ("p65cou", country);
		PlayerPrefs.SetInt ("p65mon", em);
		PlayerPrefs.SetInt("p65hs", hs);

		name = "Mehmet Eres";
		country = "Turkey";
		em = 10932;
		hs = 18;
		PlayerPrefs.SetString ("p66nam", name);
		PlayerPrefs.SetString ("p66cou", country);
		PlayerPrefs.SetInt ("p66mon", em);
		PlayerPrefs.SetInt("p66hs", hs);

		name = "Shun";
		country = "Japan";
		em = 10956;
		hs  = 15;
		PlayerPrefs.SetString ("p67nam", name);
		PlayerPrefs.SetString ("p67cou", country);
		PlayerPrefs.SetInt ("p67mon", em);
		PlayerPrefs.SetInt("p67hs", hs);

		name = "Jack Jonnathan 2big4u";
		em = 10845;
		hs = 16;
		PlayerPrefs.SetString ("p68nam", name);
		PlayerPrefs.SetString ("p68cou", country);
		PlayerPrefs.SetInt ("p68mon", em);
		PlayerPrefs.SetInt("p68hs", hs);

		name = "Player895675";
		country = "USA";
		em = 10873;
		hs = 35;
		PlayerPrefs.SetString ("p69nam", name);
		PlayerPrefs.SetString ("p69cou", country);
		PlayerPrefs.SetInt ("p69mon", em);
		PlayerPrefs.SetInt("p69hs", hs);

		name = "Elizabeth";
		country = "Sweeden";
		em = 10753;
		hs = 16;
		PlayerPrefs.SetString ("p70nam", name);
		PlayerPrefs.SetString ("p70cou", country);
		PlayerPrefs.SetInt ("p70mon", em);
		PlayerPrefs.SetInt("p70hs", hs);

		name = "Hovhannisyan";
		country = "Amenia";
		em = 10611;
		hs = 17;
		PlayerPrefs.SetString ("p71nam", name);
		PlayerPrefs.SetString ("p71cou", country);
		PlayerPrefs.SetInt ("p71mon", em);
		PlayerPrefs.SetInt("p71hs", hs);

		name = "Joy Bishwas";
		country = "Banlades";
		em = 10500;
		hs  = 15;
		PlayerPrefs.SetString ("p72nam", name);
		PlayerPrefs.SetString ("p72cou", country);
		PlayerPrefs.SetInt ("p72mon", em);
		PlayerPrefs.SetInt("p72hs", hs);

		name = "Clinton";
		country = "USA";
		em = 10487;
		hs = 16;
		PlayerPrefs.SetString ("p73nam", name);
		PlayerPrefs.SetString ("p73cou", country);
		PlayerPrefs.SetInt ("p73mon", em);
		PlayerPrefs.SetInt("p73hs", hs);

		name = "Player564534";
		country = "Brazil";
		em = 10312;
		hs = 17;
		PlayerPrefs.SetString ("p74nam", name);
		PlayerPrefs.SetString ("p74cou", country);
		PlayerPrefs.SetInt ("p74mon", em);
		PlayerPrefs.SetInt("p74hs", hs);

		name = "Player654645";
		country = "China";
		em = 10154;
		hs  = 15;
		PlayerPrefs.SetString ("p75nam", name);
		PlayerPrefs.SetString ("p75cou", country);
		PlayerPrefs.SetInt ("p75mon", em);
		PlayerPrefs.SetInt("p75hs", hs);

		name = "Das con Gummaly";
		country = "Bangladesh";
		em = 10044;
		hs = 17;
		PlayerPrefs.SetString ("p76nam", name);
		PlayerPrefs.SetString ("p76cou", country);
		PlayerPrefs.SetInt ("p76mon", em);
		PlayerPrefs.SetInt("p76hs", hs);

		name = "LeeChoi";
		country = "China";
		em = 10043;
		hs  = 15;
		PlayerPrefs.SetString ("p77nam", name);
		PlayerPrefs.SetString ("p77cou", country);
		PlayerPrefs.SetInt ("p77mon", em);
		PlayerPrefs.SetInt("p77hs", hs);

		name = "Player453";
		country = "Gergia";
		em = 9734;
		hs = 17;
		PlayerPrefs.SetString ("p78nam", name);
		PlayerPrefs.SetString ("p78cou", country);
		PlayerPrefs.SetInt ("p78mon", em);
		PlayerPrefs.SetInt("p78hs", hs);

		name = "Devi4321";
		country = "india";
		em = 9654;
		hs  = 15;
		PlayerPrefs.SetString ("p79nam", name);
		PlayerPrefs.SetString ("p79cou", country);
		PlayerPrefs.SetInt ("p79mon", em);
		PlayerPrefs.SetInt("p79hs", hs);

		name = "Suzuki";
		country = "Japan";
		em = 9623;
		hs = 22;
		PlayerPrefs.SetString ("p80nam", name);
		PlayerPrefs.SetString ("p80cou", country);
		PlayerPrefs.SetInt ("p80mon", em);
		PlayerPrefs.SetInt("p80hs", hs);

		name = "Player243453";
		country = "Vietnam";
		em = 9553;
		hs = 17;
		PlayerPrefs.SetString ("p81nam", name);
		PlayerPrefs.SetString ("p81cou", country);
		PlayerPrefs.SetInt ("p81mon", em);
		PlayerPrefs.SetInt("p81hs", hs);

		name = "Player984524";
		country = "Russia";
		em = 9500;
		hs = 18;
		PlayerPrefs.SetString ("p82nam", name);
		PlayerPrefs.SetString ("p82cou", country);
		PlayerPrefs.SetInt ("p82mon", em);
		PlayerPrefs.SetInt("p82hs", hs);

		name = "dela Cruz";
		country = "Philipin";
		em = 9433;
		hs = 15;
		PlayerPrefs.SetString ("p83nam", name);
		PlayerPrefs.SetString ("p83cou", country);
		PlayerPrefs.SetInt ("p83mon", em);
		PlayerPrefs.SetInt("p83hs", hs);

		name = "DuongNguyen";
		country = "Vietnam";
		em = 9267;
		hs = 14;
		PlayerPrefs.SetString ("p84nam", name);
		PlayerPrefs.SetString ("p84cou", country);
		PlayerPrefs.SetInt ("p84mon", em);
		PlayerPrefs.SetInt("p84hs", hs);

		name = "Matsumoto123";
		country = "Japan";
		em = 9054;
		hs = 18;
		PlayerPrefs.SetString ("p85nam", name);
		PlayerPrefs.SetString ("p85cou", country);
		PlayerPrefs.SetInt ("p85mon", em);
		PlayerPrefs.SetInt("p85hs", hs);

		name = "Player3124";
		country = "Cuba";
		em = 9011;
		hs = 16;
		PlayerPrefs.SetString ("p86nam", name);
		PlayerPrefs.SetString ("p86cou", country);
		PlayerPrefs.SetInt ("p86mon", em);
		PlayerPrefs.SetInt("p86hs", hs);

		name = "Player864645";
		country = "France";
		em = 8509;
		hs = 18;
		PlayerPrefs.SetString ("p87nam", name);
		PlayerPrefs.SetString ("p87cou", country);
		PlayerPrefs.SetInt ("p87mon", em);
		PlayerPrefs.SetInt("p87hs", hs);

		name = "SukaOgawa19";
		country = "Japan";
		em = 8309;
		hs  = 15;
		PlayerPrefs.SetString ("p88nam", name);
		PlayerPrefs.SetString ("p88cou", country);
		PlayerPrefs.SetInt ("p88mon", em);
		PlayerPrefs.SetInt("p88hs", hs);

		name = "Player742344";
		country = "Piece";
		em = 8287;
		hs = 17;
		PlayerPrefs.SetString ("p89nam", name);
		PlayerPrefs.SetString ("p89cou", country);
		PlayerPrefs.SetInt ("p89mon", em);
		PlayerPrefs.SetInt("p89hs", hs);

		name = "Amad Cun Ves";
		country = "Thailand";
		em = 8106;
		hs = 18;
		PlayerPrefs.SetString ("p90nam", name);
		PlayerPrefs.SetString ("p90cou", country);
		PlayerPrefs.SetInt ("p90mon", em);
		PlayerPrefs.SetInt("p90hs", hs);

		name = "Player974542";
		country = "Brazil";
		em = 8105;
		hs  = 15;
		PlayerPrefs.SetString ("p91nam", name);
		PlayerPrefs.SetString ("p91cou", country);
		PlayerPrefs.SetInt ("p91mon", em);
		PlayerPrefs.SetInt("p91hs", hs);


		name = "Ya ting";
		country = "China";
		em = 8053;
		hs  = 15;
		PlayerPrefs.SetString ("p92nam", name);
		PlayerPrefs.SetString ("p92cou", country);
		PlayerPrefs.SetInt ("p92mon", em);
		PlayerPrefs.SetInt("p92hs", hs);


		name = "Dominykas";
		country = "Lithuania";
		em = 7854;
		hs = 18;
		PlayerPrefs.SetString ("p93nam", name);
		PlayerPrefs.SetString ("p93cou", country);
		PlayerPrefs.SetInt ("p93mon", em);
		PlayerPrefs.SetInt("p93hs", hs);


		name = "Player776542";
		country = "Danmark";
		em = 7787;
		hs  = 15;
		PlayerPrefs.SetString ("p94nam", name);
		PlayerPrefs.SetString ("p94cou", country);
		PlayerPrefs.SetInt ("p94mon", em);
		PlayerPrefs.SetInt("p94hs", hs);


		name = "Emma";
		country = "USA";
		em = 7645;
		hs = 17;
		PlayerPrefs.SetString ("p95nam", name);
		PlayerPrefs.SetString ("p95cou", country);
		PlayerPrefs.SetInt ("p95mon", em);
		PlayerPrefs.SetInt("p95hs", hs);


		name = "Esther Dasa";
		country = "USA";
		em = 7565;
		hs = 16;
		PlayerPrefs.SetString ("p96nam", name);
		PlayerPrefs.SetString ("p96cou", country);
		PlayerPrefs.SetInt ("p96mon", em);
		PlayerPrefs.SetInt("p96hs", hs);


		name = "Florence";
		country = "canada";
		em = 7154;
		hs  = 15;
		PlayerPrefs.SetString ("p97nam", name);
		PlayerPrefs.SetString ("p97cou", country);
		PlayerPrefs.SetInt ("p97mon", em);
		PlayerPrefs.SetInt("p97hs", hs);


		name = "Wale Moris";
		country = "Algeria";
		em = 7032;
		hs = 18;
		PlayerPrefs.SetString ("p98nam", name);
		PlayerPrefs.SetString ("p98cou", country);
		PlayerPrefs.SetInt ("p98mon", em);
		PlayerPrefs.SetInt("p98hs", hs);


		name = "Player53443";
		country = "Brunei";
		em = 6965;
		hs  = 15;
		PlayerPrefs.SetString ("p99nam", name);
		PlayerPrefs.SetString ("p99cou", country);
		PlayerPrefs.SetInt ("p99mon", em);
		PlayerPrefs.SetInt("p99hs", hs);


		name = "Widelene";
		country = "Hailiti";
		em = 6954;
		hs = 17;
		PlayerPrefs.SetString ("p100nam", name);
		PlayerPrefs.SetString ("p100cou", country);
		PlayerPrefs.SetInt ("p100mon", em);
		PlayerPrefs.SetInt("p100hs", hs);


		name = "rerwer353";
		country = "india";
		em = 6576;
		hs = 18;
		PlayerPrefs.SetString ("p101nam", name);
		PlayerPrefs.SetString ("p101cou", country);
		PlayerPrefs.SetInt ("p101mon", em);
		PlayerPrefs.SetInt("p101hs", hs);

		name = "Player322332";
		country = "China";
		em = 5787;
		hs  = 15;
		PlayerPrefs.SetString ("p102nam", name);
		PlayerPrefs.SetString ("p102cou", country);
		PlayerPrefs.SetInt ("p102mon", em);
		PlayerPrefs.SetInt("p102hs", hs);


		name = "Emit raonic";
		country = "USA";
		em = 5645;
		hs = 17;
		PlayerPrefs.SetString ("p103nam", name);
		PlayerPrefs.SetString ("p103cou", country);
		PlayerPrefs.SetInt ("p103mon", em);
		PlayerPrefs.SetInt("p103hs", hs);


		name = "1234567654321";
		country = "Mozambic";
		em = 5565;
		hs = 16;
		PlayerPrefs.SetString ("p104nam", name);
		PlayerPrefs.SetString ("p104cou", country);
		PlayerPrefs.SetInt ("p104mon", em);
		PlayerPrefs.SetInt("p104hs", hs);


		name = "Werim5654";
		country = "canada";
		em = 5154;
		hs  = 15;
		PlayerPrefs.SetString ("p105nam", name);
		PlayerPrefs.SetString ("p105cou", country);
		PlayerPrefs.SetInt ("p105mon", em);
		PlayerPrefs.SetInt("p105hs", hs);


		name = "Ritham Ewod";
		country = "Croatia";
		em = 5032;
		hs = 18;
		PlayerPrefs.SetString ("p106nam", name);
		PlayerPrefs.SetString ("p106cou", country);
		PlayerPrefs.SetInt ("p106mon", em);
		PlayerPrefs.SetInt("p106hs", hs);


		name = "Player645675";
		country = "Australlia";
		em = 4965;
		hs  = 15;
		PlayerPrefs.SetString ("p107nam", name);
		PlayerPrefs.SetString ("p107cou", country);
		PlayerPrefs.SetInt ("p107mon", em);
		PlayerPrefs.SetInt("p107hs", hs);


		name = "Widic Emimin";
		country = "Africa";
		em = 4954;
		hs = 17;
		PlayerPrefs.SetString ("p108nam", name);
		PlayerPrefs.SetString ("p108cou", country);
		PlayerPrefs.SetInt ("p108mon", em);
		PlayerPrefs.SetInt("p108hs", hs);


		name = "yeomin123";
		country = "india";
		em = 4576;
		hs = 18;
		PlayerPrefs.SetString ("p109nam", name);
		PlayerPrefs.SetString ("p109cou", country);
		PlayerPrefs.SetInt ("p109mon", em);
		PlayerPrefs.SetInt("p109hs", hs);

		name = "Player64564564";
		country = "USA";
		em = 4865;
		hs  = 16;
		PlayerPrefs.SetString ("p110nam", name);
		PlayerPrefs.SetString ("p110cou", country);
		PlayerPrefs.SetInt ("p110mon", em);
		PlayerPrefs.SetInt("p110hs", hs);

		name = "Player6454645";
		country = "USA";
		em = 4715;
		hs  = 17;
		PlayerPrefs.SetString ("p111nam", name);
		PlayerPrefs.SetString ("p111cou", country);
		PlayerPrefs.SetInt ("p111mon", em);
		PlayerPrefs.SetInt("p111hs", hs);

		name = "Player64564344";
		country = "USA";
		em = 4530;
		hs  = 15;
		PlayerPrefs.SetString ("p112nam", name);
		PlayerPrefs.SetString ("p112cou", country);
		PlayerPrefs.SetInt ("p112mon", em);
		PlayerPrefs.SetInt("p112hs", hs);

		name = "Player86743645";
		country = "USA";
		em = 4467;
		hs  = 16;
		PlayerPrefs.SetString ("p113nam", name);
		PlayerPrefs.SetString ("p113cou", country);
		PlayerPrefs.SetInt ("p113mon", em);
		PlayerPrefs.SetInt("p113hs", hs);

		name = "Player656546645";
		country = "USA";
		em = 4369;
		hs  = 14;
		PlayerPrefs.SetString ("p114nam", name);
		PlayerPrefs.SetString ("p114cou", country);
		PlayerPrefs.SetInt ("p114mon", em);
		PlayerPrefs.SetInt("p114hs", hs);

		name = "Player67755647";
		country = "USA";
		em = 4295;
		hs  = 15;
		PlayerPrefs.SetString ("p115nam", name);
		PlayerPrefs.SetString ("p115cou", country);
		PlayerPrefs.SetInt ("p115mon", em);
		PlayerPrefs.SetInt("p115hs", hs);

		name = "Player86767585";
		country = "USA";
		em = 4165;
		hs  = 16;
		PlayerPrefs.SetString ("p116nam", name);
		PlayerPrefs.SetString ("p116cou", country);
		PlayerPrefs.SetInt ("p116mon", em);
		PlayerPrefs.SetInt("p116hs", hs);


		name = "Player7856856";
		country = "USA";
		em = 3965;
		hs  = 15;
		PlayerPrefs.SetString ("p117nam", name);
		PlayerPrefs.SetString ("p117cou", country);
		PlayerPrefs.SetInt ("p117mon", em);
		PlayerPrefs.SetInt("p117hs", hs);

		name = "Player9756754";
		country = "USA";
		em = 3865;
		hs  = 16;
		PlayerPrefs.SetString ("p118nam", name);
		PlayerPrefs.SetString ("p118cou", country);
		PlayerPrefs.SetInt ("p118mon", em);
		PlayerPrefs.SetInt("p118hs", hs);

		name = "Player76475647";
		country = "USA";
		em = 3765;
		hs  = 17;
		PlayerPrefs.SetString ("p119nam", name);
		PlayerPrefs.SetString ("p119cou", country);
		PlayerPrefs.SetInt ("p119mon", em);
		PlayerPrefs.SetInt("p119hs", hs);

		name = "Player32546454";
		country = "USA";
		em = 3865;
		hs  = 16;
		PlayerPrefs.SetString ("p120nam", name);
		PlayerPrefs.SetString ("p120cou", country);
		PlayerPrefs.SetInt ("p120mon", em);
		PlayerPrefs.SetInt("p120hs", hs);

		name = "Player6475778768";
		country = "USA";
		em = 3735;
		hs  = 14;
		PlayerPrefs.SetString ("p121nam", name);
		PlayerPrefs.SetString ("p121cou", country);
		PlayerPrefs.SetInt ("p121mon", em);
		PlayerPrefs.SetInt("p121hs", hs);

		name = "Player66676543";
		country = "USA";
		em = 3660;
		hs  = 15;
		PlayerPrefs.SetString ("p122nam", name);
		PlayerPrefs.SetString ("p122cou", country);
		PlayerPrefs.SetInt ("p122mon", em);
		PlayerPrefs.SetInt("p122hs", hs);

		name = "Playe7566646";
		country = "USA";
		em = 3555;
		hs  = 15;
		PlayerPrefs.SetString ("p123nam", name);
		PlayerPrefs.SetString ("p123cou", country);
		PlayerPrefs.SetInt ("p123mon", em);
		PlayerPrefs.SetInt("p123hs", hs);

		name = "Player764645";
		country = "USA";
		em = 3465;
		hs  = 15;
		PlayerPrefs.SetString ("p124nam", name);
		PlayerPrefs.SetString ("p124cou", country);
		PlayerPrefs.SetInt ("p124mon", em);
		PlayerPrefs.SetInt("p124hs", hs);

		name = "Player765445";
		country = "USA";
		em = 3395;
		hs  = 15;
		PlayerPrefs.SetString ("p125nam", name);
		PlayerPrefs.SetString ("p125cou", country);
		PlayerPrefs.SetInt ("p125mon", em);
		PlayerPrefs.SetInt("p125hs", hs);

		name = "Player745635";
		country = "USA";
		em = 3265;
		hs  = 15;
		PlayerPrefs.SetString ("p126nam", name);
		PlayerPrefs.SetString ("p126cou", country);
		PlayerPrefs.SetInt ("p126mon", em);
		PlayerPrefs.SetInt("p126hs", hs);
		name = "Player534534544";
		country = "USA";
		em = 2965;
		hs  = 15;
		PlayerPrefs.SetString ("p127nam", name);
		PlayerPrefs.SetString ("p127cou", country);
		PlayerPrefs.SetInt ("p127mon", em);
		PlayerPrefs.SetInt("p127hs", hs);

		name = "Player2453455";
		country = "USA";
		em = 2875;
		hs  = 15;
		PlayerPrefs.SetString ("p128nam", name);
		PlayerPrefs.SetString ("p128cou", country);
		PlayerPrefs.SetInt ("p128mon", em);
		PlayerPrefs.SetInt("p128hs", hs);

		name = "Player535534";
		country = "USA";
		em = 2765;
		hs  = 15;
		PlayerPrefs.SetString ("p129nam", name);
		PlayerPrefs.SetString ("p129cou", country);
		PlayerPrefs.SetInt ("p129mon", em);
		PlayerPrefs.SetInt("p129hs", hs);

		name = "Player646555564564";
		country = "USA";
		em = 4865;
		hs  = 16;
		PlayerPrefs.SetString ("p130nam", name);
		PlayerPrefs.SetString ("p130cou", country);
		PlayerPrefs.SetInt ("p130mon", em);
		PlayerPrefs.SetInt("p130hs", hs);

		name = "Player6454656645";
		country = "USA";
		em = 4715;
		hs  = 17;
		PlayerPrefs.SetString ("p131nam", name);
		PlayerPrefs.SetString ("p131cou", country);
		PlayerPrefs.SetInt ("p131mon", em);
		PlayerPrefs.SetInt("p131hs", hs);

		name = "Player6456456344";
		country = "USA";
		em = 4530;
		hs  = 15;
		PlayerPrefs.SetString ("p132nam", name);
		PlayerPrefs.SetString ("p132cou", country);
		PlayerPrefs.SetInt ("p132mon", em);
		PlayerPrefs.SetInt("p132hs", hs);

		name = "Player8674eret63645";
		country = "USA";
		em = 4467;
		hs  = 16;
		PlayerPrefs.SetString ("p133nam", name);
		PlayerPrefs.SetString ("p133cou", country);
		PlayerPrefs.SetInt ("p133mon", em);
		PlayerPrefs.SetInt("p133hs", hs);

		name = "Player6565gre46645";
		country = "USA";
		em = 4369;
		hs  = 14;
		PlayerPrefs.SetString ("p134nam", name);
		PlayerPrefs.SetString ("p134cou", country);
		PlayerPrefs.SetInt ("p134mon", em);
		PlayerPrefs.SetInt("p134hs", hs);

		name = "Player6775dwew5647";
		country = "USA";
		em = 4295;
		hs  = 15;
		PlayerPrefs.SetString ("p135nam", name);
		PlayerPrefs.SetString ("p135cou", country);
		PlayerPrefs.SetInt ("p135mon", em);
		PlayerPrefs.SetInt("p135hs", hs);

		name = "Player86767fgre85";
		country = "USA";
		em = 4165;
		hs  = 16;
		PlayerPrefs.SetString ("p136nam", name);
		PlayerPrefs.SetString ("p136cou", country);
		PlayerPrefs.SetInt ("p136mon", em);
		PlayerPrefs.SetInt("p136hs", hs);


		name = "Player7856ewew856";
		country = "USA";
		em = 3965;
		hs  = 15;
		PlayerPrefs.SetString ("p137nam", name);
		PlayerPrefs.SetString ("p137cou", country);
		PlayerPrefs.SetInt ("p137mon", em);
		PlayerPrefs.SetInt("p137hs", hs);

		name = "Player975gre6754";
		country = "USA";
		em = 3865;
		hs  = 16;
		PlayerPrefs.SetString ("p138nam", name);
		PlayerPrefs.SetString ("p138cou", country);
		PlayerPrefs.SetInt ("p138mon", em);
		PlayerPrefs.SetInt("p138hs", hs);

		name = "Player764ewee75647";
		country = "USA";
		em = 3765;
		hs  = 17;
		PlayerPrefs.SetString ("p139nam", name);
		PlayerPrefs.SetString ("p139cou", country);
		PlayerPrefs.SetInt ("p139mon", em);
		PlayerPrefs.SetInt("p139hs", hs);

		name = "Player325ew4446454";
		country = "USA";
		em = 3865;
		hs  = 16;
		PlayerPrefs.SetString ("p140nam", name);
		PlayerPrefs.SetString ("p140cou", country);
		PlayerPrefs.SetInt ("p140mon", em);
		PlayerPrefs.SetInt("p140hs", hs);

		name = "Player64757g4478768";
		country = "USA";
		em = 3735;
		hs  = 14;
		PlayerPrefs.SetString ("p141nam", name);
		PlayerPrefs.SetString ("p141cou", country);
		PlayerPrefs.SetInt ("p141mon", em);
		PlayerPrefs.SetInt("p141hs", hs);

		name = "Player66676ge4543";
		country = "USA";
		em = 3660;
		hs  = 15;
		PlayerPrefs.SetString ("p142nam", name);
		PlayerPrefs.SetString ("p142cou", country);
		PlayerPrefs.SetInt ("p142mon", em);
		PlayerPrefs.SetInt("p142hs", hs);

		name = "Playe7566646";
		country = "USA";
		em = 3555;
		hs  = 15;
		PlayerPrefs.SetString ("p143nam", name);
		PlayerPrefs.SetString ("p143cou", country);
		PlayerPrefs.SetInt ("p143mon", em);
		PlayerPrefs.SetInt("p143hs", hs);

		name = "Player7646g4445";
		country = "USA";
		em = 3465;
		hs  = 15;
		PlayerPrefs.SetString ("p144nam", name);
		PlayerPrefs.SetString ("p144cou", country);
		PlayerPrefs.SetInt ("p144mon", em);
		PlayerPrefs.SetInt("p144hs", hs);

		name = "Player765f4f4445";
		country = "USA";
		em = 3395;
		hs  = 15;
		PlayerPrefs.SetString ("p145nam", name);
		PlayerPrefs.SetString ("p145cou", country);
		PlayerPrefs.SetInt ("p145mon", em);
		PlayerPrefs.SetInt("p145hs", hs);

		name = "Player7444t45635";
		country = "USA";
		em = 3265;
		hs  = 15;
		PlayerPrefs.SetString ("p146nam", name);
		PlayerPrefs.SetString ("p146cou", country);
		PlayerPrefs.SetInt ("p146mon", em);
		PlayerPrefs.SetInt("p146hs", hs);
		name = "Player5345ge434544";
		country = "USA";
		em = 2965;
		hs  = 15;
		PlayerPrefs.SetString ("p147nam", name);
		PlayerPrefs.SetString ("p147cou", country);
		PlayerPrefs.SetInt ("p147mon", em);
		PlayerPrefs.SetInt("p147hs", hs);

		name = "Player2453e4f455";
		country = "USA";
		em = 2875;
		hs  = 15;
		PlayerPrefs.SetString ("p148nam", name);
		PlayerPrefs.SetString ("p148cou", country);
		PlayerPrefs.SetInt ("p148mon", em);
		PlayerPrefs.SetInt("p148hs", hs);

		name = "Player535ge5534";
		country = "USA";
		em = 2765;
		hs  = 15;
		PlayerPrefs.SetString ("p149nam", name);
		PlayerPrefs.SetString ("p149cou", country);
		PlayerPrefs.SetInt ("p149mon", em);
		PlayerPrefs.SetInt("p149hs", hs);
		name = "Player643w564564";
		country = "USA";
		em = 4865;
		hs  = 16;
		PlayerPrefs.SetString ("p150nam", name);
		PlayerPrefs.SetString ("p150cou", country);
		PlayerPrefs.SetInt ("p150mon", em);
		PlayerPrefs.SetInt("p150hs", hs);

		name = "Player64ew54645";
		country = "USA";
		em = 4715;
		hs  = 17;
		PlayerPrefs.SetString ("p151nam", name);
		PlayerPrefs.SetString ("p151cou", country);
		PlayerPrefs.SetInt ("p151mon", em);
		PlayerPrefs.SetInt("p151hs", hs);

		name = "Player6456vew4344";
		country = "USA";
		em = 4530;
		hs  = 15;
		PlayerPrefs.SetString ("p152nam", name);
		PlayerPrefs.SetString ("p152cou", country);
		PlayerPrefs.SetInt ("p152mon", em);
		PlayerPrefs.SetInt("p152hs", hs);

		name = "Player867fwe43645";
		country = "USA";
		em = 4467;
		hs  = 16;
		PlayerPrefs.SetString ("p153nam", name);
		PlayerPrefs.SetString ("p153cou", country);
		PlayerPrefs.SetInt ("p153mon", em);
		PlayerPrefs.SetInt("p153hs", hs);

		name = "Player65654qwe6645";
		country = "USA";
		em = 4369;
		hs  = 14;
		PlayerPrefs.SetString ("p154nam", name);
		PlayerPrefs.SetString ("p154cou", country);
		PlayerPrefs.SetInt ("p154mon", em);
		PlayerPrefs.SetInt("p154hs", hs);

		name = "Player67755ht647";
		country = "USA";
		em = 4295;
		hs  = 15;
		PlayerPrefs.SetString ("p155nam", name);
		PlayerPrefs.SetString ("p155cou", country);
		PlayerPrefs.SetInt ("p155mon", em);
		PlayerPrefs.SetInt("p155hs", hs);

		name = "Player867kui67585";
		country = "USA";
		em = 4165;
		hs  = 16;
		PlayerPrefs.SetString ("p156nam", name);
		PlayerPrefs.SetString ("p156cou", country);
		PlayerPrefs.SetInt ("p156mon", em);
		PlayerPrefs.SetInt("p156hs", hs);


		name = "Player78kkiuk56856";
		country = "USA";
		em = 3965;
		hs  = 15;
		PlayerPrefs.SetString ("p157nam", name);
		PlayerPrefs.SetString ("p157cou", country);
		PlayerPrefs.SetInt ("p157mon", em);
		PlayerPrefs.SetInt("p157hs", hs);

		name = "Player975re6754";
		country = "USA";
		em = 3865;
		hs  = 16;
		PlayerPrefs.SetString ("p158nam", name);
		PlayerPrefs.SetString ("p158cou", country);
		PlayerPrefs.SetInt ("p158mon", em);
		PlayerPrefs.SetInt("p158hs", hs);

		name = "Player7we6475647";
		country = "USA";
		em = 3765;
		hs  = 17;
		PlayerPrefs.SetString ("p159nam", name);
		PlayerPrefs.SetString ("p159cou", country);
		PlayerPrefs.SetInt ("p159mon", em);
		PlayerPrefs.SetInt("p159hs", hs);

		name = "Player325hrtr46454";
		country = "USA";
		em = 3865;
		hs  = 16;
		PlayerPrefs.SetString ("p160nam", name);
		PlayerPrefs.SetString ("p160cou", country);
		PlayerPrefs.SetInt ("p160mon", em);
		PlayerPrefs.SetInt("p160hs", hs);

		name = "Player64757ree78768";
		country = "USA";
		em = 3735;
		hs  = 14;
		PlayerPrefs.SetString ("p161nam", name);
		PlayerPrefs.SetString ("p161cou", country);
		PlayerPrefs.SetInt ("p161mon", em);
		PlayerPrefs.SetInt("p161hs", hs);

		name = "Player666jyjy76543";
		country = "USA";
		em = 3660;
		hs  = 15;
		PlayerPrefs.SetString ("p162nam", name);
		PlayerPrefs.SetString ("p162cou", country);
		PlayerPrefs.SetInt ("p162mon", em);
		PlayerPrefs.SetInt("p162hs", hs);

		name = "Playe7566ge646";
		country = "USA";
		em = 3555;
		hs  = 15;
		PlayerPrefs.SetString ("p163nam", name);
		PlayerPrefs.SetString ("p163cou", country);
		PlayerPrefs.SetInt ("p163mon", em);
		PlayerPrefs.SetInt("p163hs", hs);

		name = "Player7egr64645";
		country = "USA";
		em = 3465;
		hs  = 15;
		PlayerPrefs.SetString ("p164nam", name);
		PlayerPrefs.SetString ("p164cou", country);
		PlayerPrefs.SetInt ("p164mon", em);
		PlayerPrefs.SetInt("p164hs", hs);

		name = "Player76rer5445";
		country = "USA";
		em = 3395;
		hs  = 15;
		PlayerPrefs.SetString ("p165nam", name);
		PlayerPrefs.SetString ("p165cou", country);
		PlayerPrefs.SetInt ("p165mon", em);
		PlayerPrefs.SetInt("p165hs", hs);

		name = "Player74gg45635";
		country = "USA";
		em = 3265;
		hs  = 15;
		PlayerPrefs.SetString ("p166nam", name);
		PlayerPrefs.SetString ("p166cou", country);
		PlayerPrefs.SetInt ("p166mon", em);
		PlayerPrefs.SetInt("p166hs", hs);
		name = "Player5345gr34544";
		country = "USA";
		em = 2965;
		hs  = 15;
		PlayerPrefs.SetString ("p167nam", name);
		PlayerPrefs.SetString ("p167cou", country);
		PlayerPrefs.SetInt ("p167mon", em);
		PlayerPrefs.SetInt("p167hs", hs);

		name = "Player245ere3455";
		country = "USA";
		em = 2875;
		hs  = 15;
		PlayerPrefs.SetString ("p168nam", name);
		PlayerPrefs.SetString ("p168cou", country);
		PlayerPrefs.SetInt ("p168mon", em);
		PlayerPrefs.SetInt("p168hs", hs);

		name = "Player535i9534";
		country = "USA";
		em = 2765;
		hs  = 15;
		PlayerPrefs.SetString ("p169nam", name);
		PlayerPrefs.SetString ("p169cou", country);
		PlayerPrefs.SetInt ("p169mon", em);
		PlayerPrefs.SetInt("p169hs", hs);

		name = "Player645oiop64564";
		country = "USA";
		em = 4865;
		hs  = 16;
		PlayerPrefs.SetString ("p170nam", name);
		PlayerPrefs.SetString ("p170cou", country);
		PlayerPrefs.SetInt ("p170mon", em);
		PlayerPrefs.SetInt("p170hs", hs);

		name = "Player64545y454645";
		country = "USA";
		em = 4715;
		hs  = 17;
		PlayerPrefs.SetString ("p171nam", name);
		PlayerPrefs.SetString ("p171cou", country);
		PlayerPrefs.SetInt ("p171mon", em);
		PlayerPrefs.SetInt("p171hs", hs);

		name = "Player6455t4e64344";
		country = "USA";
		em = 4530;
		hs  = 15;
		PlayerPrefs.SetString ("p172nam", name);
		PlayerPrefs.SetString ("p172cou", country);
		PlayerPrefs.SetInt ("p172mon", em);
		PlayerPrefs.SetInt("p172hs", hs);

		name = "Player86743yr5645";
		country = "USA";
		em = 4467;
		hs  = 16;
		PlayerPrefs.SetString ("p173nam", name);
		PlayerPrefs.SetString ("p173cou", country);
		PlayerPrefs.SetInt ("p173mon", em);
		PlayerPrefs.SetInt("p173hs", hs);

		name = "Player656544r36645";
		country = "USA";
		em = 4369;
		hs  = 14;
		PlayerPrefs.SetString ("p174nam", name);
		PlayerPrefs.SetString ("p174cou", country);
		PlayerPrefs.SetInt ("p174mon", em);
		PlayerPrefs.SetInt("p174hs", hs);

		name = "Player687i857755647";
		country = "USA";
		em = 4295;
		hs  = 15;
		PlayerPrefs.SetString ("p175nam", name);
		PlayerPrefs.SetString ("p175cou", country);
		PlayerPrefs.SetInt ("p175mon", em);
		PlayerPrefs.SetInt("p175hs", hs);

		name = "Player86767ii8585";
		country = "USA";
		em = 4165;
		hs  = 16;
		PlayerPrefs.SetString ("p176nam", name);
		PlayerPrefs.SetString ("p176cou", country);
		PlayerPrefs.SetInt ("p176mon", em);
		PlayerPrefs.SetInt("p176hs", hs);


		name = "Player7856534856";
		country = "USA";
		em = 3965;
		hs  = 15;
		PlayerPrefs.SetString ("p177nam", name);
		PlayerPrefs.SetString ("p177cou", country);
		PlayerPrefs.SetInt ("p177mon", em);
		PlayerPrefs.SetInt("p177hs", hs);

		name = "Player97567erwew54";
		country = "USA";
		em = 3865;
		hs  = 16;
		PlayerPrefs.SetString ("p178nam", name);
		PlayerPrefs.SetString ("p178cou", country);
		PlayerPrefs.SetInt ("p178mon", em);
		PlayerPrefs.SetInt("p178hs", hs);

		name = "Player76475c553647";
		country = "USA";
		em = 3765;
		hs  = 17;
		PlayerPrefs.SetString ("p179nam", name);
		PlayerPrefs.SetString ("p179cou", country);
		PlayerPrefs.SetInt ("p179mon", em);
		PlayerPrefs.SetInt("p179hs", hs);

		name = "Player3254y53v6454";
		country = "USA";
		em = 3865;
		hs  = 16;
		PlayerPrefs.SetString ("p180nam", name);
		PlayerPrefs.SetString ("p180cou", country);
		PlayerPrefs.SetInt ("p180mon", em);
		PlayerPrefs.SetInt("p180hs", hs);

		name = "Player64757787t345v68";
		country = "USA";
		em = 3735;
		hs  = 14;
		PlayerPrefs.SetString ("p181nam", name);
		PlayerPrefs.SetString ("p181cou", country);
		PlayerPrefs.SetInt ("p181mon", em);
		PlayerPrefs.SetInt("p181hs", hs);

		name = "Player6667y3t36543";
		country = "USA";
		em = 3660;
		hs  = 15;
		PlayerPrefs.SetString ("p182nam", name);
		PlayerPrefs.SetString ("p182cou", country);
		PlayerPrefs.SetInt ("p182mon", em);
		PlayerPrefs.SetInt("p182hs", hs);

		name = "Playe7566tet646";
		country = "USA";
		em = 3555;
		hs  = 15;
		PlayerPrefs.SetString ("p183nam", name);
		PlayerPrefs.SetString ("p183cou", country);
		PlayerPrefs.SetInt ("p183mon", em);
		PlayerPrefs.SetInt("p183hs", hs);

		name = "Player764626245";
		country = "USA";
		em = 3465;
		hs  = 15;
		PlayerPrefs.SetString ("p184nam", name);
		PlayerPrefs.SetString ("p184cou", country);
		PlayerPrefs.SetInt ("p184mon", em);
		PlayerPrefs.SetInt("p184hs", hs);

		name = "Player76553445";
		country = "USA";
		em = 3395;
		hs  = 15;
		PlayerPrefs.SetString ("p185nam", name);
		PlayerPrefs.SetString ("p185cou", country);
		PlayerPrefs.SetInt ("p185mon", em);
		PlayerPrefs.SetInt("p185hs", hs);

		name = "Player74534635";
		country = "USA";
		em = 3265;
		hs  = 15;
		PlayerPrefs.SetString ("p186nam", name);
		PlayerPrefs.SetString ("p186cou", country);
		PlayerPrefs.SetInt ("p186mon", em);
		PlayerPrefs.SetInt("p186hs", hs);
		name = "Player53453344544";
		country = "USA";
		em = 2965;
		hs  = 15;
		PlayerPrefs.SetString ("p187nam", name);
		PlayerPrefs.SetString ("p187cou", country);
		PlayerPrefs.SetInt ("p187mon", em);
		PlayerPrefs.SetInt("p187hs", hs);

		name = "Player2453454555";
		country = "USA";
		em = 2875;
		hs  = 15;
		PlayerPrefs.SetString ("p188nam", name);
		PlayerPrefs.SetString ("p188cou", country);
		PlayerPrefs.SetInt ("p188mon", em);
		PlayerPrefs.SetInt("p188hs", hs);

		name = "Player535455534";
		country = "USA";
		em = 2765;
		hs  = 15;
		PlayerPrefs.SetString ("p189nam", name);
		PlayerPrefs.SetString ("p189cou", country);
		PlayerPrefs.SetInt ("p189mon", em);
		PlayerPrefs.SetInt("p189hs", hs);
		//	StartCoroutine(upscoreai ());
	}

	public void AddMore2(){
		string name, country;
		int hs, em;

		//up222();
	}
}

public struct Highscore {
	public string username;
	public int score, earn, country;
	public Highscore(string _username, int _earn, int _score, int _country){
		username = _username;
		country = _country;
		score = _score;
		earn = _earn;
	}
}


public struct Highscore2{
	public string username;
	public int score;
	public int earn;
	public string country;
	public Highscore2(string _username, int _earn, int _score, string _country){
		username = _username;
		country = _country;
		score = _score;
		earn = _earn;
	}
}
