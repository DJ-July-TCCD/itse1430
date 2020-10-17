/*
 * Delendrick July
 * ITSE 1430
 * Lab 2 - Character Creator
 * 10/09/2020
 */
using System;

namespace CharacterCreator
{
    public class Character
    {
        public string Name = "";
        public string Race;
        public string Job;
        public int Strength = 50;
        public int Intelligence = 50;
        public int Agility = 50;
        public int Constitution = 50;
        public int Charisma = 50;

        public string Validate ()
        {
           
            // The name of the character is required
            if (String.IsNullOrEmpty(Name))
                return ("Character Name is required");

            // The attributes of the character is preset to a value of 50
            // and mustn't fall below the upper or lower bounds.
            if (Strength < 1)
                return ("The Strength stat must fall within the values of 1 and 100");
            else if (Strength > 100)
                return ("The Strength stat must fall within the values of 1 and 100");


            if (Intelligence < 1)
                return ("The Intelligence stat must fall within the values of 1 and 100");
            else if (Intelligence > 100)
                return ("The Intelligence stat must fall within the values of 1 and 100");


            if (Agility < 1)
                return ("The Agility stat must fall within the values of 1 and 100");
            else if (Agility > 100)
                return ("The Agility stat must fall within the values of 1 and 100");


            if (Constitution < 1)
                return ("The Constitution stat must fall within the values of 1 and 100");
            else if (Constitution > 100)
                return ("The Constitution stat must fall within the values of 1 and 100");


            if (Charisma < 1)
                return ("The Charisma stat must fall within the values of 1 and 100");
            else if (Charisma > 100)
                return ("The Charisma stat must fall within the values of 1 and 100");

            return null;
        }
    }
    
}
