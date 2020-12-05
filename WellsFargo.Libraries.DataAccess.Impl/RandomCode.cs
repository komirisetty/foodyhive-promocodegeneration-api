using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WellsFargo.Libraries.Models;

namespace WellsFargo.Libraries.DataAccess.Impl
{
    public class RandomCode
    {
        Random _random = new Random();
        PromoCodeModel pcm = new PromoCodeModel();
        public void randomMethod(PromoCodeModel pcm)
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var strChars = new char[6];           

         //   Console.WriteLine("Enter n value:");
            int n = pcm.NoOfPromoCodes;
            
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < strChars.Length; j++)
                {
                    strChars[j] = chars[_random.Next(chars.Length)];
                }
                var finalString = new String(strChars);

               var promoCodeGenerated =  pcm.Prefix + finalString;

                pcm.PromocodeGenerated +=  promoCodeGenerated + ",";
               // Console.WriteLine(finalString);
            }
            
        }

    }
}
