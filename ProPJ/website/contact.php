<?php
session_start();
include 'php/ContactSend.php';
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
	<link href="css/contact.css" rel="stylesheet" type="text/css" />
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
			</script></br></br></br></br></br></br>
		<div class="grid__container">
			<form action="" method="post" class="form form--login"></br></br>
                    <?php
                                                  if(!empty($success))
                                                  {
                                                  echo $success;
                                                   }
                                        ?>
                            </br>
						<div class="form__field">
							<input id="login__username" type="text" class="form__input" name="name" placeholder="Your name*" required>
						</div></br>
						<div class="form__field">
							<input id="login__username" type="text" class="form__input" name="email" placeholder="Your email*" required>
						</div></br>
						<div class="form__field">
                                                    <input id="login__username" type="text" class="form__input" name="subject" placeholder="Subject*" required>
						</div></br>
						<div class="form__field">
							<textarea id="message"  class="form__input" name="message" cols="35" rows="7" placeholder="Your message*" required></textarea>
						</div></br>
						
                                                <input id="sendamessage" name="submit" type="submit" value="Send a message">
					</form>
					<p id="opcr" class="text--center">Open Core.inc 2015 </span></p>
			</div>
</div>
				
			<div style='clear:both'></div>
	</body>
</html>