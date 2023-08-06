namespace Users.Domain.Dtos
{
    public class ResultDto<T>
    {
        public bool Success
        {
            get { return !this.Errors.Any(); }
        }
        public T Data { get; set; }

        public List<string> Errors { get; set; } = new List<string>();
    }
}
