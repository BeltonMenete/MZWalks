SQLServer-Syntax

-- Step 1: Insert Difficulties
INSERT INTO Difficulties (Id, Name) VALUES 
('01HZX0J5ZWGFA1D9S3H4HMGWVD', 'Easy'),
('01HZX0J5ZX9Y9S9TCS59R3KH9J', 'Medium'),
('01HZX0J60AZK3D9R9YFMC2DJMD', 'Hard');

-- Step 2: Insert Regions
INSERT INTO Regions (Id, Code, Name, RegionImageURL) VALUES 
('01HZX0J60B8J1A8RPX1M0XQJ3N', 'AKL', 'Auckland', 'https://images.nzregions.com/auckland.jpg'),
('01HZX0J60C1J1A8RPX2N1YQJ3P', 'WGN', 'Wellington', 'https://images.nzregions.com/wellington.jpg'),
('01HZX0J60D1J1A8RPX3Z2ZQJ3Q', 'CAN', 'Canterbury', 'https://images.nzregions.com/canterbury.jpg'),
('01HZX0J60E1J1A8RPX4P3AQJ3R', 'STL', 'Southland', 'https://images.nzregions.com/southland.jpg'),
('01HZX0J60F1J1A8RPX5D4BQJ3S', 'OTA', 'Otago', 'https://images.nzregions.com/otago.jpg');

-- Step 3: Insert Walks (25+ entries)
INSERT INTO Walks (Id, Name, Description, LengthInKm, WalkImageURl, DifficultyId, RegionId) VALUES 
('01HZX0J60GJ1A8RPX6W5CQJ3T', 'Rangitoto Summit Track', 'A scenic volcanic climb with panoramic views.', 7.0, 'https://walks.nz/rangitoto.jpg', '01HZX0J5ZWGFA1D9S3H4HMGWVD', '01HZX0J60B8J1A8RPX1M0XQJ3N'),
('01HZX0J60HJ1A8RPX7E6DQJ3U', 'Waitakere Dam Walk', 'Dense native bush with a beautiful dam.', 8.5, 'https://walks.nz/waitakere.jpg', '01HZX0J5ZX9Y9S9TCS59R3KH9J', '01HZX0J60B8J1A8RPX1M0XQJ3N'),
('01HZX0J60IJ1A8RPX8F7EQJ3V', 'Red Rocks Walk', 'Coastal walk with seal viewing.', 10.0, 'https://walks.nz/redrocks.jpg', '01HZX0J5ZWGFA1D9S3H4HMGWVD', '01HZX0J60C1J1A8RPX2N1YQJ3P'),
('01HZX0J60JJ1A8RPX9G8FQJ3W', 'Mt Victoria Loop', 'A city summit walk with harbor views.', 4.2, 'https://walks.nz/mtvictoria.jpg', '01HZX0J5ZWGFA1D9S3H4HMGWVD', '01HZX0J60C1J1A8RPX2N1YQJ3P'),
('01HZX0J60KJ1A8RPX0H9GQJ3X', 'Hooker Valley Track', 'Iconic alpine track with swing bridges.', 11.0, 'https://walks.nz/hookervalley.jpg', '01HZX0J5ZX9Y9S9TCS59R3KH9J', '01HZX0J60D1J1A8RPX3Z2ZQJ3Q'),
('01HZX0J60LJ1A8RPX1J1HQJ3Y', 'Godley Head Loop', 'Historic WWII sites with coastal views.', 9.0, 'https://walks.nz/godleyhead.jpg', '01HZX0J60AZK3D9R9YFMC2DJMD', '01HZX0J60D1J1A8RPX3Z2ZQJ3Q'),
('01HZX0J60MJ1A8RPX2K2IQJ3Z', 'Kepler Track', 'Multi-day alpine adventure with lakes.', 60.0, 'https://walks.nz/kepler.jpg', '01HZX0J60AZK3D9R9YFMC2DJMD', '01HZX0J60E1J1A8RPX4P3AQJ3R'),
('01HZX0J60NJ1A8RPX3L3JQJ410', 'Rakiura Track', 'Remote wilderness and beach walk.', 32.0, 'https://walks.nz/rakiura.jpg', '01HZX0J5ZX9Y9S9TCS59R3KH9J', '01HZX0J60E1J1A8RPX4P3AQJ3R'),
('01HZX0J60OJ1A8RPX4M4KQJ411', 'Ben Lomond Track', 'Challenging summit with Queenstown views.', 14.3, 'https://walks.nz/benlomond.jpg', '01HZX0J60AZK3D9R9YFMC2DJMD', '01HZX0J60F1J1A8RPX5D4BQJ3S'),
('01HZX0J60PJ1A8RPX5N5LQJ412', 'Tunnel Beach Track', 'Cliffside path to a secluded beach.', 2.0, 'https://walks.nz/tunnelbeach.jpg', '01HZX0J5ZWGFA1D9S3H4HMGWVD', '01HZX0J60F1J1A8RPX5D4BQJ3S'),
('01HZX0J60QJ1A8RPX6P6MQJ413', 'Mount Iron Track', 'Short hill climb near Wanaka.', 4.5, 'https://walks.nz/mountiron.jpg', '01HZX0J5ZWGFA1D9S3H4HMGWVD', '01HZX0J60F1J1A8RPX5D4BQJ3S'),
('01HZX0J60RJ1A8RPX7Q7NQJ414', 'Hakarimata Summit', 'Steep bush walk with a lookout tower.', 3.2, 'https://walks.nz/hakarimata.jpg', '01HZX0J60AZK3D9R9YFMC2DJMD', '01HZX0J60B8J1A8RPX1M0XQJ3N'),
('01HZX0J60SJ1A8RPX8R8OQJ415', 'Cape Palliser Walk', 'Lighthouse and fur seals.', 1.5, 'https://walks.nz/palliser.jpg', '01HZX0J5ZWGFA1D9S3H4HMGWVD', '01HZX0J60C1J1A8RPX2N1YQJ3P'),
('01HZX0J60TJ1A8RPX9S9PQJ416', 'Avalanche Peak', 'Steep alpine climb for experienced hikers.', 6.0, 'https://walks.nz/avalanchepeak.jpg', '01HZX0J60AZK3D9R9YFMC2DJMD', '01HZX0J60D1J1A8RPX3Z2ZQJ3Q'),
('01HZX0J60UJ1A8RPX0T0QQJ417', 'Lake Marian Track', 'Alpine lake in Fiordland.', 10.0, 'https://walks.nz/lakemarian.jpg', '01HZX0J5ZX9Y9S9TCS59R3KH9J', '01HZX0J60E1J1A8RPX4P3AQJ3R'),
('01HZX0J60VJ1A8RPX1U1RQJ418', 'Routeburn Track', 'Stunning vistas across the Southern Alps.', 32.0, 'https://walks.nz/routeburn.jpg', '01HZX0J60AZK3D9R9YFMC2DJMD', '01HZX0J60E1J1A8RPX4P3AQJ3R');

