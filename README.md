# AstroAnts

## Introduction

Program that helps group of AstroAnts to find the best way to their sugar source on unknown planet.

## Description of Problem

Unknown planet can be describen as Graph, where every node have constant value that corresponds to difficulty of traveling through this node. Coordinates of AstroAnts group and sugar source are known. Provided program tries to find suitable way to sugar source so AstroAnts doesn't starve to the death. This task can be converted to problem of finding shortest path at the Graph. Suitable path from initial position to sugar source cannot exceed 60000ms (time of algorithm running + sum of node's values at the path).

## Used method

Program uses [A* algorithm](https://en.wikipedia.org/wiki/A*_search_algorithm) for finding optimal path at the Graph. [Manhattan distance](https://xlinux.nist.gov/dads/HTML/manhattanDistance.html) is used for computation of heuristic function.

## Json messages format

Program can commucate with API server, but format of json messages have to have this format:

Example of initial json message: 
```json
{
  "id": "2727",
  "startedTimestamp": 1503929807498,
  "map": {
  "areas": ["5-R", "1-RDL", "10-DL", "2-RD", "1-UL", "1-UD",
   "2-RU", "1-RL", "2-UL"]
  },
    "astroants": {"x": 1, "y": 0 },
    "sugar": { "x": 2, "y": 1 }
}
```

Example of send response:
```json
{
  "path":"DLDRRU"
}
```

Example of expected received response:
```json
{
  "valid": false,
  "inTime": false,
  "message": "You used connection that is not in map from [3,2] going DOWN"
}
```



