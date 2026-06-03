CREATE DATABASE BDASPB;


create table if not exists user_table(
	user_id SERIAL PRIMARY KEY,
    user_name VARCHAR(40) NOT NULL,
    user_email VARCHAR(100) UNIQUE,
    user_password VARCHAR(250) NOT NULL,
    user_acess_level VARCHAR(40) DEFAULT 'default_user_level',
    user_timestamp timestamp DEFAULT now()
);

INSERT INTO user_table (user_name, user_email, user_password) 
VALUES ('Maru', 'email@email.com', '1234');