<?php
if(isset($_SESSION['sess_email']))
{    
        $dbconn=new PDO('mysql:host=athena01.fhict.local;dbname=dbi315379','dbi315379','etV9hbpQZM');
        $dbconn->setAttribute(PDO::ATTR_ERRMODE,PDO::ERRMODE_EXCEPTION);
        $email=$_SESSION['sess_email'];
        $query=$dbconn->prepare("SELECT * FROM person WHERE Email=?");
        $query->execute(array("$email"));       
        $nrofrows=$query->rowCount();
        if($nrofrows !=0)
        {        
            while($person=$query->fetch(PDO::FETCH_OBJ))
            {            
                $ticketid=$person->Ticket_ID;
                $fname=$person->First_Name;
                $lname=$person->Last_Name;
                $dateofregp=$person->DateOfRegistration;
                $dob=$person->DateofBirth;
                $emailprofile=$person->Email;            
            }    
            $tentquery=$dbconn->prepare("SELECT tent.TentArea AS TentArea,tent.Tent_ID AS TentID,persons_in_tents.NrOfPlacesBooked AS PlacesBooked FROM Tent JOIN persons_in_tents ON Tent.Tent_ID=persons_in_tents.Tent_ID WHERE persons_in_tents.Email=?");
            $fullname=$fname. ' ' . $lname;        
            $tentquery->execute(array("$emailprofile"));
            $nrofrowstent=$tentquery->rowCount();
            if($nrofrowstent==0)
            {
                $tentareadisplay="Haven't booked a tent yet!";
                $tentiddisplay="Haven't booked a tent yet!";
                $nrbooked="Haven't booked a tent yet!";
            }
            else
            {
                while($tent=$tentquery->fetch(PDO::FETCH_OBJ))
                {
                    $tentareadisplay=$tent->TentArea;
                    $tentiddisplay=$tent->TentID;
                    $nrbooked=$tent->PlacesBooked;
                }
                $_SESSION['hastent']="yes";
            }
        }
}