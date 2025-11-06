namespace AssR1WebApp.ViewModels
{
    public class EmployeeNameWithTempMsgClrBranchViewModel
    {
        //Model Info ( hide colun name  & sen some Info)
        public int EmpId { get; set; }
        public string EmpName { get; set; }

        //Extra info
        public string Message { get; set; }
        public int Temp { get; set; }
        public string Color { get; set; }
        public List<string> Branches { get; set; }

    }
}
