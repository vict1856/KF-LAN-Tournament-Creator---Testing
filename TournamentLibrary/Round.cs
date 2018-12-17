using System;
using System.Collections.Generic;
using System.Text;

namespace TournamentLibrary
{
    public class Round
    {
        private List<Group> groups = new List<Group>();

        private bool isFinished = false;

        public void AddGroup(Group group)
        {
            groups.Add(group);
        }

        public List<Group> Groups
        {
            get
            {
                return groups;
            }
        }

        public bool IsFinished
        {
            get
            {
                return isFinished;
            }
            set
            {
                isFinished = value;
            }
        }
    }
}
