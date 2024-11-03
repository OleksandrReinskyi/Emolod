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
FOREIGN KEY(product_id) REFERENCES product(id),
FOREIGN KEY(user_id) REFERENCES user(id)
);

DROP TABLE IF EXISTS `order`;

CREATE TABLE `order`(
`id` INTEGER PRIMARY KEY AUTO_INCREMENT,
user_id INTEGER,
product_id INTEGER,
`date` TIMESTAMP,
FOREIGN KEY(user_id) REFERENCES user(id),
FOREIGN KEY(product_id) REFERENCES product(id)
);
