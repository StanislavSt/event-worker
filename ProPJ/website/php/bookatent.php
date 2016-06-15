<?php
$dbconn=new PDO('mysql:host=athena01.fhict.local;dbname=dbi315379','dbi315379','etV9hbpQZM');
$dbconn->setAttribute(PDO::ATTR_ERRMODE,PDO::ERRMODE_EXCEPTION);
$query=$dbconn->prepare("SELECT DISTINCT TentArea FROM tent WHERE Booked='no'");
$query->execute();
$nrofrows=$query->rowCount();
$options="";
if($nrofrows==0)
{
    $warning="<h3 style=color:yellow >We do not have any free tents at the moment!Click <i><a href=profile.php>HERE</a></i> to go back</h3>";
}
else
{    
    while($tent=$query->fetch(PDO::FETCH_OBJ))
    {
        $value=$tent->TentArea;
        $options=$options."<option value=".$value.">".$value."</option>";
    }
}
?>