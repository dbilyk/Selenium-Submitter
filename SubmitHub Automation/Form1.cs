﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace SubmitHub_Automation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void ResumeCampaign_Click(object sender, EventArgs e)
        {
            ResumeCampaignGo();
        }

        private int totalAutoSubmissions = 0;
        private bool browserInitialized = false;
        IWebDriver browser;

        private IWebDriver BrowserInit()
        {
            ChromeOptions opts = new ChromeOptions();
            opts.AddArgument("test-type");
            opts.AddArgument("start-maximized");
            opts.AddExcludedArgument("ignore-certificate-errors");
            opts.AddArgument("user-data-dir='C:/Users/Dmitri/SeleniumTesting/ChromeProfile'");
            opts.ToCapabilities();
            ChromeDriverService chrome = ChromeDriverService.CreateDefaultService(@"C:\Dropbox\Code Projects\Visual Studio Projects\Selenium DotNet 3.6\chrome");
            chrome.LogPath = "seleniumChrome.log";
            chrome.EnableVerboseLogging = true;
            chrome.HideCommandPromptWindow = true;

            IWebDriver browse = new ChromeDriver(@"C:\Dropbox\Code Projects\Visual Studio Projects\Selenium DotNet 3.6\chrome", opts);
            Console.WriteLine();
            browse.Manage().Timeouts().ImplicitWait = new TimeSpan(0, 0, 30);
            browse.Manage().Window.Maximize();
            return browse;
        }

        private async void ResumeCampaignGo()
        {
            
            int submissionCounter = 0;
            if (!browserInitialized)
            {
                browser = BrowserInit();
                browserInitialized = true;
            }
            
            browser.Navigate().GoToUrl("https://www.submithub.com/campaigns");
            await WaitASec();

            browser.FindElement(By.XPath("//*[@id='login-sign-in-link']")).Click();
            await WaitASec();
            browser.FindElement(By.XPath("//*[@id='login-username-or-email']")).SendKeys("biographer.info@gmail.com");
            await WaitASec();
            browser.FindElement(By.XPath("//*[@id='login-password']")).SendKeys("B!0graph3r");
            await WaitASec();
            browser.FindElement(By.XPath("//*[@id='login-buttons-password']")).Click();
            await WaitASec();
            //click on the most recently run campaign
            browser.FindElement(By.TagName("tbody")).FindElement(By.TagName("tr")).FindElement(By.TagName("td")).FindElement(By.TagName("a")).Click();
            await WaitASec();
            browser.FindElement(By.ClassName("new-campaign")).Click();
            await WaitASec();
            browser.FindElement(By.XPath("//*[@id='submit-credit-options']/div[2]/div[1]/div/div[2]/label")).Click();
            await WaitASec();
            browser.FindElement(By.XPath("//*[@id='submit-wrapper']/div[1]/div[3]/div")).Click();
            await WaitASec();
            browser.FindElement(By.XPath("//*[@id='submit-wrapper']/div[2]/div[2]/div[1]")).Click();
            await WaitASec();
           
            //select genre checks
            browser.FindElement(By.XPath("//*[@id='filter-genres']/div[2]/div[1]")).Click();
            List<IWebElement> genreChecks = new List<IWebElement>();
            genreChecks.Add(browser.FindElement(By.XPath("//*[@id='filter-genres']/div[2]/div[2]/div[12]/label")));
            await WaitASec();
            //genreChecks.Add(browser.FindElement(By.XPath("//*[@id='filter-genres']/div[2]/div[2]/div[11]/label")));
            //await WaitASec();
            //genreChecks.Add(browser.FindElement(By.Id("alternative")));
            //genreChecks.Add(browser.FindElement(By.Id("post-rock")));
            foreach (IWebElement elem in genreChecks)
            {
                elem.Click();
                await WaitASec();

            }
            //selects all blogs in list that arent hidden
            List<IWebElement> FilteredBlogs = browser.FindElements(By.CssSelector("tbody tr:not([style = 'display: none;'])")).ToList();
            Console.WriteLine(FilteredBlogs.Count());
            //checks if blog has "already submitted" div and if not, checks the box
            for (int i =0;i<FilteredBlogs.Count;i++)
            {
                Console.WriteLine("on table row number: " + i);
                if (FilteredBlogs[i].FindElements(By.XPath("./td[1]/div/label/div/div[2]")).Count == 0 )
                {
                    FilteredBlogs[i].FindElement(By.XPath("./td[1]/div/label/div[1]")).Click();
                    await WaitASec();
                    submissionCounter += 1;
                    totalAutoSubmissions += 1;
                }
                if (submissionCounter == 2)
                {
                    break;
                }
            }

            browser.FindElement(By.XPath("//*[@id='main-content']/div/div[2]/div/div[2]/div[3]/div/div[3]/div[2]/div[1]")).Click();
            await WaitASec();
            browser.FindElement(By.XPath("//*[@id='submitButton']")).Click();
            await WaitASec();

            //wait 4 hours and repeat
            await WaitFourHours();

            ResumeCampaignGo();
        }

       
        async Task WaitFourHours()
        {
            await Task.Delay(14400000);
        }

        async Task WaitASec()
        {
            await Task.Delay(1000);
        }
    }
}