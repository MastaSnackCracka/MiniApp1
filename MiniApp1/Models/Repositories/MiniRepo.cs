using Microsoft.AspNetCore.Http.HttpResults;
using MiniApp1.Models;

namespace MiniApp1.Models.Repositories
{
    public static class MiniRepo
    {
        private static List<Mini> minis = new List<Mini>()
        {
            new Mini
            {
                MiniId = 1, Name = "Faergus MacMurachadh", Category = "Hero", Size = 3, Description = "", Price = 7.99,
                Image1 = "", Image2 = "", Image3 = "", CharClass = "Barbarian", CharRace = "Human"
            },
            new Mini
            {
                MiniId = 2, Name = "Wendell Porridgepot", Category = "Hero", Size = 3, Description = "", Price = 7.99,
                Image1 = "", Image2 = "", Image3 = "", CharClass = "Rogue", CharRace = "Halfling"
            },
            new Mini
            {
                MiniId = 3, Name = "Norlak ", Category = "Hero", Size = 3, Description = "", Price = 8.99, Image1 = "",
                Image2 = "", Image3 = "", CharClass = "Barbarian", CharRace = "Minotaur"
            },
            new Mini
            {
                MiniId = 4, Name = "Big Bragg", Category = "Villain", Size = 4, Description = "", Price = 8.99,
                Image1 = "", Image2 = "", Image3 = "", CharClass = "Thug", CharRace = "Bugbear"
            },
            new Mini
            {
                MiniId = 5, Name = "Grumbar", Category = "Monster", Size = 4, Description = "", Price = 14.99,
                Image1 = "", Image2 = "", Image3 = "", CharClass = "Undead", CharRace = "Ogre Zombie"
            },
            new Mini
            {
                MiniId = 6, Name = "Auntie Lucretia ", Category = "Monster", Size = 3, Description = "", Price = 12.99,
                Image1 = "", Image2 = "", Image3 = "", CharClass = "Fiend", CharRace = "Night Hag"
            }
        };

        public static List<Mini> GetMinis()
        {
            return minis;
        }

        public static bool MiniExists(int id)
        {
            return minis.Any(x => x.MiniId == id);
        }

        public static Mini? GetMiniById(int id)
        {
            return minis.FirstOrDefault(x => x.MiniId == id);
        }

        public static Mini? GetMiniByProperties(string? name, string? category, int? size)
        {
            return minis.FirstOrDefault(x =>
                !string.IsNullOrWhiteSpace(name) &&
                !string.IsNullOrWhiteSpace(x.Name) &&
                x.Name.Equals(name, StringComparison.OrdinalIgnoreCase) &&
                !string.IsNullOrWhiteSpace(category) &&
                !string.IsNullOrWhiteSpace(x.Category) &&
                x.Category.Equals(category, StringComparison.OrdinalIgnoreCase) &&
                size.HasValue &&
                x.Size.HasValue &&
                size.Value == x.Size.Value);

        }

        public static void AddMini(Mini mini)
        {
            int maxId = minis.Max(x => x.MiniId);
            mini.MiniId = maxId + 1;
            minis.Add(mini);
        }

        public static void UpdateMini(Mini mini)
        {
            var shirtToUpdate = minis.First(x => x.MiniId == mini.MiniId);
            shirtToUpdate.Name = mini.Name;
            shirtToUpdate.Price = mini.Price;
            shirtToUpdate.Size = mini.Size;
            shirtToUpdate.Category = mini.Category;
            shirtToUpdate.Description = mini.Description;
            shirtToUpdate.Image1 = mini.Image1;
            shirtToUpdate.Image2 = mini.Image2;
            shirtToUpdate.Image3 = mini.Image3;
            shirtToUpdate.CharClass = mini.CharClass;
            shirtToUpdate.CharRace = mini.CharRace;
        }

        public static void DeleteMini(int miniId)
        {
            var mini = GetMiniById(miniId);
            if (mini != null)
            {
                minis.Remove(mini);
            }
        }
    }
}
