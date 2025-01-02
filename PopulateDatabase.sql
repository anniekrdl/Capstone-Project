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
    ("Riem", "Riem met ingebouwde waterflessen en ruimte voor snacks, perfect voor lange ritten.", 3499, 60, 2, "https://www.sefiles.net/merchant/924/images/zoom/camelbak-flow-stash-waist-packs-camelbak-0349-cxmagazine-clee_11.jpg"),
    ("Multitool", "Een compact multitool met 15 functies, inclusief inbussleutels, een kettingpons en schroevendraaiers.", 2499, 100, 2, "https://example.com/images/multitool.jpg"),
    ("Fietspomp", "Lichte, draagbare fietspomp met manometer voor onderweg.", 2999, 80, 2, "https://example.com/images/fietspomp.jpg"),
    ("Compressiezakken", "Waterdichte compressiezakken om kleding of andere items compact te houden tijdens het reizen.", 1299, 150, 1, "https://example.com/images/compressiezakken.jpg"),
     ("Hoofdlamp USB-oplaadbaar", "Heldere hoofdlamp met verstelbare lichtsterkte en USB-oplaadfunctie.", 3499, 50, 10, "https://example.com/images/hoofdlamp.jpg"),
    ("Waterfilter Fles", "Een fles met ingebouwd waterfilter, ideaal voor veilig drinken uit natuurlijke bronnen.", 3999, 100, 9, "https://example.com/images/waterfilter_fles.jpg"),
    ("Dynamo Oplader", "Een duurzame dynamo-oplader die stroom genereert tijdens het fietsen.", 5999, 25, 3, "https://example.com/images/dynamo_oplader.jpg"),
    ("EHBO-set", "Compacte EHBO-set met benodigdheden voor kleine noodgevallen onderweg.", 1999, 75, 7, "https://example.com/images/ehbo_set.jpg"),
    ("Reparatieset", "Complete reparatieset met bandenplakkers, een mini-pomp en reservebinnenband.", 2499, 120, 7, "https://example.com/images/reparatieset.jpg");;
;

INSERT INTO klant 
(gebruikersnaam, voornaam, achternaam, email, straat, huisnummer, toevoeging, woonplaats)
VALUES 
("Jan123","Jan", "Jansen", "jan.jansen@example.com", "Hoofdstraat", 123, "A", "Amsterdam"),
("Sanne456", "Sanne", "Vermeulen", "sanne.vermeulen@example.com", "Dorpsstraat", 45, NULL, "Rotterdam"),
("Peter789", "Peter", "de Vries", "peter.devries@example.com", "Kerkstraat", 12, "B", "Utrecht");


