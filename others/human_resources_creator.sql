CREATE TABLE `roles`(
	`id` INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
    `name` VARCHAR(40) NOT NULL,
    CONSTRAINT `uniq_name` unique(`name`)
);

CREATE TABLE `types_of_phone`(
	`id` INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
    `name` VARCHAR(40) NOT NULL,
    CONSTRAINT `uniq_name` unique(`name`)
);

CREATE TABLE `types_of_sessions`(
	`id` INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
    `name` VARCHAR(40) NOT NULL,
    CONSTRAINT `uniq_name` unique(`name`)
);

CREATE TABLE `countries`(
	`id` INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
    `name` VARCHAR(40) NOT NULL,
    CONSTRAINT `uniq_name` unique(`name`)
);

CREATE TABLE `regions`(
	`id` INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
    `name` VARCHAR(40) NOT NULL,
    `country_id` INT NOT NULL,
    CONSTRAINT `region_to_countries`
    FOREIGN KEY (`country_id`) REFERENCES `countries`(`id`) ON DELETE CASCADE,
    CONSTRAINT `uniq_name` unique(`name`)
);

CREATE TABLE `areas`(
	`id` INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
    `name` VARCHAR(40) NULL,
    `region_id` INT NOT NULL,
    CONSTRAINT `areas_to_regions`
    FOREIGN KEY (`region_id`) REFERENCES `regions`(`id`) ON DELETE CASCADE
);

CREATE TABLE `cities`(
	`id` INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
    `name` VARCHAR(40) NOT NULL,
    `area_id` INT NOT NULL,
    CONSTRAINT `cities_to_areas`
    FOREIGN KEY (`area_id`) REFERENCES `areas`(`id`) ON DELETE CASCADE,
    constraint `uniq_name` UNIQUE(`name`)
);

CREATE TABLE `streets`(
	`id` INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
    `name` VARCHAR(40) NOT NULL,
    constraint `uniq_name` UNIQUE(`name`)
);

CREATE TABLE `cities_streets`(
	`id` INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
    `city_id` INT NOT NULL,
    `street_id` INT NOT NULL,
    CONSTRAINT `cities_streets_to_cities`
    FOREIGN KEY (`city_id`) REFERENCES `cities`(`id`) ON DELETE CASCADE,
    CONSTRAINT `cities_streets_to_streets`
    FOREIGN KEY (`street_id`) REFERENCES `streets`(`id`) ON DELETE CASCADE
);

CREATE TABLE `addresses`(
	`id` INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
    `city_street_id` INT NOT NULL,
    `home_number` INT NOT NULL,
    `corpus` VARCHAR(3) NULL,
    `entrance` VARCHAR(3) NULL,
    `apartment` INT NOT NULL,
    CONSTRAINT `address_to_cities_streets`
    FOREIGN KEY (`city_street_id`) REFERENCES `cities_streets`(`id`) ON DELETE CASCADE
);

CREATE TABLE `people`(
	`id` INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
    `last_name` VARCHAR(40) NOT NULL,
    `first_name` VARCHAR(40) NOT NULL,
    `patronymic` VARCHAR(40) NULL,
    `login` VARCHAR(30) NOT NULL,
    `password` varchar(60) NOT NULL,
    `millitary_duty` BOOLEAN not null,
    `sex` BOOLEAN NULL,
    `address_id` INT NOT NULL,
    `role_id` INT NOT NULL,
    constraint `people_to_roles`
    foreign key (`role_id`) references `roles`(`id`),
    constraint `people_to_addresses`
    foreign key (`address_id`) references `addresses`(`id`)
);

CREATE TABLE `phones`(
	`id` INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
    `employee_id` INT NOT NULL,
    `number` VARCHAR(15) NOT NULL,
    `phone_type_id` INT NOT NULL,
    constraint `phones_to_people`
    foreign key (`employee_id`) references `people`(`id`) ON DELETE CASCADE,
    constraint `phones_to_types`
    foreign key (`phone_type_id`) references `types_of_phone`(`id`)
);

CREATE TABLE `separations`(
	`id` INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
    `name` VARCHAR(100) NOT NULL,
    `code` VARCHAR(10) NOT NULL
);

CREATE TABLE `passports`(
	`id` INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
    `employee_id` INT NOT NULL,
    `seria` INT NOT NULL,
    `number` INT NOT NULL,
    `address_registration_id` INT NOT NULL,
    `separation_id` INT NOT NULL,
    `date` DATE NOT NULL,
    `birthday` DATE NOT NULL,
    constraint `passport_to_people`
    foreign key (`employee_id`) references `people`(`id`) ON DELETE CASCADE,
    constraint `passport_to_address`
    foreign key (`address_registration_id`) references `addresses`(`id`)
);

CREATE TABLE `discipline_bans`(
	`id` INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
    `employee_id` INT NOT NULL,
    `ban` VARCHAR(255) NOT NULL,
    `date` datetime NOT NULL,
    constraint `disciplines_to_people`
    foreign key (`employee_id`) references `people`(`id`) ON DELETE CASCADE
);

CREATE TABLE `sessions`(
	`id` INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
    `employee_id` INT NOT NULL,
    `date_start` datetime NOT NULL,
    `date_end` datetime NOT NULL,
    `type_of_session_id` int not null,
    constraint `sessions_to_people`
    foreign key (`employee_id`) references `people`(`id`) ON DELETE CASCADE,
    constraint `type_of_sessions_to_people`
    foreign key (`type_of_session_id`) references `types_of_sessions`(`id`)
);