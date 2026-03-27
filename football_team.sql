CREATE DATABASE football_team;
USE football_team;
CREATE TABLE teams (
id INT PRIMARY KEY AUTO_INCREMENT,
team_name VARCHAR(100)
);
CREATE TABLE coaches (
id INT PRIMARY KEY AUTO_INCREMENT,
coach_name VARCHAR(100),
team_id INT UNIQUE,
FOREIGN KEY (team_id) REFERENCES
teams(id)
);
CREATE TABLE players (
id INT PRIMARY KEY AUTO_INCREMENT,
player_name VARCHAR(100),
position VARCHAR(50),
team_id INT,
FOREIGN KEY (team_id) REFERENCES
teams(id)
);
insert into teams (team_name) VALUES
('Динамо-Минск'),
('Крумкачы'),
('Ислочь');
insert coaches (coach_name, team_id) values
('Шагойко', 1),
('Бушма', 2),
('Комаровский', 3);
insert into players (player_name, position, team_id) values
('Хващинский', 'Нападающий', 1),
('Зыгмантович','Вратарь', 2),
('Валиев','Защитник', 3);

select * from teams;
select * from coaches;
select * from players;


