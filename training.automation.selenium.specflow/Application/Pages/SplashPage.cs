﻿using training.automation.common.Pages;
using training.automation.common.Selenium.Elements;
using OpenQA.Selenium;

namespace training.automation.specflow.Application.Pages
{
    public class SplashPage : Page
    {
        public Button LogIn;
        //public Button SignUp;

        public SplashPage() : base("Splash Page") { BuildPage(); }

        private void BuildPage()
        {
            LogIn = new Button(By.XPath("//a[@href='/login']"), "Log In Button", name);
            //SignUp = new Button(By.XPath("//a[@href='/signup']"), "Sign Up Button", name);
        }
    }
}
