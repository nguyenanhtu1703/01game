using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using TMPro;

public class DisplayHighscores : MonoBehaviour {

	// Use this for initialization

	public Text[] highscoreText;
	highscores highscoreManager;
	public Text myrank;
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
		"UK ",
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

	void Start(){
		for (int i = 0; i < highscoreText.Length; i++) {
			highscoreText [i].text = i + 1 + ". Fetching...";
		}
		highscoreManager = GetComponent<highscores> ();
		StartCoroutine ("RefreshHighscores");
	}

	public void OnHighscoreDownload(Highscore[] highscoreList){
		for (int i = 0; i < highscoreText.Length; i++) {
			highscoreText [i].text = "---";
			highscoreText [i].transform.GetChild (0).GetComponent<Text> ().text = "-";
			highscoreText [i].transform.GetChild(2).GetComponent<Text>().text = "-";
			highscoreText [i].transform.GetChild (3).GetComponent<Text> ().text = "-";
			highscoreText [i].transform.GetChild (1).GetComponent<Text> ().text = "-";
			if (highscoreList.Length > i) {
				string tmp = highscoreList [i].username;
				int mycountry = highscoreList [i].country;
				int mmr = highscoreList [i].score;
				int earn = highscoreList [i].earn;
				string tmp2 = "";
				if (tmp == null)
					continue;
				for (int j = 0; j < tmp.Length; j++)
					if (tmp [j] == '^' && tmp [j + 1] == '$')
						break;
					else {
						if (tmp [j] == '+')
							tmp2 = tmp2 + " ";
						else 
							tmp2 = tmp2 + tmp [j].ToString ();
					}
				highscoreText [i].text = tmp2;
				if (mycountry > 197 || mycountry < 0)
					mycountry = 100;
				highscoreText [i].transform.GetChild (0).GetComponent<Text> ().text = (countries[mycountry][0].ToString() + countries[mycountry][1].ToString() + countries[mycountry][2].ToString());
				highscoreText [i].transform.GetChild(2).GetComponent<Text>().text = ((i + 1).ToString());
				highscoreText [i].transform.GetChild (3).GetComponent<Text> ().text = (System.Math.Round(earn * 0.1f, 1).ToString() + "$");
				highscoreText [i].transform.GetChild (1).GetComponent<Text> ().text = (mmr.ToString());
			}
		}
	}

	IEnumerator RefreshHighscores(){
		while (true) {
			yield return new WaitForSeconds (30);
			//if(string.Compare(Highscore.))
			highscores.instance.privateCode = highscores.instance.privatecode1;
			highscores.instance.paymentrequestvar = false;
			highscoreManager.DownloadHighscores ();
		}
	}
}
