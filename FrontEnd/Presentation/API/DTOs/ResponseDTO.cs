﻿namespace FrontEnd.Presentation.API.DTOs
{
    public class ResponseDTO
    {
        public bool IsSuccess { get; set; } = true;
        public object Result { get; set; }
        public string DisplayMessage {  get; set; }
        public List<string> Errors { get; set; }
    }
}
