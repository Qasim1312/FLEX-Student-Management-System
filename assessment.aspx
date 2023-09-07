<%@ Page Language="C#" AutoEventWireup="true" CodeFile="assessment.aspx.cs" Inherits="assessment" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Student Assessment Form</title>
   
</head>

<body>
    <form id="form1" runat="server">
         <link rel="stylesheet" href="styles.css">

        <div class="'container">
            <h1>Student Assessment Form</h1>
            <label for="name">Name:</label>
            <input type="text" id="name" name="name" required>
            <br>
            <hr>
            <label for="rollno">Roll Number:</label>
            <input type="text" id="rollno" name="rollno" required>
            <br>
            <hr>
            <label for="teacher-name">Teacher Name:</label>
            <input type="text" id="teacher-name" name="teacher-name" required>
            <br>
            <hr>
            <label for="teacher-id">Teacher ID:</label>
            <input type="text" id="teacher-id" name="teacher-id" required>
            <br>
            <hr>
            <label for="course">Course:</label>
            <input type="text" id="course" name="course" required>
            <br>
            <hr>
            <h2>Please rate the teacher from 1 (poor) to 5 (excellent).</h2>
            <hr>
            <div class="user-info">
                    <h2>Appearance and Presentation*.</h2>
                   <label for="question1">Teacher attends classes in a well presentable manner:</label>
                    <input type="radio" id="teacher-performance1" name="teacher-performance" value="1" required>1
                    <input type="radio" id="teacher-performance2" name="teacher-performance" value="2">2
                    <input type="radio" id="teacher-performance3" name="teacher-performance" value="3">3
                    <input type="radio" id="teacher-performance4" name="teacher-performance" value="4">4
                    <input type="radio" id="teacher-performance5" name="teacher-performance" value="5">5
                    <br>
                     <hr>
                    <label for="question2">Teacher shows enthusiasm while teaching in class:</label>
                    <input type="radio" id="question11" name="question1" value="1" required>1
                    <input type="radio" id="question12" name="question1" value="2">2
                    <input type="radio" id="question13" name="question1" value="3">3
                    <input type="radio" id="question14" name="question1" value="4">4
                    <input type="radio" id="question15" name="question1" value="5">5
                    <br>
                    <hr>
                    <label for="question3">Teacher shows initiative and flexibility in teaching:</label>
                    <input type="radio" id="question21" name="question2" value="1" required>1
                    <input type="radio" id="question22" name="question2" value="2">2
                    <input type="radio" id="question23" name="question2" value="3">3
                    <input type="radio" id="question24" name="question2" value="4">4
                    <input type="radio" id="question25" name="question2" value="5">5
                    <br>
                    <hr>
                    <label for="question4">Teacher is well articulated and shows full knowledge on the subject:</label>
                    <input type="radio" id="question31" name="question3" value="1" required>1
                    <input type="radio" id="question32" name="question3" value="2">2
                    <input type="radio" id="question33" name="question3" value="3">3
                    <input type="radio" id="question34" name="question3" value="4">4
                    <input type="radio" id="question35" name="question3" value="5">5
                    <br>
                    <hr>
                    <label for="question5">Teacher speaks loud and clear:</label>
                    <input type="radio" id="question41" name="question4" value="1" required>1
                    <input type="radio" id="question42" name="question4" value="2">2
                    <input type="radio" id="question43" name="question4" value="3">3
                    <input type="radio" id="question44" name="question4" value="4">4
                    <input type="radio" id="question45" name="question4" value="5">5
                    <br>
               </div>
            <hr>
            <div class="user-info">
                    <h2>Professional Practice*.</h2>
                    <label for="question6">Teacher shows professionalism in class:</label>
                    <input type="radio" id="question51" name="question5" value="1" required>1
                    <input type="radio" id="question52" name="question5" value="2">2
                    <input type="radio" id="question53" name="question5" value="3">3
                    <input type="radio" id="question54" name="question5" value="4">4
                    <input type="radio" id="question55" name="question5" value="5">5
                    <br>
                    <hr>
                    <label for="question7">Teacher shows commitment to teaching in class:</label>
                    <input type="radio" id="question61" name="question6" value="1" required>1
                    <input type="radio" id="question62" name="question6" value="2">2
                    <input type="radio" id="question63" name="question6" value="3">3
                    <input type="radio" id="question64" name="question6" value="4">4
                    <input type="radio" id="question65" name="question6" value="5">5
                    <br>
                    <hr>
                    <label for="question8">Teacher encourages students participation in class discussions:</label>
                    <input type="radio" id="question71" name="question7" value="1" required>1
                    <input type="radio" id="question72" name="question7" value="2">2
                    <input type="radio" id="question73" name="question7" value="3">3
                    <input type="radio" id="question74" name="question7" value="4">4
                    <input type="radio" id="question75" name="question7" value="5">5
                    <br>
                    <hr>
                    <label for="question9">Teacher handles criticism and suggestions professionally:</label>
                    <input type="radio" id="question81" name="question8" value="1" required>1
                    <input type="radio" id="question82" name="question8" value="2">2
                    <input type="radio" id="question83" name="question8" value="3">3
                    <input type="radio" id="question84" name="question8" value="4">4
                    <input type="radio" id="question85" name="question8" value="5">5
                    <br>
                    <hr>
                    <label for="question10">Teacher comes to class on time:</label>
                    <input type="radio" id="question91" name="question9" value="1" required>1
                    <input type="radio" id="question92" name="question9" value="2">2
                    <input type="radio" id="question93" name="question9" value="3">3
                    <input type="radio" id="question94" name="question9" value="4">4
                    <input type="radio" id="question95" name="question9" value="5">5
                    <br>
                    <hr>
                    <label for="question11">Teacher ends class on time:</label>
                    <input type="radio" id="question101" name="question10" value="1" required>1
                    <input type="radio" id="question102" name="question10" value="2">2
                    <input type="radio" id="question103" name="question10" value="3">3
                    <input type="radio" id="question104" name="question10" value="4">4
                    <input type="radio" id="question105" name="question10" value="5">5
                    <br>
            </div>
            <hr>
             <div class="user-info">
                     <h2>Teaching Method*.</h2>
                    <label for="question12">Teacher shows welll rounded knowledge on the subject athand:</label>
                    <input type="radio" id="question111" name="question11" value="1" required>1
                    <input type="radio" id="question112" name="question11" value="2">2
                    <input type="radio" id="question113" name="question11" value="3">3
                    <input type="radio" id="question114" name="question11" value="4">4
                    <input type="radio" id="question115" name="question11" value="5">5
                    <br>
                    <hr>
                    <label for="question13">Teacher has organized lessons that are easy for students to understand:</label>
                    <input type="radio" id="question121" name="question12" value="1" required>1
                    <input type="radio" id="question122" name="question12" value="2">2
                    <input type="radio" id="question123" name="question12" value="3">3
                    <input type="radio" id="question124" name="question12" value="4">4
                    <input type="radio" id="question125" name="question12" value="5">5
                    <br>
                    <hr>
                    <label for="question14">Teacher shows dynamism and enthusiasm:</label>
                    <input type="radio" id="question131" name="question13" value="1" required>1
                    <input type="radio" id="question132" name="question13" value="2">2
                    <input type="radio" id="question133" name="question13" value="3">3
                    <input type="radio" id="question134" name="question13" value="4">4
                    <input type="radio" id="question135" name="question13" value="5">5
                    <br>
                    <hr>
                    <label for="question15">Teacher stimulates critical thinking of students:</label>
                    <input type="radio" id="question151" name="question15" value="1" required>1
                    <input type="radio" id="question152" name="question15" value="2">2
                    <input type="radio" id="question153" name="question15" value="3">3
                    <input type="radio" id="question154" name="question15" value="4">4
                    <input type="radio" id="question155" name="question15" value="5">5
                    <br>
                    <hr>
                    <label for="question16">Teacher handle the class environment conducive for learning:</label>
                    <input type="radio" id="question161" name="question16" value="1" required>1
                    <input type="radio" id="question162" name="question16" value="2">2
                    <input type="radio" id="question163" name="question16" value="3">3
                    <input type="radio" id="question164" name="question16" value="4">4
                    <input type="radio" id="question165" name="question16" value="5">5
                    <br>
            </div>
            <hr>
             <div class="user-info">
                     <h2>Disposition towards Students*.</h2>
                    <label for="question17">Teacher shows respect to various cultures and individuals:</label>
                    <input type="radio" id="question171" name="question17" value="1" required>1
                    <input type="radio" id="question172" name="question17" value="2">2
                    <input type="radio" id="question173" name="question17" value="3">3
                    <input type="radio" id="question174" name="question17" value="4">4
                    <input type="radio" id="question175" name="question17" value="5">5
                    <br>
                    <hr>
                    <label for="question18">Teacher belives that student can learn from class:</label>
                    <input type="radio" id="question181" name="question18" value="1" required>1
                    <input type="radio" id="question182" name="question18" value="2">2
                    <input type="radio" id="question183" name="question18" value="3">3
                    <input type="radio" id="question184" name="question18" value="4">4
                    <input type="radio" id="question185" name="question18" value="5">5
                    <br>
                    <hr>
                    <label for="question19">Teacher finds students strengths as growth and their weakness as opportunity to improve:</label>
                    <input type="radio" id="question191" name="question19" value="1" required>1
                    <input type="radio" id="question192" name="question19" value="2">2
                    <input type="radio" id="question193" name="question19" value="3">3
                    <input type="radio" id="question194" name="question19" value="4">4
                    <input type="radio" id="question195" name="question19" value="5">5
                    <br>
                    <hr>
                     <label for="question20">Teacher understands students weakness and helps them improve:</label>
                    <input type="radio" id="question141" name="question14" value="1" required>1
                    <input type="radio" id="question142" name="question14" value="2">2
                    <input type="radio" id="question143" name="question14" value="3">3
                    <input type="radio" id="question144" name="question14" value="4">4
                    <input type="radio" id="question145" name="question14" value="5">5
                    <br>
                 </div>
            <hr>
             <div class="user-info">
            <label for="comments">Comments:</label>
            <br>
            <textarea id="comments" name="comments" rows="5" cols="40"></textarea>
            <br>
                 </div>
            <input type="submit" value="Submit">
        </div>
    </form>
</body>
</html>