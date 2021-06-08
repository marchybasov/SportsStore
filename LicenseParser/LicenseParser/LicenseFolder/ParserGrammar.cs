using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sprache;
using System.Threading.Tasks;


namespace LicenseParser.LicenseFolder
{
    public class ParserGrammar
    {

        private static readonly Parser<LicenseAction> TakeLicense = Parse.String("OUT: ").Return(new LicenseAction("License taken"));
        private static readonly Parser<LicenseAction> ReturnLicense = Parse.String("IN: ").Return(new LicenseAction("License returned"));
        private static readonly Parser<LicenseAction> DeniedLicense = Parse.String("DENIED: ").Return(new LicenseAction("Access denied"));
        private static readonly Parser<LicenseAction> UnsupportedLicense = Parse.String("UNSUPPORTED: ").Return(new LicenseAction("Unsupported"));



        private static readonly Parser<LicenseAction> LicenseAction = TakeLicense.Or(ReturnLicense).Or(DeniedLicense).Or(UnsupportedLicense);

        private static Parser<LicenseTimeStamp> TimeStampWithSpace =
            from space in Parse.WhiteSpace
            from hours in Parse.Digit.Many().Text()
            from semicolon in Parse.Char(':')
            from minutes in Parse.LetterOrDigit.Many().Text()
            from semicolon2 in Parse.Char(':')
            from seconds in Parse.Digit.Many().Text()
            from close in Parse.WhiteSpace
            select new LicenseTimeStamp(new TimeSpan(Int32.Parse(hours), Int32.Parse(minutes), Int32.Parse(seconds)));

        private static Parser<LicenseTimeStamp> TimeStampWithoutSpace =
            from hours in Parse.Digit.Many().Text()
            from semicolon in Parse.Char(':')
            from minutes in Parse.LetterOrDigit.Many().Text()
            from semicolon2 in Parse.Char(':')
            from seconds in Parse.Digit.Many().Text()
            from close in Parse.WhiteSpace
            select new LicenseTimeStamp(new TimeSpan(Int32.Parse(hours), Int32.Parse(minutes), Int32.Parse(seconds)));

        private static Parser<LicenseTimeStamp> LicenseTimeStamp = TimeStampWithoutSpace.Or(TimeStampWithSpace);

        private static Parser<LicenseDateStamp> UsualLicenseDate =
            from month in Parse.Digit.Many().Text()
            from slash in Parse.Char('/')
            from day in Parse.Digit.Many().Text()
            from slash2 in Parse.Char('/')
            from year in Parse.Digit.Many().Text()
            select new LicenseDateStamp(new DateTime(Int32.Parse(year), Int32.Parse(month), Int32.Parse(day)));
        
        
        private static Parser<LicenseDateStamp> StartLicenseDate =
           from day in Parse.Letter.Many().Text()
           from space in Parse.WhiteSpace
           from month in Parse.Letter.Many().Text()
           from space2 in Parse.WhiteSpace
           from date in Parse.Digit.Many().Text()
           from space3 in Parse.WhiteSpace
           from year in Parse.Digit.Many().Text()
           from close in Parse.AnyChar.Many().Text()

           select new LicenseDateStamp(Convert.ToDateTime(String.Format("{0} {1} {2} {3}",day, month, date, year)));

        private static Parser<LicenseDateStamp> LicenseDate = UsualLicenseDate.Or(StartLicenseDate);     




        private static Parser<LicenseFeature> LicenseFeature =
            from qts in Parse.Char('\"')
            from val in Parse.CharExcept('\"').Many().Text()
            from qts2 in Parse.Char('\"')
            select new LicenseFeature(val);


        private static Parser<LicenseUser> LicenseUser =
            from space in Parse.WhiteSpace
            from val in Parse.CharExcept('@').Many().Text()
            from at in Parse.Char('@')
            select new LicenseUser(val);


        private static Parser<LicenseUserPC> UserPC =
            from val in Parse.CharExcept(' ').Many().Text()           
            select new LicenseUserPC(val);


        private static Parser<MessageHost> MessageHost =
          from open in Parse.Char('(')
          from value in Parse.CharExcept(')').Many().Text()
          from closeExp in Parse.Char(')')
          from close in Parse.WhiteSpace
          select new MessageHost(value);

        private static Parser<DenialReason> DenialReason =
                  from start in Parse.CharExcept('(').Many()
                  from open in Parse.Char('(')
                  from value in Parse.CharExcept('.').Many().Text()
                  from lineEnd in Parse.AnyChar.Many().Text()
               
                  select new DenialReason(value);


        private static Parser<LicenseUsageParsed> LicenseUsage =
              from timeStamp in LicenseTimeStamp
              from actor in MessageHost
              from licenseAction in LicenseAction
              from feature in LicenseFeature
              from user in LicenseUser
              from pc in UserPC
              select new LicenseUsageParsed(timeStamp, actor, licenseAction, feature, user, pc);


        private static Parser<UnsupportedLicenseFeature> UnsupportedFeature =
            from timeStamp in LicenseTimeStamp
            from actor in MessageHost
            from licenseAction in LicenseAction
            from feature in LicenseFeature
            from portAtHost in Parse.String(" (PORT_AT_HOST_PLUS   )")
            from user in LicenseUser
            from pc in UserPC
            from denialReason in DenialReason
            select new UnsupportedLicenseFeature(timeStamp, actor, licenseAction, feature, user, pc, denialReason);


        private static Parser<DeniedLicenseUsage> DeniedLicenseUsage =
              from timeStamp in LicenseTimeStamp
              from actor in MessageHost
              from licenseAction in LicenseAction
              from feature in LicenseFeature
              from user in LicenseUser
              from pc in UserPC
              from denialReason in DenialReason
              select new DeniedLicenseUsage(timeStamp, actor, licenseAction, feature, user, pc, denialReason);

        private static Parser<DateStamp> StandardDateStamp =
              from timeStamp in LicenseTimeStamp
              from actor in MessageHost
              from portAtHost in Parse.String("TIMESTAMP ")
              from licenseDate in LicenseDate
              select new DateStamp(licenseDate, actor);

        private static Parser<DateStamp> StartDate =
            from timeStamp in LicenseTimeStamp
            from actor in MessageHost
            from startDateInfo in Parse.String("(@lmgrd-SLOG@) Start-Date: ")
            from licenseDate in LicenseDate
            select new DateStamp(licenseDate, actor);

        private static Parser<DateStamp> DateStamp = StandardDateStamp.Or(StartDate);


        private static Parser<AnyRow> AnyRow =
            from value in Parse.AnyChar.Many().Text()
            select new AnyRow(value);


        public static Parser<RowEntity> RowEntity = DateStamp.Or<RowEntity>(UnsupportedFeature).Or<RowEntity>(DeniedLicenseUsage).Or<RowEntity>(LicenseUsage).Or<RowEntity>(AnyRow);





    }
}
