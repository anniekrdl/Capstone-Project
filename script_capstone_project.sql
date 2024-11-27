-- CREATE TABLES

CREATE TABLE klant(
	klant_id INT UNSIGNED PRIMARY KEY AUTO_INCREMENT,
	gebruikersnaam VARCHAR(50) NOT NULL UNIQUE,
	voornaam VARCHAR(50) NOT NULL,
	achternaam VARCHAR(50) NOT NULL,
	email VARCHAR(50) NOT NULL,
	straat VARCHAR(50) NOT NULL,
	huisnummer INT NOT NULL,
	toevoeging VARCHAR(50),
	woonplaats VARCHAR(50)
);

CREATE TABLE bestelling (
	bestelling_id INT UNSIGNED PRIMARY KEY AUTO_INCREMENT,
	klant_id INT UNSIGNED,
	datum DATE, -- Format YYYY-MM-DD
	status ENUM("AANGEMAAKT","GEPLAATST", "GEACCEPTEERD", "GEWEIGERD", "AFGEROND"),
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
	beschrijving TEXT,
	prijs INT UNSIGNED NOT NULL,
	voorraad INT UNSIGNED NOT NULL,
	categorie_id INT UNSIGNED,
	afbeelding_url VARCHAR(256) NOT NULL,
	CONSTRAINT fk_categorie FOREIGN KEY (categorie_id) REFERENCES categorie(categorie_id)
);

CREATE TABLE bestelling_detail (
	detail_id INT UNSIGNED PRIMARY KEY AUTO_INCREMENT,
	bestelling_id INT UNSIGNED,
	product_id INT UNSIGNED,
	aantal INT UNSIGNED NOT NULL,
	CONSTRAINT fk_bestelling FOREIGN KEY (bestelling_id) REFERENCES bestelling(bestelling_id),
	CONSTRAINT fk_product FOREIGN KEY (product_id) REFERENCES product(product_id)
);

CREATE TABLE huidige_bestelling_item (
	huidige_bestelling_id INT UNSIGNED PRIMARY KEY AUTO_INCREMENT,
	klant_id INT UNSIGNED,
	product_id INT UNSIGNED,
	aantal INT UNSIGNED NOT NULL,
	CONSTRAINT fk_klant_huidig FOREIGN KEY (klant_id) REFERENCES klant(klant_id),
	CONSTRAINT fk_product_huidig FOREIGN KEY (product_id) REFERENCES product(product_id)
);


-- TEST TABLES
-- ADD CATEGORIES

INSERT INTO categorie (naam, beschrijving)
VALUES 
    ("Kamperen", "Essentiële uitrusting voor elke kampeerder, van tenten tot slaapzakken, ontworpen om compact en lichtgewicht te zijn voor onderweg."),
    ("Fietsaccessoires", "Een breed scala aan accessoires om uw fiets klaar te maken voor een bikepacking avontuur: bagagedragers, fietstassen, bidonhouders, en meer."),
    ("Elektronica", "Draagbare opladers, zonnepanelen, GPS-systemen en andere gadgets die essentieel zijn voor een comfortabele en veilige reis."),
    ("Kookgerei", "Slimme en compacte kookoplossingen, van draagbare kookstellen tot opvouwbare pannen, voor het bereiden van maaltijden in de natuur."),
    ("Kleding", "Functionele en ademende kleding ontworpen voor outdoor activiteiten, waaronder weerbestendige jassen, snel-drogende shirts en stevige wandelschoenen."),
    ("Navigatie", "Tools en apparatuur voor navigatie, zoals kaarten, GPS-toestellen en apps om je route efficiënt te plannen."),
    ("Veiligheid", "Uitrusting voor persoonlijke veiligheid, waaronder EHBO-kits, noodflitsers, en reflecterende kleding voor zichtbaarheid."),
    ("Verlichting", "Handige en krachtige verlichting oplossingen, van hoofdlampen tot fietslampen, om in het donker veilig te navigeren."),
    ("Hydratatie", "Oplossingen voor wateropslag en -behandeling, zoals waterflessen, filters en hydratatietassen om goed gehydrateerd te blijven tijdens je avontuur."),
    ("Reisaccessoires", "Praktische accessoires voor onderweg, waaronder multifunctionele gereedschappen, reiszakken en universele adapters.");

-- ADD PRODUCTS
   INSERT INTO product (naam, beschrijving, prijs, voorraad, categorie_id, afbeelding_url)
VALUES 
    ("Ultralight Tent", "Een lichtgewicht tent voor 2 personen, ideaal voor kamperen en backpacken.", 19999, 50, 1, "https://images.squarespace-cdn.com/content/v1/5aba1e6b70e802e5fd3b93ff/1620734129257-26MDDF059I6DIDC9AGMA/best-bikepacking-tents-02.jpg"),
    ("Fietstas", "Waterdichte fietstas voor veilig vervoer van je spullen tijdens bikepacking.", 7999, 30, 2, "https://www.futurumshop.nl/img/Products/6082-0735-001-N1903/large/5.jpg"),
    ("Powerbank 20000mAh", "Krachtige powerbank met hoge capaciteit voor het opladen van al je apparaten.", 4999, 100, 3, "https://assets.mmsrg.com/isr/166325/c1/-/ASSET_MMS_139809406?x=536&y=402&format=jpg&quality=80&sp=yes&strip=yes&trim&ex=536&ey=402&align=center&resizesource&unsharp=1.5x1+0.7+0.02&cox=0&coy=0&cdx=536&cdy=402"),
    ("Camping Kookstel", "Compact kookstel met gasbranders, perfect voor koken in de buitenlucht.", 5999, 20, 4, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQjtDGOgZAEBcPHi2sDq_qaI11UGIPdg1hwDg&s"),
    ("Slaapmat", "Dunne, opblaasbare slaapmat voor extra comfort tijdens het slapen in de natuur.", 3999, 75, 1, "https://images.snowleader.com/cdn-cgi/image/f=auto,fit=scale-down,q=85/https://images.snowleader.com/media/catalog/product/cache/1/image/0dc2d03fe217f8c83829496872af24a0/T/H/THEA00278_01.jpg"),
    ("GPS Navigatiesysteem", "Betrouwbaar GPS-systeem met kaarten en navigatiefuncties voor outdoor avonturen.", 12999, 15, 3, "https://bikepacking.com/wp-content/uploads/2021/01/garmin-edge-830-review.jpg"),
    ("Etenstijden Set", "Complete set met potten en pannen voor het bereiden van maaltijden tijdens je reis.", 8999, 25, 4, "https://bikepacking.com/wp-content/uploads/2024/08/budget-camping-cook-kit_16.jpg"),
    ("Reflecterende Vest", "Veiligheidsvest met reflecterende strips voor zichtbaarheid tijdens het fietsen in het donker.", 2499, 100, 2, "https://medias.apidura.com/2023/07/apidura-packable-visibility-vest-s-m-on-body-2.jpg"),
    ("Zonnepaneel Lader", "Draagbare zonnepaneel lader voor het opladen van apparaten met zonne-energie.", 8999, 40, 3, "https://bikepacking.com/wp-content/uploads/2017/06/Anker_PowerPort_Solar_Review-15.jpg"),
    ("Hydratatie Riem", "Riem met ingebouwde waterflessen en ruimte voor snacks, perfect voor lange ritten.", 3499, 60, 2, "https://www.sefiles.net/merchant/924/images/zoom/camelbak-flow-stash-waist-packs-camelbak-0349-cxmagazine-clee_11.jpg"),
    ("Riem", "Riem met ingebouwde waterflessen en ruimte voor snacks, perfect voor lange ritten.", 3499, 60, 2, "https://www.sefiles.net/merchant/924/images/zoom/camelbak-flow-stash-waist-packs-camelbak-0349-cxmagazine-clee_11.jpg");
;
   
-- EDIT PRODUCT
UPDATE product 
SET afbeelding_url = "https://bikepacking.com/wp-content/uploads/2022/01/exped-2022-sleeping-mats_1.jpg"
WHERE naam = "Slaapmat";
  
-- DELETE PRODUCT
DELETE FROM product
WHERE naam = "Riem";
 
 -- SHOW CATALOG
SELECT naam, categorie_id 
FROM product p ;

-- ADD KLANT
INSERT INTO klant 
(gebruikersnaam ,voornaam, achternaam, email, straat, huisnummer, toevoeging, woonplaats)
VALUES 
("Jan123","Jan", "Jansen", "jan.jansen@example.com", "Hoofdstraat", 123, "A", "Amsterdam");

INSERT INTO klant 
(gebruikersnaam, voornaam, achternaam, email, straat, huisnummer, toevoeging, woonplaats)
VALUES 
("Sanne456", "Sanne", "Vermeulen", "sanne.vermeulen@example.com", "Dorpsstraat", 45, NULL, "Rotterdam"),
("Peter789", "Peter", "de Vries", "peter.devries@example.com", "Kerkstraat", 12, "B", "Utrecht"),
("Linda101", "Linda", "Bakker", "linda.bakker@example.com", "Lindenlaan", 88, NULL, "Den Haag");
-- ADD TO SHOPPING CART
INSERT INTO huidige_bestelling_item 
(klant_id, product_id, aantal)
VALUES (1, 1, 1),
(1, 8, 2);

-- REMOVE FROM SHOPPING CART
DELETE FROM huidige_bestelling_item 
WHERE product_id = 29;


-- ALL ITEMS IN SHOPPING CART
SELECT p.naam, h.aantal, p.prijs 
FROM huidige_bestelling_item h
JOIN product p ON h.product_id = p.product_id;


-- NEXT: ORDER PLACING WITH TRIGGERS

DELIMITER //

CREATE TRIGGER delete_huidige_bestelling
AFTER UPDATE ON bestelling
FOR EACH ROW
BEGIN -- blok voor meerdere statements
    IF OLD.status = 'AANGEMAAKT' AND NEW.status = 'GEPLAATST' THEN
        DELETE FROM huidige_bestelling_item
        WHERE klant_id = NEW.klant_id;
    END IF;
END//

DELIMITER ;


-- CREATE ORDER
INSERT INTO bestelling 
(klant_id, datum, status)
VALUES (1, "2024-10-31", "AANGEMAAKT")
   

-- van huidige naar bestelling_details
INSERT INTO bestelling_detail 
(bestelling_id, product_id, aantal)
VALUES (1, 1, 1)

-- PLACE ORDER
UPDATE bestelling 
SET status = "GEPLAATST"
WHERE bestelling_id =1;

-- SHOW ALL INCOMING ORDERS
SELECT * 
FROM bestelling b 
WHERE b.status = "GEPLAATST";

-- COMPLETE INCOMING ORDER
UPDATE bestelling b
SET status = "AFGEROND"
WHERE b.bestelling_id =1;

-- REJECT INCOMING ORDER
UPDATE bestelling b
SET status = "GEWEIGERD"
WHERE b.bestelling_id = 1;


-- SHOW STATUS ORDER CUSTOMER
SELECT b.klant_id , b.status 
FROM bestelling b 
WHERE b.klant_id = 1;
  

