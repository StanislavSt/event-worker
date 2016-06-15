<?php
session_start();
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
		<link rel="stylesheet" type="text/css" href="css/faq.css"/>
		<meta charset="utf-8">
  <link rel="stylesheet" href="//code.jquery.com/ui/1.11.4/themes/smoothness/jquery-ui.css">
		<script type="text/javascript" src="js/about.js"></script>
	</head>
	<body>
		<div id="center_box">
			<div class="dock" id="dock">
			<div class="dock-container">
                            <a id="menu" class="dock-item" href="eventInfo.php"><img src="images/info.png" alt="home" /><span>Event info</span></a> 
                            <a id="menu" class="dock-item" href="login.php"><img src="<?php echo $source;  ?>" alt="contact" /><span><?php echo $text; ?></span></a> 
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
			</script></br></br></br></br></br></br></br></br></br>
<div id="text">
				<div id="scrollbar">
					<font size="4">
						<a href="#"><div id="menu1" ><b>What is the capacity of the festival?</b></div></a>
						<div id="sub1">
							We limited ticket sales to 18,000 with a goal to make our festival experience convenient and comfortable.</br>
							We aim to provide easy access to the grounds, facilities, easy to see the show and easy to move around.
						</div>
						<a href="#"><div id="menu2"><b>When and where is the festival?</b></div></a>
						<div id="sub2">
							International Music Festival (IMF) is a two-day dance music festival held in Eindhoven, The Netherlands.
						</div>
                		<a href="#"><div id="menu3"><b>Is the event 18+ only ?</b></div></a>
						<div id="sub3">
                			Yes. You must be at least 18 years of age to attend.
						</div>
                		<a href="#"><div id="menu4"><b>What is allowed ?(ALL ITEMS SUBJECT TO INSPECTION, PRIOR TO ENTRY, AT VENUE GATES)</b></div></a>
						<div id="sub4">
                			-Non framed backpacks .(they will be subject to inspection at venue gates)</br>
-Small purses .(they will be subject to inspection at venue gates) </br>
-1 sealed bottle of water, 1L or less.</br>
-Foldable “bag chairs” are allowed entry until 6:30pm .</br>
						</div>
                		<a href="#"><div id="menu5"><b>Are there items I'm not allowed to bring to the festival?</b></div></a>
						<div id="sub5">
                			There are certain items that are NOT permitted and cannot be brought onto the Festival grounds.</br> OpenCore reserves the right to alter carry-in policies at any time.</br> Currently, items NOT permitted include, but are not limited to:</br>
-Coolers</br>
-Framed Backpacks</br>
-Large bags</br>
-Other carry-ins</br>
-Umbrellas</br>
-Outside food or beverages</br>
-Outside Cans or glass bottles</br>
-Alcohol</br>
-Contraband</br>
-Pets</br>
-Video equipment</br>
-Professional cameras</br>
-Recording devices</br>
-Laser pointers</br>
-Skateboards</br>
-Inline skates</br>
-Coaster wagons</br>
-Kites</br>
-Frisbees</br>
-Picnic baskets</br>
-Weapons of any kind</br>
						</div>
					</font>
				</div>
			
		</div>
			</div>
			<div style='clear:both'></div>
	</body>
</html>
	
	
	
	
	
	
	
	
	
	
	
	