namespace MarquezBouzoDanielExamen1.Models.Repository
{
    public interface IUsuariosRepository
    {
        public void Register(Usuarios usuarios);
        public Task<Usuarios> LoginAsync(Usuarios usuarios);
    }
}
