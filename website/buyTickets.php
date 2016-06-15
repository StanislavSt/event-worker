<?php
session_start();
include 'php/buyticketredirect.php';
include 'php/register.php';
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
                       <?php if(!empty($outcome))
        {echo "<h3>$outcome</h3>";}
        ?>
					<form action="" method="post" class="form form--login"></br></br></br>
						<div class="form__field">
                                                    <input id="login__username" type="text" class="form__input" placeholder="Your first name*" name="fname" required>
						</div></br>
						<div class="form__field">
                                                    <input id="login__username" type="text" class="form__input" placeholder="Your last name*" name="lname" required>
						</div></br>
				<div class="form__field">
						<input id="login__username" disabled type="text" class="form__input" placeholder="Date of birth:*"> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						<select id="day" name="day" required>
							<option>1</option><option>2</option><option>3</option><option>4</option>
							<option>5</option><option>6</option><option>7</option><option>8</option>
							<option>9</option><option>10</option><option>11</option><option>12</option>
							<option>13</option><option>14</option><option>15</option><option>16</option>
							<option>17</option><option>18</option><option>19</option><option>20</option>
							<option>21</option><option>22</option><option>23</option><option>24</option>
							<option>25</option><option>26</option><option>27</option><option>28</option>
							<option>29</option><option>30</option><option>31</option></select>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						<select id="month" name="month" required>
                                                    <option value="1">January</option><option value="2">February</option><option value="3">March</option>
					<option value="4">April</option><option value="5">May</option><option value="6">June</option>
					<option value="7">July</option><option value="8">August</option><option value="9">September</option>
					<option value="10">October</option><option value="11">November</option><option value="12">December</option></select>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						<select id="year" name="year" required><option> 1920</option>
<option> 1921</option>
<option> 1922</option>
<option> 1923</option>
<option> 1924</option>
<option> 1925</option>
<option> 1926</option>
<option> 1927</option>
<option> 1928</option>
<option> 1929</option>
<option> 1930</option>
<option> 1931</option>
<option> 1932</option>
<option> 1933</option>
<option> 1934</option>
<option> 1935</option>
<option> 1936</option>
<option> 1937</option>
<option> 1938</option>
<option> 1939</option>
<option> 1940</option>
<option> 1941</option>
<option> 1942</option>
<option> 1943</option>
<option> 1944</option>
<option> 1945</option>
<option> 1946</option>
<option> 1947</option>
<option> 1948</option>
<option> 1949</option>
<option> 1950</option>
<option> 1951</option>
<option> 1952</option>
<option> 1953</option>
<option> 1954</option>
<option> 1955</option>
<option> 1956</option>
<option> 1957</option>
<option> 1958</option>
<option> 1959</option>
<option> 1960</option>
<option> 1961</option>
<option> 1962</option>
<option> 1963</option>
<option> 1964</option>
<option> 1965</option>
<option> 1966</option>
<option> 1967</option>
<option> 1968</option>
<option> 1969</option>
<option> 1970</option>
<option> 1971</option>
<option> 1972</option>
<option> 1973</option>
<option> 1974</option>
<option> 1975</option>
<option> 1976</option>
<option> 1977</option>
<option> 1978</option>
<option> 1979</option>
<option> 1980</option>
<option> 1981</option>
<option> 1982</option>
<option> 1983</option>
<option> 1984</option>
<option> 1985</option>
<option> 1986</option>
<option> 1987</option>
<option> 1988</option>
<option> 1989</option>
<option> 1990</option>
<option> 1991</option>
<option> 1992</option>
<option> 1993</option>
<option> 1994</option>
<option> 1995</option>
<option> 1996</option>
<option> 1997</option></select>
				</div></br>
						<div class="form__field">
                                                    <input id="login__username" type="text" class="form__input" placeholder="Your email*" name="email" required>
						</div></br>
						<div class="form__field">
                                                    <input id="login__password" type="password" class="form__input" placeholder="Your password*" name="password" required>
						</div></br>
						<div class="form__field">
                                                    <input id="login__password" type="password" class="form__input" placeholder="Comfirm your password*" name="repeatpassword" required>
						</div></br>
                                                <input id="buyticket" type="submit" name="btnreg" value="Buy a ticket">
					</form>
					
			</div>
				<p id="opcr" class="text--center">Open Core.inc 2015 </span></p>
			<div style='clear:both'></div>
</div>
</body>
</html>
