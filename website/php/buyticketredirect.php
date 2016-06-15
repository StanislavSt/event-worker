<?php
if(isset($_SESSION['sess_email']))
{   if($_SESSION['access']=="Admin")
    {
    header('Location:adminpanel.php');
    }
    else
    {
    header('Location:profile.php');    
    }
}
?>

