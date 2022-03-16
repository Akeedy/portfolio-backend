using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace portfolio_backend.Models{


    public class Project{
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id{get;set;}
        public string Title{get;set;}
        public string Description{get;set;}
        public string LinkOfSource{get;set;}
        public string PathOfImage{get;set;}
        public string Technologies{get;set;}

    }
}