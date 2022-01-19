using System.Collections.Generic;

namespace dotnet_api_project.Models
{
    public class Skill
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public int Damage { get; set; }
        public List<Character> Characters { get; set; }
    }
}