﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRProject.WebUI.Dtos.NotificationDtos
{
    public class CreateNotificationDto
    {
        public string Type { get; set; }
        public string Icon { get; set; }
        public string Description { get; set; }
    }
}
