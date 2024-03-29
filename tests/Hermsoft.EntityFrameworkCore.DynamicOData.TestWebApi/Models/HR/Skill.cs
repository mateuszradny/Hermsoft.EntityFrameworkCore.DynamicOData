namespace Hermsoft.EntityFrameworkCore.DynamicOData.TestWebApi.Models.HR
{
    public class Skill
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<WorkerSkill> WorkerSkills { get; private set; } = new HashSet<WorkerSkill>();
    }
}