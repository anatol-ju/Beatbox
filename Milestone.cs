using System;

namespace Beatbox
{
    public class Milestone
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DateTime { get; set; }

        public Milestone() : this("default")
        {
        }

        public Milestone(string name) : this(name, "")
        {
        }

        public Milestone(string name, string description)
        {
            Name = name;
            Description = description;
            DateTime = DateTime.Now;
        }

        #region overrides
        public override string ToString()
        {
            return String.Format("Name: {0}\nDesctiption: {1}\nTimestamp: {2:H:mm:ss}", Name, Description, DateTime);
        }

        public override bool Equals(object obj)
        {
            try
            {
                Milestone milestone = (Milestone)obj;
                if (!milestone.Name.Equals(Name) ||
                    !milestone.DateTime.Equals(DateTime) ||
                    !milestone.Description.Equals(Description))
                {
                    return false;
                }
            }
            catch (InvalidCastException)
            {
                return false;
                throw;
            }

            return true;
        }

        public override int GetHashCode()
        {
            int code = 0;
            code += Name.Length;
            code += Description.Length / 3;
            code += DateTime.GetHashCode();
            return code;
        }
        #endregion
    }
}
