namespace blazorapp.Models;

public class User
    {
        public string? Username { get; set; }
        public string? role { get; set; }
        public int? points {get; set; }
        public string? color {get; set; }
        public bool buzzed {get; set;}
    };

    public class Questions
    {
        public string? question { get; set; }
        public int? points { get; set; }

        public bool answered { get; set; }

        public Questions()
        {
            question = null;
            points = null;
            answered = false;

        }
    }