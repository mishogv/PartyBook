namespace PartyBook.Data.Common.Models
{
    using Newtonsoft.Json;
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Message : BaseModel<int>
    {
        public string serializedData;

        public Message(object data)
            => this.Data = data;

        private Message()
        {
        }

        public Type Type { get; private set; }

        public bool Published { get; private set; } = false;

        public void MarkAsPublished() => this.Published = true;

        [NotMapped]
        public object Data
        {
            get => JsonConvert.DeserializeObject(this.serializedData, this.Type,
                new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });

            set
            {
                this.Type = value.GetType();

                this.serializedData = JsonConvert.SerializeObject(value,
                    new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            }
        }
    }
}
