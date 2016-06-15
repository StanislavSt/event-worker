<?php

$dbconn=new PDO('mysql:host=athena01.fhict.local;dbname=dbi315379','dbi315379','etV9hbpQZM');
$dbconn->setAttribute(PDO::ATTR_ERRMODE,PDO::ERRMODE_EXCEPTION);

if(isset($_POST['btnreg']))
{

    if(!empty($_POST['fname']) && !empty($_POST['lname']) && !empty($_POST['day']) && !empty($_POST['month'])
            && !empty($_POST['year']) && !empty($_POST['password']) && !empty($_POST['repeatpassword']) && !empty($_POST['email']))
    {
    $fname=$_POST['fname'];
    $lname=$_POST['lname'];
    $checkpass1=$_POST['password'];
    $checkpass2=$_POST['repeatpassword'];
    $day=$_POST['day'];
    $month=$_POST['month'];
    $year=$_POST['year'];
    $email=$_POST['email'];
    $access="User";
    $dateofreg=date("Y-m-d H:i:s");
    $dateofbirth="$year-$month-$day";
        if($checkpass1==$checkpass2)
        {
        $checkqueryprop=$dbconn->prepare("SELECT * FROM propwebsite JOIN person on propwebsite.Email=person.email WHERE person.Email=?");
        $checkqueryprop->execute(array("$email"));
        $nrofrows=$checkqueryprop->rowCount();
           if($nrofrows==0)
           {
            $insertqueryprop=$dbconn->prepare("INSERT INTO propwebsite(Email,Password,Access) VALUES(?,?,?)");
            $insertqueryperson=$dbconn->prepare("INSERT INTO person(First_Name,Last_Name,DateOfRegistration,DateOfBirth,Email)VALUES (?,?,?,?,?)");
               if($insertqueryperson->execute(array("$fname","$lname","$dateofreg","$dateofbirth","$email")) && $insertqueryprop->execute(array("$email","$checkpass1","$access")))
               {           
                  $outcome="<p style=color:green>Account succesfully created!</p>";           
               }       
           }
            else
            {       
               $outcome="<p style=color:red>This email already exists!</p>";
            }
        }
        else
        {
            $outcome="<p style=color:red>Passwords don't match!</p>";   
        }       
    }
    else
        {
            $outcome="<p style=color:red>All fields are required!</p>";
        }
}
?>


	
	