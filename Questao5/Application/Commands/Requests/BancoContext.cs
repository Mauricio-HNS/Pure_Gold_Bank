namespace Questao5.Infrastructure
{
    public class BancoContext
    {
        public object ContasCorrentes { get; internal set; }

        internal void SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}