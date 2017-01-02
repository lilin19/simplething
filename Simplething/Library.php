<?php
Class Msg{
	var $name;
	var $text;
	var $date;

	function import() {
		$this->text=$_POST['text'];
		$this->name=$_POST['name'];
	}


	/** this function output it self html table when the class is not empty  */
	function feedbackMSG(){
		echo $this->name,":",$this->text;
	}
	
	function printMSG(){
		echo "<p>",$this->name,"<br>",$this->text,"<p>","<br>";
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
	function start(){
$sql = new mysqli('127.0.0.1', 'root', '','mysql');
if($sql->connect_errno!==0){
	echo $sql->connect_errno;
}
$sql -> query("CREATE TABLE Data (Name STRING, )
		");
}
  


static function output(){
$pool = array();	
$a = new Msg();
	$sql = new mysqli('127.0.0.1', 'root', '','mysql');
	if($sql->connect_errno!==0){
		echo $sql->connect_errno;
	}
	$result =$sql -> query("select * from Data;");
	if ($result->num_rows > 0) {
		while($row = $result->fetch_array()) {
			$a->name=$row["Name"];
			$a->text=$row["Text"];
			$a->date=$row["Date"];

			array_push($pool, $a);
			$a=new Msg();
		}
}
return  $pool;
}

static function input(Msg $s){
	$a = new Msg();
	$sql = new mysqli('127.0.0.1', 'root', '','mysql');
	if($sql->connect_errno!==0){
		echo $sql->connect_errno;
	}
	$result =$sql -> query("insert into Data values ('$s->name','$s->text','$s->date');");
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