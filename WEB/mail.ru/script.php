<?php
/**
 * Created by PhpStorm.
 * User: pavel
 * Date: 25-Jun-16
 * Time: 11:19
 */


$link=mysqli_connect('localhost:3306', 'root', '', 'users');


if(!isset($_GET['name'])) return;

$name = $_GET['name'];
$result = mysqli_query($link, "SELECT id, name FROM UsersTable WHERE name='$name'");

while($row = mysqli_fetch_assoc($result)){
    echo $row['id']."</br>";
}

?>