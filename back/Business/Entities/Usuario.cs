﻿namespace back.Business.Entities
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public bool Excluido { get; set; }
        public bool Active { get; set; }
    }
}
