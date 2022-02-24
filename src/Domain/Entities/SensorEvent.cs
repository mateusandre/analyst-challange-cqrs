using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class SensorEvent : BaseEntity
    {
        public SensorEvent()
        {
            SetStatus();
        }

        [Required]
        public long Timestamp { get; set; }
        [Required]
        public string Tag { get; set; }
        private string valor;
        public string Valor {
            get => valor;
            set
            {
                valor = value;

                SetStatus();
            }
        }              
        public string Status { get; private set; }

        private void SetStatus()
        {
            Status = string.IsNullOrEmpty(Valor) ? "Erro" : "Processado";
        }
    }
}
