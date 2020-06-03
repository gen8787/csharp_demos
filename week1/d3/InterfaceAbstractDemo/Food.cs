namespace InterfaceAbstractDemo
{
    public class Food
    {
        public bool IsYummy { get; set; }
        private string message;
        public string Message
        {
            get
            {
                if (IsYummy)
                {
                    return "Yum Yum 4 My Tum Tum";
                }
                else
                {
                    return message;
                }
            }
            set
            {
                if (value != "")
                {
                    message = value;
                }
            }
        }
    }
}