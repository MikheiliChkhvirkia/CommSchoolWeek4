namespace HomeWorkWeek9.Data.SentDataModels
{
    public class GetUsersModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Possition { get; set; }
        public string Company { get; set; }
        public int? WeekDayWorkHour { get; set; }
        public int? WeekendWorkHour { get; set; }
    }
}
