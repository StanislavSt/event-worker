<?php 
session_start();
$_SESSION=array();
$_SESSION['access']=false;
unset($_SESSION['sess_email']);
unset($_SESSION['logged']);
unset($_SESSION['hastent']);
unset($_SESSION['tentstatus']);
session_destroy();
echo "<script type='text/javascript'>window.location.href = '../eventInfo.php';</script>";
exit();
?>
