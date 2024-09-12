using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TvMazeApi.TvMazeData.Entities
{
    public class Show
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public string Url { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Type {  get; set; } = string.Empty;
        public string Language {  get; set; } = string.Empty;
        public string Status {  get; set; } = string.Empty;
        public int? Runtime { get; set; } = 0;
        public int? AverageRuntime { get; set; } = 0;
        public DateTime? Ended { get; set; }
    }
}
