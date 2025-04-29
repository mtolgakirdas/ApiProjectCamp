namespace ApiProjectCamp.WebApi.Dtos.MessageDtos
{
    public class CreateMessageDto
    {
        public string NameSurname { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string MessageDetails { get; set; }
        public string SendDate { get; set; }
        public string IsRead { get; set; }
    }
}
