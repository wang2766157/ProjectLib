using System.ComponentModel.DataAnnotations;

namespace ProjectLib.Model
{
    public class ModalModel
    {
        [Key]
        public string ID { get; set; }
        public string MsgTitle { get; set; } = "";
        public string MsgContent { get; set; } = "";
        public bool MsgShow { get; set; } = false;
    }
}
