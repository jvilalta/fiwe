using System.CommandLine;

var startDateOption = new Option<DateTime>("--start-date");
var endDateOption = new Option<DateTime>("--end-date");
var rootCommand = new RootCommand()
{
    startDateOption,
    endDateOption
};
rootCommand.SetHandler(
    (DateTime sd, DateTime ed) =>
        {
            var currentDate = new DateTime(sd.Year, sd.Month, 1);
            var fridays = 0;
            var currentMonth = currentDate.Month;
            while (currentDate <= ed)
            {
                if (currentDate.Month != currentMonth)
                {
                    fridays = 0;
                    currentMonth = currentDate.Month;
                }
                if (currentDate.DayOfWeek == DayOfWeek.Friday)
                {
                    fridays++;
                }
                if (fridays == 5)
                {
                    Console.WriteLine(currentDate.ToShortDateString());
                    fridays = 0;
                }
                currentDate = currentDate.AddDays(1);
            }
        },
    startDateOption, endDateOption);

rootCommand.Invoke(args);