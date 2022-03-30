﻿namespace UseCases.User.Dto
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public byte[] Timestamp { get; set; } = null!;
    }
}
