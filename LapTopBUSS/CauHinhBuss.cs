using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LapTopOBJ;
using LapTopDAO;
namespace LapTopBUSS
{
    public class CauHinhBuss
    {
        CauHinhDAO cauhinhDAO = new CauHinhDAO();
        public List<CauHinh> LayCauHinh()
        {
            return cauhinhDAO.GetCauHinh();
        }
    }
}