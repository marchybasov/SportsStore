using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sprache;
using LicenseTracker.Models;

namespace LicenseTracker.Utility.LicenseFileParser
{
    public class ParserGrammar
    {

        private static readonly Parser<LicenseAction> TakeLicense = Parse.String("OUT: ").Return(new LicenseAction("License taken"));
        private static readonly Parser<LicenseAction> ReturnLicense = Parse.String("IN: ").Return(new LicenseAction("License returned"));
        private static readonly Parser<LicenseAction> DeniedLicense = Parse.String("DENIED: ").Return(new LicenseAction("Access denied"));

        private static readonly Parser<LicenseAction> LicenseAction = TakeLicense.Or(ReturnLicense).Or(DeniedLicense);

        private static Parser<LicenseTimeStamp> LicenseTimeStamp =            
            from hours in Parse.Digit.Many().Text()
            from semicolon in Parse.Char(':')
            from minutes in Parse.LetterOrDigit.Many().Text()
            from semicolon2 in Parse.Char(':')
            from seconds in Parse.Digit.Many().Text()
            from close in Parse.WhiteSpace
            select new LicenseTimeStamp(new TimeSpan(Int32.Parse(hours), Int32.Parse(minutes), Int32.Parse(seconds)));

        private static Parser<string> MessageDelegate =
            from open in Parse.Char('(')
            from value in Parse.CharExcept(')').Many().Text()
            from closeExp in Parse.Char(')')
            from close in Parse.WhiteSpace
            select new string(value);

        private static Parser<string> LicenseFeature =
             from open in Parse.Char('"')
             from value in Parse.CharExcept('"').Many().Text()
             from close in Parse.Char('"')
             select new string(value);

        private static Parser<string> LicenseUserPC =
            from open in Parse.AnyChar.Many().Text()

            select new string(open);


        private static Parser<string> LicenseUser =
            from open in Parse.WhiteSpace
            from val in Parse.CharExcept('@').Many().Text()
            from close in Parse.Char('@')
            select new string(val);

        private static Parser<LicenseUsage> LicenseUsage =
              from timeStamp in LicenseTimeStamp
              from actor in MessageDelegate
              from licenseAction in LicenseAction
              from feature in LicenseFeature
              from user in LicenseUser
              from pc in LicenseUserPC
              select new LicenseUsage(timeStamp, actor, licenseAction.Value, feature, user, pc);

        private static Parser<AnyRow> AnyRow =
            from timeStamp in LicenseTimeStamp
            from value in Parse.AnyChar.Many().Text()
            select new AnyRow(timeStamp.ToString() + value);
          

        public static Parser<RowEntity> RowEntity =
            LicenseUsage.Or<RowEntity>(AnyRow);
    }
}
