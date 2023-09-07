using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class assessment : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            string name = Request.Form["name"];
            string rollno = Request.Form["rollno"];
            string teacherName = Request.Form["teacher-name"];
            string teacherID = Request.Form["teacher-id"];
            string course = Request.Form["course"];

            //Get rating values
            string q1 = Request.Form["question1"];
            string q2 = Request.Form["question2"];
            string q3 = Request.Form["question3"];
            string q4 = Request.Form["question4"];
            string q5 = Request.Form["question5"];
            string q6 = Request.Form["question6"];
            string q7 = Request.Form["question7"];
            string q8 = Request.Form["question8"];
            string q9 = Request.Form["question9"];
            string q10 = Request.Form["question10"];
            string q11 = Request.Form["question11"];
            string q12 = Request.Form["question12"];
            string q13 = Request.Form["question13"];
            string q14 = Request.Form["question14"];
            string q15 = Request.Form["question15"];
            string q16 = Request.Form["question16"];
            string q17 = Request.Form["question17"];
            string q18 = Request.Form["question18"];
            string q19 = Request.Form["question19"];
            string q20 = Request.Form["question20"];

            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-UNH3EMQ\\SQLEXPRESS;Initial Catalog=flex;Integrated Security=True");

            string query = "INSERT INTO feedback(student_roll, teacher_id, course_id, rating, rtype) " +
               "VALUES (@rollno, @teacherID, @course, @q1, @rtype1)," +
               "(@rollno, @teacherID, @course, @q2, @rtype2)," +
               "(@rollno, @teacherID, @course, @q3, @rtype3)," +
               "(@rollno, @teacherID, @course, @q4, @rtype4)," +
               "(@rollno, @teacherID, @course, @q5, @rtype5)," +
               "(@rollno, @teacherID, @course, @q6, @rtype6)," +
               "(@rollno, @teacherID, @course, @q7, @rtype7)," +
               "(@rollno, @teacherID, @course, @q8, @rtype8)," +
               "(@rollno, @teacherID, @course, @q9, @rtype9)," +
               "(@rollno, @teacherID, @course, @q10, @rtype10)," +
               "(@rollno, @teacherID, @course, @q11, @rtype11)," +
               "(@rollno, @teacherID, @course, @q12, @rtype12)," +
               "(@rollno, @teacherID, @course, @q13, @rtype13)," +
               "(@rollno, @teacherID, @course, @q14, @rtype14)," +
               "(@rollno, @teacherID, @course, @q15, @rtype15)," +
               "(@rollno, @teacherID, @course, @q16, @rtype16)," +
               "(@rollno, @teacherID, @course, @q17, @rtype17)," +
               "(@rollno, @teacherID, @course, @q18, @rtype18)," +
               "(@rollno, @teacherID, @course, @q19, @rtype19)," +
               "(@rollno, @teacherID, @course, @q20, @rtype20)";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@rollno", rollno);
            cmd.Parameters.AddWithValue("@teacherID", teacherID);
            cmd.Parameters.AddWithValue("@course", course);
            cmd.Parameters.AddWithValue("@q1", q1);
            cmd.Parameters.AddWithValue("@rtype1", "Q1");
            cmd.Parameters.AddWithValue("@q2", q2);
            cmd.Parameters.AddWithValue("@rtype2", "Q2");
            cmd.Parameters.AddWithValue("@q3", q3);
            cmd.Parameters.AddWithValue("@rtype3", "Q3");
            cmd.Parameters.AddWithValue("@q4", q4);
            cmd.Parameters.AddWithValue("@rtype4", "Q4");
            cmd.Parameters.AddWithValue("@q5", q5);
            cmd.Parameters.AddWithValue("@rtype5", "Q5");
            cmd.Parameters.AddWithValue("@q6", q6);
            cmd.Parameters.AddWithValue("@rtype6", "Q6");
            cmd.Parameters.AddWithValue("@q7", q7);
            cmd.Parameters.AddWithValue("@rtype7", "Q7");
            cmd.Parameters.AddWithValue("@q8", q8);
            cmd.Parameters.AddWithValue("@rtype8", "Q8");
            cmd.Parameters.AddWithValue("@q9", q9);
            cmd.Parameters.AddWithValue("@rtype9", "Q9");
            cmd.Parameters.AddWithValue("@q10", q10);
            cmd.Parameters.AddWithValue("@rtype10", "Q10");
            cmd.Parameters.AddWithValue("@q11", q11);
            cmd.Parameters.AddWithValue("@rtype11", "Q11");
            cmd.Parameters.AddWithValue("@q12", q12);
            cmd.Parameters.AddWithValue("@rtype12", "Q12");
            cmd.Parameters.AddWithValue("@q13", q13);
            cmd.Parameters.AddWithValue("@rtype13", "Q13");
            cmd.Parameters.AddWithValue("@q14", q14);
            cmd.Parameters.AddWithValue("@rtype14", "Q14");
            cmd.Parameters.AddWithValue("@q15", q15);
            cmd.Parameters.AddWithValue("@rtype15", "Q15");
            cmd.Parameters.AddWithValue("@q16", q16);
            cmd.Parameters.AddWithValue("@rtype16", "Q16");
            cmd.Parameters.AddWithValue("@q17", q17);
            cmd.Parameters.AddWithValue("@rtype17", "Q17");
            cmd.Parameters.AddWithValue("@q18", q18);
            cmd.Parameters.AddWithValue("@rtype18", "Q18");
            cmd.Parameters.AddWithValue("@q19", q19);
            cmd.Parameters.AddWithValue("@rtype19", "Q19");
            cmd.Parameters.AddWithValue("@q20", q20);
            cmd.Parameters.AddWithValue("@rtype20", "Q20");

            conn.Open();
            for (int i = 1; i <= 20; i++)
            {
                string rating = Request.Form["question" + i];
                cmd.Parameters["@q" + i].Value = rating;
                cmd.Parameters["@rtype" + i].Value = "Q" + i;
            }
            cmd.Parameters["@q20"].Value = string.IsNullOrEmpty(q20) ? "" : q20;
            cmd.Parameters["@rtype20"].Value = "Q20";
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}