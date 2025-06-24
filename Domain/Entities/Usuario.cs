using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace TareasApi.Domain.Entities
{
    public class Usuario
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } 

        public string NombreCompleto { get; set; }

        public string Correo { get; set; }

        public string PasswordHash { get; set; } 

        public List<Tarea> Tareas { get; set; } = new();
    }
}
