using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SampleSelenium.BO
{
    class FBController
    {
        public ChromeDriver m_driver;

        public bool Init(string createurl)
        {
            try
            {
                //rootFolder = ninja_folder + "\\ChromeProfile\\" + Info.MyTempId;

                var path = Application.ExecutablePath;
                ChromeOptions options = new ChromeOptions();
                options.AddArgument("--disable-notifications");
               // if (isSilentmode)
               //     options.AddArgument("--headless");

                //if (!enablePicture)
                //{
                //    options.AddArgument("--disable-images");
                //    options.AddUserProfilePreference("profile.default_content_setting_values.images", 2);
                //}
                //else
                //{
                //    options.AddUserProfilePreference("profile.default_content_setting_values.images", 1);
                //}

                options.AddArgument("--disable-popup-blocking");
                //options.AddArgument("--width=320");
                // options.AddArgument("--height=510");
                options.AddArgument("--disable-infobars");
                //if (isAppMode)
///options.AddArguments("--app=https://m.facebook.com");

                options.AddArguments(new string[]
				{
					"--disable-notifications",
					"start-maximized",
					"--no-sandbox",
					"--disable-gpu",
					"--disable-dev-shm-usage",
					"--disable-web-security",
					"--disable-rtc-smoothness-algorithm",
					"--disable-webrtc-hw-decoding",
					"--disable-webrtc-hw-encoding",
					"--disable-webrtc-multiple-routes",
					"--disable-webrtc-hw-vp8-encoding",
					"--enforce-webrtc-ip-permission-check",
					"--force-webrtc-ip-handling-policy",
					"--ignore-certificate-errors",
					"--disable-infobars",
					"--disable-popup-blocking"
				});
                options.AddUserProfilePreference("profile.default_content_setting_values.notifications", 1);
                options.AddUserProfilePreference("profile.default_content_setting_values.plugins", 1);
                options.AddUserProfilePreference("profile.default_content_setting_values.popups", 1);
                options.AddUserProfilePreference("profile.default_content_setting_values.geolocation", 1);
                options.AddUserProfilePreference("profile.default_content_setting_values.auto_select_certificate", 1);
                options.AddUserProfilePreference("profile.default_content_setting_values.mixed_script", 1);
                options.AddUserProfilePreference("profile.default_content_setting_values.media_stream", 1);
                options.AddUserProfilePreference("profile.default_content_setting_values.media_stream_mic", 1);
                options.AddUserProfilePreference("profile.default_content_setting_values.media_stream_camera", 1);
                options.AddUserProfilePreference("profile.default_content_setting_values.protocol_handlers", 1);
                options.AddUserProfilePreference("profile.default_content_setting_values.midi_sysex", 1);
                options.AddUserProfilePreference("profile.default_content_setting_values.push_messaging", 1);
                options.AddUserProfilePreference("profile.default_content_setting_values.ssl_cert_decisions", 1);
                options.AddUserProfilePreference("profile.default_content_setting_values.metro_switch_to_desktop", 1);
                options.AddUserProfilePreference("profile.default_content_setting_values.protected_media_identifier", 1);
                options.AddUserProfilePreference("profile.default_content_setting_values.site_engagement", 1);
                options.AddUserProfilePreference("profile.default_content_setting_values.durable_storage", 1);
                options.AddUserProfilePreference("useAutomationExtension", true);


                //options.AddArgument("--noerrors");
                //options.AddArgument("--start-fullscreen");
                //options.AddArgument("--disable-infobars");
                //options.AddArgument("--disable-session-crashed-bubble");
                string currentIP = "";
                //#region Gỡ lỗi mơ cửa sổ khi mở chrome thông báo Restore Page
                //try
                //{
                //    if (Info.Uid != "")
                //    {
                //        var f = SQLiteUtils.ninja_folder + string.Format(@"\ChromeProfile\{0}\Default\Preferences", Info.Uid);
                //        if (File.Exists(f))
                //        {
                //            var c = System.IO.File.ReadAllText(f);
                //            c = c.Replace("\"exit_type\":\"Crashed\"", "\"exit_type\":\"None\"");
                //            System.IO.File.Delete(f);
                //            System.IO.File.WriteAllText(f, c);
                //        }
                //    }
                //}
                //catch (Exception ex)
                //{
                //    new LogUtils().WriteLog(Info.Uid, ex.Message + ex.InnerException, "Init Remove Chrome Error");
                //}

                //#endregion
                //options.AddArgument(@"--user-data-dir=" + rootFolder);

                //if (File.Exists("Addon/webrtc.crx") && !isSilentmode)
                //    options.AddExtensions("Addon/webrtc.crx");

                //if (MyNetWork == Networking.Proxy && Proxy.Ip != "" && Proxy.Port > 0)
                //{

                //    new LogUtils().WriteLog(Info.Uid, "Proxy", "Init");

                //    if (!String.IsNullOrWhiteSpace(Proxy.Password) && !String.IsNullOrWhiteSpace(Proxy.UserName) && !isSilentmode)
                //    {
                //        options.AddExtensions("Addon/proxy.crx");
                //        if (File.Exists("Addon/webrtc.crx"))
                //            options.AddExtensions("Addon/webrtc.crx");
                //    }

                //    options.AddArgument(@"--proxy-server=" + this.Proxy.Ip + ":" + this.Proxy.Port);
                //    currentIP = this.Proxy.Ip;


                //}
                //else if (MyNetWork == Networking.Tinsoft)
                //{
                //    new LogUtils().WriteLog(Info.Uid, "Tinsoft", "Init");
                //    if (Proxy4G.Count > 0)
                //    {
                //        if (File.Exists("Addon/webrtc.crx")) options.AddExtensions("Addon/webrtc.crx");

                //        var myProxy = Proxy4G.Dequeue();
                //        Proxy4G.Enqueue(myProxy);
                //        options.AddArgument(@"--proxy-server=" + myProxy.Ip + ":" + myProxy.Port);
                //        currentIP = myProxy.Ip;
                //    }
                //}
                //else if (MyNetWork == Networking.OBCProxy)
                //{
                //    if (Proxy4G.Count > 0 && !isSilentmode)
                //    {
                //        if (File.Exists("Addon/webrtc.crx")) options.AddExtensions("Addon/webrtc.crx");

                //        var myProxy = Proxy4G.Dequeue();
                //        options.AddArgument(@"--proxy-server=" + myProxy.Ip + ":" + myProxy.Port);
                //        Proxy4G.Enqueue(myProxy);
                //        currentIP = myProxy.PublicIp;
                //    }
                //}
                //else if (MyNetWork == Networking.Proxy_4G)
                //{
                //    new LogUtils().WriteLog(Info.Uid, "Proxy_4G", "Init");
                //    if (Proxy4G.Count > 0 && !isSilentmode)
                //    {
                //        var myProxy = Proxy4G.Dequeue();
                //        Proxy4G.Enqueue(myProxy);
                //        if (File.Exists("Addon/webrtc.crx")) options.AddExtensions("Addon/webrtc.crx");
                //        options.AddArgument(@"--proxy-server=" + myProxy.Ip + ":" + myProxy.Port);
                //        //options.AddArgument(@"--proxy-server=socks5://" + myProxy.Ip + ":" + myProxy.SockPort);
                //        currentIP = myProxy.PublicIp;
                //    }
                //}
                //else
                //{
                //    currentIP = this.IPAddress;
                //}

                //new SQLiteUtils().IPLogInser(this.Info.Uid, DateTime.Now, currentIP);
                //Info.UserAgent = "";
                //if (Info.UserAgent != "")
                //    options.AddArgument("--user-agent=" + Info.UserAgent);

                //options.BinaryLocation = "cck_chrome.exe";
                //Khoi Tao Chrome
                ChromeDriverService service = ChromeDriverService.CreateDefaultService();
                service.HideCommandPromptWindow = true;

                m_driver = new ChromeDriver(service, options);

                ICapabilities capabilities = ((RemoteWebDriver)m_driver).Capabilities;
                var version = (capabilities.GetCapability("chrome") as Dictionary<string, object>)["chromedriverVersion"];
                if (version != null && version.ToString() != "")
                {
                    version = version.ToString().Split('(')[0];
                }

                m_driver.Manage().Timeouts().ImplicitWait=TimeSpan.FromMinutes(5);
                var size = System.Windows.Forms.Screen.PrimaryScreen.Bounds;
                
                //m_driver.Manage().Window.Position = new Point(col * w, row * h);

                ////Neu co user va Pass thi phai cai dat Addon len
                //if (MyNetWork == Networking.Proxy && Proxy.Ip != null && Proxy.Ip != "" && Proxy.Password != "" && Proxy.UserName != "")
                //{
                    //((IJavaScriptExecutor)m_driver).ExecuteScript(string.Format("localStorage['proxy_login'] = '{0}'; localStorage['proxy_password'] = '{1}'", Proxy.UserName, Proxy.Password));

                    //require("IntlUtils").setCookieLocale("en_US", "ja_JP", "https:\/\/www.facebook.com\/", "www_list_selector", 0); return false;
                //}

                m_driver.Navigate().GoToUrl(createurl);
                Thread.Sleep(1000);
                ((IJavaScriptExecutor)m_driver).ExecuteScript("require(\"IntlUtils\").setCookieLocale(\"en_US\", \"ja_JP\", \"https://www.facebook.com\", \"www_list_selector\", 0);");
            }
            catch (Exception ex)
            {
                //new LogUtils().WriteLog(Info.Uid, ex.Message + ex.InnerException, "Init");
                return false;
            }

            //hideChrome();

            return true;

        }

        internal void Login(string username, string password)
        {
            if (m_driver != null)
            {
                var email = m_driver.FindElementById("ap_email");
                if (email != null)
                {
                    email.Clear();
                    email.SendKeys(username);
                    Thread.Sleep(1000);
                }
                var pass = m_driver.FindElementById("pass");
                if(pass!= null)
                {
                    pass.Clear();
                    pass.SendKeys(password);
                    Thread.Sleep(1000);
                }

                var login = m_driver.FindElementsByName("login");
                if (login != null && login.Count > 0)
                {
                    var btn = login[0];
                    if (btn != null)
                    {
                        btn.Click();
                    }
                }
            }
        }
    }
}
