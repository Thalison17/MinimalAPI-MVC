namespace WebApplication1.Model;

public class Endereco
{
    public int Id { get; set; }
    public string Logradouro { get; set; } = string.Empty;
    public int Numero { get; set; }
    public string UF { get; set; } = string.Empty;
    public string Cidade { get; set; } = string.Empty;
    public string Bairro { get; set; } = string.Empty;

    public int PessoaId { get; set; }
}