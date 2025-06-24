using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TareasApi.Domain.Entities
{
    public class Tarea
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public bool Completada { get; set; }
        public string UsuarioId { get; set; }
    }
}






