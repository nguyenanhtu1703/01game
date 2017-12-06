using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buttonpress : MonoBehaviour {

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

	public Text countryname, myage;

	public GameObject content, content2;
	// Use this for initialization
	void Start () {
		
	}

	public void assignvalueforbuttons(){
		int i = 0;
		foreach (Transform t in content.gameObject.transform) {
			t.gameObject.transform.GetChild (0).GetComponent<Text> ().text = countries [i];
			t.gameObject.transform.GetChild (0).GetComponent<Text> ().color = new Color (180 / 255f, 180 / 255f, 180 / 255f);
			i++;
		}
	}

	public void assign(){
		countryname.text = gameObject.transform.GetChild (0).GetComponent<Text> ().text;
	}

	public void assignvalueforbuttons2(){
		int i = 0;
		foreach (Transform t in content2.gameObject.transform) {
			t.gameObject.transform.GetChild (0).GetComponent<Text> ().text = i.ToString();
			t.gameObject.transform.GetChild (0).GetComponent<Text> ().color = new Color (180 / 255f, 180 / 255f, 180 / 255f);
			i++;
		}
		content2.transform.GetChild (i - 1).transform.GetChild(0).gameObject.GetComponent<Text> ().text = content2.transform.GetChild (i - 1).transform.GetChild(0).gameObject.GetComponent<Text> ().text + "+";
		content2.transform.GetChild (i - 1).transform.GetChild(0).gameObject.GetComponent<Text> ().color = new Color (180 / 255f, 180 / 255f, 180 / 255f);
	}

	public void assign2(){
		myage.text = gameObject.transform.GetChild (0).GetComponent<Text> ().text;
	}


	// Update is called once per frame
	void Update () {
		
	}
}
