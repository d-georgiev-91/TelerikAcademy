namespace PrintSequenceFirstNMembersTests
{
    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using PrintSequenceFirstNMembers;

    [TestClass]
    public class PrintSequenceFirstNMembersTests
    {
        [TestMethod]
        public void GetSequenceFirst50MembersTest1()
        {
            int sequenceBeginning = 2;
            int sequenceMembersCount = 50;
            var actual = PrintSequenceFirstNMembers.GetSequenceFirstNMembers(sequenceBeginning, sequenceMembersCount);
            List<int> expected = new List<int>()
            {
                2, 3, 5, 4, 4, 7, 5, 6, 11, 7, 5, 9, 6, 5, 9, 6, 8, 15, 9, 6, 11, 7, 7, 13, 8, 12, 23,
                13, 8, 15, 9, 6, 11, 7, 10, 19, 11, 7, 13, 8, 6, 11, 7, 10, 19, 11, 7, 13, 8, 9
            };
        }

        [TestMethod]
        public void GetSequenceFirst50MembersTest2()
        {
            int sequenceBeginning = 100;
            int sequenceMembersCount = 50;
            var actual = PrintSequenceFirstNMembers.GetSequenceFirstNMembers(sequenceBeginning, sequenceMembersCount);
            List<int> expected = new List<int>()
            {
                100, 101, 201, 102, 102, 203, 103, 202, 403, 203,
                103, 205, 104, 103, 205, 104, 204, 407, 205, 104, 
                207, 105, 203, 405, 204, 404, 807, 405, 204, 407, 
                205, 104, 207, 105, 206, 411, 207, 105, 209, 106, 
                104, 207, 105, 206, 411, 207, 105, 209, 106, 205,
            };
        }

        [TestMethod]
        public void GetSequenceFirst50MembersTest3()
        {
            int sequenceBeginning = 0;
            int sequenceMembersCount = 50;
            var actual = PrintSequenceFirstNMembers.GetSequenceFirstNMembers(sequenceBeginning, sequenceMembersCount);
            List<int> expected = new List<int>()
            {
                0, 1, 1, 2, 2, 3, 3, 2, 3, 3, 3, 5, 4, 3, 5, 4, 4, 7, 5, 4, 7, 5, 3, 5, 4,
                4, 7, 5, 4, 7, 5, 4, 7, 5, 6, 11, 7, 5, 9, 6, 4, 7, 5, 6, 11, 7, 5, 9, 6, 5
            };
        }

        [TestMethod]
        public void GetSequenceFirst50MembersTest4()
        {
            int sequenceBeginning = -2;
            int sequenceMembersCount = 50;
            var actual = PrintSequenceFirstNMembers.GetSequenceFirstNMembers(sequenceBeginning, sequenceMembersCount);
            List<int> expected = new List<int>()
            {
               -2, -1, -3, 0, 0, -1, 1, -2, -5, -1, 1, 1, 2, 1, 1, 2, 0, -1, 1, 2, 3, 3, -1, -3,
               0, -4, -9, -3, 0, -1, 1, 2, 3, 3, 2, 3, 3, 3, 5, 4, 2, 3, 3, 2, 3, 3, 3, 5, 4, 1
            };
        }
    }
}