<?php
if(isset($_POST['login']))
{ if(!empty($_POST['login']))
{
        $dbconn=new PDO('mysql:host=athena01.fhict.local;dbname=dbi315379','dbi315379','etV9hbpQZM');
        $dbconn->setAttribute(PDO::ATTR_ERRMODE,PDO::ERRMODE_EXCEPTION);
if(!empty($_POST['email']) && !empty($_POST['password']))
        {
        $emaillogin=$_POST['email'];
        $passwordlogin=$_POST['password'];
        $query=$dbconn->prepare("SELECT * FROM propwebsite WHERE Email=? AND Password=?");
        $query->execute(array("$emaillogin","$passwordlogin"));
        $nrofrows=$query->rowCount();
           if($nrofrows!=0)
           {
          while($person=$query->fetch(PDO::FETCH_OBJ))
                {
                    $dbemail=$person->Email;
                    $dbpassword=$person->Password;
                    $dbaccess=$person->Access;
                }
                if($emaillogin == $dbemail && $passwordlogin == $dbpassword)
                {
                    $_SESSION['sess_email']=$emaillogin;
                    $_SESSION['logged']=true;
                    $_SESSION['access']=$dbaccess;
                    if($_SESSION['access']=="Admin")
                    {
                        header('Location:adminpanel.php');
                    }
                    else
                    {
                        header('Location: profile.php');
                    }
                }
           }
           else
           {
                $outcome="<p style=color:red>Invalid username and/or password!</p>"; 
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


	
	