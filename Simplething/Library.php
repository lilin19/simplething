<?php

Class Msg{
	var $name;
	var $text;
	var $datel;

	function import() {
		$this->text=$_POST['text'];
		$this->name=Stream::GetIP();
		$this->datel= date("Y-m-d H:i:s");
	}


	/** this function output it self html table when the class is not empty  */
	function feedbackMSG(){
		echo $this->name,":",$this->text,$this->datel;
	}
	
	function printMSG(){
		echo "<p>",$this->name," ",$this->datel,":<br>",$this->text,"<p>","<br>";
	}
	
}

 Class Pool{
var $list = array(Msg::class);
	 function outdocu(){
		for($i=0;$i<count($this->list);$i++){
			$this->list[$i]->printMSG();
		}
	}
 function import(Msg $s){
		array_push($this->list, $s);
	}
}

Class Stream{
	function GetIP(){
		if(!empty($_SERVER["HTTP_CLIENT_IP"])){
			$cip = $_SERVER["HTTP_CLIENT_IP"];
		}
		elseif(!empty($_SERVER["HTTP_X_FORWARDED_FOR"])){
			$cip = $_SERVER["HTTP_X_FORWARDED_FOR"];
		}
		elseif(!empty($_SERVER["REMOTE_ADDR"])){
			$cip = $_SERVER["REMOTE_ADDR"];
		}
		else{
			$cip = "无法获取！";
		}
		return $cip;
	}
	
	
	function start(){
$sql = new mysqli('127.0.0.1', 'root', 'K3ymAAGMe47f','phpmyadmin');
if($sql->connect_errno!==0){
	echo $sql->connect_error;
}
$sql -> query("CREATE TABLE Data (Name STRING, )
		");
}
  


static function output(){
$pool = array();	
$a = new Msg();
	$sql = new mysqli('127.0.0.1', 'phpmyadmin','K3ymAAGMe47f','phpmyadmin');
	if($sql->connect_errno!==0){
		echo $sql->connect_error;
	}
	$result =$sql -> query("select * from Data order by Date desc limit 100;");
	if ($result->num_rows > 0) {
		while($row = $result->fetch_array()) {
			$a->name=$row["Name"];
			$a->text=$row["Text"];
			$a->datel=$row["Date"];

			array_push($pool, $a);
			$a=new Msg();
		}
}
return  $pool;
}

static function input(Msg $s){
	$sql = new mysqli('127.0.0.1', 'phpmyadmin','K3ymAAGMe47f','phpmyadmin');
	if($sql->connect_errno!==0){
		echo $sql->connect_error;
	}
	$sql -> query("INSERT INTO `phpmyadmin`.`Data` (`Name`, `Text`, `Date`) VALUES ('$s->name', '$s->text', '$s->datel');");
	$sql->close();
	
}



}



Class View{
function Viewout(){
$f=Stream::output();
for($i=0;$i<count($f);$i++){
	$f[$i]->printMSG();
}
}
}
?>