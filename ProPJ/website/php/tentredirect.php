<?php
if(isset($_SESSION['hastent']))
{
   $_SESSION['tentstatus']="<p style=color:red>You have already booked a tent!!</p>"; 
   header('Location:profile.php');
}
if(!isset($_SESSION['sess_email']))
{
    header('Location:profile.php');
}
