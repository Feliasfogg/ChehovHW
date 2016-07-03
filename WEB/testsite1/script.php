<?php
/**
 * Created by PhpStorm.
 * User: pavel
 * Date: 18-Jun-16
 * Time: 11:31
 */
$digit = 0;
if(isset($_GET['q'])){
    $digit = $_GET['q'];
    $digit = $digit*$digit;
}
echo $digit;


?>