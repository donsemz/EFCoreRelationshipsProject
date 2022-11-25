using EFCoreRelationshipsProject.Data;
using EFCoreRelationshipsProject.Dto;
using EFCoreRelationshipsProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCoreRelationshipsProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharacterController: ControllerBase
    {
        private readonly HeroContext _context;
        public CharacterController(HeroContext context)
        {
                _context=context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Character>>> Get(int userId)
        {
            var characters = await _context.Characters.Where(c => c.UserId == userId).Include(c=>c.Weapon).Include(c=>c.Skills).ToListAsync();
            return characters;
        }

        [HttpPost]
        public async Task<ActionResult<List<Character>>> Create(CreateCharacterDto request)
        {
            var user = await _context.Users.FindAsync(request.UserId);
            if (user==null)
            {
                return NotFound();
            }

            var newCharacter = new Character
            {
                Name = request.Name,
                RpgClass = request.RpgClass,
                User = user
            };

            _context.Characters.Add(newCharacter);
            await _context.SaveChangesAsync();
            return await Get(newCharacter.UserId);
        }
    }
}
