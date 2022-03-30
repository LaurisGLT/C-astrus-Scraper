using System;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Linq;
using System.IO;
using Scraper.Classes;
using Scraper;
namespace Scraper
{

    public class AAScraper
    {
        public double[] kainorastis = new double[1000]; //Masyvas

        public int a = 0;
        public int r = 0;

        private DBCon DB = new DBCon();

        public void E90Scraper()
        {
            //E90 Akumuliatoriai
            HtmlAgilityPack.HtmlWeb web = new HtmlAgilityPack.HtmlWeb();
            HtmlAgilityPack.HtmlDocument akumai = web.Load("https://autoaibe.lt/2006-bmw-3touringe91-autodalys/akumuliatoriai/akumuliatoriai-automobiliams/?subm.td=19995");

            foreach (var kaina in akumai.DocumentNode.SelectNodes("//span[@class='regular-price']"))
            {
                string KainaNew = kaina.InnerText;
                Regex rgx = new Regex("<[^>]+>|&nbsp;"); // nbsp nesamones regex kodas
                string KainaClean = rgx.Replace(KainaNew, ""); // pasalina nbsp 
                string KainaNoWs = String.Concat(KainaClean.Where(c => !Char.IsWhiteSpace(c))); //pasalina po nbsp sukurtus whitespace omg sita nesamone uzkniso belekaip
                string KainaNoQ = KainaNoWs.Replace("€", String.Empty); // euru printint testavimui nenori tai cia removina euro simboli
                double kainadouble = double.Parse(KainaNoQ, CultureInfo.InvariantCulture);
                kainorastis[a] = kainadouble;
                    a++;
            }
            foreach (var pavadinimas in akumai.DocumentNode.SelectNodes("//a[@class='name']"))
            {
                string pav = pavadinimas.InnerText;
                string hrefas = "https://autoaibe.lt" + pavadinimas.Attributes["href"].Value;
                E90Prekes E9Prekes = new E90Prekes();
                E9Prekes.product = pav;
                E9Prekes.kaina = kainorastis[r];
                E9Prekes.href = hrefas;
                E9Prekes.type = "akum";
                int result = DB.Find(pav,true);
                if (result == 0)
                {
                    DB.Save(E9Prekes);
                }
                else
                {
                    E9Prekes.Id = result;
                    DB.Update(E9Prekes);
                }
                
                r++;
            }

            a = 0; //counteriu resetas
            r = 0;
            //E90 Amortizatoriai
            HtmlAgilityPack.HtmlDocument Amor = web.Load("https://autoaibe.lt/2006-bmw-3touringe91-autodalys/detales/pakabos-dalys/amortizatoriai-amortizatoriu-ivores/?subm.td=19995");
            foreach (var kaina in Amor.DocumentNode.SelectNodes("//span[@class='regular-price']"))
            {
                string KainaNew = kaina.InnerText;
                Regex rgx = new Regex("<[^>]+>|&nbsp;"); // nbsp nesamones regex kodas
                string KainaClean = rgx.Replace(KainaNew, ""); // pasalina nbsp 
                string KainaNoWs = String.Concat(KainaClean.Where(c => !Char.IsWhiteSpace(c))); //pasalina po nbsp sukurtus whitespace omg sita nesamone uzkniso belekaip
                string KainaNoQ = KainaNoWs.Replace("€", String.Empty); // euru printint testavimui nenori tai cia removina euro simboli
                double kainadouble = double.Parse(KainaNoQ, CultureInfo.InvariantCulture);
                kainorastis[a] = kainadouble;
                a++;
            }
            foreach (var pavadinimas in Amor.DocumentNode.SelectNodes("//a[@class='name']"))
            {
                string pav = pavadinimas.InnerText;
                string hrefas = "https://autoaibe.lt" + pavadinimas.Attributes["href"].Value;
                E90Prekes E9Prekes = new E90Prekes();
                E9Prekes.product = pav;
                E9Prekes.kaina = kainorastis[r];
                E9Prekes.href = hrefas;
                E9Prekes.type = "amort";
                int result = DB.Find(pav,true);
                if (result == 0)
                {
                    DB.Save(E9Prekes);
                }
                else
                {
                    E9Prekes.Id = result;
                    DB.Update(E9Prekes);
                }
                r++;
            }

            //pabaiga
        }

        

        public void E60Scraper()
        {
            a = 0; //counteriu resetas
            r = 0;
            //E60 Akumuliatoriai
            HtmlAgilityPack.HtmlWeb web = new HtmlAgilityPack.HtmlWeb();
            HtmlAgilityPack.HtmlDocument akumai = web.Load("https://autoaibe.lt/2006-bmw-5e60-autodalys/akumuliatoriai/akumuliatoriai-automobiliams/?subm.td=19024");

            foreach (var kaina in akumai.DocumentNode.SelectNodes("//span[@class='regular-price']"))
            {
                string KainaNew = kaina.InnerText;
                Regex rgx = new Regex("<[^>]+>|&nbsp;"); // nbsp nesamones regex kodas
                string KainaClean = rgx.Replace(KainaNew, ""); // pasalina nbsp 
                string KainaNoWs = String.Concat(KainaClean.Where(c => !Char.IsWhiteSpace(c))); //pasalina po nbsp sukurtus whitespace omg sita nesamone uzkniso belekaip
                string KainaNoQ = KainaNoWs.Replace("€", String.Empty); // euru printint testavimui nenori tai cia removina euro simboli
                double kainadouble = double.Parse(KainaNoQ, CultureInfo.InvariantCulture);
                kainorastis[a] = kainadouble;

                a++;
            }
            foreach (var pavadinimas in akumai.DocumentNode.SelectNodes("//a[@class='name']"))
            {
                string pav = pavadinimas.InnerText;
                string hrefas = "https://autoaibe.lt" + pavadinimas.Attributes["href"].Value;
                E60Prekes E6Prekes = new E60Prekes();
                E6Prekes.product = pav;
                E6Prekes.kaina = kainorastis[r];
                E6Prekes.href = hrefas;
                E6Prekes.type = "akum";
                int result = DB.Find(pav,false);
                if (result == 0)
                {
                    DB.Save(E6Prekes);
                }
                else
                {
                    E6Prekes.Id = result;
                    DB.Update(E6Prekes);
                }

                r++;
            }

            a = 0; //counteriu resetas
            r = 0;
            //E60 Amortizatoriai

            HtmlAgilityPack.HtmlDocument Amor = web.Load("https://autoaibe.lt/2006-bmw-5e60-autodalys/detales/pakabos-dalys/amortizatoriai-amortizatoriu-ivores/?subm.td=19024");
            foreach (var kaina in Amor.DocumentNode.SelectNodes("//span[@class='regular-price']"))
            {
                string KainaNew = kaina.InnerText;
                Regex rgx = new Regex("<[^>]+>|&nbsp;"); // nbsp nesamones regex kodas
                string KainaClean = rgx.Replace(KainaNew, ""); // pasalina nbsp 
                string KainaNoWs = String.Concat(KainaClean.Where(c => !Char.IsWhiteSpace(c))); //pasalina po nbsp sukurtus whitespace omg sita nesamone uzkniso belekaip
                string KainaNoQ = KainaNoWs.Replace("€", String.Empty); // euru printint testavimui nenori tai cia removina euro simboli
                double kainadouble = double.Parse(KainaNoQ, CultureInfo.InvariantCulture);
                kainorastis[a] = kainadouble;
                a++;
            }
            foreach (var pavadinimas in Amor.DocumentNode.SelectNodes("//a[@class='name']"))
            {
                string pav = pavadinimas.InnerText;
                string hrefas = "https://autoaibe.lt" + pavadinimas.Attributes["href"].Value;
                E60Prekes E6Prekes = new E60Prekes();
                E6Prekes.product = pav;
                E6Prekes.kaina = kainorastis[r];
                E6Prekes.href = hrefas;
                E6Prekes.type = "amort";
                int result = DB.Find(pav,false);
                if (result == 0)
                {
                    DB.Save(E6Prekes);
                }
                else
                {
                    E6Prekes.Id = result;
                    DB.Update(E6Prekes);
                }
                r++;
            }

            //pabaiga
        }
    }

    }


    class Program
    {
        static void Main(string[] args)
        {
            AAScraper E9Prk = new AAScraper();

            E9Prk.E90Scraper();

            AAScraper E6Prk = new AAScraper();

            E6Prk.E60Scraper();
    }
    }
