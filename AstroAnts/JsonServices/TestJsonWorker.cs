﻿namespace AstroAnts.JsonServices
{
    public class TestJsonWorker : IJsonWorker
    {
        private const string SimpleTestData = @"{
            'id': '2727',
            'startedTimestamp': 1503929807498,
            'map': {
                'areas': ['5-R', '1-RDL', '10-DL', '2-RD', '1-UL', '1-UD', '2-RU', '1-RL', '2-UL']
            },
            'astroants': { 'x': 1, 'y': 0 },
            'sugar': { 'x': 2, 'y': 1 }
        }";

        public string GetJsonFile(string url)
        {
            return SimpleTestData;
        }
    }
}