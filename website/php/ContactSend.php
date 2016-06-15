<?php
if(isset($_POST['submit']))
{
    if(!empty($_POST['name']) && !empty($_POST['email']) && !empty($_POST['subject'])
            && !empty($_POST['message']))
    {   $name=$_POST['name'];
        $email=$_POST['email'];
        $subject=$_POST['subject'];
        $message=$_POST['message'];
        $postedon=date('Y-m-d H:i:s');
        try
        {
            $dbconn=new PDO('mysql:host=athena01.fhict.local;dbname=dbi315379','dbi315379','etV9hbpQZM');
            $dbconn->setAttribute(PDO::ATTR_ERRMODE,PDO::ERRMODE_EXCEPTION);
            $query=$dbconn->prepare("INSERT INTO contact(name, email, subject, message, postedon) VALUES(?,?,?,?,?)");
            if($query->execute(array("$name", "$email","$subject","$message",$postedon)))
            {   
                $success="<p style=color:green>Your message has been successfully submitted!<br> Thank you, ".$name."</p>";;
            }
            else
            {
                $success="<p style=color:red>Please try again! Was unable to submit the message!</p>";
            }
        }
        catch(PDOException $pdoex)
        {
            $success=$pdoex->getMessage();   
        }
    }
    else
    {
        $success="<p style=color:red>All fields are required!</p>";
    }
}
?>