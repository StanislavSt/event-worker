<?php
        $dbconn=new PDO('mysql:host=athena01.fhict.local;dbname=dbi315379','dbi315379','etV9hbpQZM');
        $dbconn->setAttribute(PDO::ATTR_ERRMODE,PDO::ERRMODE_EXCEPTION);
        $countquery=$dbconn->prepare("SELECT * FROM person");
        $countquery->execute();
        $nrofppl=$countquery->rowCount();
        $counttent=$dbconn->prepare("SELECT * FROM persons_in_tents");
        $counttent->execute();
        $nrofpplintent=$counttent->rowCount();
if(isset($_POST['area1']))
{       $tablestructure="<tr>
    <th>Ticket ID</th>
    <th>Full name</th>		
    <th>Tent ID</th>
  </tr>";
        
        $prepquery=$dbconn->prepare("SELECT Per.First_Name AS FName,Per.Last_Name as LName,Per.Ticket_ID AS TicketID,T.Tent_ID AS TentID FROM tent T JOIN persons_in_tents P ON P.Tent_ID=T.Tent_ID join person Per ON P.Email=Per.Email WHERE T.TentArea=? ORDER BY T.Tent_ID");
        $prepquery->execute(array("1"));
        while($info=$prepquery->fetch(PDO::FETCH_OBJ))
        {       $fname=$info->FName;
                $lname=$info->LName;
                 $fullname=$fname.' '.$lname;
                 $ticketid=$info->TicketID;
                 $tentid=$info->TentID;
            $tablestructure=$tablestructure.'<tr><td>'.$ticketid.'</td><td>'.$fullname.'</td><td>'.$tentid.'</td></tr>';
        }
        
}
if(isset($_POST['area2']))
{       $tablestructure="<tr>
    <th>Ticket ID</th>
    <th>Full name</th>		
    <th>Tent ID</th>
  </tr>";
        $dbconn=new PDO('mysql:host=athena01.fhict.local;dbname=dbi315379','dbi315379','etV9hbpQZM');
        $dbconn->setAttribute(PDO::ATTR_ERRMODE,PDO::ERRMODE_EXCEPTION);
        $prepquery=$dbconn->prepare("SELECT Per.First_Name AS FName,Per.Last_Name as LName,Per.Ticket_ID AS TicketID,T.Tent_ID AS TentID FROM tent T JOIN persons_in_tents P ON P.Tent_ID=T.Tent_ID join person Per ON P.Email=Per.Email WHERE T.TentArea=? ORDER BY T.Tent_ID");
        $prepquery->execute(array("2"));
        while($info=$prepquery->fetch(PDO::FETCH_OBJ))
        {       $fname=$info->FName;
                $lname=$info->LName;
                 $fullname=$fname.' '.$lname;
                 $ticketid=$info->TicketID;
                 $tentid=$info->TentID;
            $tablestructure=$tablestructure.'<tr><td>'.$ticketid.'</td><td>'.$fullname.'</td><td>'.$tentid.'</td></tr>';
        }
}
if(isset($_POST['area3']))
{       $tablestructure="<tr>
    <th>Ticket ID</th>
    <th>Full name</th>		
    <th>Tent ID</th>
  </tr>";
        $dbconn=new PDO('mysql:host=athena01.fhict.local;dbname=dbi315379','dbi315379','etV9hbpQZM');
        $dbconn->setAttribute(PDO::ATTR_ERRMODE,PDO::ERRMODE_EXCEPTION);
        $prepquery=$dbconn->prepare("SELECT Per.First_Name AS FName,Per.Last_Name as LName,Per.Ticket_ID AS TicketID,T.Tent_ID AS TentID FROM tent T JOIN persons_in_tents P ON P.Tent_ID=T.Tent_ID join person Per ON P.Email=Per.Email WHERE T.TentArea=? ORDER BY T.Tent_ID");
        $prepquery->execute(array("3"));
        while($info=$prepquery->fetch(PDO::FETCH_OBJ))
        {       $fname=$info->FName;
                $lname=$info->LName;
                 $fullname=$fname.' '.$lname;
                 $ticketid=$info->TicketID;
                 $tentid=$info->TentID;
            $tablestructure=$tablestructure.'<tr><td>'.$ticketid.'</td><td>'.$fullname.'</td><td>'.$tentid.'</td></tr>';
        }
}
?>