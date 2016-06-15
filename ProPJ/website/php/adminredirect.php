<?php
if($_SESSION['access'] != "Admin")
{
    header('Location: eventInfo.php');
}
?>