namespace MarquezBouzoDanielExamen1.Models.Repository
{
    public interface ICriptomonedasRepository
    {
        public Task<List<Criptomonedas>> GetAll();
        public Task<Criptomonedas> GetById(int id);
        public Task Edit(Criptomonedas c);
        public void Save(Criptomonedas c);
        public void Delete(Criptomonedas c);
    }
}
