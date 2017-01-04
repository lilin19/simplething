<?php
echo "hello";
$time= date('Y-m-d H:i:s',time());
	$sql = new mysqli('127.0.0.1', 'phpmyadmin','K3ymAAGMe47f','phpmyadmin');
	if($sql->connect_errno!==0){
		echo $sql->connect_error;
	}
	$result =$sql -> query("INSERT INTO `phpmyadmin`.`Data` (`Name`, `Text`, `Date`) VALUES ('test', '333', '$time');");
	$pool = array();
	$result =$sql -> query("select * from Data limit 100;");
	if ($result->num_rows > 0) {
		while($row = $result->fetch_array()) {
			$a->name=$row["Name"];
			$a->text=$row["Text"];
			$a->date=$row["Date"];
	
			array_push($pool, $a);
			$a=new Msg();
		}
	}
	?>