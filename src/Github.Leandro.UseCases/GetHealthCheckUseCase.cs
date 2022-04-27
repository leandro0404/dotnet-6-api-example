using Github.Leandro.Borders.UseCases;

namespace Github.Leandro.UseCases
{
    public class GetHealthCheckUseCase : IGetHealthCheckUseCase
    {
        public  Task <Boolean> Execute()
        {
          return Task.FromResult(true);
        }
        
    }
} 