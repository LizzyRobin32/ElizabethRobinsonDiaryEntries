using System.ComponentModel.DataAnnotations;

namespace ElizabethRobinsonDiaryEntries.Models
{
    public class DiaryEntries
    {
        public int Id { get; set; }
        [Display(Name = "Title")]
        public string EntryName { get; set; }
        [Display(Name = "Entry Date")]
        public DateTime EntryDate { get; set; }
        [Display(Name = "Content")]
        public string EntryContext { get; set; }
    }
}
