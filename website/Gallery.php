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
        <script type="text/javascript" src="js/gallery.js"></script>
        <script type="text/javascript" src="js/gallery.config.js" charset="utf-8"></script>
	<link href="css/login.css" rel="stylesheet" type="text/css" />
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
		<div class="grid__container">
                    <div id="pictures">
                   <a href="images/gallery/large/1.jpg" class="gallery" onclick="return hs.expand(this, config1 )">
                   <img id="small_img" src="images/gallery/thumbs/1.jpg">
                </a>
                <a href="images/gallery/large/2.jpg" class="gallery" onclick="return hs.expand(this, config1 )">
                    <img id="small_img" src="images/gallery/thumbs/2.jpg">
                </a>
                <a href="images/gallery/large/3.jpg" class="gallery" onclick="return hs.expand(this, config1 )">
                    <img id="small_img" src="images/gallery/thumbs/3.jpg">
                </a>
                <a href="images/gallery/large/4.jpg" class="gallery" onclick="return hs.expand(this, config1 )">
                    <img id="small_img" src="images/gallery/thumbs/4.jpg">
                </a>
                <a href="images/gallery/large/5.jpg" class="gallery" onclick="return hs.expand(this, config1 )">
                    <img id="small_img" src="images/gallery/thumbs/5.jpg">
                </a>
                <a href="images/gallery/large/6.jpg" class="gallery" onclick="return hs.expand(this, config1 )">
                    <img id="small_img" src="images/gallery/thumbs/6.jpg">
                </a>
                <a href="images/gallery/large/7.jpg" class="gallery" onclick="return hs.expand(this, config1 )">
                    <img id="small_img" src="images/gallery/thumbs/7.jpg">
                </a>
                <a href="images/gallery/large/8.jpg" class="gallery" onclick="return hs.expand(this, config1 )">
                    <img id="small_img" src="images/gallery/thumbs/8.jpg">
                </a>
                <a href="images/gallery/large/9.jpg" class="gallery" onclick="return hs.expand(this, config1 )">
                    <img id="small_img" src="images/gallery/thumbs/9.jpg">
                </a>
                <a href="images/gallery/large/10.jpg" class="gallery" onclick="return hs.expand(this, config1 )">
                    <img id="small_img" src="images/gallery/thumbs/10.jpg">
                </a>
                <a href="images/gallery/large/11.jpg" class="gallery" onclick="return hs.expand(this, config1 )">
                    <img id="small_img" src="images/gallery/thumbs/11.jpg">
                </a>
                <a href="images/gallery/large/13.jpg" class="gallery" onclick="return hs.expand(this, config1 )">
                    <img id="small_img" src="images/gallery/thumbs/13.jpg">
                </a>
                <a href="images/gallery/large/14.jpg" class="gallery" onclick="return hs.expand(this, config1 )">
                    <img id="small_img" src="images/gallery/thumbs/14.jpg">
                </a>
                <a href="images/gallery/large/15.jpg" class="gallery" onclick="return hs.expand(this, config1 )">
                    <img id="small_img" src="images/gallery/thumbs/15.jpg">
                </a>
                <a href="images/gallery/large/16.jpg" class="gallery" onclick="return hs.expand(this, config1 )">
                    <img id="small_img" src="images/gallery/thumbs/16.jpg">
                </a>
                <a href="images/gallery/large/17.jpg" class="gallery" onclick="return hs.expand(this, config1 )">
                    <img id="small_img" src="images/gallery/thumbs/17.jpg">
                </a>
                <a href="images/gallery/large/18.jpg" class="gallery" onclick="return hs.expand(this, config1 )">
                    <img id="small_img" src="images/gallery/thumbs/18.jpg">
                </a>
                <a href="images/gallery/large/19.jpg" class="gallery" onclick="return hs.expand(this, config1 )">
                    <img id="small_img" src="images/gallery/thumbs/19.jpg">
                </a>
                        <a href="images/gallery/large/20.jpg" class="gallery" onclick="return hs.expand(this, config1 )">
                            <img id="small_img" src="images/gallery/thumbs/20.jpg">
                </a>
                        <a href="images/gallery/large/21.jpg" class="gallery" onclick="return hs.expand(this, config1 )">
                            <img id="small_img" src="images/gallery/thumbs/21.jpg">
                </a>
					</a></div>
                    <p id="opcr" class="text--center">Open Core.inc 2015 </span></p>
                </div>
                </div>
				
			<div style='clear:both'></div>
	</body>
</html>