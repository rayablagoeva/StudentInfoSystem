using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace LibraryLogger
{
    public static class Logger
    {
        static private List<String> currentSessionActivities = new List<String>();
        private static void createDatabaseLog(String log)
        {
            LogContext context = new LogContext();
            Logs userLog = new Logs(log);

            context.UserLogs.Add(userLog);
            context.SaveChanges();
        }
        static public void LogActivity(String activity, string currentUsername, string currentUserRole)
        {
            String activityLine = DateTime.Now + ";"
                + currentUsername + ";"
                + currentUserRole + ";"
                + activity;
            currentSessionActivities.Add(activityLine);
            File.AppendAllText("test.txt", activityLine + "\n");
            createDatabaseLog(activityLine);
        }

        static public String GetCurrentSessionActivities()
        {
            StringBuilder sb = new StringBuilder();
            foreach (String activity in currentSessionActivities)
            {
                sb.Append(activity);
                sb.Append('\n');
            }
            return sb.ToString();
        }
    }
}
