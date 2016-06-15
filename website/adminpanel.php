<?php
session_start();
include 'php/adminredirect.php';
include 'php/adminpanelfill.php';
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
<html>
<head>
	<script type="text/javascript" src="js/jquery.js"></script>
	<script type="text/javascript" src="js/interface.js"></script>
	<link href="css/buyTickets.css" rel="stylesheet" type="text/css" />
</head>
	<body>

		<div id="center_box">
		<div class="dock" id="dock">
				<div class="dock-container">
                            <a id="menu" class="dock-item" href="eventInfo.php"><img src="images/info.png" alt="home" /><span>Event info</span></a> 
                            <a id="menu" class="dock-item" href="login.php"><img src="images/login.png" alt="contact" /><span>Profile</span></a> 
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
					<form action="" method="post" class="form form--login"></br></br></br>
						<div class="form__field">
                                                    <input id="login__username" type="text" class="form__input" placeholder="All registered people: <?php echo $nrofppl;?>" name="regpeople" disabled>
						</div></br>
						<div class="form__field">
                                                    <input id="login__username" type="text" class="form__input" placeholder="Number of people with rented tent: <?php echo $nrofpplintent;?>" name="rentedtent" disabled>
						</div></br>
                                                <input id="tentareabtn" type="submit" name="area1" value="Tent area 1">
                                                <input id="tentareabtn" type="submit" name="area2" value="Tent area 2">
                                                <input id="tentareabtn" type="submit" name="area3" value="Tent area 3"></br>
                                        </br>
                                        
  <?php if(!empty($tablestructure)){echo '<div id="scrollbar">
					<table id="t01">'.$tablestructure.'</table></div>';}?>
                                        </br></br></form>
                    <form action="php/logout.php" method="post" class="form form--login">
                                                <input id="logout" type="submit" name="logout" value="LOG OUT">
                                                </form>
			</div>
                        
				<p id="opcr" class="text--center">Open Core.inc 2015 </span></p>
			<div style='clear:both'></div>
</div>
</body>
</html>
