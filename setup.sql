CREATE DATABASE dbCRM;

USE dbCRM;

CREATE TABLE user (
	id BIGINT NOT NULL AUTO_INCREMENT,
    name VARCHAR(200),
    email VARCHAR(255),
    phone VARCHAR(15),
    password VARCHAR(300),
    password_salt text,
    photo VARCHAR(100),
    status bit,
    PRIMARY KEY (id)
);

CREATE TABLE log (
	id BIGINT NOT NULL AUTO_INCREMENT,
    tableLog VARCHAR(100),
    type VARCHAR(50),
    data TEXT,
    idUser BIGINT,
    PRIMARY KEY (id),
    FOREIGN KEY (idUser) REFERENCES user(id)
);

CREATE TABLE project (
	id BIGINT NOT NULL AUTO_INCREMENT,
    name VARCHAR(200),
    description VARCHAR(500),
    photo VARCHAR(100),
    createdAt DATE,
    status bit,
    idUserOwner BIGINT,
    PRIMARY KEY (id),
    FOREIGN KEY (idUserOwner) REFERENCES user(id)
);

CREATE TABLE projectAcess (
	id BIGINT NOT NULL AUTO_INCREMENT,
    userType TINYINT(1),
    idProject BIGINT,
    idUser BIGINT,
    PRIMARY KEY (id),
    FOREIGN KEY (idProject) REFERENCES project(id),
    FOREIGN KEY (idUser) REFERENCES user(id)
);

CREATE TABLE projectData (
    id BIGINT NOT NULL AUTO_INCREMENT,
    revenue DOUBLE,
    numberOfClients INT,
    projectName VARCHAR(200),
    idProject BIGINT,
    PRIMARY KEY (id),
    FOREIGN KEY (idProject) REFERENCES project (id),
    INDEX (projectName)
);

CREATE TABLE client (
	id BIGINT NOT NULL AUTO_INCREMENT,
    name VARCHAR(200),
    email VARCHAR(255),
    phone VARCHAR(15),
    document varchar(18),
    idProject BIGINT,
    status tinyint(1),
    PRIMARY KEY (id),
    FOREIGN KEY (idProject) REFERENCES project(id)
);

CREATE TABLE mailTemplate (
	id BIGINT NOT NULL AUTO_INCREMENT,
    title VARCHAR(100),
    data TEXT,
    status bit,
    PRIMARY KEY (id)
);

CREATE TABLE mail (
	id BIGINT NOT NULL AUTO_INCREMENT,
    body TEXT,
    idMailTemplate BIGINT,
    PRIMARY KEY (id),
    FOREIGN KEY (idMailTemplate) REFERENCES mailTemplate(id)
);

CREATE TABLE mailMarketingList (
	id BIGINT NOT NULL AUTO_INCREMENT,
    listName VARCHAR(150),
    status bit,
    idProject BIGINT,
    idMail BIGINT,
    PRIMARY KEY (id),
    FOREIGN KEY (idProject) REFERENCES project(id),
    FOREIGN KEY (idMail) REFERENCES mail(id)
);

CREATE TABLE statusMail (
	id BIGINT NOT NULL AUTO_INCREMENT,
    sendStatus TINYINT(1),
    idMail BIGINT,
    PRIMARY KEY (id),
    FOREIGN KEY (idMail) REFERENCES mail(id)
);

CREATE TABLE formTemplate (
	id BIGINT NOT NULL AUTO_INCREMENT,
    data TEXT,
    status BIT,
    idMailMarketingList BIGINT,
    PRIMARY KEY (id),
    FOREIGN KEY (idMailMarketingList) REFERENCES mailMarketingList(id)
);
    