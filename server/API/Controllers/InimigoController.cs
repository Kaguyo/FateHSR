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
            if (inimigoDto.Name == "Gepard")
            {
                Inimigo.Atk = 1700;
                Inimigo.HpMax = 135000;
                Inimigo.Hp = 135000;
                Inimigo.Def = 900;
                Inimigo.CritDmg = 100;
                Inimigo.CritRate = 10;
                Inimigo.UltCost = 75;
                Inimigo.Energy = 0;
                Inimigo.Speed = 90;
            }
            else if (inimigoDto.Name == "Bronya")
            {
                Inimigo.Atk = 1150;
                Inimigo.HpMax = 155000;
                Inimigo.Hp = 155000;
                Inimigo.Def = 620;
                Inimigo.CritDmg = 250;
                Inimigo.CritRate = 25;
                Inimigo.UltCost = 80;
                Inimigo.Energy = 0;
                Inimigo.Speed = 100;
            }
            else if (inimigoDto.Name == "Blade")
            {
                Inimigo.Atk = 1250;
                Inimigo.HpMax = 255000;
                Inimigo.Hp = 255000;
                Inimigo.Def = 600;
                Inimigo.CritDmg = 100;
                Inimigo.CritRate = 30;
                Inimigo.UltCost = 90;
                Inimigo.Energy = 0;
                Inimigo.Speed = 100;
            }
            else if (inimigoDto.Name == "Archer")
            {
                Inimigo.Atk = 1800;
                Inimigo.HpMax = 135000;
                Inimigo.Hp = 135000;
                Inimigo.Def = 600;
                Inimigo.CritDmg = 200;
                Inimigo.CritRate = 35;
                Inimigo.UltCost = 70;
                Inimigo.Energy = 0;
                Inimigo.Speed = 120;
            }
            if (inimigoDto.Name == "")
            {
                Inimigo.Atk = 0;
                Inimigo.HpMax = 0;
                Inimigo.Hp = 0;
                Inimigo.Def = 0;
                Inimigo.CritDmg = 0;
                Inimigo.CritRate = 0;
                Inimigo.UltCost = 0;
                Inimigo.Energy = 0;
                Inimigo.Speed = 0;
            }
            var response = new
            {
                Inimigo.Atk,
                Inimigo.HpMax,
                Inimigo.Hp,
                Inimigo.Def,
                Inimigo.CritDmg,
                Inimigo.CritRate,
                Inimigo.UltCost,
                Inimigo.Energy,
                Inimigo.Speed
            };

            return Ok(response);
        }
    }
}
