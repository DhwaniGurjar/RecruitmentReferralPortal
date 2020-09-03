using System;
using System.Linq;

namespace DbOperations.DataBaseOperations
{
    internal class OperationCheckAlreadyParsed
    {
        public static Boolean CheckIfParsed(string filepath)
        {
            Boolean check = false;
            using (var context = new ResumeParserEntities())
            {
                var checkIfFilePresent = from file in context.Resumes
                                         where file.FilePath == filepath
                                         select file;

                if (checkIfFilePresent.Any())
                    check = true;

                return check;
            }
        }
    }
}