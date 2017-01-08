<?php
include 'Library.php';
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
