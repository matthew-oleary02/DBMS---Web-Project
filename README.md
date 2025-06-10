# GameReady Tracker (GRT)

**Precise Health, Maximum Performance**  
DATA3260 Final Project | Developed by Matthew O'Leary

## Overview

GameReady Tracker (GRT) is a web-based database management system designed to optimize athlete health and performance. The system provides player-specific tracking of injury recovery and load management through historical data analysis, allowing teams to make informed decisions and fans to gain greater transparency into their favorite players' statuses.

## Problem Statement

In the world of professional sports, injuries and rest strategies often leave fans in the dark and teams making high-stakes decisions without data-backed insights. GRT addresses:

- Lack of transparency around injuries and recovery.
- Inconsistent and unstructured rehabilitation processes.
- Limited historical data to guide medical and roster decisions.

## Solution

GRT empowers sports organizations by:

- Providing realistic recovery timelines using injury-specific data.
- Analyzing player performance and health to optimize team readiness.
- Offering a visualized, query-able interface for historical injury tracking.

## Key Features

- 🧠 **Injury & Recovery Analytics**: Track injury trends by type, severity, and player position.
- 📊 **Player Performance History**: Analyze stats including points, assists, rebounds, and more.
- 🔍 **Team & Contract Management**: Evaluate expiring contracts in conjunction with player health.
- 🧾 **Custom SQL Queries**: Deep insights into player injuries and recovery plans using advanced queries.

## Data Model

Entities include:
- **Players**: Name, position, salary, performance stats, and contract details.
- **Injuries**: Injury type, severity, timeline, and recovery status.
- **Recovery Plans**: Customized next steps based on injury attributes.
- **Teams** and **Employees**: Structure for medical and performance staff management.

## Example SQL Queries

```sql
-- Count of knee injuries by position
SELECT count(InjuryRecordID) AS NumofKneeInjuries, Position
FROM players
INNER JOIN Attributes ON players.playerID = Attributes.PlayerID
INNER JOIN [Injury Records] ON players.playerID = [Injury Records].PlayerID
INNER JOIN [Injury Type] ON [Injury Records].InjuryRecordID = [Injury Type].InjuryRecordID
WHERE InjuryName LIKE '%knee%'
GROUP BY Position
ORDER BY NumofKneeInjuries DESC;
```

```sql
-- Severe injuries with recovery steps
SELECT RecoveryPlanID, InjuryName, InjuryDetails, InjurySeverity, GameType, NextSteps
FROM [Injury Records]
INNER JOIN [Injury Type] ON [Injury Records].InjuryRecordID = [Injury Type].InjuryRecordID
INNER JOIN [Recovery Plan] ON [Injury Type].InjuryTypeID = [Recovery Plan].InjuryTypeID
WHERE InjurySeverity = 'Severe';
```
