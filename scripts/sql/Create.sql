-- Create Script V1.02

CREATE TABLE IF NOT EXISTS Game (
    game_id             varchar(36)                             NOT NULL, -- Got to be generated in application layer. In case of auto generated there could be used UUID with an extension to postgres
    game_name           VARCHAR(250)                            NOT NULL UNIQUE,
    game_description    VARCHAR(2400)                           NOT NULL,
    game_img_url        varchar(2048),
    game_published_year varchar(6)                              NOT NULL,
    PRIMARY KEY (game_id)
);

CREATE TABLE IF NOT EXISTS GameScore (
    game_id             varchar(36)                             NOT NULL,
    game_score          Decimal                                 NOT NULL    CHECK (game_score >= 0 AND game_score <= 10),
    game_score_total    BIGINT                                  NOT NULL,
    total_reviews       BIGINT                                  NOT NULL,

    FOREIGN KEY (game_id) REFERENCES Game(game_id)
);
