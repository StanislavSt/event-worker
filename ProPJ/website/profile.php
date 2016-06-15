<?php

session_start();
include 'php/profileredirect.php';
include 'php/profiledetails.php';
if(!isset($_SESSION['hastent']))
                                                        {$bookatent='<a id="booktent" href="tent.php"><label>Do not have a tent? Book here!</label></a>';}
                                                     else {$bookatent='';}
if(isset($_SESSION['sess_email']))
{
    $source="images/profile.png";
    $text="Profile";
}
else
{
    $source="images/login.png";
    $text="Log in";
}
?>
<!DOCTYPE html> 
<html>
<head>
	<script type="text/javascript" src="js/jquery.js"></script>
	<script type="text/javascript" src="js/interface.js"></script>
	<link href="css/profil.css" rel="stylesheet" type="text/css" />
</head>
	<body>
		<div id="center_box">
			<div class="dock" id="dock">
			<div class="dock-container">
                            <a id="menu" class="dock-item" href="eventInfo.php"><img src="images/info.png" alt="home" /><span>Event info</span></a> 
                            <a id="menu" class="dock-item" href="login.php"><img src="<?php echo $source;  ?>" alt="contact" /><span>Profile</span></a> 
                            <a id="menu" id="menu" class="dock-item" href="buyTickets.php"><img src="images/tickets.png" alt="portfolio" /><span>Tickets</span></a> 
                            <a id="menu" class="dock-item" href="festMap.php"><img src="images/location.png" alt="music" /><span>Fest Map</span></a>
				<a id="menu" class="dock-item" href="gallery.php"><img src="images/gallery.png" alt="history" /><span>Gallery</span></a> 
                                <a id="menu" class="dock-item" href="location.php"><img src="images/direcion.png" alt="calendar" /><span>Location</span></a> 
                                <a id="menu" class="dock-item" href="faq.php"><img src="images/FAQ.png" alt="rss" /><span>FAQ</span></a> 
                                <a id="menu" class="dock-item" href="contact.php"><img src="images/contact.png" alt="rss" /><span>Contact</span></a> 
			</div>
		</div>
			<script type="text/javascript">
				$(document).ready(
					function()
					{
						$('#dock').Fisheye(
							{
								maxWidth: 70,
								items: 'a',
								itemsText: 'span',
								container: '.dock-container',
								itemWidth: 90,
								proximity: 200,
								halign : 'center'
							}
						)
					}
				);
			</script></br></br></br></br></br></br>
		<div class="grid__container">
			<form action="php/logout.php" method="post" class="form form--login"></br></br></br>
						<div class="form__field">
                                                        <input id="login__username" type="text" class="form__input" name="fullname" value="Name: <?php if(!empty($fullname)){echo $fullname;}?>" disabled>
						</div></br>
                                                <div class="form__field">
                                                        <input id="login__username" type="text" class="form__input" name="ticketid" value="Ticket ID: <?php if(!empty($ticketid)){echo $ticketid;}?>" disabled>
						</div></br>
						<div class="form__field">
							<input id="login__username" type="text" class="form__input" name="email" value="Email: <?php if(!empty($emailprofile)){echo $emailprofile;}?>" disabled>
						</div></br>
						<div class="form__field">
							<input id="login__username" type="text" class="form__input" name="dateofbirth" value="Date of Birth: <?php if(!empty($dob)){echo $dob;}?>" disabled>
						</div></br>
						<div class="form__field">
							<input id="login__username" type="text" class="form__input" name="dateofreg" value="Date of Registration: <?php if(!empty($dateofregp)){echo $dateofregp;}?>" disabled>
						</div></br>
						<div class="form__field">
							<input id="login__username" type="text" class="form__input" name="tentarea" value="Tent area: <?php if(!empty($tentareadisplay)){echo $tentareadisplay;}?>" disabled>
						</div></br>
						<div class="form__field">
							<input id="login__username" type="text" class="form__input" name="tentid" value="Tent ID: <?php if(!empty($tentiddisplay)){echo $tentiddisplay;}?> " disabled>
						</div></br>
						<div class="form__field">
							<input id="login__username" type="text" class="form__input" name="nrofplaces" value="Number of places booked: <?php if(!empty($nrbooked)){echo $nrbooked;}?>" disabled>
						</div></br>
                                                    <?php echo $bookatent;
                                                        ?>
                                                </br></br>
                                                <a href="php/logout.php"><input id="log-out" type="submit" value="Logout"></a>
					</form>
					<p id="opcr" class="text--center">Open Core.inc 2015 </span></p>
				
			</div>
</div>
</div>
				
			<div style='clear:both'></div>
	</body>
</html>0886599663