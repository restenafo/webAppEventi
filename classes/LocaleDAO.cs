//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Linq;
//using System.Web;
//using WebAppEventiCrociera.classes;

//namespace WebAppEventiCrociera.classes
//{
//    public class LocaleDAO
//    {

//        public void InsertLocale(Locale oLocale)
//        {

//            string query = "INSERT INTO LOCALI VALUES('" + oLocale.codLocale + "','" + oLocale.nome + "','" + oLocale.luogo + "'," + oLocale.posti + ")";

//            DBConnection oDBConnection = new DBConnection();
//            oDBConnection.ExecuteNonQuery(query);
//        }

//        public List<Locale> GetAllLocali()
//        {
//            List<Locale> listaLocali = new List<Locale>();

//            string sQuery = "SELECT * FROM LOCALI";
//            DBConnection d = new DBConnection();
//            DataTable dt = d.DoQuerySelect(sQuery);

//            foreach (DataRow dr in dt.Rows)
//            {
//                Locale oLocale = new Locale();
//                oLocale.codLocale = dr["CodLocale"].ToString();
//                oLocale.nome = dr["Nome"].ToString();
//                oLocale.luogo = dr["Luogo"].ToString();
//                oLocale.posti = Convert.ToInt32(dr["Posti"]);

//                listaLocali.Add(oLocale);
//            }
//            return listaLocali;
//        }


//        public void DeleteLocale(string codLocale)
//        {
//            string sQuery = "DELETE FROM LOCALI WHERE CodLocale=" + codLocale + ";";
//            DBConnection d = new DBConnection();
//            d.ExecuteNonQuery(sQuery);
//        }


//        //public void UpdateLocale(Locale oLocale)
//        //{
//        //    string sQuery = @"UPDATE LOCALI SET Nome='" + oLocale.nome +
//        //        "',Cognome='" + oLocale.cognome +
//        //        "' WHERE CodLocale='" + oLocale.codLocale + "';";
//        //    DBConnection d = new DBConnection();
//        //    d.ExecuteNonQuery(sQuery);
//        //}

//        public Locale GetLocaleById(string codLocale)
//        {
//            string sQuery = "SELECT * FROM LOCALI WHERE CodLocale=" + codLocale + ";";
//            DBConnection d = new DBConnection();

//            DataTable dt = d.DoQuerySelect(sQuery);
//            Locale oLocale = new Locale();
//            oLocale.codLocale = dt.Rows[0]["CodLocale"].ToString();
//            oLocale.luogo = dt.Rows[0]["Luogo"].ToString();
//            oLocale.nome = dt.Rows[0]["Nome"].ToString();
//            oLocale.posti = Convert.ToInt32(dt.Rows[0]["Posti"]);


//            return oLocale;

//        }

//    }
//}