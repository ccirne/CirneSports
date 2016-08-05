﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;

namespace CirneSports.LojaVirtual.Web
{
    public static class StringHelpers
    {
        public static string ToSeoUrl(this string url)
        {
            //make the url lowercase
            string encodeUrl = (url ?? "").ToLower();

            //replace "&" with "and"
            encodeUrl = Regex.Replace(encodeUrl, @"\&+", "and");

            //remove characters
            encodeUrl = encodeUrl.Replace("'", "");

            //remove invalid characters
            encodeUrl = Regex.Replace(encodeUrl, @"[^a-z0-9]", "-");

            //remove duplicates
            encodeUrl = Regex.Replace(encodeUrl, @"-+", "-");

            //trim leading & trailing characters
            encodeUrl = encodeUrl.Trim('-');

            return encodeUrl;
        }
    }
}