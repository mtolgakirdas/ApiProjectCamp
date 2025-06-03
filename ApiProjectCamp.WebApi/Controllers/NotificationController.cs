﻿using ApiProjectCamp.WebApi.Context;
using ApiProjectCamp.WebApi.Dtos.NotificationDtos;
using ApiProjectCamp.WebApi.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProjectCamp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ApiContext _context;
        public NotificationController(IMapper mapper, ApiContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        [HttpGet]
        public IActionResult NotificationList()
        {
            var values = _context.Notifications.ToList();
            return Ok(_mapper.Map<List<ResultNotificationDto>>(values));
        }

        [HttpPost]
        public IActionResult CreateNotification(CreateNotificationDto createNotificationDto)
        {
            var value = _mapper.Map<Notification>(createNotificationDto);
            _context.Notifications.Add(value);
            _context.SaveChanges();
            return Ok("Ekleme İşlemi Başarılı");
        }

        [HttpDelete]
        public IActionResult DeleteNotification(int id)
        {
            var value = _context.Notifications.Find(id);
            _context.Notifications.Remove(value);
            _context.SaveChanges();
            return Ok("Silme İşlemi Başarılı");
        }

        [HttpGet("GetNotification")]
        public IActionResult GetNotification(int id)
        {
            var value = _context.Notifications.Find(id);
            return Ok(_mapper.Map<GetNotificationByIdDto>(value));
        }

        [HttpPut]
        public IActionResult UpdateNotification(UpdateNotificationDto updateNotificationDto)
        {
            var value = _mapper.Map<Notification>(updateNotificationDto);
            _context.Notifications.Update(value);
            _context.SaveChanges();
            return Ok("Güncelleme İşlemi Başarılı");
        }
    }
}
