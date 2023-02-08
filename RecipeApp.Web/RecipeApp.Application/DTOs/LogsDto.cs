﻿namespace RecipeApp.Application.DTOs
{
    public class LogsDto
    {
        public string PlainTextContent { get; set; }
        public string FileName { get; set; }
        public Stream LogsStream { get; set; }
        public DateTime Date { get; set; }
    }
}
