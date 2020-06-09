namespace LINQDemo.Models
{
    public class Actor
    {
        public string FullName { get; set; }
        public int Age { get; set; }

        public override string ToString()
        {
            return $@"
                FullName:   {FullName}
                Age:        {Age}";
        }
    }
}