﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace WIUT.DAL
{
    public class ApplicantList
    {
        public List<Applicant> GetAllaApplicants()
        {
            return new ApplicantManager().GetAll();
        }

        public List<Applicant> Sort(ByAttribute attribute)
        {
            var result = GetAllaApplicants();

            switch (attribute)
            {
                case ByAttribute.Name:
                    result.Sort(new ByNameComparer());
                    return result;
                case ByAttribute.Surname:
                    result.Sort(new BySurnameComparer());
                    return result;
                case ByAttribute.DoB:
                    break;
                case ByAttribute.Course:
                    break;
            }

            //if we are here = something went wrong
            return null;
        }

        private class ByNameComparer : IComparer<Applicant>
        {
            public int Compare(Applicant x, Applicant y)
            {
                return string.Compare(x.Name, y.Name);
            }
        }

        private class BySurnameComparer : IComparer<Applicant>
        {
            public int Compare(Applicant x, Applicant y)
            {
                return string.Compare(x.Surname, y.Surname);
            }
        }

        private class ByDoBComparer : IComparer<Applicant>
        {
            public int Compare(Applicant x, Applicant y)
            {
                return DateTime.Compare(x.DoB, y.DoB);
            }
        }

        private class ByCourseComparer : IComparer<Applicant>
        {
            public int Compare(Applicant x, Applicant y)
            {
                return string.Compare(x.Course.Name, y.Course.Name);
            }
        }


        public List<Applicant> SortLinq(ByAttribute attribute)
        {
            switch (attribute)
            {
                case ByAttribute.Name:
                    return GetAllaApplicants().OrderBy(a => a.Name).ToList();
                case ByAttribute.Surname:
                    return GetAllaApplicants().OrderBy(a => a.Name).ToList();
                case ByAttribute.DoB:
                    return GetAllaApplicants().OrderBy(a => a.DoB).ToList();
                case ByAttribute.Course:
                    return GetAllaApplicants().OrderBy(a => a.Course.Name).ToList();
            }

            //if we are here = something went wrong
            return null;
        }

        public List<Applicant> Search(string value, ByAttribute attribute)
        {
            switch (attribute)
            {
                case ByAttribute.Name:
                    return GetAllaApplicants().Where(a => a.Name.Contains(value)).ToList();
                case ByAttribute.Surname:
                    return GetAllaApplicants().Where(a => a.Surname.Contains(value)).ToList();
            }

            //if we are here = something went wrong
            return null;
        }
    }
}