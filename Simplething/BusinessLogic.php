<?php
include 'Library.php';
$msg = new Msg();
$msg->import();

Stream::input($msg);
$lake = Stream::output();
for($i=0;$i<count($lake);$i++){
	$lake[$i]->printMSG();
}






