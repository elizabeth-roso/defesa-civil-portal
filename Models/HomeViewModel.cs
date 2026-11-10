using Microsoft.AspNetCore.Components.Forms;

namespace portal_defesa_civil.Models
{
    public class HomeViewModel
    {
        public string TextoPrincipal { get; set; } =
           "A Defesa Civil é um conjunto de ações permanentes destinadas a evitar desastres, minimizar seus impactos para a população e restabelecer a normalidade social.Ao contrário do que muitos pensam, ela não atua apenas durante uma emergência, mas sim de forma contínua através de cinco pilares fundamentais";

        public string Prevencao { get; set; } = "Mapeia áreas de risco, realiza vistorias técnicas em imóveis com problemas estruturais e combate a ocupação de locais perigosos.";

        public string Mitigacao { get; set; } = " Adota medidas para reduzir o impacto de ameaças que não podem ser completamente evitadas.";

        public string Preparacao { get; set; } = " Capacita equipes, treina a comunidade e emite alertas meteorológicos antecipados (como avisos de temporais ou ressacas).";

        public string Resposta { get; set; } = "Atua diretamente no momento do desastre, prestando socorro imediato, salvamento e assistência humanitária (abrigos, alimentação e atenção médica)";

        public string Recuperacao { get; set; } = " Ajuda a reconstruir e reabilitar as áreas afetadas para que a comunidade retorne à rotina o mais rápido possível";

    }
}
