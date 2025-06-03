using BackEnd.Domain.Entities;
using BackEnd.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InimigoController : ControllerBase
    {
        [HttpPost(Name = "PostInimigo")]
        public IActionResult Post([FromBody] InimigoDTO inimigoDto)
        {
            Inimigo enemy = new();
            if (inimigoDto.Name == "Gepard")
            {
                enemy.Atk = 1700;
                enemy.HpMax = 135000;
                enemy.Hp = 135000;
                enemy.Def = 900;
                enemy.CritDmg = 100;
                enemy.CritRate = 10;
                enemy.UltCost = 75;
                enemy.Energy = 0;
                enemy.Speed = 90;
            }
            else if (inimigoDto.Name == "Bronya")
            {
                enemy.Atk = 1150;
                enemy.HpMax = 155000;
                enemy.Hp = 155000;
                enemy.Def = 620;
                enemy.CritDmg = 250;
                enemy.CritRate = 25;
                enemy.UltCost = 80;
                enemy.Energy = 0;
                enemy.Speed = 100;
            }
            else if (inimigoDto.Name == "Blade")
            {
                enemy.Atk = 1250;
                enemy.HpMax = 255000;
                enemy.Hp = 255000;
                enemy.Def = 600;
                enemy.CritDmg = 100;
                enemy.CritRate = 30;
                enemy.UltCost = 90;
                enemy.Energy = 0;
                enemy.Speed = 100;
            }
            else if (inimigoDto.Name == "Archer")
            {
                enemy.Atk = 1800;
                enemy.HpMax = 135000;
                enemy.Hp = 135000;
                enemy.Def = 600;
                enemy.CritDmg = 200;
                enemy.CritRate = 35;
                enemy.UltCost = 70;
                enemy.Energy = 0;
                enemy.Speed = 120;
            }
            if (inimigoDto.Name == "")
            {
                enemy.Atk = 0;
                enemy.HpMax = 0;
                enemy.Hp = 0;
                enemy.Def = 0;
                enemy.CritDmg = 0;
                enemy.CritRate = 0;
                enemy.UltCost = 0;
                enemy.Energy = 0;
                enemy.Speed = 0;
            }

            return Ok(enemy);
        }
    }
}
