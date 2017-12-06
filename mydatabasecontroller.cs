using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using UnityEngine.UI;
using DatabaseControl;

public class mydatabasecontroller : MonoBehaviour {
	public static mydatabasecontroller instance = null;

	public Text menuhighscoretext, menumoneyearnedtext, menuwinnertext, numberactivetext, prizetext;

	public Text clock, clockday;

	public string databaseName = "", chatroomdatabaseName;

	public GameObject tmp;

	public GameObject shopButton;

	string username = "";
	string password = "";

	public string mymaindatabasename;

	public int secondnow, minutenow, hournow, daynow, monthnow, yearnow, secondnext, minutenext, hournext, daynext, monthnext, yearnext;
	public int secondnext2, minutenext2, hournext2, daynext2, monthnext2, yearnext2;
	double sremain, sremainday;
	public bool t1, t2, t3,  t4, t5, t6, t7, t8, t9, t10;
	public int isfirsttime;
	string thisday, beforeday;
	public float timeToUpdate;
	bool isIR;

	void Awake(){
	//	PlayerPrefs.SetInt ("my1stime", 0);
		isfirsttime = PlayerPrefs.GetInt ("my1stime");
		if (instance == null) {
			instance = this;
		} else {
			Destroy (this.gameObject);
		}
		DontDestroyOnLoad (this.gameObject);
	}

	public void deleteallscore(){
		//StartCoroutine ("DeleteAllScore");
	}

	IEnumerator DeleteAllScore(){
		WWW www = new WWW ("http://dreamlo.com/lb/" + "kq2IUgwHZ0qEocU_QlOsJA6f6U5DQUN0mNHPt9t4Wg7g" + "/clear");
		yield return www;
		if (string.IsNullOrEmpty (www.error)) {
			print ("Delete All Score Successful");
			Application.Quit ();
		} else {
			StartCoroutine ("DeleteAllScore");
			print ("Delete All Score Error " + www.error);
		}
	}

	void Start ()
	{
		timeToUpdate = 3;
	    t7 = false;
		t8 = false;
		t1 = false;
		t2 = false;
		t3 = false;
		t4 = false;
		t5 = false;
		t6 = false;
		t9 = false;
		t10 = false;
		StartCoroutine ("waitForStartCo");
	}

	IEnumerator waitForStartCo(){
		while (true) {
			if (internetchecker.instance.internet == false)
				yield return new WaitForSeconds (0.5f);
			if (internetchecker.instance.internet == true)
				break;
		}

		yield return new WaitForSeconds (0.5f);

		if(gamemanager.instance.firsttime == false) getNextDay ();
	

		//StartCoroutine (GetWinnerCo ());
	}

	public void TakeAPlace(){
		string dtb = "mydatabase" + gamemanager.instance.whichdatabase.ToString ();
		PlayerPrefs.SetString ("dtb", dtb);
		StartCoroutine ("SetCo");
	}

	IEnumerator SetCo(){
		
		while (internetchecker.instance.internet == false) {
			yield return new WaitForSeconds (0.5f);
			if (internetchecker.instance.internet == true)
				break;
		}

		IEnumerator e = DCP.RunCS(PlayerPrefs.GetString ("dtb"), "Set");

		while (e.MoveNext())
		{
			yield return e.Current;
		}

		string returnText = e.Current as string;

		if ((returnText.Length > 1 && returnText [0] == '<' && returnText [1] == '!')) {
			StartCoroutine (SetCo());
			yield break;
		}

		int pos = int.Parse (returnText);

		PlayerPrefs.SetInt ("pos1", pos);

		StartCoroutine (SetOldDayCo("123"));
		 
		yield return new WaitForSeconds (0.5f);

		getNextDay ();

		Debug.Log (PlayerPrefs.GetString ("dtb") + " " + PlayerPrefs.GetInt ("pos1").ToString());

		gamemanager.instance.SetHighScore(0);
		gamemanager.instance.SetSecurity2 ();

		gamemanager.instance.SetMoney (10);
		gamemanager.instance.SetSecurity3();


		menuhighscoretext.text = "0";
		menumoneyearnedtext.text = "1.0$";
	}

	IEnumerator SetOldDayCo(string ttt){
		IEnumerator e = DCP.RunCS(PlayerPrefs.GetString ("dtb"), "SetOldDay", new string[2] { PlayerPrefs.GetInt ("pos1").ToString(), ttt });

		while (e.MoveNext())
		{
			yield return e.Current;
		}

		string returnText = e.Current as string;

		if (returnText.Length > 1 && returnText [0] == '<' && returnText [1] == '!') {
			StartCoroutine (SetOldDayCo(ttt));
			yield break;
		}

	}


	void Update ()
	{
		timeToUpdate -= Time.deltaTime;
		if (timeToUpdate <= 0) {
			timeToUpdate = 30;
			//StartCoroutine (GetWinnerCo ());
		}
		sremainday -= Time.deltaTime;
		if (t2 == true && sremainday < 0) {
			gamemanager.instance.stop = true;
			StartCoroutine ("setNextDateCo");
		}
		if (t2 == true) {
			daynow = (int)(sremainday / (24 * 60 * 60));
			hournow = ((int)(sremainday - daynow * 24 * 60 * 60) / (60 * 60));
			minutenow = ((int)(sremainday - daynow * 24 * 60 * 60 - hournow * 60 * 60)) / 60;
			secondnow = (int)(sremainday - daynow * 24 * 60 * 60 - hournow * 60 * 60 - minutenow * 60);
			clockday.text = hournow.ToString () + ":" + minutenow.ToString () + ":" + secondnow.ToString ();
			return;
		}
		if (t7 == true) {
			if(t3 == false) calculatetimeremaining ();
			t3 = true;
		}
		if (t8 == true) {
			if(t4 == false) timeremainingday ();
			t4 = true;
		}
	}

	public void calculatetimeremaining(){
		StartCoroutine ("caltime");
	}

	public void timeremainingday(){
		StartCoroutine ("caltimeday");
	}

	IEnumerator caltimeday(){
		IEnumerator e = DCP.RunCS(databaseName, "caltimeday", new string[6] {secondnext2.ToString(), minutenext2.ToString(), hournext2.ToString(), 
			daynext2.ToString(), (monthnext2 - 1).ToString(), yearnext2.ToString()} );

		while (e.MoveNext())
		{
			yield return e.Current;
		}

		string returnText = e.Current as string;

		if (returnText.Length > 1 && returnText [0] == '<' && returnText [1] == '!') {
			StartCoroutine (caltimeday());
			yield break;
		}

		sremainday = float.Parse (returnText);
		sremainday *= -1;

		if (sremainday < 0) {
			StartCoroutine ("setNextDateCo");
			gamemanager.instance.stop = true;
		} else {
			StartCoroutine (CheckingBonnusCo());
		}

		clockday.gameObject.SetActive (true);

		t2 = true;
	}

	IEnumerator setNextDateCo(){
		int secondnext3, hournext3, minutenext3, daynext3, monthnext3, yearnext3;

		daynext3 = daynext2;
		monthnext3 = monthnext2;
		yearnext3 = yearnext2;

		if (daynext2 == 31 && monthnext2 == 12) {
			daynext3 = 1;
			monthnext3 = 1;
			yearnext3 = yearnext2 + 1;
		} else {
			if ((yearnext2 % 4 == 0 && yearnext2 % 100 != 0) || yearnext2 % 400 == 0) {
				int[] nmonth = new int[12]{31, 29, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31};
				if(daynext2 == nmonth[monthnext2 - 1]){
					daynext3 = 1;
					monthnext3 = monthnext2 + 1;
				} else {
					daynext3 = daynext2 + 1;
					monthnext3 = monthnext2;
				}
			} else {
				int[] nmonth = new int[12]{31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31};
				if(daynext2 == nmonth[monthnext2 - 1]){
					daynext3 = 1;
					monthnext3 = monthnext2 + 1;
				} else {
					daynext3 = daynext2 + 1;
					monthnext3 = monthnext2;
				}
			}
		}

		string tmp = "0:0:0";

		tmp += ":" + daynext3.ToString() + ":" + monthnext3.ToString() + ":" + yearnext3.ToString();

		IEnumerator e = DCP.RunCS(databaseName, "setNextDate", new string[1]{tmp});

		while (e.MoveNext())
		{
			yield return e.Current;
		}

		string returnText = e.Current as string;

		if (returnText.Length > 1 && returnText [0] == '<' && returnText [1] == '!') {
			StartCoroutine (setNextDateCo());
			yield break;
		}

		DeleteActive ();
	}

	public void DeleteActive(){
		StartCoroutine (DeleteActiveCo());
	}
		
	IEnumerator SetBonusDailyCo(){
		yield break;
	}

	#region button pressed methods

	public void getNextDay(){
		StartCoroutine("getNextDateCo");
	}

	IEnumerator getNextDateCo(){
		IEnumerator e = DCP.RunCS(databaseName, "getNextDate");

		while (e.MoveNext())
		{
			yield return e.Current;
		}

		string returnText = e.Current as string;

		if (returnText.Length > 1 && returnText [0] == '<' && returnText [1] == '!') {
			StartCoroutine (getNextDateCo());
			yield break;
		}

		PlayerPrefs.SetString ("thisday", returnText);

		thisday = returnText;

		int tmp = 0, i = 0;
		for (; i <= returnText.Length - 1; i++) {
			if (returnText [i] == ':')
				break;
			else
				tmp = tmp * 10 + (returnText [i] - '0');
		}
		i++;
		secondnext2 = tmp;
		tmp = 0;

		for (; i <= returnText.Length - 1; i++) {
			if (returnText [i] == ':')
				break;
			else
				tmp = tmp * 10 + (returnText [i] - '0');
		}
		i++;
		minutenext2 = tmp;
		tmp = 0;

		for (; i <= returnText.Length - 1; i++) {
			if (returnText [i] == ':')
				break;
			else
				tmp = tmp * 10 + (returnText [i] - '0');
		}
		i++;
		hournext2 = tmp;
		tmp = 0;

		for (; i <= returnText.Length - 1; i++) {
			if (returnText [i] == ':')
				break;
			else
				tmp = tmp * 10 + (returnText [i] - '0');
		}
		i++;
		daynext2 = tmp;
		tmp = 0;

		for (; i <= returnText.Length - 1; i++) {
			if (returnText [i] == ':')
				break;
			else
				tmp = tmp * 10 + (returnText [i] - '0');
		}
		i++;
		monthnext2 = tmp;
		tmp = 0;

		for (; i <= returnText.Length - 1; i++) {
			if (returnText [i] == ':')
				break;
			else
				tmp = tmp * 10 + (returnText [i] - '0');
		}
		i++;
		yearnext2 = tmp;
		tmp = 0;

		t8 = true;
	}



	IEnumerator GetOldDayCo(){

		IEnumerator e = DCP.RunCS(PlayerPrefs.GetString ("dtb"), "GetOldDay", new string[1] { PlayerPrefs.GetInt ("pos1").ToString() });

		while (e.MoveNext())
		{
			yield return e.Current;
		}

		string returnText = e.Current as string;

		if (returnText.Length > 1 && returnText [0] == '<' && returnText [1] == '!') {
			StartCoroutine (GetOldDayCo());
			yield break;
		}

		beforeday = returnText;

		t9 = true;

		if (string.Compare (beforeday, thisday) != 0) {
			while (t5 == false) {
				yield return new WaitForSeconds(0.5f);
				if(t5 == true) break;
			}
			yield return new WaitForSeconds(0.5f);
			menuhighscoretext.text = gamemanager.instance.GetHighScore().ToString ();
			t10 = true;
		}

		StartCoroutine (SetOldDayCo(thisday));
	}

	public void AI(){
		StartCoroutine ("AICo");
	}

	IEnumerator AICo(){
		for (int i = 1; i <= 129; i++) {
			isIR = true;
			StartCoroutine (FAKEAICO(i));
			while (isIR == true) {
				yield return new WaitForSeconds (0.1f);
				if (isIR == false)
					break;
			}
		}
	}

	IEnumerator FAKEAICO(int i){


		IEnumerator e = DCP.RunCS(databaseName, "AI", new string[5] { i.ToString(), PlayerPrefs.GetString ("p" + i.ToString() + "nam"),  PlayerPrefs.GetString ("p" + i.ToString() + "cou"), PlayerPrefs.GetInt ("p" + i.ToString() + "mon").ToString(), PlayerPrefs.GetInt ("p" + i.ToString() + "hs").ToString()});

		while (e.MoveNext())
		{
			yield return e.Current;
		}

		string returnText = e.Current as string;

		if (returnText.Length > 1 && returnText [0] == '<' && returnText [1] == '!') {
			StartCoroutine (GetOldDayCo());
			yield break;
		}
		isIR = false;
		Debug.Log ("done " + i);
	}

	IEnumerator CheckingBonnusCo(){

		StartCoroutine (GetOldDayCo());

		yield break;

	}

	public void LoginStuff_LoginButtonPressed (string name, string password2)
	{
			username = name;
			password = password2;
			StartCoroutine(Login());
	}
		
	public void RegisterStuff_RegisterButtonPressed (string name, string password2)
	{

			username = name;
			password = password2;
			StartCoroutine(Register()); 
	}
		
	public void Data_SetDataButtonPressed (string data)
	{
	//	StartCoroutine(SetData(data));
	}
		
	public void Data_GetDataButtonPressed()
	{
		//StartCoroutine(GetData());
	}
	#endregion

	#region Run Command Sequences
	//Run the command sequence to login a user
	IEnumerator Login ()
	{
		while (internetchecker.instance.internet == false) {
			yield return new WaitForSeconds (0.5f);
			if (internetchecker.instance.internet == true)
				break;
		}
		StartCoroutine (GetCo());
		yield return new WaitForSeconds (0.5f);
	}


	IEnumerator GetWinnerCo(){
		IEnumerator e = DCP.RunCS(databaseName, "GetWinner");

		while (e.MoveNext())
		{
			yield return e.Current;
		}

		string returnText = e.Current as string;

		if ((returnText.Length > 1 && returnText [0] == '<' && returnText [1] == '!')) {
			StartCoroutine (GetWinnerCo());
			yield break;
		}

		menuwinnertext.text = returnText;
		StartCoroutine (GetActiveCo());

	}

	IEnumerator GetPrizeCo(){
		IEnumerator e = DCP.RunCS(databaseName, "GetPrize");

		while (e.MoveNext())
		{
			yield return e.Current;
		}

		string returnText = e.Current as string;

		if ((returnText.Length > 1 && returnText [0] == '<' && returnText [1] == '!')) {
			StartCoroutine (GetPrizeCo());
			yield break;
		}

		prizetext.text = returnText;

	}

	IEnumerator GetActiveCo(){
		IEnumerator e = DCP.RunCS(databaseName, "GetActivePlayers");

		while (e.MoveNext())
		{
			yield return e.Current;
		}

		string returnText = e.Current as string;

		if ((returnText.Length > 1 && returnText [0] == '<' && returnText [1] == '!')) {
			StartCoroutine (GetActiveCo());
			yield break;
		}

		numberactivetext.text = (int.Parse(returnText) + 1).ToString();
		StartCoroutine (GetPrizeCo ());

	}


	public void AddMoney(){
		StartCoroutine (AddMoneyCo());
	}

	IEnumerator AddMoneyCo(){
		IEnumerator e = DCP.RunCS(databaseName, "addmoney", new string[1]{"1"});

		while (e.MoveNext())
		{
			yield return e.Current;
		}

		string returnText = e.Current as string;

		if ((returnText.Length > 1 && returnText [0] == '<' && returnText [1] == '!')) {
			StartCoroutine (AddMoneyCo());
			yield break;
		}

	}

	public void GetTotalMoney(){
		StartCoroutine (GetMoneyCo());
	}

	IEnumerator GetMoneyCo(){
		IEnumerator e = DCP.RunCS(databaseName, "gettotalmoney");

		while (e.MoveNext())
		{
			yield return e.Current;
		}

		string returnText = e.Current as string;

		if ((returnText.Length > 1 && returnText [0] == '<' && returnText [1] == '!')) {
			StartCoroutine (GetMoneyCo());
			yield break;
		}
		gamemanager.instance.totalmoney = int.Parse (returnText);
		gamemanager.instance.totalmoneytxt.text = gamemanager.instance.totalmoney.ToString ();
	}

	public void Check(){
		StartCoroutine (CheckCo());
	}

	IEnumerator CheckCo(){
		string dtbcheck = "mydatabase" + gamemanager.instance.whichdatabasecheck.ToString ();
		IEnumerator e = DCP.RunCS(dtbcheck, "Get", new string[1]{gamemanager.instance.whichpositioncheck.ToString()});

		while (e.MoveNext())
		{
			yield return e.Current;
		}

		string returnText = e.Current as string;

		if ((returnText.Length > 1 && returnText [0] == '<' && returnText [1] == '!')) {
			StartCoroutine (CheckCo());
			yield break;
		}
		gamemanager.instance.identitycheck = returnText;
		gamemanager.instance.resulttxtcheck.text = gamemanager.instance.identitycheck;
	}

	IEnumerator DeleteActiveCo(){
		
		yield break;

		IEnumerator e = DCP.RunCS(databaseName, "DeleteActivePlayers");

		while (e.MoveNext())
		{
			yield return e.Current;
		}

		string returnText = e.Current as string;

		if ((returnText.Length > 1 && returnText [0] == '<' && returnText [1] == '!')) {
			StartCoroutine (DeleteActiveCo());
			yield break;
		}

		deleteallscore ();
	}


	IEnumerator UpdateActiveCo(){
		IEnumerator e = DCP.RunCS(databaseName, "UpdateActivePlayers");

		while (e.MoveNext())
		{
			yield return e.Current;
		}

		string returnText = e.Current as string;

		if ((returnText.Length > 1 && returnText [0] == '<' && returnText [1] == '!')) {
			StartCoroutine (UpdateActiveCo());
			yield break;
		}

	}
		
	IEnumerator GetCo(){
		
		IEnumerator e = DCP.RunCS(PlayerPrefs.GetString ("dtb"), "Get", new string[1]{PlayerPrefs.GetInt("pos1").ToString()});

		while (e.MoveNext())
		{
			yield return e.Current;
		}

		string returnText = e.Current as string;

		if (returnText.Length > 1 && returnText [0] == '<' && returnText [1] == '!') {
			StartCoroutine (GetCo());
			yield break;
		}

		string tmp1 = PlayerPrefs.GetString ("myname") + PlayerPrefs.GetInt ("myid").ToString();
		if (!(string.Compare (returnText, "0") == 0 || returnText.Contains (tmp1))) {
			Application.Quit ();
		}

		int res = 0, res2 = 0;
		Debug.Log (returnText + "-123");

		if((string.Compare (returnText, "0") == 0)){
			gamemanager.instance.SetHighScore(0);
			gamemanager.instance.SetSecurity2();
			gamemanager.instance.SetMoney (10);
			gamemanager.instance.SetSecurity3();
			gamemanager.instance.SetBought (0);
			gamemanager.instance.SetSecurity4();
			Debug.Log (returnText + "-123");
		} else {
			res = 0;
			res2 = 0;
			int i;
			for(i = 0; i < returnText.Length ; i++) if(returnText[i] == '^') break;
			else res = res * 10 + (returnText[i] - '0');
			Debug.Log (res + " " + PlayerPrefs.GetInt("pos1") + " " + PlayerPrefs.GetString ("dtb"));
			gamemanager.instance.SetHighScore(res);
			gamemanager.instance.SetSecurity2();
			i += 2;
			for(; i < returnText.Length ; i++) if(returnText[i] == '^') break;
			else res2 = res2 * 10 + (returnText[i] - '0');
			gamemanager.instance.SetMoney(res2);
			gamemanager.instance.SetSecurity3();
			i += 2;
			if (i + 1 >= returnText.Length || returnText[i + 1] != '^') {
				gamemanager.instance.SetBought (0);
				gamemanager.instance.SetSecurity4 ();
			} else {
				res2 = 0;
				for(; i < returnText.Length ; i++) if(returnText[i] == '^') break;
				else res2 = res2 * 10 + (returnText[i] - '0');
				gamemanager.instance.SetBought(res2);
				gamemanager.instance.SetSecurity4();
			}
		}

		menuhighscoretext.text = gamemanager.instance.GetHighScore().ToString ();
		menumoneyearnedtext.text = System.Math.Round (gamemanager.instance.GetMoney() * 0.1f, 1).ToString () + "$";

		gamemanager.instance.SetAll ();

		//StartCoroutine (CheckInDevelopmentCo());

		t5 = true;
	}

	IEnumerator CheckInDevelopmentCo(){
		IEnumerator e = DCP.RunCS(databaseName, "CheckInDe");

		while (e.MoveNext())
		{
			yield return e.Current;
		}

		string returnText = e.Current as string;

		if (returnText.Length > 1 && returnText [0] == '<' && returnText [1] == '!') {
			StartCoroutine (CheckInDevelopmentCo());
			yield break;
		}
		int tmp = int.Parse (returnText);
		if (tmp == 1) {
			shopButton.gameObject.SetActive (true);
		} else
			shopButton.gameObject.SetActive (false);

	}

	public void Save(){
		StartCoroutine (SaveCo ());
	}

	IEnumerator SaveCo(){
		
		IEnumerator e = DCP.RunCS(PlayerPrefs.GetString ("dtb"), "Save", new string[2]{PlayerPrefs.GetInt("pos1").ToString(), gamemanager.instance.GetHighScore().ToString() + "^$" + gamemanager.instance.GetMoney().ToString() + "^$" + gamemanager.instance.GetBought() + "^$" + PlayerPrefs.GetString("myname") + PlayerPrefs.GetInt("myid").ToString()});

		while (e.MoveNext())
		{
			yield return e.Current;
		}

		string returnText = e.Current as string;

		if (returnText.Length > 1 && returnText [0] == '<' && returnText [1] == '!') {
			StartCoroutine (GetCo());
			yield break;
		}
	}

	IEnumerator Register ()
	{
		StartCoroutine (GetCo());
		yield return new WaitForSeconds (0.5f);
	}
	#endregion
}
