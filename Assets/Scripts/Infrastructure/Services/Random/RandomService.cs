using IdGen;

namespace Infrastructure.Services.Analytics
{
    public class RandomService : IRandomService
    {
        private IdGenerator _generator = new IdGenerator(0);
        
        public long GenerateId() => 
            _generator.CreateId();
    }
}