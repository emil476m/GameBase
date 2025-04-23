-- Mock data V1.03
-- this is Example texting | Examples have been auto generated
INSERT INTO Game (game_id, game_name, game_description, game_img_url, game_published_year) VALUES
('1a9d8a28-01f1-41ad-9c71-6a3a82e30c10', 'Pixel Quest', 'An 8-bit style platformer where you explore ancient ruins and collect hidden artifacts.', 'https://example.com/images/pixel-quest.jpg', '2002'),
('5e9c2bcd-0f0c-48dc-9734-07a1846f2b57', 'Galactic Defender', 'A space shooter where players must defend their galaxy from waves of alien invaders.', 'https://example.com/images/galactic-defender.jpg', '2020'),
('d3c4ed9b-b340-4c5e-8231-c194f5aadb5c', 'Mystic Forest', 'A magical adventure game set in an enchanted forest full of puzzles and mythical creatures.', 'https://example.com/images/mystic-forest.jpg', '2010'),
('3d22d8d4-e82d-42e7-91d8-5b2cf7d68f36', 'Speed Rush', 'An arcade racing game with fast-paced tracks and customizable vehicles.', 'https://example.com/images/speed-rush.jpg', '2003'),
('e55a2072-83b5-4f75-9a12-7b42f9989b62', 'Code Breaker', 'A logic-based puzzle game where players crack codes and unlock secrets.', NULL, '2000');  -- NULL url to test optional image

-- Mocks game_score
INSERT INTO GameScore (game_score, game_id, game_score_total, total_reviews) values
(9.2,'1a9d8a28-01f1-41ad-9c71-6a3a82e30c10', 920, 10),
(6.5,'5e9c2bcd-0f0c-48dc-9734-07a1846f2b57', 6500, 100),
(2.0,'d3c4ed9b-b340-4c5e-8231-c194f5aadb5c', 50, 25),
(5.5,'3d22d8d4-e82d-42e7-91d8-5b2cf7d68f36', 110, 20),
(10.0,'e55a2072-83b5-4f75-9a12-7b42f9989b62', 10000, 1000);