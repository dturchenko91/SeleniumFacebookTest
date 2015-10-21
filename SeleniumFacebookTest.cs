# SeleniumFacebookTest
//A short and dirty selenium automation to create a facebook status and change its visibility

//Insert your own username and password into the username and password variables

//This code was written in xamarin studio using the selenium webdriver package plugin from nuget
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;


namespace SeleniumHelloWorld2
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			IWebDriver driver = new FirefoxDriver ();

			//opens facebook page in browser
			driver.Navigate ().GoToUrl ("http://www.facebook.com/");
			driver.Manage ().Window.Maximize ();

			//Logs in to facebook
			IWebElement login = driver.FindElement (By.Id ("email"));
			
			//INSERT YOUR EMAIL HERE
			login.SendKeys ("");
			IWebElement password = driver.FindElement (By.Id ("pass"));
			
			//INSERT YOUR PASSWORD HERE
			password.SendKeys ("");
			password.SendKeys (Keys.Enter);

			//writes status update
			IWebElement status = driver.FindElement(By.CssSelector("textarea[title=\"What's on your mind?\"]"));
			status.Click ();
			status.SendKeys ("Hello, World!");

			//finds visibility options box. goal is so set visibility so only I can see i
			//IWebElement visibility = driver.FindElement(By.CssSelector("span._55pe"));
			IWebElement visibility = driver.FindElement(By.CssSelector("a[aria-label=\"Your friends\"]"));
			visibility.Click ();

			//selects "more options" under visibility options
			//IWebElement moreOptions = driver.FindElement(By.XPath("/html/body/div[1]/div[2]/div[5]/div/div/div/div/div[1]/div/div/ul/li[4]/a/span/span"));
			//moreOptions.Click ();

			//selects "only me" under the additional visibility options
			IWebElement onlyMe = driver.FindElement(By.XPath("/html/body/div[1]/div[2]/div[5]/div/div/div/div/div[1]/div/div/ul/li[4]/a/div"));
			onlyMe.Click ();

			//posts status
			IWebElement submit = driver.FindElement(By.XPath("/html/body/div[1]/div[2]/div[1]/div/div[2]/div[2]/div[2]/div/div[3]/div/div/div/form/div/div[5]/div/ul/li[2]/button"));
			submit.Click ();

			//resets visibility options to "friends" or this won't work twice
			visibility.Click();

			IWebElement friends = driver.FindElement (By.XPath ("/html/body/div[1]/div[2]/div[5]/div/div/div/div/div[1]/div/div/ul/li[3]/a/span/span"));
			friends.Click ();

		}
	}
}
