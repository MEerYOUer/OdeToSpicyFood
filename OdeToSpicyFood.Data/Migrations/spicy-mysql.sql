CREATE TABLE IF NOT EXISTS `__EFMigrationsHistory` (
    `MigrationId` varchar(95) NOT NULL,
    `ProductVersion` varchar(32) NOT NULL,
    CONSTRAINT `PK___EFMigrationsHistory` PRIMARY KEY (`MigrationId`)
);

CREATE TABLE `Restaurants` (
    `Id` int NOT NULL,
    `Name` nvarchar(1000) NOT NULL,
    `Location` nvarchar(1000) NOT NULL,
    `Rating` float NOT NULL,
    `Cuisine` int NOT NULL,
    CONSTRAINT `PK_Restaurants` PRIMARY KEY (`Id`)
);

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20191212014039_initialcreate', '3.1.0');

ALTER TABLE `Restaurants` DROP COLUMN `Location`;

ALTER TABLE `Restaurants` ADD `City` nvarchar(1000) NOT NULL DEFAULT '';

ALTER TABLE `Restaurants` ADD `Country` nvarchar(1000) NOT NULL DEFAULT '';

ALTER TABLE `Restaurants` ADD `State` nvarchar(1000) NOT NULL DEFAULT '';

ALTER TABLE `Restaurants` ADD `Street` nvarchar(1000) NOT NULL DEFAULT '';

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20191223171210_paramchange', '3.1.0');

ALTER TABLE `Restaurants` DROP COLUMN `Country`;

ALTER TABLE `Restaurants` ADD `Zip` int NOT NULL DEFAULT 0;

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20191223172551_locationchange', '3.1.0');

ALTER TABLE `Restaurants` MODIFY COLUMN `Street` longtext CHARACTER SET utf8mb4 NOT NULL;

ALTER TABLE `Restaurants` MODIFY COLUMN `State` longtext CHARACTER SET utf8mb4 NOT NULL;

ALTER TABLE `Restaurants` MODIFY COLUMN `Rating` double NOT NULL;

ALTER TABLE `Restaurants` MODIFY COLUMN `Name` longtext CHARACTER SET utf8mb4 NOT NULL;

ALTER TABLE `Restaurants` MODIFY COLUMN `City` longtext CHARACTER SET utf8mb4 NOT NULL;

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20200104011138_initialMySql', '3.1.0');
