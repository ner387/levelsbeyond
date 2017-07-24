using Notes.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Notes.Controllers
{
    public class NotesController : ApiController
    {
        private static IList<NotesModel> Notes { get; set; }

        [HttpGet]
        public List<NotesModel> Get(int? id=null)
        {            
            if (Notes == null)
            {
                Notes = new List<NotesModel>();
            }

            if (id.HasValue)
            {
                if (id.Value <= 0 || id.Value > Notes.Count)
                {
                    return new List<NotesModel>()
                    {
                        new NotesModel
                        {
                            Id = id.Value,
                            Body = "Invalid Id"
                        }
                    };
                } else
                {
                    return Notes.Where(x => x.Id == id).ToList();
                }
            } else
            {
                return Notes.ToList();
            }
        }

        [HttpGet]
        public List<NotesModel> Get(string query)
        {
            if (query == null)
            {
                query = "";
            }
            if (Notes == null)
            {
                Notes = new List<NotesModel>();
            }
            return Notes.Where(x => x.Body.ToLower().Contains(query.ToLower())).ToList();
        }

        [HttpPost]
        public NotesModel Post(NotesModel note)
        {
            if (Notes == null)
            {
                Notes = new List<NotesModel>();
            }

            Notes.Add(new NotesModel
            {
                Id = Notes.Count + 1,
                Body = note.Body
            });

            return Notes[Notes.Count-1];
        }
    }
}
