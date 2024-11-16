DROP DATABASE IF EXISTS shop;
CREATE DATABASE shop;
USE shop;

DROP TABLE IF EXISTS `user`;

CREATE TABLE `user`(
`id` INTEGER PRIMARY KEY AUTO_INCREMENT,
`name` VARCHAR(50) NOT NULL,
`login`  VARCHAR(50) NOT NULL,
`password`  VARCHAR(32) NOT NULL
);

DROP TABLE IF EXISTS `category`;

CREATE TABLE category(
id INTEGER PRIMARY KEY AUTO_INCREMENT,
`name` VARCHAR(50) NOT NULL
);

DROP TABLE IF EXISTS `product`;

CREATE TABLE `product`(
`id` INTEGER PRIMARY KEY AUTO_INCREMENT,
`name` TEXT NOT NULL,
category_id INTEGER,
price INTEGER NOT NULL,
FOREIGN KEY(category_id) REFERENCES category(id)
);

DROP TABLE IF EXISTS `feedback`;

CREATE TABLE `feedback`(
`id` INTEGER PRIMARY KEY AUTO_INCREMENT,
user_id INTEGER,
product_id INTEGER,
feedback_text TEXT NOT NULL,
FOREIGN KEY(product_id) REFERENCES product(id) ON DELETE CASCADE,
FOREIGN KEY(user_id) REFERENCES user(id)
);

DROP TABLE IF EXISTS `order`;

CREATE TABLE `order`(
`id` INTEGER PRIMARY KEY AUTO_INCREMENT,
user_id INTEGER,
`date` TIMESTAMP,
FOREIGN KEY(user_id) REFERENCES user(id)
);

DROP TABLE IF EXISTS `order_info`;

CREATE TABLE `order_info`(
`product_id` INTEGER NOT NULL,
`order_id` INTEGER NOT NULL,

FOREIGN KEY(product_id) REFERENCES product(id),
FOREIGN KEY(order_id) REFERENCES `order`(id) ON DELETE CASCADE
); 


INSERT INTO category(`name`) VALUES ("Board Games");
INSERT INTO category(`name`) VALUES ("Books");

INSERT INTO `product` (`name`,category_id,price) VALUES ('3 player Chess',1,1000);
INSERT INTO `product` (`name`,category_id,price) VALUES ('The Adventures of Josef Sveik',2,200);
