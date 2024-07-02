using System.Collections.Generic;

namespace CaixaEletronicoAPI.Services
{
    public class SaqueService
    {
        private readonly int[] _notasDisponiveis = { 100, 50, 20, 10, 5, 2 };
        private readonly Dictionary<int, Dictionary<int, int>> _cache = new Dictionary<int, Dictionary<int, int>>();

        public Dictionary<int, int> CalcularCedulas(int valor)
        {
            if (_cache.ContainsKey(valor))
            {
                return _cache[valor];
            }

            var resultado = new Dictionary<int, int>();
            int valorOriginal = valor;

            // Inicializar todas as cédulas com 0
            foreach (var nota in _notasDisponiveis)
            {
                resultado[nota] = 0;
            }

            foreach (var nota in _notasDisponiveis)
            {
                if (valor >= nota)
                {
                    int quantidadeNotas = valor / nota;
                    valor -= quantidadeNotas * nota;
                    resultado[nota] = quantidadeNotas;
                }
            }

            if (valor > 0)
            {
                throw new Exception("Não é possível sacar o valor solicitado com as notas disponíveis.");
            }

            _cache[valorOriginal] = new Dictionary<int, int>(resultado);

            return resultado;
        }
    }
}
