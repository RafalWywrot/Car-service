namespace CarService.Repository.CustomTypes
{
    public enum ServiceBookingStatus
    {
        Created = 0,
        Verify = 1,
        WaitingClientApprove = 2,
        Accepted = 3,
        Declined = 4,
        InProgress = 5, //w trakcie realizacji
        Finished = 6
    }
}