<?php
include 'Library.php';
$time= date("Y-m-d H:i:s");
echo "<h4><span class='label label-primary'>",$time,"</span></h4>";
$lake = Stream::output();
for($i=0;$i<count($lake);$i++){
	$lake[$i]->printMSG();
}

if($_POST['tail']=='input')
{
$msg = new Msg();
$msg->import(); 
Stream::input($msg);
}
