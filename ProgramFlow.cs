namespace Funhouse
{
    internal class ProgramFlow
    {
        private static int reedJobAmount, jobsiteAmount, indeedAmount, findajobAmount, specappAmount;
        private static string[] reedInput, jobsiteInput, indeedInput, findajobInput, specappInput;
        private static string path;
        private static string lastMeeting;
        private static DateTime parsedLastMeeting;
        private static DateTime todayDate;

        private static void Initialize()
        {
            Console.WriteLine("Input the date of your last meeting. Format: dd-MM-yyyy");
            lastMeeting = Console.ReadLine();
            parsedLastMeeting = DateTime.Parse(lastMeeting);
            todayDate = DateTime.Today;
            path = $"C:\\Users\\44753\\Documents\\Andy\\Logs\\programlogs\\{parsedLastMeeting.ToString("dd-MM-yyyy")}to{todayDate.ToString("dd-MM-yyyy")}.txt";
        }

        private static void AddMondayJobLog()
        {
            reedJobAmount++;
            jobsiteAmount++;
            indeedAmount++;
        }

        private static void AddTuesdayJobLog()
        {
            reedJobAmount++;
            jobsiteAmount++;
            indeedAmount++;
            findajobAmount++;
            specappAmount = specappAmount + 2;
        
        }

        private static void AddWednesdayJobLog()
        { 
            reedJobAmount++;
            jobsiteAmount++;
            indeedAmount++;
        }

        private static void AddThursdayJobLog()
        {
            reedJobAmount++;
        }

        private static void AddFridayJobLog()
        {
            reedJobAmount++;
        }


        public static void Run()
        {
            Initialize();
            List<DateTime> dates = InitilizeJobLogDates();
            List<string> fileContents = new List<string>();

            reedInput = new string[reedJobAmount]; jobsiteInput = new string[jobsiteAmount]; indeedInput = new string[indeedAmount];
            findajobInput = new string[findajobAmount]; specappInput = new string[specappAmount];

            JobLog.Input(reedInput, reedJobAmount, "Reed");
            JobLog.Input(jobsiteInput, jobsiteAmount, "Jobsite");
            JobLog.Input(indeedInput, indeedAmount, "Indeed");
            JobLog.Input(findajobInput, findajobAmount, "Find a Job");
            JobLog.Input(specappInput, specappAmount, "Speculative Application");

            List<string> fileContentsToWrite = DetermineFileContents(dates, fileContents);
            MakeFile(fileContentsToWrite);
            Console.WriteLine("Process Ended");
            
        }

        private static List<string> DetermineFileContents(List<DateTime> dates, List<string>fileContents)
        {
            int iReed = 0; int iJobsite = 0; int iIndeed = 0; int iFindajob = 0; int iSpecApp = 0;
            foreach (DateTime date in dates)
            {
                switch (date.DayOfWeek)
                {
                    case DayOfWeek.Monday:
                        fileContents.AddRange(WriteMondayJobLog(date, ref iReed, ref iJobsite, ref iIndeed));
                        break;
                    case DayOfWeek.Tuesday:
                        fileContents.AddRange(WriteTuesdayJobLog(date, ref iReed, ref iJobsite, ref iIndeed, ref iFindajob, ref iSpecApp));
                        break;
                    case DayOfWeek.Wednesday:
                        fileContents.AddRange(WriteWednesdayJobLog(date, ref iReed, ref iJobsite, ref iIndeed));
                        break;
                    case DayOfWeek.Thursday:
                        fileContents.AddRange(WriteThursdayJobLog(date, ref iReed));
                        break;
                    case DayOfWeek.Friday:
                        fileContents.AddRange(WriteFridayJobLog(date, ref iReed));
                        break;
                }
            }
            return fileContents;
        }

        private static List<DateTime> InitilizeJobLogDates()
        {
            int i = 0;
            TimeSpan numberOfJobLogDays = todayDate.Date - parsedLastMeeting.Date;
            Double totalJobLogDays = numberOfJobLogDays.TotalDays;
            DateTime iDate = parsedLastMeeting;
            List<DateTime> dates = new List<DateTime>();

            for (i = 0; i < totalJobLogDays; i++)
            {
                iDate = iDate.AddDays(1);

                switch (iDate.DayOfWeek)
                {
                    case DayOfWeek.Monday:
                        AddMondayJobLog();
                        break;
                    case DayOfWeek.Tuesday:
                        AddTuesdayJobLog();
                        break;
                    case DayOfWeek.Wednesday:
                        AddWednesdayJobLog();
                        break;
                    case DayOfWeek.Thursday:
                        AddThursdayJobLog();
                        break;
                    case DayOfWeek.Friday:
                        AddFridayJobLog();
                        break;
                }

                dates.Add(iDate);
            }

            return dates;


        }

        private static List <string> WriteMondayJobLog(DateTime date, ref int iReed, ref int iJobsite, ref int iIndeed)
        {
            List<string> mondayItems = new List<string>();
            mondayItems.Add(date.ToString("dd-MM-yyyy") +" - " + "reed - " + reedInput[iReed]);
            mondayItems.Add(date.ToString("dd-MM-yyyy") +" - " + "jobsite - " + jobsiteInput[iJobsite]);
            mondayItems.Add(date.ToString("dd-MM-yyyy") + " - " + "indeed - " + indeedInput[iIndeed]);

            iReed++; iJobsite++; iIndeed++;

            return mondayItems;
        }

        private static List<string> WriteTuesdayJobLog(DateTime date, ref int iReed, ref int iJobsite, ref int iIndeed, ref int iFindajob, ref int iSpecApp)
        {
            List<string> tuesdayItems = new List<string>();
            tuesdayItems.Add(date.ToString("dd-MM-yyyy") + " - " + "reed - " + reedInput[iReed]);
            tuesdayItems.Add(date.ToString("dd-MM-yyyy") + " - " + "jobsite - " + jobsiteInput[iJobsite]);
            tuesdayItems.Add(date.ToString("dd-MM-yyyy") + " - " + "indeed - " + indeedInput[iIndeed]);
            tuesdayItems.Add(date.ToString("dd-MM-yyyy") + " - " + "Find A Job - " + findajobInput[iFindajob]);
            tuesdayItems.Add(date.ToString("dd-MM-yyyy") + " - " + "Speculative Application - " + specappInput[iSpecApp]);
            iSpecApp++;
            tuesdayItems.Add(date.ToString("dd-MM-yyyy") + " - " + "Speculative Application - " + specappInput[iSpecApp]);

            iReed++; iJobsite++; iIndeed++; iFindajob++; iSpecApp++;

            return tuesdayItems;
        }

        private static List<string> WriteWednesdayJobLog(DateTime date, ref int iReed, ref int iJobsite, ref int iIndeed)
        {
            List<string> wednesdayItems = new List<string>();
            wednesdayItems.Add(date.ToString("dd-MM-yyyy") + " - " + "reed - " + reedInput[iReed]);
            wednesdayItems.Add(date.ToString("dd-MM-yyyy") + " - " + "jobsite - " + jobsiteInput[iJobsite]);
            wednesdayItems.Add(date.ToString("dd-MM-yyyy") + " - " + "indeed - " + indeedInput[iIndeed]);

            iReed++; iJobsite++; iIndeed++;

            return wednesdayItems;
        }

        private static List<string> WriteThursdayJobLog(DateTime date, ref int iReed)
        {
            List<string> thursdayItems = new List<string>();
            thursdayItems.Add(date.ToString("dd-MM-yyyy") + " - " + "reed - " + reedInput[iReed]);

            iReed++;

            return thursdayItems;
        }

        private static List<string> WriteFridayJobLog(DateTime date, ref int iReed)
        {
            List<string> fridayItems = new List<string>();
            fridayItems.Add(date.ToString("dd-MM-yyyy") + " - " + "reed - " + reedInput[iReed]);

            iReed++;

            return fridayItems;
        }
        private static void MakeFile(List<string> contents)
        {
            File.WriteAllLines(path, contents);
        }
    }


}


