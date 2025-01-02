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
("Linda101", "Linda", "Bakker", "linda.bakker@example.com", "Lindenlaan", 88, NULL, "Den Haag");

-- ADD TO SHOPPINGCART
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
SET status = "GEACCEPTEERD"
WHERE b.bestelling_id =1;

-- REJECT INCOMING ORDER
UPDATE bestelling b
SET status = "GEWEIGERD"
WHERE b.bestelling_id = 1;


-- SHOW STATUS ORDER CUSTOMER
SELECT b.klant_id , b.status 
FROM bestelling b 
WHERE b.klant_id = 1;
  