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
            if (personagemDto.Name == "Artoria")
            {
                Personagem.Atk = 1700;
                Personagem.HpMax = 175000;
                Personagem.Hp = 175000;
                Personagem.Def = 600;
                Personagem.CritDmg = 100;
                Personagem.CritRate = 10;
                Personagem.UltCost = 75;
                Personagem.Energy = 0;
                Personagem.Speed = 100;
            }
            else if (personagemDto.Name == "Baobhan") 
            {
                Personagem.Atk = 1550;
                Personagem.HpMax = 155000;
                Personagem.Hp = 155000;
                Personagem.Def = 620;
                Personagem.CritDmg = 150;
                Personagem.CritRate = 15;
                Personagem.UltCost = 80;
                Personagem.Energy = 0;
                Personagem.Speed = 90;
            }
            else if (personagemDto.Name == "Kafka")
            {
                Personagem.Atk = 2550;
                Personagem.HpMax = 145000;
                Personagem.Hp = 145000;
                Personagem.Def = 600;
                Personagem.CritDmg = 50;
                Personagem.CritRate = 10;
                Personagem.UltCost = 60;
                Personagem.Energy = 0;
                Personagem.Speed = 100;
            }
            else if (personagemDto.Name == "Seele")
            {
                Personagem.Atk = 1800;
                Personagem.HpMax = 135000;
                Personagem.Hp = 135000;
                Personagem.Def = 600;
                Personagem.CritDmg = 100;
                Personagem.CritRate = 35;
                Personagem.UltCost = 70;
                Personagem.Energy = 0;
                Personagem.Speed = 120;
            }
            if (personagemDto.Name == "") 
            {
                Personagem.Atk = 0;
                Personagem.HpMax = 0;
                Personagem.Hp = 0;
                Personagem.Def = 0;
                Personagem.CritDmg = 0;
                Personagem.CritRate = 0;
                Personagem.UltCost = 0;
                Personagem.Energy = 0;
                Personagem.Speed = 0;
            }
            var response = new
            {
                Personagem.Atk,
                Personagem.HpMax,
                Personagem.Hp,
                Personagem.Def,
                Personagem.CritDmg,
                Personagem.CritRate,
                Personagem.UltCost,
                Personagem.Energy,
                Personagem.Speed
            };

            return Ok(response);
        }
    }
}
