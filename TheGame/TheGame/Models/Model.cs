using System;

namespace TheGame.Models
{
    public class Model
    {
        public string Id { get; set; }
        public string Text { get; set; }
        public string Description { get; set; }
    }
    public class Quest
    {
        public int ID { get; set; }
        
        public int fk_quest_type { get; set; }
        public string QuestName { get; set; }
        public string Description { get; set; }
    }
    public class Task
    {
        public int ID { get; set; }
        public int fk_quest_id { get; set; }
        public string TaskImage { get; set; }
        public string TaskDescription { get; set; }
    }
}