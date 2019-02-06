using System;
using System.Collections.Generic;
using System.Linq;
using P08_MilitaryElite.Contracts;
using P08_MilitaryElite.Enums;
using P08_MilitaryElite.Models;

namespace P08_MilitaryElite.Core
{
    public class Engine
    {
        private ICollection<ISoldier> soldiers;

        private ISoldier soldier;

        public Engine()
        {
            this.soldiers = new List<ISoldier>();
        }

        public void Run()
        {
            string input = String.Empty;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] inputArgs = input.Split();

                string type = inputArgs[0];

                int id = int.Parse(inputArgs[1]);

                string firstName = inputArgs[2];

                string lastName = inputArgs[3];


                switch (type)
                {
                    case "Private":

                        soldier = CreatePrivate(id, firstName, lastName, inputArgs);
                        break;

                    case "LieutenantGeneral":

                        soldier = CreateLieutenantGeneral(id, firstName, lastName, inputArgs);
                        break;

                    case "Engineer":

                        soldier = CreateEngineer(id, firstName, lastName, inputArgs);
                        break;
                    case "Commando":

                        soldier = CreateCommando(id, firstName, lastName, inputArgs);
                        break;

                    case "Spy":
                        soldier = CreateSpy(id, firstName, lastName, inputArgs);
                        break;

                }

                if (soldier != null)
                {
                    soldiers.Add(soldier);
                }
            }

            foreach (var soldier in soldiers)
            {
                Console.WriteLine(soldier);
            }
        }

        private ISoldier CreateSpy(int id, string firstName, string lastName, string[] inputArgs)
        {
            int codeNUmber = int.Parse(inputArgs[4]);

            ISpy spy = new Spy(id, firstName, lastName, codeNUmber);

            return spy;
        }

        private ISoldier CreateCommando(int id, string firstName, string lastName, string[] inputArgs)
        {
            decimal salray = decimal.Parse(inputArgs[4]);


            if (!Enum.TryParse(inputArgs[5], out Corps corps))
            {
                return null;
            }

            ICommando commando = new Commando(id, firstName, lastName, salray, corps);

            for (int i = 6; i < inputArgs.Length; i += 2)
            {
                string misionCodeName = inputArgs[i];


                if (!Enum.TryParse(inputArgs[i + 1], out State state))
                {
                    continue;
                }

                IMission mission = new Mission(misionCodeName, state);

                commando.Missions.Add(mission);

            }

            return commando;
        }

        private ISoldier CreateEngineer(int id, string firstName, string lastName, string[] inputArgs)
        {
            decimal salray = decimal.Parse(inputArgs[4]);

         

            if (!Enum.TryParse(inputArgs[5], out Corps corps))
            {
                return null;
            }

            IEngineer engineer = new Engineer(id, firstName, lastName, salray, corps);

            for (int i = 6; i < inputArgs.Length; i += 2)
            {
                string partName = inputArgs[i];
                int hoursWorked = int.Parse(inputArgs[i + 1]);

                IRepair repair = new Repair(partName, hoursWorked);

                engineer.Repairs.Add(repair);

            }

            return engineer;
        }

        private ISoldier CreateLieutenantGeneral(int id, string firstName, string lastName, string[] inputArgs)
        {
            decimal salray = decimal.Parse(inputArgs[4]);

            ILieutenantGeneral lieutenantGeneral = new LieutenantGeneral(id, firstName, lastName, salray);

            for (int i = 5; i < inputArgs.Length; i++)
            {
                int currentId = int.Parse(inputArgs[i]);

                IPrivate curentPrivate = (IPrivate)soldiers.FirstOrDefault(x => x.Id == currentId);

                lieutenantGeneral.Privates.Add(curentPrivate);
            }

            return lieutenantGeneral;
        }

        private ISoldier CreatePrivate(int id, string firstName, string lastName, string[] inputArgs)
        {
            decimal salray = decimal.Parse(inputArgs[4]);

            IPrivate privateSoldier = new Private(id, firstName, lastName, salray);
            return privateSoldier;
        }
    }

}