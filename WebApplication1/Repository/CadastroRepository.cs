using WebApplication1.Context;
using WebApplication1.Model;

namespace WebApplication1.Repository
{
    public class CadastroRepository
    {
        private readonly AppDbContext _dbContext;

        public CadastroRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Pessoa CreatePessoa(Pessoa pessoa)
        {
            _dbContext.Pessoa.Add(pessoa);
            _dbContext.SaveChanges();
            return pessoa;
        }

        public Endereco CreateEndereco(Endereco endereco, int idPessoa)
        {
            endereco.PessoaId = idPessoa;
            _dbContext.Endereco.Add(endereco);
            _dbContext.SaveChanges();
            return endereco;
        }

        public Pessoa GetPessoaById(int id)
        {
            return _dbContext.Pessoa.Where(pessoa => pessoa.Id == id).FirstOrDefault();
        }

        public List<Endereco> GetEnderecoByPessoaId(int id)
        {
            return _dbContext.Endereco.Where(endereco => endereco.PessoaId == id).ToList();
        }

        public void DeletePessoa(int id)
        {
            if (GetPessoaById(id) == null)
                throw new Exception("Não foi possível deletar, não existe uma Pessoa para esse Id.");

            _dbContext.Pessoa.Remove(GetPessoaById(id));
            _dbContext.SaveChanges();
        }

        public void DeleteEnderecoByPessoaId(int idPessoa, int idEndereco)
        {
            if (GetPessoaById(idPessoa) == null)
                throw new Exception("Não foi possível deletar, não existe uma Pessoa para esse Id.");

            var Enderecos = GetEnderecoByPessoaId(idPessoa);

            foreach (var item in Enderecos)
            {
                if (item.Id == idEndereco)
                {
                    _dbContext.Endereco.Remove(item);
                }
            }

            _dbContext.SaveChanges();
        }

        public void DeleteAllEndereco(int idPessoa)
        {
            if (GetPessoaById(idPessoa) == null)
                throw new Exception("Não foi possível deletar, não existe uma Pessoa para esse Id.");

            var Enderecos = GetEnderecoByPessoaId(idPessoa);

            foreach (var item in Enderecos)
            {
                _dbContext.Endereco.Remove(item);
            }

            _dbContext.SaveChanges();
        }

        public Pessoa UpdatePessoa(int id, Pessoa pessoa)
        {
            Pessoa objParaAtualizar = GetPessoaById(id);

            objParaAtualizar.Nome = pessoa.Nome;
            objParaAtualizar.Email = pessoa.Email;
            objParaAtualizar.Idade = pessoa.Idade;

            _dbContext.SaveChanges();

            return objParaAtualizar;
        }

        public Endereco UpdateEndereco(int id, Endereco endereco)
        {
            Endereco objAtualizado = new Endereco();
            List<Endereco> objParaAtualizar = GetEnderecoByPessoaId(id);

            foreach (var item in objParaAtualizar)
            {
                if (item.Id == endereco.Id)
                {
                    item.Logradouro = endereco.Logradouro;
                    item.UF = endereco.UF;
                    item.Cidade = endereco.Cidade;
                    item.Bairro = endereco.Bairro;
                    item.Numero = endereco.Numero;

                    objAtualizado = item;
                }
            }

            _dbContext.SaveChanges();

            return objAtualizado;
        }

        public IQueryable<Pessoa> GetPessoas()
        {
            return _dbContext.Pessoa;
        }

        public IQueryable<Endereco> GetEnderecos()
        {
            return _dbContext.Endereco;
        }
    }
}