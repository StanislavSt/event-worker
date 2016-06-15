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
	<link href="css/eventInfo.css" rel="stylesheet" type="text/css" />
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
		<div id="festmap"><img src="gallery/map.jpg" width="800" height="500"  alt="some_text"></div>
</div>
				
			<div style='clear:both'></div>
	</body>
</html>






