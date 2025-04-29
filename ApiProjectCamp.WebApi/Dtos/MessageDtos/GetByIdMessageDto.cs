namespace ApiProjectCamp.WebApi.Dtos.MessageDtos
{
    public class GetByIdMessageDto
    {
        public int MessageId { get; set; }
        public string NameSurname { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string MessageDetails { get; set; }
        public string SendDate { get; set; }
        public string IsRead { get; set; }
    }
}
