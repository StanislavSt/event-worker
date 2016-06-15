<?php
if(isset($_POST['bookatent']))
{
    $check=$_POST['bookatent'];
    if($check=="Book a tent")  
    {           $dbconn=new PDO('mysql:host=athena01.fhict.local;dbname=dbi315379','dbi315379','etV9hbpQZM');
                $dbconn->setAttribute(PDO::ATTR_ERRMODE,PDO::ERRMODE_EXCEPTION);
                $arrayofppl=array();
                if(!empty($_POST['email0']))
                {
                    $arrayofppl[0]=$_POST['email0'];
                } 
                if(!empty($_POST['email1']))
                {
                    $arrayofppl[1]=$_POST['email1'];
                }
                if(!empty($_POST['email2']))
                {
                    $arrayofppl[2]=$_POST['email2'];
                }   
                if(!empty($_POST['email3']))
                {
                    $arrayofppl[3]=$_POST['email3'];
                }
                if(!empty($_POST['email4']))
                {
                    $arrayofppl[4]=$_POST['email4'];
                }       
                if(!empty($_POST['email5']))
                {
                    $arrayofppl[5]=$_POST['email5'];
                }
                $nrofemails=0;
                $checkpeoplequery=$dbconn->prepare("SELECT * FROM person where Email=?");
                foreach($arrayofppl as $valuecheck)
                {
                    $checkpeoplequery->execute(array("$valuecheck"));
                    $nrofemails=$nrofemails+$checkpeoplequery->rowCount();
                }
                $arraysize=  count($arrayofppl);
                if($arraysize==$nrofemails)
                {
                       
                       $tentarea=$_POST['tentarea'];
                       $query=$dbconn->prepare("SELECT *  FROM tent WHERE Booked='no' AND TentArea=? ORDER BY Tent_ID LIMIT 1");
                       $query->execute(array("$tentarea"));
                       $nrofrows=$query->rowCount();
                        if($nrofrows!=0)
                        {
                            while($tent=$query->fetch(PDO::FETCH_OBJ))
                            {
                                    $tentid=$tent->Tent_ID;
                            }
                            $checktentquery=$dbconn->prepare("SELECT * FROM persons_in_tents WHERE Email=?");
                            $nrofrowsinpersonsintents=0;
                            foreach($arrayofppl as $emailcheck)
                            {
                                $checktentquery->execute(array("$emailcheck"));
                                $nrofrowsinpersonsintents=$nrofrowsinpersonsintents+$checktentquery->rowCount();
                            }
                            if($nrofrowsinpersonsintents==0)
                            {$insertpeoplequery=$dbconn->prepare("INSERT INTO persons_in_tents(Tent_ID,Email,NrOfPlacesBooked,Price,Paid) VALUES(?,?,?,?,?)");
                                $updatequery=$dbconn->prepare("UPDATE `dbi315379`.`tent` SET `Booked` = 'yes' WHERE `tent`.`Tent_ID` = ?");
                                $price=30+($nrofemails-1)*20;
                                $paid="no";
                                foreach($arrayofppl as $val)
                                    {
                                        $insertpeoplequery->execute(array("$tentid","$val",$nrofemails,$price,"$paid"));                
                                    }
                                if($updatequery->execute(array("$tentid")));
                                {
                                 $errormsg="<h3 style=color:green>You have successfully booked the tent!Redirecting you to your profile page...!</h3>";  
                                 header("Refresh:5,profile.php");
                                }   
                            }
                            else
                            {
                                $errormsg="<h3 style=color:yellow>One or more emails have already booked a tent!Please check again!</h3>";
                            }
                        }
                }
                else
                {
                    $errormsg="<h3 style=color:yellow>One or more emails do not exists in our database!Please check again!</h3>";
                }
    }
}
?>