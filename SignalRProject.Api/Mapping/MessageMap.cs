using AutoMapper;
using SignalRProject.DtoLayer.MessageDtos;
using SignalRProject.EntityLayer.Entities;

namespace SignalRProject.Api.Mapping
{
    public class MessageMap:Profile
    {
        public MessageMap()
        {
            CreateMap<Message, CreateMessageDto>().ReverseMap();
            CreateMap<Message, ResultMessageDto>().ReverseMap();
            CreateMap<Message, GetMessageByIdDto>().ReverseMap();
            CreateMap<Message, UpdateMessageDto>().ReverseMap();
        }
    }
}
