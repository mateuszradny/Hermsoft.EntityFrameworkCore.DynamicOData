using Microsoft.EntityFrameworkCore;

namespace Hermsoft.EntityFrameworkCore.DynamicOData.TestWebApi.Models.HR
{
    [PrimaryKey(nameof(WorkerId), nameof(SkillId))]
    public class WorkerSkill
    {
        public int WorkerId { get; set; }
        public int SkillId { get; set; }
        public SkillLevel Level { get; set; }

        public Worker Worker { get; set; }
        public Skill Skill { get; set; }
    }
}