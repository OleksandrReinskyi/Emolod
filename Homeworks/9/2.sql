
DROP SCHEMA IF EXISTS Blog;
CREATE SCHEMA Blog;
USE Blog;



CREATE TABLE category(
category_id int NOT NULL AUTO_INCREMENT,
name varchar(255),

PRIMARY KEY(category_id)
);

CREATE TABLE user(
user_id int AUTO_INCREMENT,
name varchar(255) UNIQUE NOT NULL,
password varchar(32) NOT NULL,
email varchar(255) NOT NULL, 


PRIMARY KEY(user_id)
);

CREATE TABLE post(
post_id int AUTO_INCREMENT,
user_id int NOT NULL,
category_id int NOT NULL,

content TEXT NOT NULL,
likes int DEFAULT 0,
dislikes int DEFAULT 0,
create_date TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,

FOREIGN KEY(user_id) REFERENCES user(user_id),
FOREIGN KEY(category_id) REFERENCES category(category_id),
PRIMARY KEY(post_id)
);

CREATE TABLE comment(
comment_id int AUTO_INCREMENT,
post_id int NOT NULL,
user_id int NOT NULL,

content TEXT NOT NULL,
likes int DEFAULT 0,
dislikes int DEFAULT 0,
create_date TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,

PRIMARY KEY(comment_id),
FOREIGN KEY(post_id) REFERENCES post(post_id),
FOREIGN KEY(user_id) REFERENCES user(user_id)
);

INSERT INTO category(name) VALUES ("shitpost");
INSERT INTO user(name,password,email) VALUES ("Karl Marx","proletariansUnited","karlmarx@gmail.com");
INSERT INTO post(content,user_id, category_id) VALUES ("capital", (SELECT user_id FROM user WHERE name="Karl Marx"),(SELECT category_id FROM category WHERE name="shitpost"));

