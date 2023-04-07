﻿-- CREATE TABLE SPORTS(sportsId int NOT NULL, sportsName nchar(50) NOT NULL);
-- CREATE TABLE PLAYERS(playerId int NOT NULL, playerName nchar(50) NOT NULL, collegeId int);
-- CREATE TABLE COLLEGE(collegeId int NOT NULL, collegeName nchar(50) NOT NULL);
-- CREATE TABLE TOURNAMENTS(tournamentId int NOT NULL, tournamentName nchar(50) NOT NULL, collegeId int);
-- CREATE TABLE SCOREBOARD(studentId int NOT NULL, tournamentId int NOT NULL, score int);
-- CREATE TABLE TOURNAMENTSPORTS(tournamentId int NOT NULL,sportsID int NOT NULL);
-- CREATE TABLE TEAM(teamId int NOT NULL PRIMARY KEY,teamName nchar(50) NOT NULL);

ALTER TABLE SCOREBOARD ADD sportsID int NOT NULL;
ALTER TABLE SCOREBOARD DROP COLUMN studentId;
ALTER TABLE SCOREBOARD ADD playerID int NOT NULL;

ALTER TABLE PLAYERS ADD teamId int;

ALTER TABLE PLAYERS ADD CONSTRAINT fk_player_team FOREIGN KEY (teamID) REFERENCES TEAM(teamID);

ALTER TABLE SPORTS ADD PRIMARY KEY(sportsID);
ALTER TABLE TOURNAMENTS ADD PRIMARY KEY(tournamentId);
ALTER TABLE PLAYERS ADD PRIMARY KEY(playerId);
ALTER TABLE COLLEGE ADD PRIMARY KEY(collegeId);

ALTER TABLE TOURNAMENTS ADD CONSTRAINT fk_tournament_college FOREIGN KEY (collegeId) REFERENCES COLLEGE(collegeID);
ALTER TABLE PLAYERS ADD CONSTRAINT fk_player_college FOREIGN KEY (collegeId) REFERENCES COLLEGE(collegeID);
ALTER TABLE TOURNAMENTSPORTS ADD CONSTRAINT fk_tournament FOREIGN KEY (tournamentID) REFERENCES TOURNAMENTS(tournamentID);
ALTER TABLE TOURNAMENTSPORTS ADD CONSTRAINT fk_sports FOREIGN KEY (sportsID) REFERENCES SPORTS(sportsID);

ALTER TABLE SCOREBOARD ADD CONSTRAINT fk_tournament_score FOREIGN KEY (tournamentID) REFERENCES TOURNAMENTS(tournamentID);
ALTER TABLE SCOREBOARD ADD CONSTRAINT fk_sports_score FOREIGN KEY (sportsID) REFERENCES SPORTS(sportsID);
ALTER TABLE SCOREBOARD ADD CONSTRAINT fk_player_score FOREIGN KEY (playerID) REFERENCES PLAYERS(playerID);

CREATE OR ALTER PROCEDURE removeCollege @collegeId int
AS
DECLARE @tournamentid int;
BEGIN
DELETE FROM PLAYERS WHERE collegeId = @collegeId;
SELECT @tournamentid = tournamentID FROM TOURNAMENTS WHERE collegeID = @collegeid;
EXEC removeTournament @tournamentid
DELETE FROM COLLEGE WHERE collegeId = @collegeId;
END

CREATE OR ALTER PROCEDURE removeTournament @tournamentId int
AS
BEGIN
DELETE FROM TOURNAMENTS WHERE tournamentId = @tournamentId;
DELETE FROM TOURNAMENTSPORTS WHERE tournamentId = @tournamentId;
END

CREATE OR ALTER PROCEDURE removePlayer @playerId int
AS
BEGIN
DELETE FROM PLAYERS WHERE playerId = @playerId;
END

CREATE OR ALTER PROCEDURE removeSports @sportsId int
AS
BEGIN
DELETE FROM SPORTS WHERE sportsId = @sportsId;
DELETE FROM TOURNAMENTSPORTS WHERE sportsId = @sportsId;
END

-- DELETE FROM COLLEGE WHERE collegeId = 7822;

SELECT * FROM SPORTS;
SELECT * FROM PLAYERS;
SELECT * FROM COLLEGE;
SELECT * FROM TOURNAMENTS;
SELECT * FROM TOURNAMENTSPORTS;
SELECT * FROM TEAM;
SELECT * FROM SCOREBOARD;