
using System;

namespace Application.SensorEvent.DTO
{
    public class SensorEventsDTO
    {
        public SensorEventsDTO(string tag, long timestamp, string valor, string status)
        {
            Valor = valor;
            Status = status;
            Timestamp = timestamp;

            SetTagValues(tag);
        }

        public long Timestamp { get; set; }
        public string Regiao { get; set; }
        public string Sensor { get; set; }
        public string Valor { get; }
        public string Status { get; }

        private void SetTagValues(string tag)
        {
            if (!string.IsNullOrEmpty(tag))
            {
                var tagArray = tag.Split('.');

                if (tagArray.Length > 2)
                {
                    Regiao = tagArray[1];
                    Sensor = tagArray[2];
                }
            }

        }
    }
}
