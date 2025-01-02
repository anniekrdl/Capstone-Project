CREATE TABLE klant(
	klant_id INT UNSIGNED PRIMARY KEY AUTO_INCREMENT,
	gebruikersnaam VARCHAR(50) NOT NULL UNIQUE,
	voornaam VARCHAR(50) NOT NULL,
	achternaam VARCHAR(50) NOT NULL,
	email VARCHAR(50) NOT NULL,
	straat VARCHAR(50) NOT NULL,
	huisnummer INT NOT NULL,
	toevoeging VARCHAR(50),
	woonplaats VARCHAR(50) NOT NULL
);

CREATE TABLE bestelling (
	bestelling_id INT UNSIGNED PRIMARY KEY AUTO_INCREMENT,
	klant_id INT UNSIGNED NOT NULL,
	datum DATE NOT NULL, -- Format YYYY-MM-DD
	status ENUM("AANGEMAAKT","GEPLAATST", "GEACCEPTEERD", "GEWEIGERD", "AFGEROND") NOT NULL,
	CONSTRAINT fk_klant FOREIGN KEY (klant_id) REFERENCES klant(klant_id)
);

CREATE TABLE categorie (
	categorie_id INT UNSIGNED PRIMARY KEY AUTO_INCREMENT,
	naam VARCHAR(50) NOT NULL,
	beschrijving TEXT NOT NULL
);


CREATE TABLE product (
	product_id INT UNSIGNED PRIMARY KEY AUTO_INCREMENT,
	naam VARCHAR(50) NOT NULL,
	beschrijving TEXT NOT NULL,
	prijs INT UNSIGNED NOT NULL,
	voorraad INT UNSIGNED NOT NULL,
	categorie_id INT UNSIGNED NOT NULL,
	afbeelding_url VARCHAR(256) NOT NULL,
	CONSTRAINT fk_categorie FOREIGN KEY (categorie_id) REFERENCES categorie(categorie_id)
);

CREATE TABLE bestelling_detail (
	detail_id INT UNSIGNED PRIMARY KEY AUTO_INCREMENT,
	bestelling_id INT UNSIGNED NOT NULL,
	product_id INT UNSIGNED NOT NULL,
	aantal INT UNSIGNED NOT NULL,
	CONSTRAINT fk_bestelling FOREIGN KEY (bestelling_id) REFERENCES bestelling(bestelling_id),
	CONSTRAINT fk_product FOREIGN KEY (product_id) REFERENCES product(product_id)
);

CREATE TABLE huidige_bestelling_item (
	huidige_bestelling_id INT UNSIGNED PRIMARY KEY AUTO_INCREMENT,
	klant_id INT UNSIGNED NOT NULL,
	product_id INT UNSIGNED NOT NULL,
	aantal INT UNSIGNED NOT NULL,
	CONSTRAINT fk_klant_huidig FOREIGN KEY (klant_id) REFERENCES klant(klant_id),
	CONSTRAINT fk_product_huidig FOREIGN KEY (product_id) REFERENCES product(product_id)
);
