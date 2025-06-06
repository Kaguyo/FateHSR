using BackEnd.Domain.Entities;
using BackEnd.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonagemController : ControllerBase
    {
        [HttpPost(Name = "PostPersonagem")]
        public IActionResult Post([FromBody] PersonagemDTO personagemDto)
        {
            Personagem personagem = new();
            if (personagemDto.Name == "Artoria")
            {
                personagem.Atk = 1700;
                personagem.HpMax = 175000;
                personagem.Hp = 175000;
                personagem.Def = 600;
                personagem.CritDmg = 100;
                personagem.CritRate = 10;
                personagem.UltCost = 75;
                personagem.Energy = 0;
                personagem.Speed = 100;
            }
            else if (personagemDto.Name == "Baobhan") 
            {
                personagem.Atk = 1550;
                personagem.HpMax = 155000;
                personagem.Hp = 155000;
                personagem.Def = 620;
                personagem.CritDmg = 150;
                personagem.CritRate = 15;
                personagem.UltCost = 80;
                personagem.Energy = 0;
                personagem.Speed = 90;
            }
            else if (personagemDto.Name == "Kafka")
            {
                personagem.Atk = 2550;
                personagem.HpMax = 145000;
                personagem.Hp = 145000;
                personagem.Def = 600;
                personagem.CritDmg = 50;
                personagem.CritRate = 10;
                personagem.UltCost = 60;
                personagem.Energy = 0;
                personagem.Speed = 100;
            }
            else if (personagemDto.Name == "Seele")
            {
                personagem.Atk = 1800;
                personagem.HpMax = 135000;
                personagem.Hp = 135000;
                personagem.Def = 600;
                personagem.CritDmg = 100;
                personagem.CritRate = 35;
                personagem.UltCost = 70;
                personagem.Energy = 0;
                personagem.Speed = 120;
            }
            if (personagemDto.Name == "") 
            {
                personagem.Atk = 0;
                personagem.HpMax = 0;
                personagem.Hp = 0;
                personagem.Def = 0;
                personagem.CritDmg = 0;
                personagem.CritRate = 0;
                personagem.UltCost = 0;
                personagem.Energy = 0;
                personagem.Speed = 0;
            }

            return Ok(personagem);
        }
    }
}
