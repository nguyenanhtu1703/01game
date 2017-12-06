using UnityEngine;
using System.Collections;

public class share : MonoBehaviour 
{
	/* TWITTER VARIABLES*/

	//Twitter Share Link
	string TWITTER_ADDRESS = "http://twitter.com/intent/tweet";

	//Language
	string TWEET_LANGUAGE = "en";

	//This is the text which you want to show
	string textToDisplay="Hey Guys! Check out my new high score daily: ";

	/*END OF TWITTER VARIABLES*/

	/* FACEBOOK VARAIBLES */

	//App ID
	string AppID = "1077225622403938";

	//This link is attached to this post
	string Link = "https://play.google.com/store/apps/details?id=om.milliondowloads.zeroonegamee";

	//The URL of a picture attached to this post. The Size must be atleat 200px by 200px.
	string Picture = "http://i-cdn.phonearena.com/images/article/85835-thumb/Google-Pixel-3-codenamed-Bison-to-be-powered-by-Andromeda-OS.jpg";

	//The Caption of the link appears beneath the link name
	string Caption = "Check out My New High Score daily: ";

	//The Description of the link
	string Description = "Try your luck 50 / 50 on 2 buttons, Challenger yourself to earn big money";

	/* END OF FACEBOOK VARIABLES */

	// Twitter Share Button	
	public void shareScoreOnTwitter () // " " + Link + " " +
	{
		Application.OpenURL (TWITTER_ADDRESS + "?text=" + WWW.EscapeURL(textToDisplay) + PlayerPrefs.GetInt ("myhighscore").ToString() + "&amp;lang=" + WWW.EscapeURL(TWEET_LANGUAGE));
	}

	// Facebook Share Button
	public void shareScoreOnFacebook ()
	{
		Caption += PlayerPrefs.GetInt ("myhighscore").ToString();
		Application.OpenURL ("https://www.facebook.com/dialog/feed?" + "app_id=" + AppID + "&link=" + Link + "&picture=" + Picture
			+ "&caption=" + Caption + "&description=" + Description);
	
		gamemanager.instance.SetNOFT (gamemanager.instance.GetNOFT() + 100);
		gamemanager.instance.numberoftrytext.text = gamemanager.instance.GetNOFT ().ToString ();
	}

	public void vote(){
		Application.OpenURL ("market://details?id=om.the01game.earnrealmoney");
	}
}
