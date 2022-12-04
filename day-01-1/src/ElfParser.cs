using System;
//using System.Collections.Generic;

namespace Elf {
    class Parser {
        private string file;
        private List<List<int>> packedCalories;

        public Parser(string f) {
            file = f;
            packedCalories = new List<List<int>>();

            int elfCounter = 0;
            foreach (string l in System.IO.File.ReadAllLines(@file)) {
                // add a new list if smaller then elfcounter
                if (packedCalories.Count() <= elfCounter) {
                    packedCalories.Add(new List<int>());
                }
                // if the line isnt empty add the calories to the current elf
                if (!string.IsNullOrEmpty(l)) {
                    packedCalories[elfCounter].Add(Int32.Parse(l));
                    continue;
                }
                // if the line is add the calories to the next elf
                elfCounter += 1;
            }
        }

        public List<List<int>> getCalories() {
            return packedCalories;
        }

    }
}