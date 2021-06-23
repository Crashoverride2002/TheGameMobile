using System;
using Xamarin.Forms;

namespace TheGame.Models
{
    public class Model
    {
        public string Id { get; set; }
        public string Text { get; set; }
        public string Description { get; set; }
        public bool button { get; set; }
        public string button_id { get; set; }
    }
    public class Quest
    {
        public int ID { get; set; }
        public string QuetImage { get; set; }
        public int fk_quest_image_type { get; set; }
        public double lon { get; set; } // Longdetude
        public double lat { get; set; } // Latitude
        public int dir { get; set; } // direction
        public string imageType { get; set; } // MOV, STIL ~ Movie or still..
        public int fk_quest_type { get; set; }
        public string QuestName { get; set; }
        public string Description { get; set; }
    }
    public class SolutionItem
    {
        public int ID { get; set; }
        public int fk_taks_id { get; set; }
        public int fk_Item_id { get; set; } // Task item id.
        public string SolutionItemImage { get; set; }
        public int fk_quest_image_type { get; set; }
    }
    public class SolutionTask 
    {
        public int ID { get; set; }
        public int fk_taks_id { get; set; }
        public int fk_item_id { get; set; }
        public string Question { get; set; }
        public string Solution { get; set; }
        public double lon { get; set; } // Longdetude
        public double lat { get; set; } // Latitude
        public int dir { get; set; } // direction
        public string TaskGoalEppilog { get; set; } // A text eppilog of the task.
        public string SolutionItemImage { get; set; }
        public int fk_quest_image_type { get; set; }
    }
    public class TaskClue
    {
        public int ID { get; set; }
        public string ClueDescription { get; set; }
        public double lon { get; set; } // Longdetude
        public double lat { get; set; } // Latitude
        public int dir { get; set; } // direction
        public DateTime ObtainAtTime { get; set; }
        public string ClueImage { get; set; }
        public int fk_quest_image_type { get; set; }
    }
    public class TaskImages
    {
        public int ID { get; set; }
        public int fk_task_id { get; set; }
        public double lon { get; set; } // Longdetude
        public double lat { get; set; } // Latitude
        public int dir { get; set; } // direction
        public int fk_quest_image_type {get;set;}
        public string imageType { get; set; } // MOV, STIL ~ Movie or Still
    }
    public class TaskItem
    {
        public int ID { get; set; }
        public int fk_task_id { get; set; }
        public string ItemImage { get; set; }
        public double lon { get; set; } // Longdetude
        public double lat { get; set; } // Latitude
        public int dir { get; set; } // direction
        public string ItemSolvDescription { get; set; }
        public string fk_ItemType { get; set; } // ID describing what type of clue it is pastic metal paper wood.
        public int puzzelPeace { get; set; } // if 0 then its a complated peace if 1 its a puzzel peace.
    }

    public class ClueInventory
    {
        public int ID { get; set; }
        public int QuestID { get; set;}
        public int ItemCount { get; set; }
        public Image image { get; set; }
    }

    public class GPSDegrees
    {
        public string Direction { get; set; }
        public double course { get; set; }
    }
    public class GPSLock
    {
        public string Direction { get; set; } // N S E W
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
    public class User
    {
        public int ID { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public int GroupId { get; set; }
    }
    public class Groups
    {
        public int ID { get; set; }
        public string GroupName { get; set; }
    }
    public class Task
    {
        public int ID { get; set; }
        public int fk_quest_id { get; set; }
        public string TaskImage { get; set; }
        public string TaskDescription { get; set; }
    }
}