<?php
if(isset($_POST['nrofpeople']))
{
if(!empty($_POST['nrofpeople']))
{$text="Book a tent";
$boxes="";
$nrofboxes=$_POST['nrofpeople'];
for($i=0;$i<$nrofboxes;$i++)
{   $name="email".$i;
$placeholder="Your email*";
    $boxes=$boxes.' <div class="form__field">
                                                    <input id="login__username" type="text" class="form__input" placeholder="'.$placeholder.'" name="'.$name.'" required>
						</div></br>';
    
}
}
}



