namespace portal_defesa_civil.DTOs
{
    public class NoticiaDTO
    {
        public int Id { get; set; }
        public required string Titulo { get; set; }
        public string? Url { get; set; }
        public string? Subtitulo { get; set; }
        public string? Conteudo { get; set; }
        public string? Tags { get; set; }
        public int? AutorPrincipalId { get; set; }
        public DateTime? DataNoticia { get; set; } 
        public DateTime? DataPublicacao { get; set; }
        public int UsuarioCriacao { get; set; }
        public DateTime? DataAlteracao { get; set; }
        public int? UsuarioAlteracao { get; set; }
        public bool Politico { get; set; } = false;
        public bool Ativo { get; set; }
        public int? BancoFotosLegado { get; set; }
        public string? ImagemPrincipal { get; set; }
        public int? GaleriaId { get; set; }
        public required List<string> Autores { get; set; }
        public List<FotoDTO>? Fotos { get; set; }
        public List<string>? Categorias { get; set; }
        public List<string>? Publicacoes { get; set; }
    }
}
