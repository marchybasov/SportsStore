using System;
using System.Collections.Generic;
using System.Linq;
using LicenseParser.LicenseFolder;

namespace LicenseParser
{
    public class LicenseUsageGetter : ILicenseUsageGetter
    {
        private readonly ILicenseFileReader fileReader;
        public LicenseUsageGetter()
        {
            fileReader = new LicenseFileReader();
        }
        public Stack<LicenseUsageParsed> ParseLicenseUsages( string logFilePath)
        {            
            Stack<RowEntity> rowEntitiesStack = new Stack<RowEntity>();
            string[] rows = fileReader.GetLicenseFileInfo(logFilePath);
            foreach (string row in rows)
            {

                var entity = RowEntity.Parse(row);
                Console.WriteLine(entity.GetType());
                if (entity.GetType() != typeof(AnyRow))
                {
                    rowEntitiesStack.Push(entity);
                }
            }
            return GetLicenseUsages(rowEntitiesStack, new Stack<LicenseUsageParsed>());
        }
        private Stack<LicenseUsageParsed> GetLicenseUsages(Stack<RowEntity> parsedEntities, Stack<LicenseUsageParsed> licenseUsages)
        {
            if (parsedEntities.Count > 0)
            {
                Queue<LicenseUsageParsed> tempLicenseUsageQueue = new Queue<LicenseUsageParsed>();
                RowEntity[] arr = new RowEntity[parsedEntities.Count()];
                parsedEntities.CopyTo(arr, 0);
                DateTime currentDate = FindNearestDateStampInLog(arr);
                while (parsedEntities.Count() > 0)
                {
                    var entity = parsedEntities.Peek();

                    while (parsedEntities.Count() > 0 && parsedEntities.Peek().GetType() != typeof(DateStamp))
                    {

                        tempLicenseUsageQueue.Enqueue(((LicenseUsageParsed)parsedEntities.Pop()));

                    }
                    if (entity.GetType() == typeof(DateStamp))
                    {
                        DateStamp tempDate = (DateStamp)entity;
                        if (tempDate.Date.GetValue<DateTime>().Date >= currentDate.Date)
                        {
                            while (tempLicenseUsageQueue.Count() > 0)
                            {
                                licenseUsages.Push(ApplyDateToUsage(tempLicenseUsageQueue.Dequeue(), currentDate));
                            }

                            parsedEntities.Pop();
                        }
                        else
                        {
                            while (tempLicenseUsageQueue.Count() > 0)
                            {
                                parsedEntities.Push(tempLicenseUsageQueue.Dequeue());
                            }

                            GetLicenseUsages(parsedEntities, licenseUsages);
                        }
                    }

                }

            }

            return licenseUsages;
        }
        static DateTime FindNearestDateStampInLog(RowEntity[] parsedLogEntites)
        {
            RowEntity entity;
            for (int i = 0; i < parsedLogEntites.Length; i++)
            {
                entity = parsedLogEntites[i];
                if (entity.GetType() == typeof(DateStamp))
                {
                    DateStamp val = (DateStamp)entity;
                    return val.Date.GetValue<DateTime>();
                }
            }
            return default;
        }

        static LicenseUsageParsed ApplyDateToUsage(LicenseUsageParsed usage, DateTime date)
        {
            usage.FullTimeStamp = date + usage.TimeStamp;
            return usage;
        }
    }

}
