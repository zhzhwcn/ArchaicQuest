﻿using MIMWebClient.Core.Room;
using MIMWebClient.Core.World.Anker;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using MIMWebClient.Core.World.Tutorial;
using LiteDB;

namespace UpdateDB
{
    class UpdateDb
    {
        public LiteCollection<Room> roomCollection { get; set; }



        static void Main(string[] args)
        {
            //TODO: Clean up :)

          
            using (var db = new LiteDatabase(@"C:\MyData.db"))
            {

                var col = db.GetCollection<Room>("Room");
               
                Console.WriteLine("Cleaning DB");
                db.DropCollection("Room");
                Console.WriteLine("Compiling Areas.");

                var areaSpeed = new Stopwatch();
                areaSpeed.Start();

                var areas = new List<Room>
                {
                    Ambush.TutorialRoom1(),
                    Ambush.TutorialRoom2(),
                    Ambush.TutorialLostInTheWoods(),
                    Ambush.TutorialLostInTheWoods2(),
                    Ambush.TutorialLostInTheWoods3(),
                    Ambush.TutorialLostInTheWoods4(),
                    Ambush.TutorialLostInTheWoods5(),
                    Ambush.TutorialLostInTheWoods6(),
                    Ambush.TutorialGoblinCamp(),
                    Ambush.TutorialGoblinCampTentNorth(),
                    Ambush.TutorialGoblinCampTentSouth(),
                    Awakening.TempleOfTyr(),
                    Anker.VillageSquare(),
                    Anker.SquareWalkOutsideTavern(),
                    Anker.SquareWalkOutsideStables(),
                    Anker.RedLionStables(),
                    Anker.SquareWalkCommerceCorner(),
                    Anker.SquareWalkEastOfCentre(),
                    Anker.SquareWalkEntrance(),
                    Anker.SquareWalkSouthWestOfCentre(),
                    Anker.SquareWalkWestOfCentre(),
                    Anker.SquareWalkSouthOfCentre(),
                    Anker.DrunkenSailor(),
                    Anker.GeneralStore(),
                    Anker.MetalMedley(),
                    Anker.VillageHall(),
                    Anker.VillageHallEntrance(),
                    Anker.VillageHallEldersRoom(),
                    Anker.TempleRoad(),
                    Anker.TempleRoad2(),
                    Anker.TempleEntrance(),
                    Anker.PathToTheSquare(),
                    Anker.AnkerLane(),
                    Anker.AnkerLaneWest21(),
                    Anker.AnkerLaneWest25(),
                    Anker.AnkerLaneWest37(),
                    Anker.AnkerLaneEast22(),
                    Anker.AnkerLaneEast23(),
                    Anker.AnkerLaneEast24(),
                    Anker.AnkerHome(),
                    Anker.AnkerHome2(),
                    Anker.AnkerHome3(),
                    Anker.AnkerHome4(),
                    Anker.AnkerHome5(),
                    Anker.AnkerHome6(),
                    Anker.AnkerHome31(),
                    Anker.AnkerHome32(),
                    Anker.AnkerHome33(),
                    Anker.AnkerHome34(),
                    Anker.AnkerHome35(),
                    Anker.AnkerHome36(),
                };
                areaSpeed.Stop();
                Console.WriteLine("Compiling Areas Completed in {0}ms.", areaSpeed.Elapsed.Milliseconds);

                //check areas for duplicate ids


                Console.WriteLine("Adding Area's to Database");
                var addSpeed = new Stopwatch();
                addSpeed.Start();
                foreach (var area in areas)
                {
                    Console.WriteLine("Added {0}", area.title);
             
                    col.Insert(Guid.NewGuid(), area);
                }
                addSpeed.Stop();

                Console.WriteLine("Adding Area's to Database Completed in {0}ms.", addSpeed.Elapsed.Milliseconds);
                Console.WriteLine("{0} Areas added", areas.Count);
                Console.ReadLine();
            }
        }
    }
}
