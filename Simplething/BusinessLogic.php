<?php

include 'Library.php';


$msg = new Msg();
$msg->import();
$msg->feedbackMSG();
Stream::input($msg);
$lake = Stream::output();
for($i=0;$i<count($lake);$i++){
	$lake[$i]->printMSG();
}






