using System.Diagnostics.CodeAnalysis;

namespace Questao5.Infrastructure.Sqlite
{
    public class DatabaseConfig
    {
        [AllowNull]
        public string Name { get; set; }
    }
}