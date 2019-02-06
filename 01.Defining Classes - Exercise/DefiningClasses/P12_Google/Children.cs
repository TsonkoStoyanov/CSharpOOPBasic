namespace P12_Google
{
    public class Children
    {
        public Children(string childName, string childBirthday)
        {
            ChildName = childName;
            ChildBirthday = childBirthday;
        }

        public string ChildName { get; set; }

        public string ChildBirthday { get; set; }

        public override string ToString()
        {
            return $"{ChildName} {ChildBirthday}";
        }
    }
}