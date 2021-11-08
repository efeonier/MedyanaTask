using System.Collections.Generic;

namespace Medyana.API.Model
{
    public class ErrorModel
    {
        public ErrorModel()
        {
            Errors = new List<string>();
        }

        public List<string> Errors { get; set; }
        public int Status { get; set; }
    }
}