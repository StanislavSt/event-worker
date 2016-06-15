<?php
session_start();
include 'php/tentredirect.php';
include 'php/finishtent.php';
if(isset($_POST['bookatent']))
{
if($_POST['bookatent']!= "Book a tent")
{
    include 'php/nrpeople.php';
}
}
include 'php/bookatent.php';

if(isset($_SESSION['sess_email']))
{
    $source="images/profile.png";
    $texte="Profile";
}
else
{
    $source="images/login.png";
    $texte="Log in";
}
?>
<html>
<head>
	<script type="text/javascript" src="js/jquery.js"></script>
	<script type="text/javascript" src="js/interface.js"></script>
	<link href="css/tent.css" rel="stylesheet" type="text/css" />
</head>
	<body>

		<div id="center_box">
		<div class="dock" id="dock">
			<div class="dock-container">
                            <a id="menu" class="dock-item" href="eventInfo.php"><img src="images/info.png" alt="home" /><span>Event info</span></a> 
                            <a id="menu" class="dock-item" href="login.php"><img src="<?php echo $source;  ?>" alt="contact" /><span><?php echo $texte; ?></span></a> 
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
						<img id="tentarea" src="gallery/tent.jpg" /></br></br>
						<div class="form__field">
						<input id="login__username" disabled type="text" class="form__input" placeholder="Tent area:*">
						<select id="area" name="tentarea" required>
							<?php echo $options;?></select>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                <input id="login__username" disabled type="text" class="form__input" placeholder="Number of people:*"> 
						<select id="nrofpeople" name="nrofpeople" required>
                                                    <option>1</option> <option>2</option> <option>3</option> <option>4</option> <option>5</option> <option>6</option></select>
                                                </div></br>
                                <?php
                                if(!empty($boxes))
                                    {echo $boxes;}
                                    if(!empty($errormsg))
                                    { echo $errormsg;}
                                    if(!empty($warning) && empty($errormsg))
                                    {echo $warning;}
                                    ?>
                                
                                <input id="bookatent" type="submit" name="bookatent" value="<?php if(!empty($text)){ echo $text;}  else {
    
                                {
                                    echo "Proceed";
                                }}?>">
					</form>
			</div>
				<p id="opcr" class="text--center">Open Core.inc 2015 </span></p>
			<div style='clear:both'></div>
                       
</body>
</html>
